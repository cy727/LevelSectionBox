using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Autodesk;
using Autodesk.Revit;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.ApplicationServices;


namespace LevelSectionBox
{
    class ClassApplication : IExternalApplication
    {
        // class instance
        internal static ClassApplication thisApp = null;
        // ModelessForm instance
        private FormSectionBox m_FormSectionBox;
        private FormSectionBoxList m_FormSectionBoxList;

        public Result OnShutdown(UIControlledApplication application)
        {
            if (m_FormSectionBox != null && m_FormSectionBox.Visible)
            {
                m_FormSectionBox.Close();
            }

            if (m_FormSectionBoxList != null && m_FormSectionBoxList.Visible)
            {
                m_FormSectionBoxList.Close();
            }

            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            m_FormSectionBox = null;   // no dialog needed yet; the command will bring it
            m_FormSectionBoxList = null;
            thisApp = this;  // static access to this application instance

            return Result.Succeeded;
        }

        public void ShowForm(UIApplication uiapp)
        {
            // If we do not have a dialog yet, create and show it
            if (m_FormSectionBox == null || m_FormSectionBox.IsDisposed)
            {
                // A new handler to handle request posting by the dialog
                ClassRequestHandler handler = new ClassRequestHandler();

                // External Event for the dialog to use (to post requests)
                ExternalEvent exEvent = ExternalEvent.Create(handler);

                // We give the objects to the new dialog;
                // The dialog becomes the owner responsible fore disposing them, eventually.
                m_FormSectionBox = new FormSectionBox(uiapp, exEvent, handler);
                //m_FormSectionBox = new FormSectionBox(exEvent, handler);
                m_FormSectionBox.Show();
            }
        }

        public void ShowFormCopy(UIApplication uiapp)
        {
            // If we do not have a dialog yet, create and show it
            if (m_FormSectionBoxList == null || m_FormSectionBoxList.IsDisposed)
            {
                // A new handler to handle request posting by the dialog
                ClassRequestHandler handler = new ClassRequestHandler();

                // External Event for the dialog to use (to post requests)
                ExternalEvent exEvent = ExternalEvent.Create(handler);

                // We give the objects to the new dialog;
                // The dialog becomes the owner responsible fore disposing them, eventually.
                m_FormSectionBoxList = new FormSectionBoxList(uiapp, exEvent, handler);
                //m_FormSectionBox = new FormSectionBox(exEvent, handler);
                m_FormSectionBoxList.Show();
            }
        }

        public void WakeFormUp()
        {
            if (m_FormSectionBox != null)
            {
                m_FormSectionBox.WakeUp();
            }
        }
    }
}
