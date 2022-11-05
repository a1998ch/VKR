using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ViewGUI
{
    public partial class MainForm : Form
    {
        private List<double> _listVoltage = new List<double>(3); 

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainFormLoad(object sender, EventArgs e)
        {
            double Uab = 225.8, Ubc = 229, Uca = 214.2;
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

        }
    }
}
