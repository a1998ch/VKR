using CalculationModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using CK = Monitel.Rtdb.Api;
using CK11Model;
using Monitel.Mal.Context.CIM16;
using Monitel.Mal;
using lib60870;
using System.Linq;
using DataBaseModel;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Threading.Tasks;
using System.Threading;
using System.IO.Ports;
using System.IO;
using System.Text;
using Monitel.Rtdb.Api.Config;
using System.Collections;

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
        /// Модель СК-11
        /// </summary>
        private ModelImage _modelImage;

        /// <summary>
        /// Uid контролируемого объекта энергетики
        /// </summary>
        private Guid _observableObjectUid;

        /// <summary>
        /// Uid активной мощности контролируемого объекта энергетики
        /// </summary>
        private Guid[] _activePowerUid = new Guid[1];

        /// <summary>
        /// Uid реактивной мощности контролируемого объекта энергетики
        /// </summary>
        private Guid[] _reactivePowerUid = new Guid[1];

        private List<string> _listCheckParamForObj = new List<string>();

        /// <summary>
        /// Наименование объекта энергетики
        /// </summary>
        private string _objectName;

        /// <summary>
        /// Наименование С-РС
        /// </summary>
        private string _schemeName;

        /// <summary>
        /// Тип регулирования
        /// </summary>
        private string _regulationType;

        /// <summary>
        /// Строка подключения к базе данных
        /// </summary>
        private string _sqlConnection;

        /// <summary>
        /// Список междуфазных напряжений
        /// </summary>
        private readonly List<double> _listVoltage = new List<double>(3);

        /// <summary>
        /// Список uids междуфазных напряжений
        /// </summary>
        private readonly List<Guid> _listVoltageUid = new List<Guid>(3);

        /// <summary>
        /// Активная мощность ОЭ
        /// </summary>
        private float _activePower;

        /// <summary>
        /// Реактивная мощность ОЭ
        /// </summary>
        private float _reactivePower;

        /// <summary>
        /// Остановить расчёт
        /// </summary>
        private bool _false = false;

        /// <summary>
        /// Коэффициент чувствительности напряжения
        /// </summary>
        private double _voltageSensitivity = 0.00256;

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
            LabelWorkStatus.Text = "Расчёт не запущен";

            // Подключение к модели
            _modelImage = new WorkingWithCK11().AccessingTheMalApi();

            // Подключение к скрверу для передачи данных в БДРВ
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
            Thread.Sleep(2000);
            if (_false == true)
            {
                SelectionOfRequestedData.Enabled = false;
                ChoiceOfSchema.Enabled = false;
            }
            LabelWorkStatus.Text = "Система осуществляет расчёт";
        }

        private async void StartSystemMouseDown(object sender, MouseEventArgs e)
        {
            await Task.Run(() => StartCalc());
        }

        /// <summary>
        /// Расчёт резерва активной мощности
        /// </summary>
        private void StartCalc()
        {
            if (_false == true) { return; }

            if (_sqlConnection == null)
            {
                MessageBox.Show("Не осуществлено подключение к базе данных",
                                "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!CheckObj) { return; }
            if (!CheckParamForObj) { return; }
            if (!CheckSchema) { return; }
            if (!CheckRegType) { return; }

            _false = true;
            SetData();

            PowerReserve power = new PowerReserve();
            var sendCK11 = new DataTransferToCK11();

            float activePowerReserve = 0;
            try
            {
                while (_false)
                {
                    double checkPower = _activePower;
                    GetActivePower();
                    GetVoltage();

                    if (checkPower == _activePower) { continue; }

                    if (_activePower == -1 || _listVoltage.Count == 0)
                    {
                        sendCK11.DataTransfer(_server, _coa, 200, activePowerReserve, true);
                        continue;
                    }

                    double meanVoltage = (_listVoltage[0] + _listVoltage[1] + _listVoltage[2]) / _listVoltage.Count;
                    double correctVoltage = 0;
                    for (int k = 0; k < 2; k++)
                    {
                        if (k != 0) { meanVoltage = correctVoltage; }

                        var limitingActivePower = power.LimitFlow(_objectName, _schemeName, _regulationType,
                                                                    _sqlConnection, _listVoltage, meanVoltage);
                        activePowerReserve = (float)limitingActivePower - _activePower;
                        sendCK11.DataTransfer(_server, _coa, 200, activePowerReserve);

                        correctVoltage = meanVoltage - _voltageSensitivity * (limitingActivePower - _activePower);
                    }
                    sendCK11.DataTransfer(_server, _coa, 200, activePowerReserve);
                }
            }
            catch (ArgumentException ex)
            {
                _false = false;
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Имитация поступления данных в СК-11 с ОЭ
        /// </summary>
        private async void SetData()
        {
            int invalid = 0;
            int i = 1;
            double j = 0;
            if (_false == true)
            {
                await Task.Run(() =>
                {
                    while (_false)
                    {
                        invalid += 1;
                        i += 5;
                        j += 0.5;
                        if (invalid <= 5)
                        {
                            SetValueToCK11(i, j);
                        }
                        else if (invalid > 5 && invalid <= 10)
                        {
                            SetValueToCK11(i, j, nonTop: true);
                        }
                        else
                        {
                            SetValueToCK11(i, j);
                        }
                        Thread.Sleep(5000);
                    }
                }
                );
            }
        }

        /// <summary>
        /// Прекращение расчёта
        /// </summary>
        /// <param name="sender">Объект</param>
        /// <param name="e">Данные события</param>
        private void StopSystemClick(object sender, EventArgs e)
        {
            if (_false == false)
            {
                MessageBox.Show("Расчёт не запущен",
                "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            _false = false;

            SelectionOfRequestedData.Enabled = true;
            ChoiceOfSchema.Enabled = true;

            LabelWorkStatus.Text = "Расчёт не запущен";
        }

        /// <summary>
        /// Получения значения активной мощности из СК-11
        /// </summary>
        private void GetActivePower()
        {
            var dataRequest = new WorkingWithCK11(_connectionStringToRtdb);
            var data = dataRequest.GetSignals(_activePowerUid);
            var tempData = new Examination(data);
            bool checkValue = tempData.GetValidData();

            if (!checkValue)
            {
                _activePower = -1;
            }
            else
            {
                _activePower = (float)Convert.ToDouble(data[0].Value.AnalogValue);
            }
        }

        /// <summary>
        /// Получения значений междуфазных напряжений из СК-11
        /// </summary>
        private void GetVoltage()
        {
            _listVoltage.Clear();

            var dataRequest = new WorkingWithCK11(_connectionStringToRtdb);
            var data = dataRequest.GetSignals(_listVoltageUid.ToArray());
            var tempData = new Examination(data);
            bool checkValue = tempData.GetValidData();

            if (!checkValue)
            {
                _listVoltage.Clear();
            }
            else
            {
                foreach (var item in data)
                {
                    _listVoltage.Add(item.Value.AnalogValue);
                }
            }
        }

        /// <summary>
        /// Задание величин, имитирующих поступление данных в СК-11 с ОЭ
        /// </summary>
        /// <param name="i">Величина увеличения АМ на одной итерации</param>
        /// <param name="j">Величина уменьшения междуфазных напряжений на одной итерации</param>
        private void SetValueToCK11(int i, double j, bool nonTop = false)
        {
            Random random = new Random();
            float Uab = (float)(215 - j);
            float Ubc = (float)(243.7 - j);
            float Uca = (float)(223 - j);
            float U = (Uab + Ubc + Uca) / 3;
            float P = 50 + i;

            var sendCK11 = new DataTransferToCK11();
            sendCK11.DataTransfer(_server, _coa, 100, U);
            sendCK11.DataTransfer(_server, _coa, 101, Uab);
            sendCK11.DataTransfer(_server, _coa, 102, Ubc);
            sendCK11.DataTransfer(_server, _coa, 103, Uca);
            sendCK11.DataTransfer(_server, _coa, 104, P, invalid: false, nonTopical: nonTop);
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
        /// Подключение к БД СК-11
        /// </summary>
        /// <param name="sender">Объект</param>
        /// <param name="e">Данные события</param>
        private void OikDBClick(object sender, EventArgs e)
        {
            // Подключение к модели
            _modelImage = new WorkingWithCK11().AccessingTheMalApi();
        }

        /// <summary>
        /// Получение UID контролируемого объекта по имени
        /// </summary>
        private void GetUidObj()
        {
            foreach (var item in CheckedListBoxEnObj.CheckedItems) 
            {
                _observableObjectUid = new WorkingWithCK11().GetUidObjectByName<Substation>(_modelImage, item.ToString());
            }
        }

        /// <summary>
        /// Добавление нового контролируемого объекта
        /// </summary>
        /// <param name="sender">Объект</param>
        /// <param name="e">Данные события</param>
        private void AddEnObjButtonClick(object sender, EventArgs e)
        {
            this.Hide();
            AddNewObjForm addNewObjForm = new AddNewObjForm(_modelImage);
            addNewObjForm.CloseForm += OtherCloseForm;
            addNewObjForm.AddObjEvent += (o, args) =>
            {
                foreach (var item in args.ToList())
                {
                    foreach (var jtem in CheckedListBoxEnObj.Items)
                    {
                        if (item == jtem.ToString())
                        {
                            args.Remove(item);
                        }
                    }
                }
                foreach (var item in args)
                {
                    CheckedListBoxEnObj.Items.Add(item);
                }
            };
            addNewObjForm.ShowDialog();
        }

        /// <summary>
        /// Исключение возможности выбора нескольких объектов
        /// </summary>
        /// <param name="sender">Объект</param>
        /// <param name="e">Данные события</param>
        private void CheckedListBoxEnObjItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < CheckedListBoxEnObj.Items.Count; ++ix)
            {
                if (ix != e.Index) CheckedListBoxEnObj.SetItemChecked(ix, false);
            }

            SelectionOfRequestedData.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            ChoiceOfSchema.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            ChoiceOfRegType.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            _listCheckParamForObj.Clear();
            _schemeName = String.Empty;
            _regulationType = String.Empty;
        }

        /// <summary>
        /// Получение значений АМ, РМ и междуфазных напряжений
        /// </summary>
        /// <param name="sender">Объект</param>
        /// <param name="e">Данные события</param>
        private void SelectionOfRequestedDataClick(object sender, EventArgs e)
        {
            if (!CheckObj) { return; }

            GetUidObj();

            this.Hide();
            var customizeSettingsForm = 
                new SelectionOfRequestedDataForm(_listVoltageUid, _modelImage, _observableObjectUid, _listCheckParamForObj);
            customizeSettingsForm.CloseForm += OtherCloseForm;
            customizeSettingsForm.ShowDialog();

            _listCheckParamForObj.AddRange(customizeSettingsForm.ListCheckObj);
            _activePowerUid = customizeSettingsForm.GetActivePowerUid;
            _reactivePowerUid = customizeSettingsForm.GetReactivePowerUid;

            if (_listCheckParamForObj.Count != 0)
            {
                SelectionOfRequestedData.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            }
        }

        /// <summary>
        /// Выбор С-РС
        /// </summary>
        /// <param name="sender">Объект</param>
        /// <param name="e">Данные события</param>
        private void ChoiceOfSchemaClick(object sender, EventArgs e)
        {
            string checkSchemName = _schemeName;

            if (!CheckObj) { return; }

            if (_sqlConnection == null)
            {
                MessageBox.Show("Не осуществлено подключение к базе данных",
                                "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            this.Hide();
            ChoiceOfSchemaForm choiceOfSchemaForm = new ChoiceOfSchemaForm(_sqlConnection, _objectName, _schemeName);
            choiceOfSchemaForm.CloseForm += OtherCloseForm;
            choiceOfSchemaForm.SchemeEvent += (o, args) => _schemeName = args;
            choiceOfSchemaForm.ShowDialog();

            if (_schemeName != null && _schemeName != String.Empty)
            {
                ChoiceOfSchema.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            }

            if (checkSchemName != _schemeName)
            {
                _regulationType = null;
                ChoiceOfRegType.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            }
        }

        /// <summary>
        /// Выбор типа регулирования
        /// </summary>
        /// <param name="sender">Объект</param>
        /// <param name="e">Данные события</param>
        private void ChoiceOfRegTypeClick(object sender, EventArgs e)
        {
            if (!CheckSchema) { return; }

            if (_sqlConnection == null)
            {
                MessageBox.Show("Не осуществлено подключение к базе данных",
                                "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            this.Hide();
            ChoiceOfRegTypeForm choiceOfSchemaForm = 
                new ChoiceOfRegTypeForm(_sqlConnection, _objectName, _schemeName, _regulationType);
            choiceOfSchemaForm.CloseForm += OtherCloseForm;
            choiceOfSchemaForm.RegulationTypeEvent += (o, args) => _regulationType = args;
            choiceOfSchemaForm.ShowDialog();

            if (_regulationType != null && _regulationType != String.Empty)
            {
                ChoiceOfRegType.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            }
        }

        /// <summary>
        /// Проверка на выбор ОЭ
        /// </summary>
        private bool CheckObj
        {
            get
            {
                if (CheckedListBoxEnObj.CheckedItems.Count == 0)
                {
                    MessageBox.Show("Выбирете объект электроэнергетики",
                                    "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else
                {
                    foreach (var item in CheckedListBoxEnObj.CheckedItems)
                    {
                        _objectName = item.ToString();
                    }
                }
                return true;
            }
        }

        private bool CheckParamForObj
        {
            get
            {
                if (_listCheckParamForObj.Count == 0)
                {
                    MessageBox.Show("Выбирете запрашиваемые данные для объекта электроэнергетики",
                                    "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                return true;
            }
        }

        private bool CheckSchema
        {
            get
            {
                if (_schemeName == null || _schemeName == String.Empty)
                {
                    MessageBox.Show("Выбирете схемно-режимную ситуацию для объекта электроэнергетики",
                                    "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                return true;
            }
        }

        private bool CheckRegType
        {
            get
            {
                if (_regulationType == null || _regulationType == String.Empty)
                {
                    MessageBox.Show("Выбирете тип регулирования для объекта электроэнергетики",
                                    "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                return true;
            }
        }

        private void AboutProgClick(object sender, EventArgs e)
        {
            string path = @"D:\Магистратура\ВКР\Моё\Диссер ИТ\VKR\_VKR\VKR\Manual\Hello world.html";
            System.Diagnostics.Process.Start(path);
        }
    }
}
