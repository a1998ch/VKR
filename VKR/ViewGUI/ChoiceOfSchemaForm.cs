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

        internal event EventHandler<string> RegulationTypeEvent;

        private readonly string _connectionString;

        private readonly string _objName;

        public ChoiceOfSchemaForm(string connectionString, string objName)
        {
            InitializeComponent();
            _connectionString = connectionString;
            _objName = objName;
        }

        private void ChoiceOfSchemaFormLoad(object sender, EventArgs e)
        {
            comboBoxScheme.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxReg.DropDownStyle = ComboBoxStyle.DropDownList;
            var wdb = new WorkingWithDatabase();

            var listScheme = wdb.GetData(_connectionString, DataBaseQuerys.QueryForSchemaName(_objName));
            var noDupesScheme = listScheme.Distinct().ToArray();
            comboBoxScheme.Items.AddRange(noDupesScheme);

            var listRegType = wdb.GetData(_connectionString, DataBaseQuerys.QueryForRegType(_objName));
            var noDupesRegType = listRegType.Distinct().ToArray();
            comboBoxReg.Items.AddRange(noDupesRegType);
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
            if (comboBoxScheme.SelectedItem == null || comboBoxReg.SelectedItem == null)
            {
                MessageBox.Show("Не выбрана схемно-режимная ситуация или не выбран тип регулирования", 
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.Close();
            SchemeEvent?.Invoke(this, comboBoxScheme.SelectedItem.ToString());
            RegulationTypeEvent?.Invoke(this, comboBoxReg.SelectedItem.ToString());
        }
    }
}
