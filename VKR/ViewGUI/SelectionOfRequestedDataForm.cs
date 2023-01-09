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
    public partial class SelectionOfRequestedDataForm : Form
    {
        internal event EventHandler CloseForm;

        /// <summary>
        /// Uid типа значения - "Напряжение"
        /// </summary>
        private readonly Guid _measurementTypeVoltage = Guid.Parse("10000bdf-0000-0000-c000-0000006d746c");

        /// <summary>
        /// Uid типа значения - "Переток активной мощности"
        /// </summary>
        private readonly Guid _measurementTypeActivePower = Guid.Parse("10000849-0000-0000-C000-0000006D746C");

        /// <summary>
        /// Uid типа значения - "Переток реактивной мощности"
        /// </summary>
        private readonly Guid _measurementTypeReactivePower = Guid.Parse("10000B3B-0000-0000-C000-0000006D746C");
        
        /// <summary>
        /// Модель СК-11
        /// </summary>
        private readonly ModelImage _modelImage;

        /// <summary>
        /// Uid контролируемого объекта энергетики
        /// </summary>
        private readonly Guid _observableObjectUid;

        /// <summary>
        /// Строка подключения к СК-11, для запроса данных
        /// </summary>
        private const string _connectionStringToRtdb = "10.221.3.29:900";

        /// <summary>
        /// Список междуфазных напряжений
        /// </summary>
        private List<Guid> _listVoltageUid = new List<Guid>(3);

        /// <summary>
        /// Uid активной мощности контролируемого объекта энергетики
        /// </summary>
        private Guid[] _activePowerUid = new Guid[1];

        /// <summary>
        /// Uid реактивной мощности контролируемого объекта энергетики
        /// </summary>
        private Guid[] _reactivePowerUid = new Guid[1];

        private List<string> _listCheckObj;

        public List<string> ListCheckObj => _listCheckObj;

        public Guid[] GetActivePowerUid => _activePowerUid;

        public Guid[] GetReactivePowerUid => _reactivePowerUid;

        public SelectionOfRequestedDataForm(
            List<Guid> listVoltageUid, ModelImage modelImage, Guid observableObjectUid, List<string> listCheckObj)
        {
            InitializeComponent();
            _listVoltageUid = listVoltageUid;
            _modelImage = modelImage;
            _observableObjectUid = observableObjectUid;
            _listCheckObj = listCheckObj;
        }

        public SelectionOfRequestedDataForm() 
        {
            InitializeComponent();
        }

        private void CustomizeSettingsFormLoad(object sender, EventArgs e)
        {
            treeViewObj.CheckBoxes = true;

            GetElemnt<BusbarSection>();
            GetElemnt<PowerTransformer>();

            SetCheckNode();
        }

        private void GetElemnt<T>() where T : class, IdentifiedObject
        {
            var wwck = new WorkingWithCK11();

            var objects = wwck.GetSpecificObject<T>(_modelImage, _observableObjectUid);
            foreach (var parent in objects)
            {
                if (parent.name == null) { continue; }

                TrNode rootNode = new TrNode
                {
                    Name = parent.Uid.ToString(),
                    Text = parent.name + $"   Type: ({parent.GetType().Name.Substring(14)})"
                };

                treeViewObj.Nodes.Add(rootNode);
                var arrayChild = wwck.GetChildObject(parent);

                foreach (var child in arrayChild)
                {
                    if (child.name == null) { continue; }

                    TrNode childNode = new TrNode
                    {
                        Name = child.Uid.ToString(),
                        Text = child.name + $"   Type: ({child.GetType().Name.Substring(14)})"
                    };

                    rootNode.Nodes.Add(childNode);

                    var arrayChildTwo = wwck.GetChildObject(child);

                    foreach (var childTwo in arrayChildTwo)
                    {
                        if (childTwo.name == null) { continue; }

                        TrNode childsNodeTwo = new TrNode
                        {
                            Name = childTwo.ParentObject.Uid.ToString(),
                            Text = childTwo.name + $"   Type: ({childTwo.GetType().Name.Substring(14)})"
                        };

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
            _listCheckObj.Clear();
            var wwck = new WorkingWithCK11();
            var list = GetUids();

            var obj = wwck.GetObjectByUid<Analog>(_modelImage, list);

            _listVoltageUid.Clear();
            var voltage = wwck.GetFilterObject(obj, _measurementTypeVoltage);
            var voltageEnumPhase = wwck.GetFilterVoltage(voltage);
            var childVoltage = wwck.GetChildObject(voltageEnumPhase);
            if (childVoltage.Count() != 3) 
            {
                MessageBox.Show("Неверно выбраны значения междуфазных напряжений",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }
            foreach (var item in childVoltage)
            {
                _listVoltageUid.Add(item.Uid);
            }

            var activePower = wwck.GetFilterObject(obj, _measurementTypeActivePower);
            var childActivePower = wwck.GetChildObject(activePower);
            if (childActivePower.Count() != 1)
            {
                MessageBox.Show("Неверно выбрано значение активной мощности",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach (var item in childActivePower)
            {
                _activePowerUid[0] = item.Uid;
            }

            //var reactivePower = wwck.GetFilterObject(obj, _measurementTypeReactivePower);
            //var childReactivePower = wwck.GetChildObject(reactivePower);
            //if (childReactivePower.Count() != 1)
            //{
            //    MessageBox.Show("Неверно выбрано значение реактивной мощности",
            //                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //foreach (var item in childReactivePower)
            //{
            //    _reactivePowerUid[0] = item.Uid;
            //}
            _listCheckObj = SaveCheckNode();
            this.Close();
        }

        public List<string> SaveCheckNode()
        {
            List<string> list = new List<string>();
            foreach (TrNode parent in treeViewObj.Nodes)
            {
                foreach (TrNode child in parent.Nodes)
                {
                    foreach (TrNode childTwo in child.Nodes)
                    {
                        if (childTwo.Checked)
                        {
                            list.Add(childTwo.Text.Trim());
                        }
                    }
                }
            }
            return list;
        }

        private void SetCheckNode()
        {
            if (_listCheckObj.Count == 0) { return; }

            foreach (TrNode parent in treeViewObj.Nodes)
            {
                foreach (TrNode child in parent.Nodes)
                {
                    foreach (TrNode childTwo in child.Nodes)
                    {
                        if (_listCheckObj.Contains(childTwo.Text))
                        {
                            treeViewObj.SelectedNode = childTwo;
                            childTwo.Checked = true;
                        }
                    }
                }
            }
        }
    }
}
