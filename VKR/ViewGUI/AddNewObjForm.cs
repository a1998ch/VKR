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
    public partial class AddNewObjForm : Form
    {
        internal event EventHandler CloseForm;

        internal event EventHandler<string> AddObjEvent;

        public AddNewObjForm()
        {
            InitializeComponent();
        }

        private void AddNewObjFormFormClosing(object sender, FormClosingEventArgs e)
        {
            CloseForm?.Invoke(sender, e);
        }

        private void ButtonCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddElementClick(object sender, EventArgs e)
        {
            if (textBoxAddObj.Text == String.Empty) 
            {
                MessageBox.Show("Введите наименование", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            string newObj = textBoxAddObj.Text;
            AddObjEvent.Invoke(this, newObj);
            this.Close();
        }
    }
}
