﻿using Monitel.DataContext.Tools.ModelExtensions;
using Monitel.Mal;
using Monitel.Mal.Context.CIM16;
using Monitel.Mal.Providers;
using Monitel.Mal.Providers.Mal;
using Monitel.ObjectDb.Client;
using Monitel.Supervisor.Infrastructure.AutoUpdateCommon.Wcf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CK = Monitel.Rtdb.Api;

namespace CK11Model
{
    /// <summary>
    /// Класс для взаимодействия с СК-11
    /// </summary>
    public class WorkingWithCK11
    {
        /// <summary>
        /// Строка подключения к CK-11
        /// </summary>
        private readonly string _connectionStringToCk;

        /// <summary>
        /// Порт для подключения к CK-11
        /// </summary>
        private readonly int _port;

        /// <summary>
        /// Конструктор класса WorkingWithCK11
        /// </summary>
        /// <param name="connectionStringToCk">Строка подключения к CK-11</param>
        public WorkingWithCK11(string connectionStringToCk)
        {
            _connectionStringToCk = connectionStringToCk;
        }

        /// <summary>
        /// Конструктор класса WorkingWithCK11
        /// </summary>
        /// <param name="port">Порт для подключения к CK-11</param>
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
        /// <returns>Модель СК-11</returns>
        public ModelImage AccessingTheMalApi()
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

        /// <summary>
        /// Запрос объектов из СК-11
        /// </summary>
        /// <typeparam name="T">Тип объектов для перечисления</typeparam>
        /// <param name="modelImage">Модель СК-11</param>
        /// <param name="uidParentObj">Uid родительского объекта</param>
        /// <returns>Перечисление объектов различных типов, 
        /// принадлежащих родительскому объекту</returns>
        private IEnumerable<T> ChoiceObject<T>(ModelImage modelImage, Guid uidParentObj) where T : class, IdentifiedObject
        {
            var enumObjects = modelImage.GetObjects<T>().Where(
                obj =>
                {
                    var parent = obj.ParentObject;
                    while (parent.Uid != modelImage.GetRootObject().Uid)
                    {
                        if (parent.Uid == uidParentObj)
                        {
                            return true;
                        }
                        parent = parent.ParentObject;
                    }
                    return false;
                }
            );
            return enumObjects;
        }

        /// <summary>
        /// Запрос uids из СК-11
        /// </summary>
        /// <typeparam name="T">Тип объектов для перечисления</typeparam>
        /// <param name="modelImage">Модель СК-11</param>
        /// <param name="uidParentObj">Uid родительского объекта</param>
        /// <returns>Перечисление uids заданных объектов</returns>
        public Guid[] GetUids<T>(ModelImage modelImage, Guid uidParentObj) where T : class, IdentifiedObject
        {
            var enumUid = ChoiceObject<T>(modelImage, uidParentObj);

            Guid[] uidsArray = new Guid[enumUid.Count()];
            
            foreach(var uid in enumUid)
            {
                uidsArray.Append(uid.Uid);
            }
            return uidsArray;
        }
    }
}
