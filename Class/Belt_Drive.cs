using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luan_van1
{
    class Belt_Drive
    {
        double loaidai;
        double kyhieudai;
        double b_t;
        double b_belt;
        double h;
        double y0;
        double area;
        string d1_bound;
        string l_bound;

        double l0;//
        double t_shaft;//
        double n_shaft;//
        string d1;
        double d1_modify;//
        double v;
        double u_shaft;//
        double epxilon;//
        double d2;
        double d2_modify;
        double a_d2;//
        double a_pre;
        string a_bound;
        double l_pre;
        double a;
        double l;//
        double alpha1_angle;//>120do
        double z;//lamtronlen
        double p_dc;//
        double p0;//tbl6_19
        double k_d;//
        double c_alpha;//
        double c_l;//
        double c_u;//
        double c_z;//
        double t;//
        double e;//
        double h0;//
        double b_belt_wheel;
        double d_a1;
        double d_a2;
        double q_m;
        double f_v;
        double f_o;
        double f_r;


        public Belt_Drive(Dictionary<string, double> hash)
        {
            L0 = hash["l0"];
            D1_modify = hash["d1_modify"];
            T_shaft = hash["t_shaft"];
            N_shaft = hash["n_shaft"];
            U_shaft = hash["u_shaft"];
            Epxilon = hash["epxilon"];
            D2_modify = hash["d2_modify"];
            A_d2 = hash["a_d2"];
            L = hash["l"];
            P_dc = hash["p_dc"];
            P0 = hash["p0"];
            K_d = hash["k_d"];
            C_alpha = hash["c_alpha"];
            C_l = hash["c_l"];
            C_u = hash["c_u"];
            C_z = hash["c_z"];
            T = hash["t"];
            E = hash["e"];
            H0 = hash["h0"];
            Q_m = hash["q_m"];
        }
        double quadratic_equations(double a, double b, double c)
        {
            double delta = b * b - 4 * a * c;
            return ((-1) * b + Math.Sqrt(delta)) / (2 * a);
            //if (delta > 0)
            //{
            //    double x1 = ((-1) * b + Math.Sqrt(delta)) / (2 * a);
            //    double x2 = ((-1) * b - Math.Sqrt(delta)) / (2 * a);
            //    if (x1 > 0)
            //    {
            //        return x1;
            //    }
            //    else
            //    {
            //        return x2;
            //    }
            //}
            //else if (delta == 0)
            //{
            //    double x1 = (-1 * b) / (2 * a);
            //    return x1;
            //}
            //else
            //{
            //    return 0;
            //}
        }
        public double deg_to_rad(double a)
        {
            return a * (3.14 / 180.0);
        }
        public double rad_to_deg(double a)
        {
            return a * (180.0 / 3.14);
        }
        #region
        public double Loaidai { get => loaidai; set => loaidai = value; }
        public double Kyhieudai { get => kyhieudai; set => kyhieudai = value; }
        public double B_t { get => b_t; set => b_t = value; }
        public double B_belt { get => b_belt; set => b_belt = value; }
        public double H { get => h; set => h = value; }
        public double Y0 { get => y0; set => y0 = value; }
        public double Area { get => area; set => area = value; }
        public string D1_bound { get => d1_bound; set => d1_bound = value; }
        public string L_bound { get => l_bound; set => l_bound = value; }

        public double L0 { get => l0; set => l0 = value; }
        public double T_shaft { get => t_shaft; set => t_shaft = value; }
        public string D1 { get => Convert.ToString(Math.Round(5.2*Math.Pow(T_shaft, 1.0/3.0),1)) + " : " + Convert.ToString(Math.Round(6.4 * Math.Pow(T_shaft, 1.0 / 3.0),1)); set => d1 = value; }
        public double D1_modify { get => d1_modify; set => d1_modify = value; }
        public double N_shaft { get => n_shaft; set => n_shaft = value; }
        public double V { get => 3.14*D1_modify*N_shaft/60000; set => v = value; }
        public double U_shaft { get => u_shaft; set => u_shaft = value; }
        public double Epxilon { get => epxilon; set => epxilon = value; }
        public double D2 { get => D1_modify * U_shaft*(1-epxilon); set => d2 = value; }/// <summary>
        /// ///////////
        /// </summary>
        public double A_d2 { get => a_d2; set => a_d2 = value; }
        public string A_bound { get => Convert.ToString(Math.Round(0.55 * (D1_modify + D2_modify), 1)) + "<= a <=" + Convert.ToString(Math.Round(2 * (D1_modify + D2_modify), 1)); set => a_bound = value; }
        public double D2_modify { get => d2_modify; set => d2_modify = value; }
        public double A_pre { get => D2*A_d2; set => a_pre = value; }
        public double L_pre { get => 2*A_pre+(3.14*(D1_modify+D2)/2)+(Math.Pow(D2-D1_modify,2)/(4*A_pre)); set => l_pre = value; }
        public double A { get => quadratic_equations(8, 2*3.14*(D1_modify+D2)-4*L_pre, Math.Pow(D2-D1_modify,2)); set => a = value; }
        public double L { get => l; set => l = value; }
        public double Alpha1_angle { get => 180-(D2-D1_modify)*57/A; set => alpha1_angle = value; }
        public double Z { get => Math.Ceiling(P_dc*K_d/(P0*C_u*C_l*C_z*C_alpha)); set => z = value; }
        public double P_dc { get => p_dc; set => p_dc = value; }
        public double P0 { get => p0; set => p0 = value; }
        public double K_d { get => k_d; set => k_d = value; }
        public double C_alpha { get => 1-0.0025*(180-Alpha1_angle); set => c_alpha = value; }
        public double C_l { get => c_l; set => c_l = value; }
        public double C_u { get => c_u; set => c_u = value; }
        public double C_z { get => c_z; set => c_z = value; }
        public double T { get => t; set => t = value; }
        public double E { get => e; set => e = value; }
        public double H0 { get => h0; set => h0 = value; }
        public double B_belt_wheel { get => (Z-1)*T+2*E; set => b_belt_wheel = value; }
        public double D_a1 { get => D1_modify+2*H0; set => d_a1 = value; }
        public double D_a2 { get => D2+2*H0; set => d_a2 = value; }
        public double Q_m { get => q_m; set => q_m = value; }
        public double F_v { get => Q_m*Math.Pow(V,2); set => f_v = value; }
        public double F_o { get => (780*P_dc*K_d/(V*C_alpha*Z))+F_v; set => f_o = value; }
        public double F_r { get => 2*F_o*Z*Math.Sin(deg_to_rad(Alpha1_angle/2)); set => f_r = value; }
        


        #endregion
    }
}
