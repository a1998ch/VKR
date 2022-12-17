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
        private ModelImage _modelImage;

        /// <summary>
        /// Uid контролируемого объекта энергетики
        /// </summary>
        private readonly Guid _observableObjectUid = Guid.Parse("0904FE7A-A7F8-4649-AF02-CEC613C55624");

        /// <summary>
        /// Uid активной мощности контролируемого объекта энергетики
        /// </summary>
        private readonly Guid[] _activePowerUid = new Guid[1] { Guid.Parse("1267F451-6150-4F66-B530-22DDF9186936") };

        /// <summary>
        /// Uid типа значения - "Напряжение"
        /// </summary>
        private readonly Guid _measurementTypeVoltage = Guid.Parse("10000bdf-0000-0000-c000-0000006d746c");

        /// <summary>
        /// Uid типа значения - "Переток активной мощности"
        /// </summary>
        private readonly Guid _measurementTypeActivePower = Guid.Parse("10000849-0000-0000-C000-0000006D746C");

        /// <summary>
        /// Uid типа значения - "Переток реактивной мощности"
        /// </summary>
        private readonly Guid _measurementTypeReactivePower = Guid.Parse("10000B3B-0000-0000-C000-0000006D746C");

        /// <summary>
        /// Наименование объекта энергетики
        /// </summary>
        private string _objectName;

        /// <summary>
        /// Наименование С-РС
        /// </summary>
        private string _schemeName;

        /// <summary>
        /// Строка подключения к базе данных
        /// </summary>
        private string _sqlConnection;

        /// <summary>
        /// Список междуфазных напряжений
        /// </summary>
        private readonly List<double> _listVoltage = new List<double>(3);

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
        private bool _false = true;

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
            CheckedListBoxEnObj.Items.Add("Объект электроэнергетики");

            double Uab = 215, Ubc = 243.7, Uca = 223;
            _listVoltage.Add(Uab);
            _listVoltage.Add(Ubc);
            _listVoltage.Add(Uca);

            // Подключение к модели
            var ConnectCK11 = new WorkingWithCK11(_serverPort);
            _modelImage = ConnectCK11.AccessingTheMalApi();

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
        private async void StartSystemClick(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                int i = 1;
                double j = 0;
                _false = true;

                PowerReserve power = new PowerReserve();
                var sendCK11 = new DataTransferToCK11();

                ChoiseObject();

                while (_false)
                {
                    i += 5;
                    j += 0.5;
                    SetValueToCK11(i, j);
                    GetActivePower();
                    GetVoltage();

                    var limitingActivePower = power.LimitFlow(_objectName, _schemeName, _sqlConnection, _listVoltage);
                    float activePowerReserve = (float)limitingActivePower - _activePower;
                    sendCK11.DataTransfer(_server, _coa, 200, activePowerReserve);

                    Thread.Sleep(5000);
                }
            }
            );
        }

        private void StopSystemClick(object sender, EventArgs e)
        {
            _false = false;
        }

        private void GetActivePower()
        {
            var dataRequest = new WorkingWithCK11(_connectionStringToRtdb);
            var data = dataRequest.GetSignals(_activePowerUid);
            _activePower = (float)Convert.ToDouble(data[0].Value.AnalogValue);
        }

        private void GetVoltage()
        {
            _listVoltage.Clear();

            var ConnectCK11 = new WorkingWithCK11(_serverPort);

            var objects = ConnectCK11.GetSpecificObject<Analog>(_modelImage, _observableObjectUid);
            var voltageEnum = ConnectCK11.GetFilterObject(objects, _measurementTypeVoltage);
            var voltageEnumPhase = ConnectCK11.GetFilterVoltage(voltageEnum);
            var child = ConnectCK11.GetChildObject(voltageEnumPhase);
            Guid[] uids = ConnectCK11.GetUids(child);

            var dataRequest = new WorkingWithCK11(_connectionStringToRtdb);
            var data = dataRequest.GetSignals(uids);

            foreach (var item in data)
            {
                _listVoltage.Add(item.Value.AnalogValue);
            }
        }

        private void SetValueToCK11(int i, double j)
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
            sendCK11.DataTransfer(_server, _coa, 104, P);
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
            var ConnectCK11 = new WorkingWithCK11(_serverPort);
            _modelImage = ConnectCK11.AccessingTheMalApi();
        }

        private int GetRandomVoltageValue(Random rnd) => rnd.Next(200, 252);

        private int GetRandomPowerValue(Random rnd) => rnd.Next(50, 100);

        private void AddEnObjButtonClick(object sender, EventArgs e)
        {
            this.Hide();
            AddNewObjForm addNewObjForm = new AddNewObjForm();
            addNewObjForm.CloseForm += OtherCloseForm;
            addNewObjForm.AddObjEvent += (o, args) => CheckedListBoxEnObj.Items.Add(args);
            addNewObjForm.ShowDialog();
        }

        private void CheckedListBoxEnObjItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < CheckedListBoxEnObj.Items.Count; ++ix)
            {
                if (ix != e.Index) CheckedListBoxEnObj.SetItemChecked(ix, false);
            }
        }

        private void SelectionOfRequestedDataClick(object sender, EventArgs e)
        {
            if (!CheckObj) { return; }

            this.Hide();
            CustomizeSettingsForm customizeSettingsForm = new CustomizeSettingsForm(_serverPort, _listVoltage);
            _activePower = customizeSettingsForm.GetActivePower;
            _reactivePower = customizeSettingsForm.GetReactivePower;
            customizeSettingsForm.CloseForm += OtherCloseForm;
            customizeSettingsForm.ShowDialog();
        }

        private void ChoiceOfSchemaClick(object sender, EventArgs e)
        {
            if (!CheckObj) { return; }

            this.Hide();
            ChoiceOfSchemaForm choiceOfSchemaForm = new ChoiceOfSchemaForm(_sqlConnection);
            choiceOfSchemaForm.CloseForm += OtherCloseForm;
            choiceOfSchemaForm.SchemeEvent += (o, args) => _schemeName = args;
            choiceOfSchemaForm.ShowDialog();
        }

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
                return true;
            }
        }

        private void ChoiseObject()
        {
            foreach (var item in CheckedListBoxEnObj.CheckedItems)
            {
                _objectName = item.ToString();
            }
            if (_objectName == "Объект электроэнергетики")
            {
                _objectName = "ВНС";
            }
        }
    }
}
