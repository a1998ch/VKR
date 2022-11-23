﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculationModel
{
    public class PowerReserve
    {
        public PowerReserve() { }

        private string QueryCharacteristicsFromDB(string regulationType, int voltageLevel)
        {
            return $"SELECT p.K2U_Value, p.Power_Value, v.Voltage_value, r.Regulation_type, s.Energy_object_name, s.Scheme_number " +
                   $"FROM Value_param p, Voltage_level v, Regulation r, Scheme s " +
                   $"WHERE s.Voltage_id = v.Voltage_id AND " +
                   $"s.Value_id = p.Value_id AND " +
                   $"r.Regulation_id = s.Regulation_id AND " +
                   $"Regulation_type = '{regulationType}' AND " +
                   $"Voltage_value = {voltageLevel};";
        }

        private Dictionary<double, double> DatabaseDataLoading(string connectionString, string regulationType, int voltageLevel)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                Dictionary<double, double> dictWithCharact = new Dictionary<double, double>();

                string sql = QueryCharacteristicsFromDB(regulationType, voltageLevel);
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

        public double LimitFlow(string connectionString, List<double> listVoltage)
        {
            Dictionary<double, double> dict = new Dictionary<double, double>();

            if (MeanVoltage(listVoltage) > 220)
            {
                var one = Interpolation(RangePowerAndK2U(listVoltage, DatabaseDataLoading(connectionString, "Симметричное", 240)), listVoltage);
                var two = Interpolation(RangePowerAndK2U(listVoltage, DatabaseDataLoading(connectionString, "Симметричное", 220)), listVoltage);
                dict.Add(220, two);
                dict.Add(240, one);
                return Interpolation(dict, listVoltage, true);
            }
            else if (MeanVoltage(listVoltage) < 220)
            {
                var one = Interpolation(RangePowerAndK2U(listVoltage, DatabaseDataLoading(connectionString, "Симметричное", 220)), listVoltage);
                var two = Interpolation(RangePowerAndK2U(listVoltage, DatabaseDataLoading(connectionString, "Симметричное", 200)), listVoltage);
                dict.Add(200, two);
                dict.Add(220, one);
                return Interpolation(dict, listVoltage, true);
            }
            else
            {
                throw new ArgumentException("Ошибка");
            }
        }

        private Dictionary<double, double> RangePowerAndK2U(List<double> listVoltage, Dictionary<double, double> dict)
        {
            var K2U = AsymmetryCoefficientCalc(listVoltage);

            Dictionary<double, double> dictResult = new Dictionary<double, double>();
            for (int i = 0; i < dict.Count; i++)
            {
                if (dict.Keys.ElementAt(i) > K2U)
                {
                    dictResult.Add(dict.Keys.ElementAt(i), dict.Values.ElementAt(i));
                    dictResult.Add(dict.Keys.ElementAt(i + 1), dict.Values.ElementAt(i + 1));
                    break;
                }
            }
            return dictResult;
        }

        private double Interpolation(Dictionary<double, double> dict, List<double> listVoltage, bool flag = false)
        {
            var K2U = AsymmetryCoefficientCalc(listVoltage);
            var pathEquations = ((dict.Values.ElementAt(0) - dict.Values.ElementAt(1)) /
                                (dict.Keys.ElementAt(0) - dict.Keys.ElementAt(1)));

            if (!flag)
            {
                return pathEquations * K2U + (dict.Values.ElementAt(1) - pathEquations * dict.Keys.ElementAt(1));
            }
            else
            {
                return pathEquations * MeanVoltage(listVoltage) + (dict.Values.ElementAt(0) - pathEquations * dict.Keys.ElementAt(1));
            }
        }

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

        private double MeanVoltage(List<double> listVoltage)
        {
            return (listVoltage[0] + listVoltage[1] + listVoltage[2]) / listVoltage.Count;
        }
    }
}
