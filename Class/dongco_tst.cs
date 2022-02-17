using System;
using System.Collections.Generic;
namespace luan_van1
{
    class dongco_tst
    {
        

        private double f;
        private double v;
        private double z;
        private double p;
        private double tgian_1;
        private double tgian_2;
        private double chuky_1;
        private double chuky_2;
        private double hsuat_1;
        private double hsuat_2;
        private double hsuat_3;
        private double hsuat_4;
        private double hsuat_5;
        private double hsuat_6;
        private double hsuat;
        private double p_lv;
        private double p_td;
        private double p_ct;
        private double n_lv;
        private double u_d;
        private double u_tv;
        private double u_sb;
        private double n_sb;
        private double n_dc;
        private double p_dc;
        private double u_1;
        private double u_2;
        private double p_truc1;
        private double p_truc2;
        private double p_truc3;
        private double n_truc1;
        private double n_truc2;
        private double n_truc3;
        private double t_dc;
        private double t_truc1;
        private double t_truc2;
        private double t_truc3;

        public dongco_tst(List<double> list)
        {
            this.f = list[0];
            this.v = list[1];
            this.z = list[2];
            this.p = list[3];
            this.tgian_1 = list[4];
            this.tgian_2 = list[5];
            this.chuky_1 = list[6];
            this.chuky_2 = list[7];
            this.hsuat = list[8];;
            this.u_sb = list[9];
            this.u_1 = list[10];
            this.u_2 = list[11];
            this.u_d = list[12];
            this.hsuat_1 = list[13];
            this.hsuat_2 = list[14];
            this.hsuat_5 = list[15];
            this.n_dc = list[16];
            this.p_dc = list[17];
        }

        public double Ti_Tmax(int num)
        {
            return  (((tgian_1 * chuky_1) + (tgian_2 * Math.Pow(chuky_2, num))) / (tgian_1 + tgian_2));
        }
        //List<string> lst = new List<string>();
        //XElement xElement = XElement.Load("XMLFile1.xml");
        //IEnumerable<XElement> a = xElement.Elements();
        //    foreach (var b in a)
        //    {
        //        lst.Add(b.Value);
        //    }
        //    foreach (var b in lst)
        //    {
        //        Console.WriteLine(b);
        //    }
        //string fileName = Path.Combine(Application.StartupPath, "dataC1.xml");
        //XElement emp = XDocument.Load(Path.Combine(Application.StartupPath, "dataC1.xml")).Descendants("dataC1").FirstOrDefault();

        public double F { get => f; set => f = value; }
        public double V { get => v; set => v = value; }

        public double Tgian_1 { get => tgian_1; set => tgian_1 = value; }
        public double Chuky_1 { get => chuky_1; set => chuky_1 = value; }
        public double Hsuat { get => hsuat; set => hsuat = value; }
        public double P_lv { get => (F*V)/1000; set => p_lv = value; }
        public double P_td { get => (P_lv*Math.Sqrt(Ti_Tmax(2))); set => P_td = value; }
        public double N_dc { get => n_dc; set => n_dc = value; }
        public double N_lv { get => 60000*V/(Z*P); set => n_lv = value; }
        public double U_sb { get => u_sb; set => u_sb = value; }
        public double U_d { get => u_d; set => u_d = value; }
        public double U_tv { get => u_tv; set => u_tv = value; }
        public double N_sb { get => (N_lv*U_sb); set => n_sb = value; }
        public double P_dc { get => p_dc; set => p_dc = value; }
        public double Tgian_2 { get => tgian_2; set => tgian_2 = value; }
        public double Chuky_2 { get => chuky_2; set => chuky_2 = value; }
        public double P_ct { get => (P_td/Hsuat); set => p_ct = value; }
        public double Z { get => z; set => z = value; }
        public double P { get => p; set => p = value; }
        public double U_1 { get => u_1; set => u_1 = value; }
        public double U_2 { get => u_2; set => u_2 = value; }
        public double Hsuat_1 { get => hsuat_1; set => hsuat_1 = value; }
        public double Hsuat_2 { get => hsuat_2; set => hsuat_2 = value; }
        public double Hsuat_3 { get => hsuat_3; set => hsuat_3 = value; }
        public double Hsuat_4 { get => hsuat_4; set => hsuat_4 = value; }
        public double Hsuat_5 { get => hsuat_5; set => hsuat_5 = value; }
        public double Hsuat_6 { get => hsuat_6; set => hsuat_6 = value; }
        public double P_truc1 { get => P_ct*Hsuat_1*Hsuat_5; set => p_truc1 = value; }
        public double P_truc2 { get => P_truc1*Hsuat_2*Hsuat_5; set => p_truc2 = value; }
        public double P_truc3 { get => P_truc2*Hsuat_2*Hsuat_5; set => p_truc3 = value; }
        public double N_truc1 { get => N_dc/U_d; set => n_truc1 = value; }
        public double N_truc2 { get => N_truc1/U_1; set => n_truc2 = value; }
        public double N_truc3 { get => N_truc2/U_2; set => n_truc3 = value; }
        public double T_dc { get => (9.55e6 * P_dc / N_dc); set => t_dc = value; }
        public double T_truc1 { get => (9.55e6 * P_truc1 / N_truc1); set => t_truc1 = value; }
        public double T_truc2 { get => (9.55e6 * P_truc2 / N_truc2); set => t_truc2 = value; }
        public double T_truc3 { get => (9.55e6 * P_truc3 / N_truc3); set => t_truc3 = value; }
    }
}
