using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Xml;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;

using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.DB.Structure;

using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Plumbing;



namespace LevelSectionBox
{
    public static class CommRevit
    {
        //精度控制
        public const double EP = 1e-3;

        //单位换算
        public const double INCH = 304.8;
        public const double INCH2 = 0.09290304;
        public const double INCH3 = 0.0283168;

        //public string[] sStructuralMaterialType = { "未定义", "钢", "混凝土", "木材", "其他", "预制混凝土", "未注册", "铝材" };

        public static double changeINCHtoMM(double dINCH) //转换英尺到毫米
        {
            return dINCH * INCH;
        }

        public static double changeMMtoINCH(double dMM) //转换英尺到毫米
        {
            return dMM / INCH;
        }

        public static double changeINCHtoM2(double dMM2) //转换平方英尺到平方米
        {
            return dMM2 * INCH2;
        }

        public static double changeINCHtoM3(double dMM3) //转换立方英尺到立方米
        {
            return dMM3 * INCH3;
        }

        public static string changeToDatabaseString(Parameter parString) //转换数据库格式
        {
            if (parString == null)
                return "NULL";
            else
                return "N'" + parString.AsString() + "'";
        }

        public static string changeToDatabaseDouble(Parameter parDouble) //转换数据库格式
        {
            if (parDouble == null)
                return "NULL";
            else
                return parDouble.AsDouble().ToString();
        }

        public static string changeToDatabaseDouble1(Parameter parDouble) //转换数据库格式 毫米
        {
            if (parDouble == null)
                return "NULL";
            else
                return changeINCHtoMM(parDouble.AsDouble()).ToString();
        }

        public static string changeToDatabaseDouble2(Parameter parDouble) //转换数据库格式 平方米
        {
            if (parDouble == null)
                return "NULL";
            else
                return changeINCHtoM2(parDouble.AsDouble()).ToString();
        }

        public static string changeToDatabaseDouble3(Parameter parDouble) //转换数据库格式 立方米
        {
            if (parDouble == null)
                return "NULL";
            else
                return changeINCHtoM3(parDouble.AsDouble()).ToString();
        }

        public static string changeToDatabaseDoubleMM3(Parameter parDouble) //转换数据库格式 立方毫米
        {
            if (parDouble == null)
                return "NULL";
            else
                return changeINCHtoM3(parDouble.AsDouble() * 1000000000).ToString();
        }

        public static string changeToDatabaseInt(Parameter parInt) //转换数据库格式
        {
            if (parInt == null)
                return "NULL";
            else
                return parInt.AsInteger().ToString();
        }

        public static Element FindFamilyType(Document docRevit, Type typeRevit, string sFamilyName, string sTypeName)
        {
            Element eleFamily = null;

            FilteredElementCollector TypeCollector = new FilteredElementCollector(docRevit);
            TypeCollector.OfClass(typeRevit);

            var TypeElems = from eleFilter in TypeCollector
                            where eleFilter.Name == sTypeName && eleFilter.get_Parameter(BuiltInParameter.SYMBOL_FAMILY_NAME_PARAM).AsString() == sFamilyName
                            select eleFilter;

            /*
            var TypeElems = from eleFilter in TypeCollector
                            where eleFilter.Name == sTypeName 
                            select eleFilter;
            */
            IList<Element> TList = TypeElems.ToList();

            if (TList.Count > 0)
            {
                eleFamily = TList[0];
            }
            return eleFamily;
        }

        //public IList<Element> FindElement(Document docRevit, Type typeRevit, BuiltInCategory bicRevit, string sEleName)
        public static IList<Element> FindElement(Document docRevit, Type typeRevit, string sEleName)
        {

            FilteredElementCollector EleCollector = new FilteredElementCollector(docRevit);
            EleCollector.OfClass(typeRevit);
            //EleCollector.OfClass(typeof(FamilyInstance)).OfCategory(bicRevit);

            var TypeElems = from eleFilter in EleCollector
                            //where eleFilter.get_Parameter(BuiltInParameter.SYMBOL_ID_PARAM).AsString() == sEleName
                            where eleFilter.Name == sEleName
                            select eleFilter;

            IList<Element> EList = TypeElems.ToList();
            return EList;
        }

        //取得两条线段的交点，直线延长线上的相交不算。
        public static XYZ IntersectionPoint(Line line1, Line line2)
        {
            IntersectionResultArray intersectionR = new IntersectionResultArray();
            SetComparisonResult comparisonR;
            comparisonR = line1.Intersect(line2, out intersectionR);
            XYZ intersectionResult = null;
            if (SetComparisonResult.Disjoint != comparisonR)//Disjoint不交
            {
                if (!intersectionR.IsEmpty)//两条直线如果重复为一条直线，这里也为空
                {
                    intersectionResult = intersectionR.get_Item(0).XYZPoint;
                }
            }
            return intersectionResult;
        }

        //中点
        public static XYZ BoundingBoxPOINT(FamilyInstance fi, Autodesk.Revit.DB.View view)
        {
            if (fi.get_BoundingBox(view) == null)
                return null;

            XYZ xyzpositionPoint = new XYZ(fi.get_BoundingBox(view).Min.X + (fi.get_BoundingBox(view).Max.X - fi.get_BoundingBox(view).Min.X) / 2.0, fi.get_BoundingBox(view).Min.Y + (fi.get_BoundingBox(view).Max.Y - fi.get_BoundingBox(view).Min.Y) / 2.0, fi.get_BoundingBox(view).Min.Z + (fi.get_BoundingBox(view).Max.Z - fi.get_BoundingBox(view).Min.Z) / 2.0);

            return xyzpositionPoint;

        }

    }
    
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    public class ClassSesectionBox : IExternalCommand
    {
        
        UIApplication uiApp;
        Autodesk.Revit.ApplicationServices.Application app;
        Document doc;
        UIDocument uiDoc;
       
        public Autodesk.Revit.UI.Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {

            //FormSectionBox fs = new FormSectionBox(commandData);

            //fs.ShowDialog();

            //uiApp = commandData.Application;
            //app = uiApp.Application;
            //doc = uiApp.ActiveUIDocument.Document;

            //View3D d3d = (View3D)doc.ActiveView;

            //BoundingBoxXYZ sectionBox = d3d.SectionBox;
            //// Expand the section box
            //sectionBox.Max = new XYZ(sectionBox.Max.X, sectionBox.Max.Y, CommRevit.changeMMtoINCH(double.Parse(fs.labelCeil.Text) * 1000.0));
            //sectionBox.Min = new XYZ(sectionBox.Min.X, sectionBox.Min.Y, CommRevit.changeMMtoINCH(double.Parse(fs.labelFloor.Text) * 1000.0));

            //Transaction transPZ = new Transaction(doc, "sectionBox Level");
            //transPZ.Start();
            //d3d.SectionBox = sectionBox;
            //doc.Regenerate();
            //transPZ.Commit();

            try
            {
                ClassApplication.thisApp.ShowForm(commandData.Application);

                return Result.Succeeded;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return Result.Failed;
            }

            //return Autodesk.Revit.UI.Result.Succeeded;
        }
    }

    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    public class ClassSesectionBoxCopy : IExternalCommand
    {

        UIApplication uiApp;
        Autodesk.Revit.ApplicationServices.Application app;
        Document doc;
        UIDocument uiDoc;

        public Autodesk.Revit.UI.Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            uiApp = commandData.Application;

            FormSectionBoxList fs = new FormSectionBoxList(commandData.Application,null,null);

            if (fs.ShowDialog() == DialogResult.OK)
            {
                if (uiApp.ActiveUIDocument.Document.ActiveView.ViewType != ViewType.ThreeD)
                {
                    TaskDialog.Show("提示", "只对3维视图有效", TaskDialogCommonButtons.Close);
                    return Autodesk.Revit.UI.Result.Succeeded; 
                }
                View3D view3dActive = (View3D)uiApp.ActiveUIDocument.Document.ActiveView;
                BoundingBoxXYZ sectionBox = view3dActive.GetSectionBox();

                using (Transaction trans = new Transaction(uiApp.ActiveUIDocument.Document))
                {
                    // The name of the transaction was given as an argument
                    if (trans.Start("sectionBox Copy") == TransactionStatus.Started)
                    {

                        // apply the requested operation to every door
                        //view3dActive.SetSectionBox();

                        trans.Commit();
                    }
                }


            }
            return Autodesk.Revit.UI.Result.Succeeded;



            //try
            //{
            //    ClassApplication.thisApp.ShowFormCopy(commandData.Application);

            //    return Result.Succeeded;
            //}
            //catch (Exception ex)
            //{
            //    message = ex.Message;
            //    return Result.Failed;
            //}

            
        }
    }
}
