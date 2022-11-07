using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelModel;

namespace MethodologyModel
{
    public class PowerReserve
    {
        public double LimitFlow(List<double> listVoltage)
        {
            Dictionary<double, double> dict = new Dictionary<double, double>();
            if (MeanVoltage(listVoltage) > 220)
            {
                var one = Interpolation(RangePowerAndK2U(listVoltage, 1), listVoltage);
                var two = Interpolation(RangePowerAndK2U(listVoltage, 2), listVoltage);
                dict.Add(220, two);
                dict.Add(240, one);
                return Interpolation(dict, listVoltage, true);
            }
            else if (MeanVoltage(listVoltage) < 220)
            {
                var one = Interpolation(RangePowerAndK2U(listVoltage, 2), listVoltage);
                var two = Interpolation(RangePowerAndK2U(listVoltage, 3), listVoltage);
                dict.Add(two, one);
                return Interpolation(dict, listVoltage, true);
            }
            else
            {
                throw new ArgumentException("Ошибка");
            }
        }

        private Dictionary<double, double> RangePowerAndK2U(List<double> listVoltage, int listNumber)
        {
            Excel excel = new Excel(@"D:\универ\Магистратура\ВКР\Моё\Диссер ИТ\Test.xlsx", listNumber);

            List<double> listK2U = excel.WriteBookColumn<double>("A", 2);
            List<double> listPower = excel.WriteBookColumn<double>("B", 2);
            var K2U = AsymmetryCoefficientCalc(listVoltage);

            Dictionary<double, double> dict = new Dictionary<double, double>();

            for (int i = 0; i < listK2U.Count; i++)
            {
                if (listK2U[i] > K2U)
                {
                    dict.Add(Math.Round(listK2U[i], 0), Math.Round(listPower[i], 3));
                    dict.Add(Math.Round(listK2U[i - 1], 0), Math.Round(listPower[i - 1], 3));
                    break;
                }
            }
            excel.ExcelClose();
            return dict;
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
