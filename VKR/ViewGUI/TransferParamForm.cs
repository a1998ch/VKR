using Monitel.Rtdb.Api.Config;
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
    public partial class TransferParamForm : Form
    {
        internal event EventHandler CloseForm;

        internal event EventHandler<int> CoaEvent;

        internal event EventHandler<int> IoaEvent;

        private readonly int _coa;

        private readonly int _ioa;

        public TransferParamForm(int coa, int ioa)
        {
            InitializeComponent();
            _coa = coa;
            _ioa = ioa;
        }

        private void TransferParamFormLoad(object sender, EventArgs e)
        {
            CoaTextBox.Text = _coa.ToString();
            IoaTextBox.Text = _ioa.ToString();
        }

        private void TransferParamFormClosing(object sender, FormClosingEventArgs e)
        {
            CloseForm?.Invoke(sender, e);
        }

        private void ButtonOKClick(object sender, EventArgs e)
        {
            if (!int.TryParse(CoaTextBox.Text, out int _))
            {
                MessageBox.Show("Неверно задан общий адрес АСДУ", 
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                CoaEvent.Invoke(this, Convert.ToInt32(CoaTextBox.Text));
            }

            if (!int.TryParse(IoaTextBox.Text, out int _))
            {
                MessageBox.Show("Неверно задан адрес объекта информации",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                IoaEvent.Invoke(this, Convert.ToInt32(IoaTextBox.Text));
            }
            this.Close();
        }

        private void ButtonCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
