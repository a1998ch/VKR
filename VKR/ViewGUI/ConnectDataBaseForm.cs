using DataBaseModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            NameServer.Text = @"DESKTOP-M77O4Q0\SQLEXPRESS";
            NameDB.Text = "DataBase";
        }

        private void ConnectDataBaseClosing(object sender, FormClosingEventArgs e)
        {
            CloseForm?.Invoke(sender, e);
        }

        private void ConnectDBClick(object sender, EventArgs e)
        {
            string connectionString = DataBaseQuerys.ConnectToDB(NameServer.Text, NameDB.Text);

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                }
                MessageBox.Show("Соединение с сервером базы данных успешно", 
                                "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ConnectEvent.Invoke(this, connectionString);
                this.Close();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancellationClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
