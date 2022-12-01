using CalculationModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using CK = Monitel.Rtdb.Api;
using CK11Model;

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

        private string _sqlConnection;

        private readonly List<double> _listVoltage = new List<double>(3); 

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainFormLoad(object sender, EventArgs e)
        {
            double Uab = 215, Ubc = 243.7, Uca = 223;
            _listVoltage.Add(Uab);
            _listVoltage.Add(Ubc);
            _listVoltage.Add(Uca);
        }

        private void ConnectDBClick(object sender, EventArgs e)
        {
            this.Hide();
            ConnectDataBaseForm connectDataBase = new ConnectDataBaseForm();
            connectDataBase.CloseForm += OtherCloseForm;
            connectDataBase.ConnectEvent += (o, args) => _sqlConnection = args;
            connectDataBase.ShowDialog();
        }

        private void OtherCloseForm(object sender, EventArgs e)
        {
            this.Show();
        }

        private void StartSystemClick(object sender, EventArgs e)
        {
            PowerReserve power = new PowerReserve();
            var P = power.LimitFlow("ВНС", "Нормальная схема", _sqlConnection, _listVoltage);
            textBox1.Text = P.ToString();
        }

        private void AddEditDataDBClick(object sender, EventArgs e)
        {
            this.Hide();
            DatabaseEditorForm databaseEditor = new DatabaseEditorForm(_sqlConnection);
            databaseEditor.CloseForm += OtherCloseForm;
            databaseEditor.ShowDialog();
        }

        public void ExeptionMessage(Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ConnectCK11Click(object sender, EventArgs e)
        {
            Guid[] arr = new Guid[1] { Guid.Parse("6C72BF14-A296-4AF5-9C15-4ED3E48F7121") };

            var dataRequest = new ConnectCK11(_connectionStringToRtdb);

            var data = dataRequest.GetSignals(arr);

            foreach (var item in data)
            {
                textBox1.Text += item.Value.AnalogValue.ToString();
            }
        }
    }
}
