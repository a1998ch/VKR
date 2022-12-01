using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CK = Monitel.Rtdb.Api;

namespace CK11Model
{
    public class ConnectCK11
    {
        private readonly string _connectionStringToCk;

        public ConnectCK11(string connectionStringToCk)
        {
            _connectionStringToCk = connectionStringToCk;
        }


        /// <summary>
        /// Запрос данных из БДРВ
        /// </summary>
        /// <param name="uidsArray">Массив uids нужных ТИ</param>
        /// <returns>Массив ТИ</returns>
        public CK.RtdbValue[] GetSignals(Guid[] uidsArray)
        {
            using (CK.IRtdbProvider provider = CK.RtdbProvider.CreateProvider())
            {
                CK.IRtdbProxy proxy = provider.Connect(_connectionStringToCk);

                var request = new CK.Requests.ValuesSliceReadRequest(uidsArray, null);

                using (var tracker = proxy.SendRequest(request))
                {
                    var response = tracker.WaitResponse();
                    return response.Values;
                }
            }
        }
    }
}
