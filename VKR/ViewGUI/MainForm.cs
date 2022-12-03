﻿using CalculationModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using CK = Monitel.Rtdb.Api;
using CK11Model;
using Monitel.Mal.Context.CIM16;
using Monitel.Mal;
using lib60870;

namespace ViewGUI
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Строка подключения к СК-11, для запроса данных
        /// </summary>
        private const string _connectionStringToRtdb = "10.221.3.29:900";

        /// <summary>
        /// Адрес сервера передачи ТИ
        /// </summary>
        private const string _serverAddress = "10.221.3.57";

        /// <summary>
        /// Сервер СК-11
        /// </summary>
        private Server _server;

        /// <summary>
        /// Порт для приняти ТИ
        /// </summary>
        private const int _serverPort = 2404;

        /// <summary>
        /// Общий адрес ТИ
        /// </summary>
        private const int _coa = 5;

        /// <summary>
        /// Адрес объекта информации
        /// </summary>
        private const int _ioa = 100;

        /// <summary>
        /// Модель СК-11
        /// </summary>
        private ModelImage modelImage;

        /// <summary>
        /// Uid контролируемого объекта энергетики
        /// </summary>
        private Guid _observableObjectUid = Guid.Parse("0904FE7A-A7F8-4649-AF02-CEC613C55624");

        /// <summary>
        /// Строка подключения к базе данных
        /// </summary>
        private string _sqlConnection;

        /// <summary>
        /// Список междуфазных напряжений
        /// </summary>
        private readonly List<double> _listVoltage = new List<double>(3);

        /// <summary>
        /// Конструктор класса MainForm
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Действия при запуске программы 
        /// </summary>
        /// <param name="sender">Объект</param>
        /// <param name="e">Данные события</param>
        private void MainFormLoad(object sender, EventArgs e)
        {
            double Uab = 215, Ubc = 243.7, Uca = 223;
            _listVoltage.Add(Uab);
            _listVoltage.Add(Ubc);
            _listVoltage.Add(Uca);

            var ConnectCK11 = new WorkingWithCK11(_serverPort);
            modelImage = ConnectCK11.AccessingTheMalApi();

            var sendCK11 = new DataTransferToCK11();
            _server = sendCK11.ConnectServer(_serverAddress, _serverPort);
        }

        /// <summary>
        /// Подключение к базе данных
        /// </summary>
        /// <param name="sender">Объект</param>
        /// <param name="e">Данные события</param>
        private void ConnectDBClick(object sender, EventArgs e)
        {
            this.Hide();
            ConnectDataBaseForm connectDataBase = new ConnectDataBaseForm();
            connectDataBase.CloseForm += OtherCloseForm;
            connectDataBase.ConnectEvent += (o, args) => _sqlConnection = args;
            connectDataBase.ShowDialog();
        }

        /// <summary>
        /// Обработчик события закрытия формы
        /// </summary>
        /// <param name="sender">Объект</param>
        /// <param name="e">Данные события</param>
        private void OtherCloseForm(object sender, EventArgs e)
        {
            this.Show();
        }

        /// <summary>
        /// Запуск программы
        /// </summary>
        /// <param name="sender">Объект</param>
        /// <param name="e">Данные события</param>
        private void StartSystemClick(object sender, EventArgs e)
        {
            PowerReserve power = new PowerReserve();
            var P = power.LimitFlow("ВНС", "Нормальная схема", _sqlConnection, _listVoltage);
            textBox1.Text = P.ToString();
        }

        /// <summary>
        /// Добавление/редактирования данных в базе данных
        /// </summary>
        /// <param name="sender">Объект</param>
        /// <param name="e">Данные события</param>
        private void AddEditDataDBClick(object sender, EventArgs e)
        {
            this.Hide();
            DatabaseEditorForm databaseEditor = new DatabaseEditorForm(_sqlConnection);
            databaseEditor.CloseForm += OtherCloseForm;
            databaseEditor.ShowDialog();
        }

        /// <summary>
        /// Сообщение об ошибке
        /// </summary>
        /// <param name="ex">Экземпляр exeption</param>
        public void ExeptionMessage(Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Подключение к БДРВ ОИК "СК-11"
        /// </summary>
        /// <param name="sender">Объект</param>
        /// <param name="e">Данные события</param>
        private void ConnectCK11Click(object sender, EventArgs e)
        {
            var ConnectCK11 = new WorkingWithCK11(_serverPort);
            var objects = ConnectCK11.GetSpecificObject<RemoteAnalogValue>(modelImage, _observableObjectUid);
            Guid[] uids = ConnectCK11.GetUids(objects);

            var dataRequest = new WorkingWithCK11(_connectionStringToRtdb);
            var data = dataRequest.GetSignals(uids);

            foreach (var item in data)
            {
                textBox1.Text += item.Value.AnalogValue.ToString() + " ";
            }
        }

        /// <summary>
        /// Подключение к БД СК-11
        /// </summary>
        /// <param name="sender">Объект</param>
        /// <param name="e">Данные события</param>
        private void OikDBClick(object sender, EventArgs e)
        {
            var ConnectCK11 = new WorkingWithCK11(_serverPort);
            var objects = ConnectCK11.GetSpecificObject<RemoteAnalogValue>(modelImage, _observableObjectUid);
            var uids = ConnectCK11.GetUids(objects);

            foreach (var uid in uids)
            {
                textBox1.Text += uid + " ";
            }
        }

        private void SendToCK11Click(object sender, EventArgs e)
        {
            Random random = new Random();

            var value = random.Next(100, 1000);

            var sendCK11 = new DataTransferToCK11();
            sendCK11.DataTransfer(_server, _coa, _ioa, value);
        }
    }
}
