using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luan_van1.Class
{
    class Worm_Gear
    {
     
        double n_shaft;
        double m_shaft;
        double u_shaft;
        double d_per_y;
        double shift;
        double working_hours;
        double tgian_1;
        double chuky_1;
        double tgian_2;
        double chuky_2;
        double ti_Tmax_engine;

        double v_s_pre;
        double cond1;
        double sigma_b;
        double sigma_ch;

        double n_HE;
        double k_HL;
        string sigma_HO_bound;
        double sigma_HO_bound_modify;
        double sigma_H_bound;

        double cond2;
        double n_FE;
        double k_FL;
        double sigma_FO_bound;
        double sigma_F_bound;

        double sigma_Hmax_bound;
        double sigma_Fmax_bound;

        double z1;
        double z2;
        double q;
        string k_H;
        double k_H_modify;
        double a_w;
        double m;
        double x;

        double v_s2;
        double worm_angle;
        double d_w1;

        double sigma_H;
        double hieusuat;
        double friction_angle;
        double k_H_beta;
        double k_H2;
        double k_Hv;
        double heso_biendang;
        double k_t;

        double m_n;
        double k_F_beta;
        double k_Fv;
        double k_F;
        double y_F;
        double sigma_F;


        double sigma_Hmax;
        double sigma_Fmax;

        double d1;
        double d2;
        double d_a1;
        double d_a2;
        double d_f1;
        double d_f2;
        double d_a_M2;  
        double b1;
        double b2; // can cho phan kiem nghiem phia tren
        double goc_om;

        double t0;
        double hieuso_truyennhiet;
        double k_t_nhiet;
        double a1;
        double a;
        double heso_thoatnhiet;
        double beta_angle;
        double t_d_bound;

        #region
        public double D1 { get => d1; set => d1 = value; }
        public double D2 { get => d2; set => d2 = value; }
        public double D_a1 { get => d_a1; set => d_a1 = value; }
        public double D_a2 { get => d_a2; set => d_a2 = value; }
        public double D_f1 { get => d_f1; set => d_f1 = value; }
        public double D_f2 { get => d_f2; set => d_f2 = value; }
        public double D_a_M2 { get => d_a_M2; set => d_a_M2 = value; }
        public double B1 { get => b1; set => b1 = value; }
        public double B2 { get => b2; set => b2 = value; }
        public double Goc_om { get => goc_om; set => goc_om = value; }
        #endregion
        #region
        public double T0 { get => t0; set => t0 = value; }
        public double Hieuso_truyennhiet { get => hieuso_truyennhiet; set => hieuso_truyennhiet = value; }
        public double K_t_nhiet { get => k_t_nhiet; set => k_t_nhiet = value; }
        public double A1 { get => a1; set => a1 = value; }
        public double A { get => a; set => a = value; }
        public double Heso_thoatnhiet { get => heso_thoatnhiet; set => heso_thoatnhiet = value; }
        public double Beta_angle { get => beta_angle; set => beta_angle = value; }
        public double T_d_bound { get => t_d_bound; set => t_d_bound = value; }
        #endregion
        #region
        public double V_s_pre { get => 4.5e-5 * n_shaft * Math.Pow(m_shaft, 1.0 / 3.0); set => v_s_pre = value; }
        public double Sigma_b { get => sigma_b; set => sigma_b = value; }
        public double Sigma_ch { get => sigma_ch; set => sigma_ch = value; }
        public double N_HE
        {
            get
            {
                double temp = (60 * n_shaft * Ti_Tmax(4));
                if (temp > 25e7)
                    return 25e7;
                else
                    return temp;
            }
            set { beta_angle = value; }
        }
        public double K_HL { get => Math.Pow(1e7/N_HE,1.0/8.0); set => k_HL = value; }
        public string Sigma_HO_bound { get => Convert.ToString(0.75 * Sigma_b) + " : " + Convert.ToString(0.9 * Sigma_b); set => sigma_HO_bound = value; }
        public double Sigma_HO_bound_modify { get => sigma_HO_bound_modify; set => sigma_HO_bound_modify = value; }
        public double Sigma_H_bound
        {
            get
            {
                if (cond1 == 0)
                    return Sigma_HO_bound_modify * K_HL;
                else
                    return 0;/////
            }
            set { beta_angle = value; }
        }//!!
        public double N_FE
        {
            get
            {
                double temp = (60 * n_shaft * Ti_Tmax(9));
                if (temp < 1e6) return 1e6;
                else if (temp > 25e7) return 25e7;
                else return temp;
            }
            set { beta_angle = value; }
        }
        public double K_FL { get => Math.Pow(1e7 / N_HE, 1.0 / 9.0); set => k_FL = value; }
        public double Sigma_FO_bound
        {
            get
            {
                if (cond2 == 0)
                    return 0.25*Sigma_b+0.08*sigma_ch;
                else 
                    return 0.16*sigma_b;
            }
            set { beta_angle = value; }
        }
        public double Sigma_F_bound { get => Sigma_FO_bound*K_FL; set => sigma_F_bound = value; }
        public double Sigma_Hmax_bound
        {
            get
            {
                if (cond1 == 0) return 4 * Sigma_ch;
                else if (cond1 == 1) return 2 * Sigma_ch;
                else return 1.5*Sigma_H_bound;
            }
            set { beta_angle = value; }
        }
        public double Sigma_Fmax_bound
        {
            get
            {
                if (cond1 == 0) return 0.8 * Sigma_b;
                else if (cond1 == 1) return 0.8 * Sigma_b;
                else return 0.6 * Sigma_b;
            }
            set { beta_angle = value; }
        }

        public double Z1 { get => z1; set => z1 = value; }
        public double Z2 { get => u_shaft*Z1; set => z2 = value; }
        public double Q { get => q; set => q = value; }
        public string K_H { get => "1.1" + " : " + "1.9"; set => k_H = value; }
        public double K_H_modify { get => k_H_modify; set => k_H_modify = value; }
        public double A_w { get => (Z2+Q)*Math.Pow(Math.Pow(170/(Z2*Sigma_H_bound),2)*m_shaft*K_H_modify/Q,1.0/3.0); set => a_w = value; }
        public double M { get => 2*A_w/(Z2+Q); set => m = value; }
        public double X { get => (A_w/M)-0.5*(Q+Z2); set => x = value; }
        public double V_s2 { get => Math.PI*D_w1*n_shaft/(6e4*Math.Cos(deg_to_rad(Worm_angle))); set => v_s2 = value; }
        public double Worm_angle { get => Math.Atan(Z1/(Q+2*X)); set => worm_angle = value; }
        public double D_w1 { get => (Q+2*X)*M; set => d_w1 = value; }

        public double Sigma_H { get => (170/Z2)*Math.Sqrt(Math.Pow((Z2+Q)/A_w,1.0/3.0)*m_shaft*K_H_modify/Q); set => sigma_H = value; }
        public double Hieusuat { get => 0.95*Math.Tan(deg_to_rad(Worm_angle))/(Math.Tan(deg_to_rad(Worm_angle+ Friction_angle))); set => hieusuat = value; }
        public double Friction_angle { get => friction_angle; set => friction_angle = value; }
        public double K_H_beta { get => 1+Math.Pow(Z2/Heso_biendang,3)*(1-K_t); set => k_H_beta = value; }///////
        public double K_H2 { get => k_H_beta*K_Hv; set => k_H2 = value; }
        public double K_Hv { get => k_Hv; set => k_Hv = value; }
        public double Heso_biendang { get => heso_biendang; set => heso_biendang = value; }
        public double K_t { get => Ti_Tmax(1)/((d_per_y * shift * working_hours * 10)); set => k_t = value; }

        public double M_n { get => M*Math.Cos(deg_to_rad(Worm_angle)); set => m_n = value; }
        public double K_F_beta { get => k_F_beta; set => k_F_beta = value; }
        public double K_Fv { get => k_Fv; set => k_Fv = value; }
        public double K_F { get => k_F; set => k_F = value; }
        public double Y_F { get => y_F; set => y_F = value; }
        public double Sigma_F { get => 1.4*m_shaft*Y_F*K_F/(B2*D2*M_n); set => sigma_F = value; }

        public double Sigma_Hmax { get => sigma_H*Math.Sqrt(ti_Tmax_engine); set => sigma_Hmax = value; }
        public double Sigma_Fmax { get => sigma_F*ti_Tmax_engine; set => sigma_Fmax = value; }
#endregion

        Worm_Gear(Dictionary<string, double> hash)
        {
            n_shaft = hash["n_shaft"];
            m_shaft = hash["m_shaft"];
            u_shaft = hash["u_shaft"];
            d_per_y = hash["d_per_y"];
            shift = hash["shift"];
            working_hours = hash["working_hours"];
            tgian_1 = hash["tgian_1"];
            chuky_1 = hash["chuky_1"];
            tgian_2 = hash["tgian_2"];
            chuky_2 = hash["chuky_2"];
            select_material();
        }
        public double Ti_Tmax(double num)// ham tinh (Ti/Tmax)^int cho may cong thuc khac
        {
            return (d_per_y * shift * working_hours * 10) * (((tgian_1 * chuky_1) / (tgian_1 + tgian_2)) + ((tgian_2 * Math.Pow(chuky_2, num) / (tgian_1 + tgian_2))));
        }
        public double deg_to_rad(double a)
        {
            return a * (3.14 / 180.0);
        }
        public double rad_to_deg(double a)
        {
            return a * (180.0 / 3.14);
        }
        void select_material()
        {
            if (V_s_pre >= 5) cond1 = 0;
            else if (V_s_pre < 5 && V_s_pre >= 2) cond1 = 1;
            else cond1 = 2;
        }
    }

}
