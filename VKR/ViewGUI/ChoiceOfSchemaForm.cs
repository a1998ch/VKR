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

        public ChoiceOfSchemaForm()
        {
            InitializeComponent();
        }

        public ChoiceOfSchemaForm(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString;
        }

        private void ChoiceOfSchemaFormLoad(object sender, EventArgs e)
        {
            comboBoxScheme.DropDownStyle = ComboBoxStyle.DropDownList;

            var wdb = new WorkingWithDatabase();
            var listScheme = wdb.GetData(_connectionString, DataBaseQuerys.QueryForSchemaName);
            var noDupes = listScheme.Distinct().ToArray();

            comboBoxScheme.Items.AddRange(noDupes);
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
            this.Close();
            SchemeEvent?.Invoke(this, comboBoxScheme.SelectedItem.ToString());
        }
    }
}
