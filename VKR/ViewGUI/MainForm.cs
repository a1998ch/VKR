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
        public MainForm()
        {
            InitializeComponent();
        }

        private void ToolStripMenuItemBDClick(object sender, EventArgs e)
        {
            this.Hide();
            DownloadForm downloadForm = new DownloadForm();
            downloadForm.CloseForm += DownloadFormCloseForm;
            downloadForm.ShowDialog();
        }

        private void DownloadFormCloseForm(object sender, EventArgs e)
        {
            this.Show();
        }
    }
}
