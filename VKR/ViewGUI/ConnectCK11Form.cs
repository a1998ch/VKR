using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CK11Model;
using lib60870;
using CK = Monitel.Rtdb.Api;

namespace ViewGUI
{
    public partial class ConnectCK11Form : Form
    {
        internal event EventHandler CloseForm;

        internal event EventHandler<string> ConnectionStringBdrvEvent;

        internal event EventHandler<Server> ServerEvent;

        public ConnectCK11Form()
        {
            InitializeComponent();
        }

        private void ConnectCK11FormLoad(object sender, EventArgs e)
        {
            AddressBdrvTextBox.Text = "10.221.3.29";
            PortBdrvTextBox.Text = "900";
            AddressPcTextBox.Text = "10.221.3.57";
            PortPcTextBox.Text = "2404";
        }

        private void ConnectCK11FormFormClosing(object sender, FormClosingEventArgs e)
        {
            CloseForm?.Invoke(sender, e);
        }

        private void ButtonOKClick(object sender, EventArgs e)
        {
            try
            {
                AddressBdrvTextBox.BackColor = Color.White;
                PortBdrvTextBox.BackColor = Color.White;

                string connectionString = $"{AddressBdrvTextBox.Text}:{PortBdrvTextBox.Text}";
                using (CK.IRtdbProvider provider = CK.RtdbProvider.CreateProvider())
                {
                    CK.IRtdbProxy proxy = provider.Connect(connectionString);
                }
                ConnectionStringBdrvEvent.Invoke(this, connectionString);
            }
            catch (Exception ex)
            {
                AddressBdrvTextBox.BackColor = Color.Red;
                PortBdrvTextBox.BackColor = Color.Red;

                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                AddressPcTextBox.BackColor = Color.White;
                PortPcTextBox.BackColor = Color.White;

                var dtf = new DataTransferToCK11();
                Server server = dtf.ConnectServer(AddressPcTextBox.Text, Convert.ToInt32(PortPcTextBox.Text));
                ServerEvent.Invoke(this, server);
            }
            catch (Exception ex)
            {
                AddressPcTextBox.BackColor = Color.Red;
                PortPcTextBox.BackColor = Color.Red;

                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Соединение с сервером СК-11 успешно",
                "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void ButtonCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
