using CalculationModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ViewGUI
{
    public partial class DatabaseEditorForm : Form
    {
        internal event EventHandler CloseForm;

        private DataTable _dataTable = new DataTable();

        public DatabaseEditorForm()
        {
            InitializeComponent();
        }

        private void DatabaseEditorFormLoad(object sender, EventArgs e)
        {
            dataGridViewDB.DataSource = _dataTable;
            dataGridViewDB.AutoResizeColumns();
        }

        private void DatabaseEditorFormClosing(object sender, FormClosingEventArgs e)
        {
            CloseForm?.Invoke(sender, e);
        }

        private void AddDataToDBClick(object sender, EventArgs e)
        {
            var openFile = new OpenFileDialog();
            openFile.Filter = "Файл csv (*.csv)|*.csv";
            openFile.ShowDialog();
            string path = openFile.FileName;

            if (string.IsNullOrEmpty(path)) { return; }

            var db = new WorkingWithDatabase();
            _dataTable = db.ConvertToDataTable(path);
            dataGridViewDB.DataSource = _dataTable;
        }

        public void PullData(string connectionString, string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                SqlDataAdapter sqlAdapret = new SqlDataAdapter(sqlCommand);
                sqlAdapret.Fill(_dataTable);
                sqlAdapret.Dispose();
            }
        }
    }
}
