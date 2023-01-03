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
using TrNode = System.Windows.Forms.TreeNode;
using TrView = System.Windows.Forms.TreeView;

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
            TreeViewVoltage.Visible = false;
            TreeViewVoltage.CheckBoxes = true;

            TreeViewRegType.Visible = false;
            TreeViewRegType.CheckBoxes = true;

            TreeViewSchema.Visible = false;
            TreeViewSchema.CheckBoxes = true;

            TreeViewEnObj.Visible = false;
            TreeViewEnObj.CheckBoxes = true;
        }

        private void DatabaseEditorFormClosing(object sender, FormClosingEventArgs e)
        {
            CloseForm?.Invoke(sender, e);
        }

        private void LoadDataFromDbClick(object sender, EventArgs e)
        {
            var wdb = new WorkingWithDatabase();
            _dataTable = wdb.PullData(_connectionString, DataBaseQuerys.QueryData);
            dataGridViewDB.DataSource = _dataTable;
            DataGridViewHeadersName();
            dataGridViewDB.AutoResizeColumns();

            TreeViewVoltage.Nodes.Clear();
            TreeViewRegType.Nodes.Clear();
            TreeViewSchema.Nodes.Clear();
            TreeViewEnObj.Nodes.Clear();

            SetElemnetToTreeView("Schema_data", "Voltage_value", TreeViewVoltage);
            SetElemnetToTreeView("Schema_data", "Regulation_type", TreeViewRegType);
            SetElemnetToTreeView("Schema_data", "Scheme_name", TreeViewSchema);
            SetElemnetToTreeView("Energy_object", "Energy_object_name", TreeViewEnObj);
        }

        private void DataGridViewHeadersName()
        {
            dataGridViewDB.Columns[0].HeaderText = "Наименование объекта электроэнергетики";
            dataGridViewDB.Columns[1].HeaderText = "Схемно-режимная ситуация";
            dataGridViewDB.Columns[2].HeaderText = "Тип регулирования";
            dataGridViewDB.Columns[3].HeaderText = "Уровень напряжения, кВ";
            dataGridViewDB.Columns[4].HeaderText = "Коэффициент несимметрии, %";
            dataGridViewDB.Columns[5].HeaderText = "Активная мощность, МВт";
            dataGridViewDB.Columns[6].HeaderText = "Ток обратной последовательности, А";
        }

        /// <summary>
        /// Сохранение/загрузка данных
        /// </summary>
        /// <FilterParam name="saveOpenFile">saveFileDialog or openFileDialog</FilterParam>
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
            DataGridViewHeadersName();
            dataGridViewDB.AutoResizeColumns();
        }

        private void LoadDataIntoDBClick(object sender, EventArgs e)
        {
            var db = new WorkingWithDatabase();
            var checkSchema = db.AddTableToDb(_connectionString, DataBaseQuerys.QueryForSchemaData, _dataTable);
            var checkEnObj = db.AddTableToDb(_connectionString, DataBaseQuerys.QueryForEnObj, _dataTable, autoGenId: true);

            if (checkSchema || checkEnObj)
            {
                MessageBox.Show("Запись данных в БД выполнена", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Нельзя добавить уже существующие данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                save.SaveToCSV(_connectionString, _dataTable, path);

                MessageBox.Show("Сохранение успешно", "Сообщение",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetElemnetToTreeView(string tableName, string columnName, TrView treeView)
        {
            List<string> list = new List<string>();
            foreach (DataRow row in _dataTable.Rows)
            {
                foreach (DataColumn col in _dataTable.Columns)
                {
                    list.Add(row[columnName].ToString());
                }
            }
            var noDupeslistDataCol = list.Distinct().ToArray();

            foreach (var element in noDupeslistDataCol)
            {
                TrNode rootNode = new TrNode
                {
                    Name = element,
                    Text = element
                };
                treeView.Nodes.Add(rootNode);
            }
        }

        private string GetTreeValue(TrView treeView)
        {
            var FilterParam = String.Empty;
            foreach (TrNode value in treeView.Nodes)
            {
                if (value.Checked)
                {
                    FilterParam = value.Name;
                }
            }
            return FilterParam;
        }

        private void TreeViewFilter(TreeViewEventArgs e, TrView treeView, string columnName)
        {
            string value = GetTreeValue(treeView);

            DataTable dt = new DataTable();
            dt.Merge(_dataTable);
            _dataTable.Clear();

            foreach (DataRow row in dt.Rows)
            {
                var dtRow = _dataTable.Rows.Add();
                bool flag = false;
                foreach (DataColumn col in dt.Columns)
                {
                    if (row[columnName].ToString() == value)
                    {
                        flag = true;
                    }
                    else
                    {
                        dtRow.Delete();
                    }
                }
                foreach (DataColumn col in dt.Columns)
                {
                    if (flag)
                    {
                        dtRow[col.ColumnName] = row[col.ColumnName];
                    }
                }
            }
            dataGridViewDB.DataSource = _dataTable;
            dataGridViewDB.AutoResizeColumns();
        }

        private void TreeViewVoltageAfterCheck(object sender, TreeViewEventArgs e)
        {
            TreeViewFilter(e, TreeViewVoltage, "Voltage_value");

            TreeViewVoltage.Nodes.Clear();
            SetElemnetToTreeView("Schema_data", "Voltage_value", TreeViewVoltage);

            TreeViewRegType.Nodes.Clear();
            SetElemnetToTreeView("Schema_data", "Regulation_type", TreeViewRegType);

            TreeViewSchema.Nodes.Clear();
            SetElemnetToTreeView("Schema_data", "Scheme_name", TreeViewSchema);

            TreeViewEnObj.Nodes.Clear();
            SetElemnetToTreeView("Energy_object", "Energy_object_name", TreeViewEnObj);
        }

        private void TreeViewRegTypeAfterCheck(object sender, TreeViewEventArgs e)
        {
            TreeViewFilter(e, TreeViewRegType, "Regulation_type");

            TreeViewVoltage.Nodes.Clear();
            SetElemnetToTreeView("Schema_data", "Voltage_value", TreeViewVoltage);

            TreeViewRegType.Nodes.Clear();
            SetElemnetToTreeView("Schema_data", "Regulation_type", TreeViewRegType);

            TreeViewSchema.Nodes.Clear();
            SetElemnetToTreeView("Schema_data", "Scheme_name", TreeViewSchema);

            TreeViewEnObj.Nodes.Clear();
            SetElemnetToTreeView("Energy_object", "Energy_object_name", TreeViewEnObj);
        }

        private void TreeViewSchemaAfterCheck(object sender, TreeViewEventArgs e)
        {
            TreeViewFilter(e, TreeViewSchema, "Scheme_name");

            TreeViewVoltage.Nodes.Clear();
            SetElemnetToTreeView("Schema_data", "Voltage_value", TreeViewVoltage);

            TreeViewRegType.Nodes.Clear();
            SetElemnetToTreeView("Schema_data", "Regulation_type", TreeViewRegType);

            TreeViewSchema.Nodes.Clear();
            SetElemnetToTreeView("Schema_data", "Scheme_name", TreeViewSchema);

            TreeViewEnObj.Nodes.Clear();
            SetElemnetToTreeView("Energy_object", "Energy_object_name", TreeViewEnObj);
        }

        private void TreeViewEnObjAfterCheck(object sender, TreeViewEventArgs e)
        {
            TreeViewFilter(e, TreeViewEnObj, "Energy_object_name");

            TreeViewVoltage.Nodes.Clear();
            SetElemnetToTreeView("Schema_data", "Voltage_value", TreeViewVoltage);

            TreeViewRegType.Nodes.Clear();
            SetElemnetToTreeView("Schema_data", "Regulation_type", TreeViewRegType);

            TreeViewSchema.Nodes.Clear();
            SetElemnetToTreeView("Schema_data", "Scheme_name", TreeViewSchema);

            TreeViewEnObj.Nodes.Clear();
            SetElemnetToTreeView("Energy_object", "Energy_object_name", TreeViewEnObj);
        }

        private void ButtonVoltageClick(object sender, EventArgs e)
        {
            TreeViewVoltage.Visible = true;
        }

        private void ButtonRegTypeClick(object sender, EventArgs e)
        {
            TreeViewRegType.Visible = true;
        }

        private void ButtonSchemaClick(object sender, EventArgs e)
        {
            TreeViewSchema.Visible = true;
        }

        private void ButtonEnergyObjClick(object sender, EventArgs e)
        {
            TreeViewEnObj.Visible = true;
        }

        private void TreeViewVoltageMouseLeave(object sender, EventArgs e)
        {
            TreeViewVoltage.Visible = false;
        }

        private void TreeViewRegTypeMouseLeave(object sender, EventArgs e)
        {
            TreeViewRegType.Visible = false;
        }

        private void TreeViewSchemaMouseLeave(object sender, EventArgs e)
        {
            TreeViewSchema.Visible = false;
        }

        private void TreeViewEnObjMouseLeave(object sender, EventArgs e)
        {
            TreeViewEnObj.Visible = false;
        }

        private void ButtonClearFilterClick(object sender, EventArgs e)
        {
            var wdb = new WorkingWithDatabase();
            _dataTable = wdb.PullData(_connectionString, DataBaseQuerys.QueryData);
            dataGridViewDB.DataSource = _dataTable;
            DataGridViewHeadersName();
            dataGridViewDB.AutoResizeColumns();

            TreeViewVoltage.Nodes.Clear();
            TreeViewRegType.Nodes.Clear();
            TreeViewSchema.Nodes.Clear();
            TreeViewEnObj.Nodes.Clear();

            SetElemnetToTreeView("Schema_data", "Voltage_value", TreeViewVoltage);
            SetElemnetToTreeView("Schema_data", "Regulation_type", TreeViewRegType);
            SetElemnetToTreeView("Schema_data", "Scheme_name", TreeViewSchema);
            SetElemnetToTreeView("Energy_object", "Energy_object_name", TreeViewEnObj);
        }
    }
}
