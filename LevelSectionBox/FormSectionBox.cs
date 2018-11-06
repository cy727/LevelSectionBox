//this is github codes
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Autodesk.Revit;
using System.Collections;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB.Structure;
using System.Threading;

namespace LevelSectionBox
{
    public partial class FormSectionBox : System.Windows.Forms.Form
    {

        //ExternalCommandData m_commandData;
        public UIApplication m_UIApplication;
        public UIDocument m_activeDocument;

        private ClassRequestHandler m_Handler;
        private ExternalEvent m_ExEvent;

        public FormSectionBox(UIApplication uiapp, ExternalEvent exEvent, ClassRequestHandler handler)
        {
            m_UIApplication = uiapp;

            m_Handler = handler;
            m_ExEvent = exEvent;

            InitializeComponent();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // we own both the event and the handler
            // we should dispose it before we are closed
            m_ExEvent.Dispose();
            m_ExEvent = null;
            m_Handler = null;

            // do not forget to call the base class
            base.OnFormClosed(e);
        }

        private void EnableCommands(bool status)
        {
            foreach (System.Windows.Forms.Control ctrl in this.Controls)
            {
                ctrl.Enabled = status;
            }
            if (!status)
            {
                this.btnCancel.Enabled = true;
            }
        }

        //private void MakeRequest()
        //{
        //    m_ExEvent.Raise();
        //    DozeOff();
        //}

        private void DozeOff()
        {
            EnableCommands(false);
        }

        public void WakeUp()
        {
            EnableCommands(true);
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSection_Click(object sender, EventArgs e)
        {
            m_Handler.Request.Make(new cSectionbox(double.Parse(labelCeil.Text), double.Parse(labelFloor.Text), checkBoxSelect.Checked, (double)numericUpDownWY.Value, checkBoxZ.Checked));
            m_ExEvent.Raise();
            DozeOff();
        }

        private void FormSectionBox_Load(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void RefreshForm()
        {
            if (m_UIApplication == null)
                return;

            comboBoxLevelA.Items.Clear();
            ArrayList alLevel = new ArrayList();
            ArrayList alFloor = new ArrayList();
            ArrayList alCeil = new ArrayList();

            FilteredElementCollector collector;
            collector = new FilteredElementCollector(m_UIApplication.ActiveUIDocument.Document).OfCategory(BuiltInCategory.OST_Levels).OfClass(typeof(Level));

            var Elems = from eleFilter in collector
                        orderby ((Level)eleFilter).Elevation 
                        select eleFilter;

            foreach (Element ele in Elems) //得到楼层
            {
                Level l=ele as Level;
                //cLevel cl = new cLevel(l.Name, CommRevit.changeINCHtoMM(l.Elevation)/1000);
                cLevel cl = new cLevel(l.Name, UnitUtils.ConvertFromInternalUnits(l.Elevation,DisplayUnitType.DUT_METERS));
                alLevel.Add(cl);
                alCeil.Add(cl);
                alFloor.Add(cl);
                
            }

            comboBoxLevelA.DisplayMember = "sLevelName";
            comboBoxLevelA.ValueMember = "dElevation";
            comboBoxLevelA.DataSource = alLevel;

            comboBoxCeil.DisplayMember = "sLevelName";
            comboBoxCeil.ValueMember = "dElevation";
            comboBoxCeil.DataSource = alFloor;
            if (comboBoxCeil.Items.Count > 1)
                comboBoxCeil.SelectedIndex = 1;

            comboBoxFloor.DisplayMember = "sLevelName";
            comboBoxFloor.ValueMember = "dElevation";
            comboBoxFloor.DataSource = alCeil;
            if (comboBoxFloor.Items.Count > 0)
                comboBoxFloor.SelectedIndex = 0;

        }

        private void comboBoxCeil_SelectedIndexChanged(object sender, EventArgs e)
        {
            numericUpDownCeil.Value = decimal.Parse((comboBoxCeil.SelectedItem as cLevel).dElevation.ToString("f3"));
            //CountAmount();
        }
        private void comboBoxFloor_SelectedIndexChanged(object sender, EventArgs e)
        {
            numericUpDownFloor.Value = decimal.Parse((comboBoxFloor.SelectedItem as cLevel).dElevation.ToString("f3"));
            //CountAmount();
        }
        private void CountAmount()
        {
            labelCeil.Text = (numericUpDownCeil.Value + numericUpDownC.Value).ToString("f3");
            labelFloor.Text = (numericUpDownFloor.Value + numericUpDownF.Value).ToString("f3");
        }

        private void numericUpDownCeil_ValueChanged(object sender, EventArgs e)
        {
            CountAmount();
        }

        private void numericUpDownFloor_ValueChanged(object sender, EventArgs e)
        {
            CountAmount();
        }

        private void numericUpDownC_ValueChanged(object sender, EventArgs e)
        {
            CountAmount();
        }

        private void numericUpDownF_ValueChanged(object sender, EventArgs e)
        {
            CountAmount();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void comboBoxLevelA_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach(object obj in comboBoxFloor.Items)
            {
                cLevel cl=obj as cLevel;
                if (cl.dElevation == ((cLevel)comboBoxLevelA.SelectedItem).dElevation)
                {
                    comboBoxFloor.Text = cl.sLevelName;
                    break;
                }
            }

            //上一个
            if (comboBoxLevelA.SelectedIndex == comboBoxLevelA.Items.Count - 1) //到顶层
            {
                comboBoxCeil.Text = comboBoxLevelA.Text;
                return;
            }
            string sss = ((cLevel)comboBoxLevelA.Items[comboBoxLevelA.SelectedIndex + 1]).sLevelName;
            comboBoxCeil.Text = ((cLevel)comboBoxLevelA.Items[comboBoxLevelA.SelectedIndex + 1]).sLevelName;

            
            //foreach (object obj in comboBoxCeil.Items)
            //{
            //    cLevel cl = obj as cLevel;
            //    if (cl.dElevation == ((cLevel)comboBoxLevelA.SelectedItem).dElevation)
            //    {
            //        comboBoxFloor.Text = cl.sLevelName;
            //        break;
            //    }
            //}
        }
    }

    class cLevel
    {

        public string sLevelName{ get; set; }
        public double dElevation{ get; set; }


        public cLevel(string sLevelName, double dElevation) //带参数的构造函数
        {
            this.sLevelName = sLevelName;
            this.dElevation = dElevation;
        }
    }

    
}
