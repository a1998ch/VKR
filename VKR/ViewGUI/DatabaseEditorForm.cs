using DataBaseModel;
using Monitel.Mal.Context.CIM16;
using System;
using System.Collections;
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

        private DataTable _dataTableAll = new DataTable();

        private readonly string _connectionString;

        public DatabaseEditorForm(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString;
        }

        private void DatabaseEditorFormLoad(object sender, EventArgs e)
        {
            var db = new WorkingWithDatabase();
            _dataTableAll = db.PullData(_connectionString, DataBaseQuerys.QueryAllData);
            dataGridViewDB.DataSource = _dataTableAll;
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
            _dataTable = db.ConvertToDataTable(path);
            dataGridViewDB.DataSource = _dataTable;
            dataGridViewDB.AutoResizeColumns();
        }

        private DataTable AddTableToDb(string query, string tableName = "", string columnName = "")
        {
            DataTable dt = new DataTable();
            var db = new WorkingWithDatabase();

            List<string> colNameList = db.GetColumnName(_connectionString, query);
            foreach (var col in colNameList)
            {
                dt.Columns.Add(col);
            }

            List<string> dataList = new List<string>();
            if (tableName != String.Empty || columnName != String.Empty)
            {
                dataList = db.GetData(_connectionString, DataBaseQuerys.QueryForColumn(tableName, columnName));
            }

            foreach (DataRow row in _dataTable.Rows)
            {
                var dtRow = dt.Rows.Add();
                foreach (DataColumn col in _dataTable.Columns)
                {
                    if (colNameList.Contains(col.ColumnName))
                    {
                        if (dataList.Contains(row[col.ColumnName])) { continue; }
                        dtRow[col.ColumnName] = row[col.ColumnName];
                    }
                }
            }
            dataGridViewDB.DataSource = dt;
            return dt;
        }

        private void LoadDataIntoDBClick(object sender, EventArgs e)
        {
            //DataTable dt = AddTableToDb(DataBaseQuerys.QueryForValue);
            //DataTable dt = AddTableToDb(DataBaseQuerys.QueryForScheme, "Scheme", "Scheme_name");
            //DataTable dt = AddTableToDb(DataBaseQuerys.QueryForReg, "Regulation", "Regulation_type");
            DataTable dt = AddTableToDb(DataBaseQuerys.QueryForVoltage, "Voltage_level", "Voltage_value");

            for (int i = 0, j = 0; i < dt.Columns.Count; i++)
            {
                if (string.IsNullOrEmpty(dt.Rows[0][i].ToString())) { j++; }
                if (j == dt.Columns.Count) { return; }
            }

            string sql = DataBaseQuerys.QueryForVoltage;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var adapter = new SqlDataAdapter(sql, connection);
                var commandBuilder = new SqlCommandBuilder(adapter);
                adapter.Update(dt);
            }
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
    }
}
