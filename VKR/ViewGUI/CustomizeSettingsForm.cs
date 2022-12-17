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
        private readonly List<double> _listVoltage = new List<double>(3);

        /// <summary>
        /// Активная мощность ОЭ
        /// </summary>
        private float _activePower;

        public float GetActivePower => _activePower;

        /// <summary>
        /// Реактивная мощность ОЭ
        /// </summary>
        private float _reactivePower;

        public float GetReactivePower => _reactivePower;

        public CustomizeSettingsForm(List<double> listVoltage, ModelImage modelImage, Guid observableObjectUid)
        {
            InitializeComponent();
            _listVoltage = listVoltage;
            _modelImage = modelImage;
            _observableObjectUid = observableObjectUid;
        }

        public CustomizeSettingsForm() 
        {
            InitializeComponent();
        }

        private void CustomizeSettingsFormLoad(object sender, EventArgs e)
        {
            treeViewObj.CheckBoxes = true;

            GetElemnt<BusbarSection>();
            GetElemnt<PowerTransformer>();
        }

        private void GetElemnt<T>() where T : class, IdentifiedObject
        {
            var ConnectCK11 = new WorkingWithCK11();

            var objects = ConnectCK11.GetSpecificObject<T>(_modelImage, _observableObjectUid);
            foreach (var parent in objects)
            {
                if (parent.name == null) { continue; }

                TrNode rootNode = new TrNode
                {
                    Name = parent.Uid.ToString(),
                    Text = parent.name + $"   Type: ({parent.GetType().Name.Substring(14)})"
                };

                treeViewObj.Nodes.Add(rootNode);
                var arrayChild = ConnectCK11.GetChildObject(parent);

                foreach (var child in arrayChild)
                {
                    if (child.name == null) { continue; }

                    TrNode childNode = new TrNode
                    {
                        Name = child.Uid.ToString(),
                        Text = child.name + $"   Type: ({child.GetType().Name.Substring(14)})"
                    };

                    rootNode.Nodes.Add(childNode);

                    var arrayChildTwo = ConnectCK11.GetChildObject(child);

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
            var wwck = new WorkingWithCK11();
            var list = GetUids();

            var obj = wwck.GetObjectByUid<Analog>(_modelImage, list);

            var voltage = wwck.GetFilterObject(obj, _measurementTypeVoltage);
            var voltageEnumPhase = wwck.GetFilterVoltage(voltage);
            var childVoltage = wwck.GetChildObject(voltageEnumPhase);

            var activePower = wwck.GetFilterObject(obj, _measurementTypeActivePower);
            var childActivePower = wwck.GetChildObject(activePower);

            var reactivePower = wwck.GetFilterObject(obj, _measurementTypeReactivePower);
            var childReactivePower = wwck.GetChildObject(reactivePower);

            Guid[] uids = wwck.GetUids(childVoltage);

            var dataRequest = new WorkingWithCK11(_connectionStringToRtdb);
            try
            {
                var dataVoltage = dataRequest.GetSignals(uids);
                foreach (var item in dataVoltage)
                {
                    _listVoltage.Add(item.Value.AnalogValue);
                }
            }
            catch
            {
                throw new ArgumentException("Неверно выбраны значения междуфазных напряжений");
            }

            Guid[] uidsActive = wwck.GetUids(childActivePower);
            try
            {
                var dataActive = dataRequest.GetSignals(uidsActive);
                foreach (var item in dataActive)
                {
                    _activePower = (float)item.Value.AnalogValue;
                }
            }
            catch
            {
                throw new ArgumentException("Неверно выбрано значение активной мощности");
            }

            Guid[] uidsReactive = wwck.GetUids(childReactivePower);
            try
            {
                var dataReactive = dataRequest.GetSignals(uidsReactive);
                foreach (var item in dataReactive)
                {
                    _reactivePower = (float)item.Value.AnalogValue;
                }
            }
            catch
            {
                throw new ArgumentException("Неверно выбрано значение реактивной мощности");
            }
        }
    }
}
