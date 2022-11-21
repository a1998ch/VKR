using CalculationModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ViewGUI
{
    public partial class MainForm : Form
    {
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
            connectDataBase.ConnectEvent += (o, args) =>
            {
                _sqlConnection = args;
            };
            connectDataBase.ShowDialog();
        }

        private void OtherCloseForm(object sender, EventArgs e)
        {
            this.Show();
        }

        private void StartSystemClick(object sender, EventArgs e)
        {
            PowerReserve power = new PowerReserve(_sqlConnection);
            var P = power.LimitFlow(_listVoltage);
            textBox1.Text = P.ToString();
        }

        private void DatabaseDataImportClick(object sender, EventArgs e)
        {
            var saveFile = new SaveFileDialog();
            saveFile.Filter = "Файл csv (*.csv)|*.csv";
            saveFile.ShowDialog();
            string path = saveFile.FileName;

            if (string.IsNullOrEmpty(path)) { return; }

            try
            {
                var save = new WorkingWithDatabase();
                save.SaveToCSV(_sqlConnection, path);
                MessageBox.Show("Сохранение успешно", "Сообщение", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                ExeptionMessage(ex);
            }
        }

        public void ExeptionMessage(Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
