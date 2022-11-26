using CalculationModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ViewGUI
{
    public partial class DatabaseEditorForm : Form
    {
        internal event EventHandler CloseForm;

        private DataTable _dataTable = new DataTable();

        private readonly string _connectionString;

        public DatabaseEditorForm(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString;
        }

        private void DatabaseEditorFormLoad(object sender, EventArgs e)
        {
            PullData(_dataTable, DataBaseQuerys.QueryAllData);
            dataGridViewDB.DataSource = _dataTable;
            dataGridViewDB.AutoResizeColumns();
        }

        private void DatabaseEditorFormClosing(object sender, FormClosingEventArgs e)
        {
            CloseForm?.Invoke(sender, e);
        }

        /// <summary>
        /// Сохранение/загрузка данных
        /// </summary>
        /// <param name="saveOpenFile">saveFileDialog or openFileDialog</param>
        /// <returns>Путь для сохранения/загрузки</returns>
        private string WorkWithCSV(FileDialog saveOpenFile)
        {
            saveOpenFile.Filter = "Файл csv (*.csv)|*.csv";
            saveOpenFile.ShowDialog();
            string path = saveOpenFile.FileName;
            return path;
        }

        private void ImportFromCSVClick(object sender, EventArgs e)
        {
            var openFile = new OpenFileDialog();
            string path = WorkWithCSV(openFile);

            if (string.IsNullOrEmpty(path)) { return; }

            var db = new WorkingWithDatabase();
            dataGridViewDB.DataSource = db.ConvertToDataTable(path);
            dataGridViewDB.AutoResizeColumns();

            _dataTable = db.ConvertToDataTable(path);
        }

        private void AutoGenId(string sqlQuery)
        {
            var dtFromAllData = new DataTable();
            PullData(dtFromAllData, sqlQuery);

            foreach (DataColumn col1 in dtFromAllData.Columns)
            {
                foreach (DataColumn col2 in _dataTable.Columns)
                {
                    if (col1.ColumnName == col2.ColumnName)
                    {

                    }
                }
            }

            foreach (DataRow row in dtFromAllData.Rows)
            {
                foreach (DataColumn column in dtFromAllData.Columns)
                {

                }
            }

            var db = new WorkingWithDatabase();
        }

        private void LoadDataIntoDBClick(object sender, EventArgs e)
        {
            AutoGenId(DataBaseQuerys.QueryForEnObj);

            /*string sql = "SELECT * FROM Value_param";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var adapter = new SqlDataAdapter(sql, connection);
                var commandBuilder = new SqlCommandBuilder(adapter);
                adapter.Update(_dataTable);
            }*/
        }

        private void DataExportFromDBClick(object sender, EventArgs e)
        {
            var saveFile = new SaveFileDialog();
            string path = WorkWithCSV(saveFile);

            if (string.IsNullOrEmpty(path)) { return; }

            try
            {
                var save = new WorkingWithDatabase();
                save.SaveToCSV(_connectionString, DataBaseQuerys.QueryData, path);
                MessageBox.Show("Сохранение успешно", "Сообщение",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PullData(DataTable dataTable, string query)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                SqlDataAdapter sqlAdapret = new SqlDataAdapter(sqlCommand);
                sqlAdapret.Fill(dataTable);
                sqlAdapret.Dispose();
            }
        }
    }
}
