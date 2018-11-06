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
    public partial class FormSectionBoxList : System.Windows.Forms.Form
    {
        //ExternalCommandData m_commandData;
        public UIApplication m_UIApplication;
        public UIDocument m_activeDocument;

        private ClassRequestHandler m_Handler;
        private ExternalEvent m_ExEvent;

        public FormSectionBoxList(UIApplication uiapp, ExternalEvent exEvent, ClassRequestHandler handler)
        {
            m_UIApplication = uiapp;

            m_Handler = handler;
            m_ExEvent = exEvent;

            InitializeComponent();
        }

        private void FormSectionBoxList_Load(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void FormSectionBoxList_FormClosed(object sender, FormClosedEventArgs e)
        {
            // we own both the event and the handler
            // we should dispose it before we are closed
            //m_ExEvent.Dispose();
            //m_ExEvent = null;
            //m_Handler = null;

            //// do not forget to call the base class
            //base.OnFormClosed(e);
        }

        //private void EnableCommands(bool status)
        //{
        //    foreach (System.Windows.Forms.Control ctrl in this.Controls)
        //    {
        //        ctrl.Enabled = status;
        //    }
        //    if (!status)
        //    {
        //        this.btnCancel.Enabled = true;
        //    }
        //}

        //private void DozeOff()
        //{
        //    EnableCommands(false);
        //}

        //public void WakeUp()
        //{
        //    EnableCommands(true);
        //}

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RefreshForm()
        {
            if (m_UIApplication == null)
                return;

            ArrayList alDoc = new ArrayList();
            foreach (Document doc in m_UIApplication.Application.Documents)
            {
                cDoc cdoc = new cDoc(doc.Title,doc);
                alDoc.Add(cdoc);
            }
            comboBoxDoc.DisplayMember = "sDocName";
            comboBoxDoc.ValueMember = "dDoc";
            comboBoxDoc.DataSource = alDoc;
            //comboBoxDoc.DisplayMember
        }

        private void comboBoxDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridViewView.DataSource = null;
            Document doc = comboBoxDoc.SelectedValue as Document;
            ArrayList alView = new ArrayList();

            FilteredElementCollector collector;
            collector = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Views).OfClass(typeof(View3D));

            var Elems = from eleFilter in collector
                        where ((View3D)eleFilter).IsTemplate == false
                        orderby ((View3D)eleFilter).Name 
                        select eleFilter;

            foreach (Element ele in Elems) //得到楼层
            {
                View3D v3dView = ele as View3D;

                cView cview = new cView(v3dView.Name, v3dView,v3dView.GetSectionBox());
                alView.Add(cview);
            }

            dataGridViewView.DataSource = alView;
        }

        private void btnRef_Click(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
        }
    }

    class cDoc
    {
        public string sDocName { get; set; }
        public Document dDoc { get; set; }

        public cDoc(string sDocName, Document dDoc) //带参数的构造函数
        {
            this.sDocName = sDocName;
            this.dDoc = dDoc;
        }
    }

    class cView
    {

        public string sViewName { get; set; }
        public Autodesk.Revit.DB.View3D vView { get; set; }
        public Autodesk.Revit.DB.BoundingBoxXYZ bXYZ { get; set; }

        public cView(string sViewName, Autodesk.Revit.DB.View3D vView,BoundingBoxXYZ bXXY) //带参数的构造函数
        {
            this.sViewName = sViewName;
            this.vView = vView;
            this.bXYZ = bXYZ;
        }
    }
}
