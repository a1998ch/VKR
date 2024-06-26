﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataBaseModel;


namespace CalculationModel
{
    /// <summary>
    /// Класс для расчёта резервов
    /// </summary>
    public class PowerReserve
    {
        private double _k2u;

        /// <summary>
        /// Конструктор класса PowerReserve
        /// </summary>
        public PowerReserve() { }

        /// <summary>
        /// Запрос характеристик из базы данных
        /// </summary>
        /// <param name="eoName">Наименование объекта энергетики</param>
        /// <param name="schemeName">Наименование схемно-режимной ситуации</param>
        /// <param name="connectionString">Строка подключения к базе данных</param>
        /// <param name="regulationType">Тип регулирования</param>
        /// <param name="voltageLevel">Уровень напряжения</param>
        /// <returns>Словарь зависимостей P(K2U); Key = K2U, Value = P</returns>
        private Dictionary<double, double> DatabaseDataLoading(string eoName, string schemeName, string connectionString, 
                                                                string regulationType, int voltageLevel)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                Dictionary<double, double> dictWithCharact = new Dictionary<double, double>();

                string sql = DataBaseQuerys.QueryForCalc(eoName, schemeName, regulationType, voltageLevel);
                sqlConnection.Open();
                SqlCommand comand = new SqlCommand(sql, sqlConnection);
                SqlDataReader dataReader = comand.ExecuteReader();

                while (dataReader.Read())
                {
                    dictWithCharact.Add(dataReader.GetDouble(0), dataReader.GetDouble(1));
                }
                return dictWithCharact;
            }
        }

        /// <summary>
        /// Расчёт предельной мощности
        /// </summary>
        /// <param name="eoName">Наименование объекта энергетики</param>
        /// <param name="schemeName">Наименование схемно-режимной ситуации</param>
        /// <param name="connectionString">Строка подключения к базе данных</param>
        /// <param name="listVoltage">Список междуфазных напряжений</param>
        /// <returns>Предельную мощность</returns>
        /// <exception cref="ArgumentException">Некорректный уровень напряжения</exception>
        public double LimitFlow(string eoName, string schemeName, 
                                string regulationType, string connectionString, 
                                List<double> listVoltage, double meanVoltage)
        {
            Dictionary<double, double> dict = new Dictionary<double, double>();
            _k2u = AsymmetryCoefficientCalc(listVoltage);

            try
            {
                if (meanVoltage >= 220)
                {
                    var one = Interpolation(RangePowerAndK2U(
                        DatabaseDataLoading(
                            eoName, schemeName, connectionString, regulationType, 240)), listVoltage);
                    var two = Interpolation(RangePowerAndK2U(
                        DatabaseDataLoading(
                            eoName, schemeName, connectionString, regulationType, 220)), listVoltage);
                    dict.Add(240, one);
                    dict.Add(220, two);
                    double powerReserve = Interpolation(dict, listVoltage, true);

                    if (regulationType == "Симметричное")
                    {
                        return powerReserve;
                    }
                    else
                    {
                        return LimitPowerForAsym(eoName, schemeName, connectionString, 240, powerReserve);
                    }
                }
                else if (meanVoltage < 220)
                {
                    var one = Interpolation(RangePowerAndK2U(
                        DatabaseDataLoading(
                            eoName, schemeName, connectionString, regulationType, 220)), listVoltage);
                    var two = Interpolation(RangePowerAndK2U(
                        DatabaseDataLoading(
                            eoName, schemeName, connectionString, regulationType, 200)), listVoltage);
                    dict.Add(220, one);
                    dict.Add(200, two);
                    double powerReserve = Interpolation(dict, listVoltage, true);

                    if (regulationType == "Симметричное")
                    {
                        return powerReserve;
                    }
                    else
                    {
                        return LimitPowerForAsym(eoName, schemeName, connectionString, 240, powerReserve);
                    }
                }
                else
                {
                    throw new ArgumentException("Ошибка");
                }
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        /// <summary>
        /// Определение величины активной мощности для текущего K2U
        /// </summary>
        /// <param name="listVoltage">Список междуфазных напряжений</param>
        /// <param name="dict">Словарь зависимостей P(K2U)</param>
        /// <returns>Словарь P(K2U)</returns>
        private Dictionary<double, double> RangePowerAndK2U(Dictionary<double, double> dict)
        {
            Dictionary<double, double> dictResult = new Dictionary<double, double>();
            for (int i = 0; i < dict.Count; i++)
            {
                if (dict.Keys.ElementAt(i) > _k2u)
                {
                    dictResult.Add(dict.Keys.ElementAt(i - 1), dict.Values.ElementAt(i - 1));
                    dictResult.Add(dict.Keys.ElementAt(i), dict.Values.ElementAt(i));
                    break;
                }
            }

            if (dictResult.Count != 2)
            {
                throw new ArgumentException("Недостаточно данных для проведения расчёта");
            }

            return dictResult;
        }

        /// <summary>
        /// Интерполяция
        /// </summary>
        /// <param name="dict">Словарь P(K2U)</param>
        /// <param name="listVoltage">Список междуфазных напряжений</param>
        /// <param name="flag">bool</param>
        /// <returns>Уточнённые величины мощности и напряжения</returns>
        private double Interpolation(Dictionary<double, double> dict, List<double> listVoltage, bool flag = false)
        {
            var pathEquations = ((dict.Values.ElementAt(1) - dict.Values.ElementAt(0)) /
                                (dict.Keys.ElementAt(1) - dict.Keys.ElementAt(0)));

            if (!flag)
            {
                return pathEquations * _k2u + (dict.Values.ElementAt(0) - pathEquations * dict.Keys.ElementAt(0));
            }
            else
            {
                return pathEquations * MeanVoltage(listVoltage) + (dict.Values.ElementAt(0) - pathEquations * dict.Keys.ElementAt(0));
            }
        }

        /// <summary>
        /// Расчёт величины K2U
        /// </summary>
        /// <param name="listVoltage">Список междуфазных напряжений</param>
        /// <returns>Величину K2U</returns>
        private double AsymmetryCoefficientCalc(List<double> listVoltage)
        {
            double Uab = listVoltage[0];
            double Ubc = listVoltage[1];
            double Uca = listVoltage[2];

            double a2 = Math.Pow(Uab, 2) + Math.Pow(Ubc, 2) + Math.Pow(Uca, 2);
            double a4 = Math.Pow(Uab, 4) + Math.Pow(Ubc, 4) + Math.Pow(Uca, 4);
            double a22 = Math.Pow(Uab, 2) * Math.Pow(Ubc, 2) + Math.Pow(Ubc, 2) * Math.Pow(Uca, 2) + Math.Pow(Uca, 2) * Math.Pow(Uab, 2);

            double U1 = Math.Sqrt((a2 + Math.Sqrt(6 * a22 - 3 * a4)) / 6);
            double U2 = Math.Sqrt((a2 - Math.Sqrt(6 * a22 - 3 * a4)) / 6);

            double K2U = (U2 / U1) * 100;
            return K2U;
        }

        /// <summary>
        /// Расчёт среднего напряжения
        /// </summary>
        /// <param name="listVoltage">Список междуфазных напряжений</param>
        /// <returns>Среднее напряжение</returns>
        private double MeanVoltage(List<double> listVoltage)
        {
            return (listVoltage[0] + listVoltage[1] + listVoltage[2]) / listVoltage.Count;
        }

        private Dictionary<double, double> LoadingCurrentForAsym(string eoName, string schemeName, 
                                                                    string connectionString, int voltageLevel)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                Dictionary<double, double> dictWithCharact = new Dictionary<double, double>();

                string sql = DataBaseQuerys.QueryForCalcAsym(eoName, schemeName, "Несимметричное", voltageLevel);
                sqlConnection.Open();
                SqlCommand comand = new SqlCommand(sql, sqlConnection);
                SqlDataReader dataReader = comand.ExecuteReader();

                while (dataReader.Read())
                {
                    dictWithCharact.Add(dataReader.GetDouble(0), dataReader.GetDouble(1));
                }
                return dictWithCharact;
            }
        }

        private Dictionary<double, double> CurrentDetectionForAsym(Dictionary<double, double> dict)
        {
            Dictionary<double, double> dictResult = new Dictionary<double, double>();
            for (int i = 0; i < dict.Count; i++)
            {
                if (dict.Keys.ElementAt(i) >= _k2u)
                {
                    dictResult.Add(dict.Keys.ElementAt(i), dict.Values.ElementAt(i));
                    break;
                }
            }
            return dictResult;
        }

        private double LimitPowerForAsym(string eoName, string schemeName, string connectionString, 
                                          int voltageLevel, double powerReserv)
        {
            var dictOne = LoadingCurrentForAsym(eoName, schemeName, connectionString, voltageLevel);

            var dictTwo = CurrentDetectionForAsym(dictOne);

            var newCurrent = dictTwo.Values.ElementAt(0) * ((200 - powerReserv) / 200);

            var pathEquations = ((_k2u - _k2u * 2.1) / (dictTwo.Values.ElementAt(0)));

            var newK2u = pathEquations * newCurrent + ((_k2u * 2.1) - pathEquations);

            var data = DatabaseDataLoading(eoName, schemeName, connectionString, "Несимметричное", voltageLevel);

            double limitPower = 0;
            for (int i = 0; i < data.Count; i++)
            {
                if (data.Keys.ElementAt(i) >= newK2u)
                {
                    limitPower = data.Values.ElementAt(i);
                    break;
                }
            }
            return limitPower;
        }
    }
}
