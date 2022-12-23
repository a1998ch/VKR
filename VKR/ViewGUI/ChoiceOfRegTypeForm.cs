using DataBaseModel;
using Monitel.Rtdb.Api.Config;
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
    public partial class ChoiceOfRegTypeForm : Form
    {
        internal event EventHandler CloseForm;

        internal event EventHandler<string> RegulationTypeEvent;

        private readonly string _connectionString;

        private readonly string _objName;

        public ChoiceOfRegTypeForm(string connectionString, string objName)
        {
            InitializeComponent();
            _connectionString = connectionString;
            _objName = objName;
        }

        private void ChoiceOfRegTypeFormLoad(object sender, EventArgs e)
        {
            comboBoxReg.DropDownStyle = ComboBoxStyle.DropDownList;
            var wdb = new WorkingWithDatabase();

            var listRegType = wdb.GetData(_connectionString, DataBaseQuerys.QueryForRegType(_objName));
            var noDupesRegType = listRegType.Distinct().ToArray();
            comboBoxReg.Items.AddRange(noDupesRegType);
        }

        private void ChoiceOfRegTypeFormClosing(object sender, FormClosingEventArgs e)
        {
            CloseForm?.Invoke(sender, e);
        }

        private void ButtonCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OKClick(object sender, EventArgs e)
        {
            if (comboBoxReg.SelectedItem == null)
            {
                MessageBox.Show("Не выбран тип регулирования",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.Close();
            RegulationTypeEvent?.Invoke(this, comboBoxReg.SelectedItem.ToString());
        }
    }
}
