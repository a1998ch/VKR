using DataBaseModel;
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
            db.PullData(_connectionString, _dataTableAll, DataBaseQuerys.QueryAllData);
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

        private void DataTableAdd(DataTable dataTable, string query)
        {
            var db = new WorkingWithDatabase();
            List<string> colNameList = db.ColumnName<string>(_connectionString, query);

            foreach (var col in colNameList)
            {
                dataTable.Columns.Add(col);
            }

            var dict = db.DataDict<object>(_connectionString, query);

            foreach (DataRow row in _dataTable.Rows)
            {
                var dtRow = dataTable.Rows.Add();
                foreach (DataColumn column in _dataTable.Columns)
                {
                    foreach (var item in dict.Keys)
                    {
                        if (column.ColumnName == item)
                        {
                            dtRow[column.ColumnName] = row[column.ColumnName];
                        }
                    }
                }
            }
        }

        private void AutoGenId()
        {
            var dt = new DataTable();
            var db = new WorkingWithDatabase();
            int id = db.SearchLastId(_connectionString, "Scheme", "Scheme_id");

            DataTableAdd(dt, DataBaseQuerys.QueryAllData);

            // Генерация id для Scheme
            var dict = db.DataDict<object>(_connectionString, DataBaseQuerys.QueryForScheme);

            foreach (var key in dict.Keys)
            {
                if (key == "Scheme_name")
                {
                    foreach (var value in dict.Values)
                    {
                        if (value[0].ToString() != dt.Rows[0].Field<string>("Scheme_name"))
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                row["Scheme_id"] = id + 1;
                            }
                        }
                    }

                }
            }

            //// Генерация id для Regulation
            //var dict2 = db.DataDict<object>(_connectionString, DataBaseQuerys.QueryForReg);

            //foreach (var key in dict.Keys)
            //{
            //    if (key == "Regulation_type")
            //    {
            //        foreach (var value in dict.Values)
            //        {
            //            int i = 0;
            //            if (value[0].ToString() != dt.Rows[i].Field<string>("Regulation_type"))
            //            {
            //                foreach (DataRow row in dt.Rows)
            //                {
            //                    row["Scheme_id"] = id + 1;
            //                }
            //            }
            //        }

            //    }
            //}











            dataGridViewDB.DataSource = dt;

            //// Заполнение столбца - "Energy_object_name"
            //foreach (DataRow row in _dataTableAll.Rows)
            //{
            //    var dtRow = dt.Rows.Add();
            //    foreach (DataColumn column in _dataTableAll.Columns)
            //    {
            //        if (colNameList.Contains(column.ColumnName))
            //        {
            //            dtRow[column.ColumnName] = row[column.ColumnName];
            //        }
            //    }
            //}

            //foreach (DataRow row in _dataTableAll.Rows)
            //{
            //    //row["Energy_object_id"];
            //}

            //// Заполнение столбца - "Energy_object_id"
            //int i = 1;
            //foreach (DataRow row in dt.Rows)
            //{
            //    foreach (DataColumn column in dt.Columns)
            //    {
            //        row["Energy_object_id"] = id + i;
            //    }
            //    i++;
            //}

            //// Заполнение столбца - "Energy_object_number"
            //List<int> valueList = 
            //    db.Data<int>(_connectionString, DataBaseQuerys.QueryForColumn("Energy_object", "Energy_object_number"));
            //bool flag = false;
            //foreach (DataRow row in _dataTable.Rows)
            //{
            //    foreach (DataColumn column in _dataTable.Columns)
            //    {
            //        if (valueList[valueList.Count - 1] != (int)row["Energy_object_number"])
            //        {
            //            flag = true;
            //        }
            //    }
            //}
            //foreach (DataRow row in dt.Rows)
            //{
            //    foreach (DataColumn column in dt.Columns)
            //    {
            //        if (flag) { row["Energy_object_number"] = valueList[valueList.Count - 1] + 1; }
            //        else { row["Energy_object_number"] = valueList[valueList.Count - 1]; }
            //    }
            //}



            /*using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                SqlCommand comand = new SqlCommand(sqlQuery, sqlConnection);
                SqlDataReader dataReader = comand.ExecuteReader();

                var db = new WorkingWithDatabase();
                db.GetDataFromDB(dataReader, columnName, false);

                foreach (var col in columnName)
                {
                    if (col == "Energy_object_id") { continue; }
                    dt.Columns.Add(col);
                }

                foreach (DataRow row in _dataTable.Rows)
                {
                    foreach (DataColumn col in dt.Columns)
                    {
                        dt.Rows.Add(row[col]);
                    }
                }
                dataGridViewDB.DataSource = dt;
            }*/
        }

        private void LoadDataIntoDBClick(object sender, EventArgs e)
        {
            AutoGenId();

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
    }
}
