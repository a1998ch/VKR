using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MethodologyModel;
using System.IO;
using System.Data.SqlClient;

namespace ViewGUI
{
    public partial class MainForm : Form
    {
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

        private void ToolStripMenuItemBDClick(object sender, EventArgs e)
        {
            this.Hide();
            DownloadForm downloadForm = new DownloadForm();
            downloadForm.CloseForm += OtherCloseForm;
            downloadForm.ShowDialog();
        }

        private void OtherCloseForm(object sender, EventArgs e)
        {
            this.Show();
        }

        private void ToolStripMenuItemCalcClick(object sender, EventArgs e)
        {
            PowerReserve power = new PowerReserve();
            var P = power.LimitFlow(_listVoltage);
            textBox1.Text = P.ToString();
        }

        private void ToolStripMenuItemConnectBDClick(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=ST15;Initial Catalog=DatabaseDownload;Integrated Security=True");
            string sql = "SELECT Voltage_value From Voltage_level";
            sqlConnection.Open();
            SqlCommand comand = new SqlCommand(sql, sqlConnection);
            SqlDataReader dataReader = comand.ExecuteReader();

            List<int> list = new List<int>();
            while(dataReader.Read())
            {
                textBox1.Text += Convert.ToString(dataReader.GetString(0));
            }
            sqlConnection.Close();
        }
    }
}
