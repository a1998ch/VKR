using System;
using System.Windows.Forms;

namespace ViewGUI
{
    public partial class SensitivityFactorForm : Form
    {
        internal event EventHandler CloseForm;

        internal event EventHandler<double> FactorEvent;

        private readonly double _voltageSensitivity;

        public SensitivityFactorForm(double voltageSensitivity)
        {
            InitializeComponent();
            _voltageSensitivity = voltageSensitivity;
        }

        private void SensitivityFactorFormLoad(object sender, EventArgs e)
        {
            SensitivityFactorTextBox.Text = _voltageSensitivity.ToString();
        }

        private void SensitivityFactorFormClosing(object sender, FormClosingEventArgs e)
        {
            CloseForm?.Invoke(sender, e);
        }

        private void ButtonOKClick(object sender, EventArgs e)
        {
            try
            {
                if (!double.TryParse(SensitivityFactorTextBox.Text, out double _))
                {
                    MessageBox.Show("Задан неверный формат",
                                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    FactorEvent.Invoke(this, Convert.ToDouble(SensitivityFactorTextBox.Text));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }

        private void ButtonCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
