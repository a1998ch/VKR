using DataBaseModel;
using System;
using System.Windows.Forms;

namespace ViewGUI
{
    public partial class ConnectDataBaseForm : Form
    {
        internal event EventHandler CloseForm;

        internal event EventHandler<string> ConnectEvent;

        public ConnectDataBaseForm()
        {
            InitializeComponent();
        }

        private void ConnectDataBaseLoad(object sender, EventArgs e)
        {
            NameServer.Text = @"STS81\SQLEXPRESS";
            NameDB.Text = "DataBase";
        }

        private void ConnectDataBaseClosing(object sender, FormClosingEventArgs e)
        {
            CloseForm?.Invoke(sender, e);
        }

        private void ConnectDBClick(object sender, EventArgs e)
        {
            string connectionString = DataBaseQuerys.ConnectToDB(NameServer.Text, NameDB.Text);
            ConnectEvent.Invoke(this, connectionString);
            this.Close();
        }

        private void CancellationClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
