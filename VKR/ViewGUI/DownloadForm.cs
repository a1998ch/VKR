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
    public partial class DownloadForm : Form
    {
        internal event EventHandler CloseForm;

        public DownloadForm()
        {
            InitializeComponent();
        }

        private void DownloadFormFormClosing(object sender, FormClosingEventArgs e)
        {
            CloseForm?.Invoke(sender, e);
        }
    }
}
