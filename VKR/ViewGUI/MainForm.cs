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
            var queryAllData = new WorkingWithDatabase();
            var a = queryAllData.Data<object>(_sqlConnection);
            int i = 0;
            foreach (var item in a)
            {
                i++;
                if (i == 5)
                {
                    textBox1.Text += item.ToString() + "\n";
                    i = 0;
                }
                else
                {
                    textBox1.Text += item.ToString() + ";";
                }
            }
        }
    }
}
