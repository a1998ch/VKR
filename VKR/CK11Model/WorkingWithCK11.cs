using Monitel.DataContext.Tools.ModelExtensions;
using Monitel.Mal;
using Monitel.Mal.Context.CIM16;
using Monitel.Mal.Providers;
using Monitel.Mal.Providers.Mal;
using Monitel.ObjectDb.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CK = Monitel.Rtdb.Api;

namespace CK11Model
{
    public class WorkingWithCK11
    {
        private readonly string _connectionStringToCk;

        private readonly int _port;

        public WorkingWithCK11() { }

        public WorkingWithCK11(string connectionStringToCk)
        {
            _connectionStringToCk = connectionStringToCk;
        }

        public WorkingWithCK11(int port)
        {
            _port = port;
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

        /// <summary>
        /// Получение доступа к MAL API
        /// </summary>
        /// <returns>объект ModelImage</returns>
        private ModelImage AccessingTheMalApi()
        {
            // Соединение с супервизором текущего домена АИП
            var supervisor = new Monitel.Supervisor.Infrastructure.Rpc.SupervisorConnection(null);

            // Получение имени сервера и имени базы данных Рабочей модели
            // Все базы данных информационной модели описаны в АИП как ресурсы.
            // Для получения описания ресурса выполняется:
            var odbresource = supervisor.FindResources(
                Monitel.PlatformInfrastructure.ResourceUids.ResourceUids.ENERGY_MAIN_MODEL).FirstOrDefault();

            // Далее, по строке подключения к ресурсу определяются его параметры:
            var contextparams = Monitel.Mal.Providers.MalContextParams.Parse(odbresource.ConnectionString);

            // OdbserverName — имя сервера, на котором расположена база данных
            // OdbInstanceName — имя Odb базы данных
            // OdbModelVersion — идентификатор версии модели. Если параметр не указан,
            // подключение будет производиться к актуальной версии модели.
            MalContextParams context = new MalContextParams()
            {
                OdbServerName = contextparams.OdbServerName,
                OdbInstanseName = contextparams.OdbInstanseName,
                OdbModelVersionId = 92,
            };

            // mode — способ подключения к контексту данных(Open(открыть),
            // moduleInfo — имя подключаемого модуля, передаётся сервису мал
            // для идентификации подключившейся программы.
            // port — номер порта, на котором работает мал сервис.
            var defaultProvaider = new MalProvider(context, MalContextMode.Open, _connectionStringToCk, _port);

            // Создание объекта ModelImage
            var modelImage = new ModelImage(defaultProvaider);

            return modelImage;
        }

        public string GetUids<T>() //where T : class, IdentifiedObject
        {
            string a = "";
            //List<T> list = new List<T>();
            var modelImage = AccessingTheMalApi();
            foreach (var sourceValue in modelImage.GetObjects<AnalogValue>())
            {
                a += sourceValue.name + " ";
            }
            return a;
        }

        /*public string GetUids() //where T : class, Monitel.Mal.Context.CIM16.IdentifiedObject
        {
            var modelImage = AccessingTheMalApi();
            string a = String.Empty;
            foreach (var sourceValue in modelImage.GetObjects<AnalogValue>())
            {
                a += sourceValue.name.ToString() + " ";
            }

            return String.Empty;
        }*/
    }
}
