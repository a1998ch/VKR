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
        private double ActivePower(List<double> listVoltage, int listNumber)
        {
            /*int listNumber;

            if (MeanVoltage(listVoltage) > 220 && MeanVoltage(listVoltage) < 240)
            {
                listNumber = 1;
            }
            else if (MeanVoltage(listVoltage) > 200 && MeanVoltage(listVoltage) < 220)
            {
                listNumber = 2;
            }
            else
            {
                throw new ArgumentException("Ошибка");
            }*/

            Excel excel = new Excel(@"D:\универ\Магистратура\ВКР\Моё\Диссер ИТ\Test.xlsx", listNumber);

            List<double> list = excel.WriteBookColumn<double>("A", 2);
            var K2U = AsymmetryCoefficientCalc(listVoltage);

            Dictionary<int, double> dictK2U = new Dictionary<int, double>();

            for (int i = 0, cellNumber = 2; i < list.Count; i++, cellNumber++)
            {
                if (list[i] > K2U)
                {
                    dictK2U.Add(cellNumber-2, list[i - 2]);
                    dictK2U.Add(cellNumber, list[i]);
                    break;
                }
            }

            /*switch (MeanVoltage(listVoltage))
            {
                case 1:
                    break;
            }*/
            return 0;
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
