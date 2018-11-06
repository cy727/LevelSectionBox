using System;
using System.Collections.Generic;

using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace LevelSectionBox
{
    public class ClassRequestHandler : IExternalEventHandler
    {
        private ClassRequest m_request = new ClassRequest();

        public ClassRequest Request
        {
            get { return m_request; }
        }

        private BoundingBoxXYZ changeSectionBox(BoundingBoxXYZ SectionBoxIn, double dCeil,double dFloor)
        {
            XYZ XYZmin=SectionBoxIn.Transform.OfPoint(SectionBoxIn.Min);
            XYZ XYZmax=SectionBoxIn.Transform.OfPoint(SectionBoxIn.Max);

            XYZ XYZMinNew = SectionBoxIn.Transform.Inverse.OfPoint(new XYZ(XYZmin.X, XYZmin.Y, UnitUtils.ConvertToInternalUnits(dFloor, DisplayUnitType.DUT_METERS)));
            XYZ XYZMaxNew = SectionBoxIn.Transform.Inverse.OfPoint(new XYZ(XYZmax.X, XYZmax.Y, UnitUtils.ConvertToInternalUnits(dCeil, DisplayUnitType.DUT_METERS)));

            SectionBoxIn.Max = XYZMaxNew;
            SectionBoxIn.Min = XYZMinNew;

            return SectionBoxIn;

        }

        public void Execute(UIApplication uiapp)
        {
            bool bFirst = true;
            double xTempMax=0, yTempMax=0, zTempMax=0;
            double xTempMin=0, yTempMin=0, zTempMin=0;

            try
            {
                cSectionbox cS=Request.Take();
                //必须为3d View
                if (uiapp.ActiveUIDocument.Document.ActiveView.ViewType != ViewType.ThreeD)
                {
                    TaskDialog.Show("提示", "只对3维视图有效", TaskDialogCommonButtons.Close);
                    return;
                }
                View3D view3dActive = (View3D)uiapp.ActiveUIDocument.Document.ActiveView;
                BoundingBoxXYZ sectionBox = view3dActive.GetSectionBox();
                XYZ xyzT;

                if (cS.bSelect) //选择集决定
                {
                    //ICollection<ElementId> selElements = uiapp.ActiveUIDocument.Selection.GetElementIds();

                    //if (uiapp.ActiveUIDocument.Selection.Elements.Size > 0)
                    if (uiapp.ActiveUIDocument.Selection.GetElementIds().Count > 0)
                    {
                       
                        bFirst = true;
                        foreach (ElementId eId in uiapp.ActiveUIDocument.Selection.GetElementIds())
                        {
                            Element el = uiapp.ActiveUIDocument.Document.GetElement(eId);
                            BoundingBoxXYZ bXYZ = el.get_BoundingBox(uiapp.ActiveUIDocument.ActiveView);


                            if (bXYZ == null)
                                continue;

                            if (bFirst) //第一次
                            {
                                xTempMax=bXYZ.Max.X;yTempMax=bXYZ.Max.Y;zTempMax=bXYZ.Max.Z;
                                xTempMin=bXYZ.Min.X;yTempMin=bXYZ.Min.Y;zTempMin=bXYZ.Min.Z;

                                bFirst = false;
                            }
                            else
                            {
                                xTempMax=Math.Max(xTempMax,bXYZ.Max.X);
                                yTempMax=Math.Max(yTempMax,bXYZ.Max.Y);
                                zTempMax=Math.Max(zTempMax,bXYZ.Max.Z);

                                xTempMin=Math.Min(xTempMin,bXYZ.Min.X);
                                yTempMin=Math.Min(yTempMin,bXYZ.Min.Y);
                                zTempMin=Math.Min(zTempMin,bXYZ.Min.Z);

                                //TaskDialog.Show("提示", "xTemp=" + xTemp.ToString() + " yTemp=" + yTemp.ToString() + " zTemp" + zTemp.ToString(), TaskDialogCommonButtons.Close);


                            }
                            

                        }
                        if(!bFirst)
                        {

                            if (cS.bZ)
                            {
                                XYZ XYZMaxNew = sectionBox.Transform.Inverse.OfPoint(new XYZ(xTempMax + UnitUtils.ConvertToInternalUnits(cS.dWY, DisplayUnitType.DUT_MILLIMETERS), yTempMax + UnitUtils.ConvertToInternalUnits(cS.dWY, DisplayUnitType.DUT_MILLIMETERS), zTempMax + UnitUtils.ConvertToInternalUnits(cS.dWY, DisplayUnitType.DUT_MILLIMETERS)));
                                XYZ XYZMinNew = sectionBox.Transform.Inverse.OfPoint(new XYZ(xTempMin - UnitUtils.ConvertToInternalUnits(cS.dWY, DisplayUnitType.DUT_MILLIMETERS), yTempMin - UnitUtils.ConvertToInternalUnits(cS.dWY, DisplayUnitType.DUT_MILLIMETERS), zTempMin - UnitUtils.ConvertToInternalUnits(cS.dWY, DisplayUnitType.DUT_MILLIMETERS)));

                                sectionBox.Max = XYZMaxNew;
                                sectionBox.Min = XYZMinNew;
                            }
                            else
                            {
                                XYZ XYZMaxNew = sectionBox.Transform.Inverse.OfPoint(new XYZ(xTempMax + UnitUtils.ConvertToInternalUnits(cS.dWY, DisplayUnitType.DUT_MILLIMETERS), yTempMax + UnitUtils.ConvertToInternalUnits(cS.dWY, DisplayUnitType.DUT_MILLIMETERS), zTempMax));
                                XYZ XYZMinNew = sectionBox.Transform.Inverse.OfPoint(new XYZ(xTempMin - UnitUtils.ConvertToInternalUnits(cS.dWY, DisplayUnitType.DUT_MILLIMETERS), yTempMin - UnitUtils.ConvertToInternalUnits(cS.dWY, DisplayUnitType.DUT_MILLIMETERS), zTempMin));

                                sectionBox.Max = XYZMaxNew;
                                sectionBox.Min = XYZMinNew;
                            }

                            //sectionBox
                        }
                    }
                    else
                    {
                        TaskDialog.Show("提示", "请进行选择", TaskDialogCommonButtons.Close);
                        return;
                    }
                }
                else
                {
                    sectionBox = changeSectionBox(sectionBox, cS.dCeil, cS.dFloor);
                    bFirst = false;
                }

                //TaskDialog.Show(cS.dCeil.ToString(), cS.dFloor.ToString());
                if (!bFirst)
                {
                    using (Transaction trans = new Transaction(uiapp.ActiveUIDocument.Document))
                    {
                        // The name of the transaction was given as an argument
                        if (trans.Start("sectionBox Level") == TransactionStatus.Started)
                        {

                            // apply the requested operation to every door
                            view3dActive.SetSectionBox(sectionBox);

                            trans.Commit();
                        }
                    }
                }










                //TaskDialog.Show("提示", "sectionBox.Max.z" + sectionBox.Max.Z.ToString()+" sectionBox.Min.z" + sectionBox.Min.Z.ToString(), TaskDialogCommonButtons.Close);
                
                //Transaction trans = new Transaction(uiapp.ActiveUIDocument.Document, "sectionBox Level");
                //view3dActive.SetSectionBox(sectionBox);
                //view3dActive.SectionBox = sectionBox;

                //287091

            }
            finally
            {
                ClassApplication.thisApp.WakeFormUp();
            }

            return;
        }

        public String GetName()
        {
            return "SectionBOX Control by chenyi";
        }

    }
}
