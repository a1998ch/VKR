using CK11Model;
using DataBaseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ViewGUI
{
    public partial class ChoiceOfSchemaForm : Form
    {
        internal event EventHandler CloseForm;

        internal event EventHandler<string> SchemeEvent;

        private readonly string _connectionString;

        private readonly string _objName;

        private readonly string _schemeName;

        public ChoiceOfSchemaForm(string connectionString, string objName, string schemeName)
        {
            InitializeComponent();
            _connectionString = connectionString;
            _objName = objName;
            _schemeName = schemeName;
        }

        private void ChoiceOfSchemaFormLoad(object sender, EventArgs e)
        {
            comboBoxScheme.SelectedText = _schemeName;
            var wdb = new WorkingWithDatabase();
            var listScheme = wdb.GetData(_connectionString, DataBaseQuerys.QueryForSchemaName(_objName));
            var noDupesScheme = listScheme.Distinct().ToArray();
            comboBoxScheme.Items.AddRange(noDupesScheme);
        }

        private void ChoiceOfSchemaFormClosing(object sender, FormClosingEventArgs e)
        {
            CloseForm?.Invoke(sender, e);
        }

        private void ButtonCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OKClick(object sender, EventArgs e)
        {
            if (comboBoxScheme.SelectedItem == null)
            {
                MessageBox.Show("Неверно выбрана или не выбрана схемно-режимная ситуация", 
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.Close();
            SchemeEvent?.Invoke(this, comboBoxScheme.SelectedItem.ToString());
        }
    }
}
