using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

namespace luan_van1
{
    public class PartModel
    {
        public double d { get; set; }
        public double df { get; set; }
        public double da { get; set; }
        public double a { get; set; }
        public double at { get; set; }
        public double atw { get; set; }
        public double db { get; set; }
        public double ha { get; set; }
        public double hf { get; set; }
        public double h { get; set; }
        public double st { get; set; }
        public double ut { get; set; }
        public double b { get; set; }
        public double dtruc { get; set; }
        public double bthen { get; set; }
        public double hthen { get; set; }
        public double ab { get; set; }
        public double xt { get; set; }
        public double yt { get; set; }
        public int m { get; set; }

        public double dkhoet_a { get; set; }
        public double dkhoet_f { get; set; }
        public double hkhoet { get; set; }
        public double dlo { get; set; }
        public int zlo { get; set; }
        SldWorks swApp;
        ModelDoc2 swModel;
        Feature swFeature;
        bool status;
        string defaultPartTemplate;

        FeatureManager swFeatureMgr;
        SketchManager swSketchMgr;
        SelectionMgr swSelectionMgr;
        object vSkLines;
        double deg_to_rad(double a)
        {
            return a * Math.PI / 180;
        }
        void loop_COINCIDENT(string a)
        {
            swModel.ClearSelection2(true);
            status = swModel.Extension.SelectByID2("Point" + a, "SKETCHPOINT", 0, 0, 0, true, 0, null, (int)swSelectOption_e.swSelectOptionDefault);
            status = swModel.Extension.SelectByID2("Arc1", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, (int)swSelectOption_e.swSelectOptionDefault);
            swModel.SketchAddConstraints("sgCOINCIDENT");
        }
        public void CreatePart()
        {

            #region

            df = 651 / 10;
            da = 677 / 10;
            st = 10 / 10;
            hf = ((da - df) / 2) * 0.25;
            ha = ((da - df) / 2) * 0.75;
            b = 20;
            m = 110;
            at = 20;
            atw = 22;
            dtruc = 110 / 10;
            hthen = 25 / 10;
            bthen = 28 / 10;

            dkhoet_a = 60;
            dkhoet_f = 18;
            hkhoet = 8;
            dlo = dtruc;
            zlo = 6;

            swApp = GetSolidworks.GetApplication();
            defaultPartTemplate = swApp.GetUserPreferenceStringValue((int)swUserPreferenceStringValue_e.swDefaultTemplatePart);

            swApp.NewDocument(defaultPartTemplate, 0, 0, 0);
            swModel = (ModelDoc2)swApp.ActiveDoc;
            swFeature = swModel.FeatureByPositionReverse(2); // top plane

            status = swModel.Extension.SelectByID2("RefPlane", "PLANE", 0, 0, 0, false, 0, null, 0);
            swModel.InsertSketch2(true);
            swModel.ClearSelection2(true);



            swModel.CreateCircleByRadius2(0, 0, 0, df / 2);
            #region
            swModel.CreateCenterLineVB(0, 0, 0, 0, da / 2, 0);
            swModel.CreateLine2(st / 2, (df / 2) - (Math.Tan(Math.Asin(st / (2 * df))) * st / 2), 0, (st / 2) - hf * Math.Tan(deg_to_rad(20)), hf + df / 2, 0);


            swModel.ClearSelection2(true);
            status = swModel.Extension.SelectByID2("Point5", "SKETCHPOINT", 0, 0, 0, false, 0, null, (int)swSelectOption_e.swSelectOptionDefault);
            status = swModel.Extension.SelectByID2("Arc1", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, (int)swSelectOption_e.swSelectOptionDefault);
            swModel.SketchAddConstraints("sgCOINCIDENT");


            swModel.CreateLine2((st / 2) - hf * Math.Tan(deg_to_rad(at)), hf + df / 2, 0, (st / 2) - hf * Math.Tan(deg_to_rad(at)) - ha * Math.Tan(deg_to_rad(atw)), da / 2, 0);
            swModel.CreateLine2((st / 2) - hf * Math.Tan(deg_to_rad(at)) - ha * Math.Tan(deg_to_rad(atw)), da / 2, 0, 0, da / 2, 0);

            swModel.ClearSelection2(true);
            status = swModel.Extension.SelectByID2("Point6", "SKETCHPOINT", 0, 0, 0, true, 0, null, (int)swSelectOption_e.swSelectOptionDefault);
            status = swModel.Extension.SelectByID2("Point7", "SKETCHPOINT", 0, 0, 0, true, 0, null, (int)swSelectOption_e.swSelectOptionDefault);
            swModel.SketchAddConstraints("sgMERGEPOINTS");

            swModel.ClearSelection2(true);
            status = swModel.Extension.SelectByID2("Line1", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, (int)swSelectOption_e.swSelectOptionDefault);
            status = swModel.Extension.SelectByID2("Line2", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, (int)swSelectOption_e.swSelectOptionDefault);
            status = swModel.Extension.SelectByID2("Line3", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, (int)swSelectOption_e.swSelectOptionDefault);
            status = swModel.Extension.SelectByID2("Line4", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, (int)swSelectOption_e.swSelectOptionDefault);
            swModel.SketchMirror();
            #endregion
            swModel.ClearSelection2(true);
            status = swModel.Extension.SelectByID2("Point2", "SKETCHPOINT", 0, 0, 0, true, 0, null, (int)swSelectOption_e.swSelectOptionDefault);
            status = swModel.Extension.SelectByID2("Line2", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, (int)swSelectOption_e.swSelectOptionDefault);
            status = swModel.Extension.SelectByID2("Line3", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, (int)swSelectOption_e.swSelectOptionDefault);
            status = swModel.Extension.SelectByID2("Line4", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, (int)swSelectOption_e.swSelectOptionDefault);
            status = swModel.Extension.SelectByID2("Line6", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, (int)swSelectOption_e.swSelectOptionDefault);
            status = swModel.Extension.SelectByID2("Line7", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, (int)swSelectOption_e.swSelectOptionDefault);

            status = swModel.SketchManager.CreateCircularSketchStepAndRepeat(da / 2 - hf * 1.8, Math.PI * 3000 / 2000, m, 2, true, "", false, false, true);

            Sketch swSketch = swModel.IGetActiveSketch2();
            SketchRelationManager skRelMgr = swSketch.RelationManager;
            skRelMgr.DeleteAllRelations();

            int temp = 11;
            loop_COINCIDENT("10");
            loop_COINCIDENT("5");
            swModel.ClearSelection2(true);
            for (int i = 1; i < m; i++)
            {
                loop_COINCIDENT(temp.ToString());
                temp += 5;
                loop_COINCIDENT(temp.ToString());
                temp += 1;
            }

            swModel.ClearSelection2(true);
            status = swModel.Extension.SelectByID2("Arc1", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, (int)swSelectOption_e.swSelectOptionDefault);
            status = swModel.SketchManager.SketchTrim((int)swSketchTrimChoice_e.swSketchTrimClosest, (df / 2) * Math.Sin((0) * 2 * Math.PI / m), (df / 2) * Math.Cos((0) * 2 * Math.PI / m), 0);
            for (int i = 0; i < m; i++)
            {
                swModel.ClearSelection2(true);
                status = swModel.Extension.SelectByID2("Arc1", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, (int)swSelectOption_e.swSelectOptionDefault);
                status = swModel.SketchManager.SketchTrim((int)swSketchTrimChoice_e.swSketchTrimClosest, (df / 2) * Math.Sin((i) * 2 * Math.PI / m), (df / 2) * Math.Cos((i) * 2 * Math.PI / m), 0);
            }

            swModel.CreateCircleByRadius2(0, 0, 0, dtruc / 2);
            swModel.ClearSelection2(true);
            status = swModel.Extension.SelectByID2("Arc" + (m + 1).ToString(), "SKETCHSEGMENT", 0, 0, 0, true, 0, null, (int)swSelectOption_e.swSelectOptionDefault);
            swModel.SketchAddConstraints("sgFIXED");

            swModel.CreateLine2(bthen / 2, (dtruc / 2) - (Math.Tan(Math.Asin(bthen / (2 * dtruc))) * bthen / 2), 0, bthen / 2, hthen + (dtruc / 2) - (Math.Tan(Math.Asin(bthen / (2 * dtruc))) * bthen / 2), 0);
            swModel.CreateLine2(bthen / 2, hthen + (dtruc / 2) - (Math.Tan(Math.Asin(bthen / (2 * dtruc))) * bthen / 2), 0, 0, hthen + (dtruc / 2) - (Math.Tan(Math.Asin(bthen / (2 * dtruc))) * bthen / 2), 0);
            swModel.ClearSelection2(true);
            status = swModel.Extension.SelectByID2("Point" + ((10 + 6) + (m - 1) * 6).ToString(), "SKETCHPOINT", 0, 0, 0, true, 0, null, (int)swSelectOption_e.swSelectOptionDefault);
            status = swModel.Extension.SelectByID2("Point2", "SKETCHPOINT", 0, 0, 0, true, 0, null, (int)swSelectOption_e.swSelectOptionDefault);
            swModel.SketchAddConstraints("sgVERTPOINTS");

            swModel.ClearSelection2(true);
            status = swModel.Extension.SelectByID2("Line" + (8 + (m - 1) * 5).ToString(), "SKETCHSEGMENT", 0, 0, 0, true, 0, null, (int)swSelectOption_e.swSelectOptionDefault);
            swModel.SketchAddConstraints("sgVERTICAL");

            swModel.ClearSelection2(true);
            status = swModel.Extension.SelectByID2("Line" + (8 + (m - 1) * 5).ToString(), "SKETCHSEGMENT", 0, 0, 0, true, 0, null, (int)swSelectOption_e.swSelectOptionDefault);
            status = swModel.Extension.SelectByID2("Line" + (9 + (m - 1) * 5).ToString(), "SKETCHSEGMENT", 0, 0, 0, true, 0, null, (int)swSelectOption_e.swSelectOptionDefault);
            status = swModel.Extension.SelectByID2("Line1", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, (int)swSelectOption_e.swSelectOptionDefault);
            swModel.SketchMirror();

            swModel.ClearSelection2(true);
            status = swModel.Extension.SelectByID2("Point" + ((10 + 8) + (m - 1) * 6).ToString(), "SKETCHPOINT", 0, 0, 0, true, 0, null, (int)swSelectOption_e.swSelectOptionDefault);
            status = swModel.Extension.SelectByID2("Arc" + (m + 1).ToString(), "SKETCHSEGMENT", 0, 0, 0, true, 0, null, (int)swSelectOption_e.swSelectOptionDefault);
            swModel.SketchAddConstraints("sgCOINCIDENT");

            swModel.ClearSelection2(true);
            status = swModel.Extension.SelectByID2("Arc" + (m + 1).ToString(), "SKETCHSEGMENT", 0, 0, 0, true, 0, null, (int)swSelectOption_e.swSelectOptionDefault);
            status = swModel.SketchManager.SketchTrim((int)swSketchTrimChoice_e.swSketchTrimClosest, 0, dtruc / 2, 0);

            swModel.ClearSelection2(true);
            status = swModel.Extension.SelectByID2("Arc" + (m + 1).ToString(), "SKETCHSEGMENT", 0, 0, 0, true, 0, null, (int)swSelectOption_e.swSelectOptionDefault);
            status = swModel.SketchManager.SketchTrim((int)swSketchTrimChoice_e.swSketchTrimClosest, 0, dtruc / 2, 0);

            //swModel.ClearSelection2(true);
            //status = swModel.Extension.SelectByID2("Sketch1", "SKETCH", 0, 0, 0, true, 0, null, (int)swSelectOption_e.swSelectOptionDefault);
            //swModel.SketchModifyScale(0.01);///


            swModel.ClearSelection2(true);
            status = swModel.Extension.SelectByID2("Sketch1", "SKETCH", 0, 0, 0, true, 0, null, (int)swSelectOption_e.swSelectOptionDefault);
            swModel.FeatureManager.FeatureExtrusion3(true, false, false, 6, 0, b, 0, false, false, false, false, 0, 0, false, false, false, false, false, false, false, 0, 0, false);
            // mat 1
            swModel.ClearSelection2(true);
            status = swModel.Extension.SelectByID2("", "FACE", 1.2 * dtruc / 2, 0, b / 2, false, 0, null, 0);

            swModel.CreateCircleByRadius2(0, 0, 0, dkhoet_a / 2);
            swModel.CreateCircleByRadius2(0, 0, 0, dkhoet_f / 2);
            swModel.CreateCenterLineVB(0, 0, 0, 0, df / 2, 0);

            swModel.ClearSelection2(true);
            status = swModel.Extension.SelectByID2("Sketch2", "SKETCH", 0, 0, 0, true, 0, null, (int)swSelectOption_e.swSelectOptionDefault);
            swModel.FeatureManager.FeatureCut3(true, false, false, 0, 0, hkhoet, 0, true, false, false, false, deg_to_rad(5), 0, false, false, false, false, false, true, true, true, true, false, 0, 0, false);
            // mat 2
            swModel.ClearSelection2(true);
            status = swModel.Extension.SelectByID2("", "FACE", 1.2 * dtruc / 2, 0, -b / 2, false, 0, null, 0);

            swModel.CreateCircleByRadius2(0, 0, 0, dkhoet_a / 2);
            swModel.CreateCircleByRadius2(0, 0, 0, dkhoet_f / 2);
            swModel.CreateCenterLineVB(0, 0, 0, 0, df / 2, 0);

            swModel.ClearSelection2(true);
            status = swModel.Extension.SelectByID2("Sketch3", "SKETCH", 0, 0, 0, true, 0, null, (int)swSelectOption_e.swSelectOptionDefault);
            swModel.FeatureManager.FeatureCut3(true, false, false, 0, 0, hkhoet, 0, true, false, false, false, deg_to_rad(5), 0, false, false, false, false, false, true, true, true, true, false, 0, 0, false);

            // lo
            swModel.ClearSelection2(true);
            status = swModel.Extension.SelectByID2("", "FACE", 0, (dkhoet_a - dkhoet_f) / 2, (b / 2) - hkhoet, false, 0, null, 0);
            swModel.CreateCircleByRadius2(0, (dkhoet_a + dkhoet_f) / 4, 0, dlo / 2);
            //duc lo
            swModel.CreatePoint2(0, 0, 0);
            swModel.ClearSelection2(true);
            status = swModel.Extension.SelectByID2("Arc1", "SKETCHSEGMENT", 0, 0, 0, true, 0, null, (int)swSelectOption_e.swSelectOptionDefault);
            status = swModel.SketchManager.CreateCircularSketchStepAndRepeat((dkhoet_a + dkhoet_f) / 4, Math.PI * 3000 / 2000, zlo, 2, false, "", false, false, true);
            swModel.ClearSelection2(true);
            status = swModel.Extension.SelectByID2("Sketch4", "SKETCH", 0, 0, 0, true, 0, null, (int)swSelectOption_e.swSelectOptionDefault);
            swModel.FeatureManager.FeatureCut3(true, false, false, 11, 0, hkhoet, 0, true, false, false, false, 0, 0, false, false, false, false, false, true, true, true, true, false, 0, 0, false);
            //scale
            swModel.ClearSelection2(true);
            swModel.FeatureManager.InsertScale((short)swScaleType_e.swScaleAboutOrigin, true, 0.01, 0.01, 0.01);
            #endregion
        }
    }
}
