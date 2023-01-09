using DataBaseModel;
using Monitel.Mal.Context.CIM16;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CK11Model;
using Monitel.Mal;
using TrNode = System.Windows.Forms.TreeNode;

namespace ViewGUI
{
    public partial class AddNewObjForm : Form
    {
        internal event EventHandler CloseForm;

        internal event EventHandler<List<string>> AddObjEvent;

        /// <summary>
        /// Модель СК-11
        /// </summary>
        private readonly ModelImage _modelImage;

        public AddNewObjForm(ModelImage modelImage)
        {
            InitializeComponent();
            _modelImage = modelImage;
        }

        private void AddNewObjFormLoad(object sender, EventArgs e)
        {
            treeViewObj.CheckBoxes = true;
            GetObject();
        }

        private void AddNewObjFormFormClosing(object sender, FormClosingEventArgs e)
        {
            CloseForm?.Invoke(sender, e);
        }

        private void ButtonCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GetObject()
        {
            var CK11 = new WorkingWithCK11();

            var objects = CK11.GetObjectCK11<Substation>(_modelImage);
            foreach (var obj in objects)
            {
                TrNode rootNode = new TrNode
                {
                    Name = obj.Uid.ToString(),
                    Text = obj.name
                };
                treeViewObj.Nodes.Add(rootNode);
            }
        }

        private void AddElementClick(object sender, EventArgs e)
        {
            List<string> listObj = new List<string>();
            foreach (TrNode node in treeViewObj.Nodes)
            {
                if (node.Checked)
                {
                    listObj.Add(node.Text.Trim());
                }
            }
            if (listObj.Count == 0) 
            {
                MessageBox.Show("Выберете объект электроэнергетики",
                                "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            AddObjEvent?.Invoke(this, listObj);
            this.Close();
        }
    }
}
