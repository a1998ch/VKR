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

        private readonly string _connectionString;

        public DatabaseEditorForm(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString;
        }

        private void DatabaseEditorFormLoad(object sender, EventArgs e)
        {

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

        private void LoadDataIntoDBClick(object sender, EventArgs e)
        {
            var db = new WorkingWithDatabase();
            try
            {
                db.AddDataToDb(_connectionString, DataBaseQuerys.QueryForSchemaData, _dataTable);
                db.AddDataToDb(_connectionString, DataBaseQuerys.QueryForEnObj, _dataTable, autoGenId: true);

                MessageBox.Show("Запись данных в БД выполнена", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
