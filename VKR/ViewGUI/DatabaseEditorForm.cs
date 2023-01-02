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
            dataGridViewDB.AutoResizeColumns();

            GetElemnet("Voltage_value");
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
            dataGridViewDB.AutoResizeColumns();
        }

        private void LoadDataIntoDBClick(object sender, EventArgs e)
        {
            var db = new WorkingWithDatabase();
            try
            {
                db.AddTableToDb(_connectionString, DataBaseQuerys.QueryForSchemaData, _dataTable);
                db.AddTableToDb(_connectionString, DataBaseQuerys.QueryForEnObj, _dataTable, autoGenId: true);

                MessageBox.Show("Запись данных в БД выполнена", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void GetElemnet(string colimnName)
        {
            var wdb = new WorkingWithDatabase();
            var listDataCol = wdb.GetData(_connectionString, DataBaseQuerys.QueryForColumn("Schema_data", colimnName));
            var noDupeslistDataCol = listDataCol.Distinct().ToArray();

            foreach (var element in noDupeslistDataCol)
            {
                TrNode rootNode = new TrNode
                {
                    Name = element,
                    Text = element
                };
                TreeViewVoltage.Nodes.Add(rootNode);
            }
        }

        private void CheckedTreeView(TreeViewEventArgs e)
        {
            if (e.Node.Checked)
            {
                foreach (TrNode cur_node in e.Node.TreeView.Nodes)
                {
                    if (cur_node != e.Node)
                    {
                        cur_node.Checked = false;
                    }
                }
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

        private void TreeViewVoltageAfterCheck(object sender, TreeViewEventArgs e)
        {
            CheckedTreeView(e);
            string voltage = GetTreeValue(TreeViewVoltage);

            DataTable dt = new DataTable(); 
            dt.Merge(_dataTable);
            _dataTable.Clear();

            foreach (DataRow row in dt.Rows)
            {
                var dtRow = _dataTable.Rows.Add();
                bool flag = false;
                foreach (DataColumn col in dt.Columns)
                {
                    if (row["Voltage_value"].ToString() == voltage)
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

            var wdb = new WorkingWithDatabase();
            //_dataTable = wdb.PullData(_connectionString, DataBaseQuerys.VoltageFilter(voltage));
            dataGridViewDB.DataSource = _dataTable;
            dataGridViewDB.AutoResizeColumns();
            _dataTable = wdb.PullData(_connectionString, DataBaseQuerys.QueryData);
        }

        private void ButtonVoltageClick(object sender, EventArgs e)
        {
            TreeViewVoltage.Visible = true;
        }

        private void TreeViewVoltageMouseLeave(object sender, EventArgs e)
        {
            TreeViewVoltage.Visible = false;
        }
    }
}
