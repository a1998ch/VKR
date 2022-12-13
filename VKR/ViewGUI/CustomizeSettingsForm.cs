using CK11Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Monitel.Mal.Context.CIM16;
using Monitel.Mal;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TrNode = System.Windows.Forms.TreeNode;
using System.Security.Cryptography;

namespace ViewGUI
{
    public partial class CustomizeSettingsForm : Form
    {
        internal event EventHandler CloseForm;

        private readonly int _serverPort;

        private ModelImage _modelImage;

        /// <summary>
        /// Uid типа значения - "Напряжение"
        /// </summary>
        private readonly Guid _measurementTypeVoltage = Guid.Parse("10000bdf-0000-0000-c000-0000006d746c");

        /// <summary>
        /// Uid типа значения - "Генерация активной мощности"
        /// </summary>
        private readonly Guid _measurementTypePower = Guid.Parse("10000849-0000-0000-C000-0000006D746C");

        /// <summary>
        /// Uid контролируемого объекта энергетики
        /// </summary>
        private readonly Guid _observableObjectUid = Guid.Parse("0904FE7A-A7F8-4649-AF02-CEC613C55624");

        public CustomizeSettingsForm(int serverPort)
        {
            InitializeComponent();
            _serverPort = serverPort;
        }

        public CustomizeSettingsForm() 
        {
            InitializeComponent();
        }

        private void CustomizeSettingsFormLoad(object sender, EventArgs e)
        {
            treeViewObj.CheckBoxes = true;

            // Подключение к модели
            var ConnectCK11 = new WorkingWithCK11(_serverPort);
            _modelImage = ConnectCK11.AccessingTheMalApi();

            GetElemnt<BusbarSection>();
            GetElemnt<PowerTransformer>();
        }

        private void GetElemnt<T>() where T : class, IdentifiedObject
        {
            var ConnectCK11 = new WorkingWithCK11(_serverPort);

            var objects = ConnectCK11.GetSpecificObject<T>(_modelImage, _observableObjectUid);
            foreach (var parent in objects)
            {
                if (parent.name == null) { continue; }

                TrNode rootNode = new TrNode();
                rootNode.Name = parent.Uid.ToString();
                rootNode.Text = parent.name + $"   Type: ({ parent.GetType().Name.Substring(14) })";

                treeViewObj.Nodes.Add(rootNode);
                var arrayChild = ConnectCK11.GetChildObject(parent);

                foreach (var child in arrayChild)
                {
                    if (child.name == null) { continue; }

                    TrNode childNode = new TrNode();
                    childNode.Name = child.Uid.ToString();
                    childNode.Text = child.name + $"   Type: ({child.GetType().Name.Substring(14) })";

                    rootNode.Nodes.Add(childNode);

                    var arrayChildTwo = ConnectCK11.GetChildObject(child);

                    foreach (var childTwo in arrayChildTwo)
                    {
                        if (childTwo.name == null) { continue; }

                        TrNode childsNodeTwo = new TrNode();
                        childsNodeTwo.Name = childTwo.Uid.ToString();
                        childsNodeTwo.Text = childTwo.name + $"   Type: ({childTwo.GetType().Name.Substring(14) })";

                        childNode.Nodes.Add(childsNodeTwo);
                    }
                }
            }
        }

        private void CustomizeSettingsFormFormClosing(object sender, FormClosingEventArgs e)
        {
            CloseForm?.Invoke(sender, e);
        }

        private void ButtonCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private List<Guid> GetUids()
        {
            List<Guid> list = new List<Guid>();
            foreach (TrNode parent in treeViewObj.Nodes)
            {
                foreach (TrNode child in parent.Nodes)
                {
                    foreach (TrNode childTwo in child.Nodes)
                    {
                        if (childTwo.Checked)
                        {
                            list.Add(Guid.Parse(childTwo.Name.Trim()));
                        }
                    }
                }
            }
            return list;
        }

        private void ButtonOKClick(object sender, EventArgs e)
        {
            var wwck = new WorkingWithCK11();
            var list = GetUids();

            //wwck.GetFilterObject<IdentifiedObject>(list, _measurementTypeVoltage);
        }
    }
}
