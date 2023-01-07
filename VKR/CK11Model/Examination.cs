using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CK = Monitel.Rtdb.Api;

namespace CK11Model
{
    public class Examination
    {
        /// <summary>
        /// Достоверный код качества ТИ
        /// </summary>
        private readonly string[] _goodQualitys =
            new string[]
            {
                "10000002",
                "10004000",
                "10008000",
                "10010000",
                "10020000",
                "10000020"
            };

        /// <summary>
        /// Входные данные
        /// </summary>
        private CK.RtdbValue[] _inputData;

        /// <summary>
        /// Входные данные
        /// </summary>
        public CK.RtdbValue[] InputData
        {
            get => _inputData;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException
                        ("Массив не содержит данных.");
                }

                _inputData = value;
            }
        }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="inputData">Входные данные для проверки</param>
        public Examination(CK.RtdbValue[] inputData)
        {
            InputData = inputData;
        }

        /// <summary>
        /// Осуществление проверки данных
        /// </summary>
        /// <returns>Массив достоверных значений</returns>
        public bool GetValidData()
        {
            bool check = true;

            for (int i = 0; i < this.InputData.Length; i++)
            {
                if (Array.Exists(_goodQualitys, value => value ==
                    Convert.ToString(this.InputData[i].QualityCodes, 16)))
                {

                }
                else
                {
                    check = false;
                }
            }

            return check;
        }
    }
}
