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
    }
}
