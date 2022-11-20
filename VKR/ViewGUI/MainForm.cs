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
            ConnectDataBase connectDataBase = new ConnectDataBase();
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
            PowerReserve power = new PowerReserve();
            var P = power.LimitFlow(_listVoltage);
            textBox1.Text = P.ToString();
        }

        private void DatabaseDataImportClick(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(_sqlConnection);
            string sql = "SELECT Voltage_value From Voltage_level";
            sqlConnection.Open();
            SqlCommand comand = new SqlCommand(sql, sqlConnection);
            SqlDataReader dataReader = comand.ExecuteReader();

            List<int> list = new List<int>();
            int i = 0;
            while(dataReader.Read())
            {
                list.Add(dataReader.GetInt32(0));
                textBox1.Text += list[i].ToString() + " ";
                i++;
            }
            sqlConnection.Close();
        }
    }
}
