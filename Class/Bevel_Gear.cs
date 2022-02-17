using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using luan_van1;

namespace luan_van1
{
    class Bevel_Gear : Gear
    {
        double k_R_pre;
        double r_e_pre;

        double d_e1_pre;
        double z1;
        double z2;
        double d_m1_pre;
        double m_tm;
        double m_te;
        double m_te_new1;
        double m_tm_new1;
        double d_m1_new1;

        //kich thuoc thuc te
        double r_e;
        double b;
        double r_m;
        double d_e1;
        double d_e2;
        double bevel_angle1; //goc con o1
        double bevel_angle2;
        double h_e;
        double h_ae1;
        double h_ae2;
        double h_fe1;
        double h_fe2;
        double d_ae1;
        double d_ae2;
        double s_e1;
        double s_e2;
        double pin_f1_angle; //goc chan rang thelta f1
        double pin_f2_angle;
        double bevel_a1_angle; //goc con chia oa1
        double bevel_a2_angle;
        double bevel_f1_angle;// goc con day of1
        double bevel_f2_angle;
        double d_m1;
        double d_m2;
        double b1;
        double b2;
        double m_nm;
        double k_be = 0, z1p = 0, beta_m_angle = 0, x_n1, x_t1, alpha_n_angle;
        public Bevel_Gear(Dictionary<string, List<double>> hash) : base(hash)
        {
            hash.Remove("spur_wheel");
             
            //Sigma_H_average_bound = 554.54545;
            K_be = hash["Bevel_Gear"][0];
            Z1p = hash["Bevel_Gear"][1];
            Beta_m_angle = hash["Bevel_Gear"][2];
            X_n1 = hash["Bevel_Gear"][3];
            X_t1 = hash["Bevel_Gear"][4];
            Alpha_n_angle = hash["Bevel_Gear"][5];
            K_d = hash["Bevel_Gear"][6];
            M_te_new1 = hash["Bevel_Gear"][7];
        }

        //K_R_pre * Math.Sqrt(Math.Pow(U_shaft, 2) + 1) * Math.Pow(M_shaft * K_H_beta / ((1 - K_be) * K_be * U_shaft * Math.Pow(Sigma_H_average_bound, 2)), 1.0 / 3.0) o trong bi am <0
        public double K_R_pre { get => 0.5 * K_d; set => k_R_pre = value; }
        public double R_e_pre { get => K_R_pre * Math.Sqrt(Math.Pow(U_shaft, 2) + 1) * Math.Pow(M_shaft * K_H_beta / ((1 - K_be) * K_be * U_shaft * Math.Pow(554.54545, 2)), 1.0 / 3.0); set => r_e_pre = value; }
        public double D_e1_pre { get => K_d * Math.Pow(M_shaft * K_H_beta / ((1 - K_be) * K_be * U_shaft * Math.Pow(554.54545, 2)), 1.0 / 3.0); set => d_e1_pre = value; }
        public double Z1 
        {
            get
            {
                if (HB_1 <= 350 && HB_2 <= 350)
                    return (Math.Ceiling(1.6 * z1p));
                else if (HB_1 >= 422.51 && HB_2 <= 350)
                    return (Math.Ceiling(1.3 * z1p));
                else if (HB_1 >= 422.51 && HB_2 >= 422.51)
                    return (Math.Ceiling(z1p));
                else
                    return z1;
            }
            set { z1 = value; }
        }
        public double Z2 { get => U_shaft*Z1; set => z2 = value; }
        public double D_m1_pre { get => (1 - 0.5 * K_be) * D_e1_pre; set => d_m1_pre = value; }
        public double M_tm { get => D_m1_pre / Z1; set => m_tm = value; }
        public double M_te { get => M_tm / (1 - 0.5 * K_be); set => m_te = value; }
        public double R_e { get => 0.5 * M_te_new1 * Math.Sqrt(Math.Pow(Z1, 2) + Math.Pow(Z2, 2)); set => r_e = value; }
        public double B { get => K_be * R_e; set => b = value; }
        public double M_tm_new1 { get => M_te_new1 * (1 - 0.5 * K_be); set => m_tm_new1 = value; }
        public double D_m1_new1 { get => M_tm_new1 * Z1; set => d_m1_new1 = value; }
        public double R_m { get => R_e - 0.5 * B; set => r_m = value; }
        public double D_e1 { get => M_te_new1 * Z1; set => d_e1 = value; }
        public double D_e2 { get => M_te_new1 * Z2; set => d_e2 = value; }
        public double Bevel_angle1 { get => rad_to_deg(Math.Atan(Z1 / Z2)); set => bevel_angle1 = value; }
        public double Bevel_angle2 { get => 90 - Bevel_angle1; set => bevel_angle2 = value; }
        public double H_e { get => 2 * Math.Cos(Beta_m_angle) * M_te_new1 + 0.2 * M_te_new1; set => h_e = value; }
        public double H_ae1 { get => (1 + X_n1) * Math.Cos(Beta_m_angle) * M_te_new1; set => h_ae1 = value; }
        public double H_ae2 { get => 2 * Math.Cos(Beta_m_angle) * M_te_new1 - H_ae1; set => h_ae2 = value; }
        public double H_fe1 { get => H_e - H_ae1; set => h_fe1 = value; }
        public double H_fe2 { get => H_e - H_ae2; set => h_fe2 = value; }
        public double D_ae1 { get => D_e1 + 2 * H_ae1 * Math.Cos(Bevel_angle1); set => d_ae1 = value; }
        public double D_ae2 { get => D_e2 + 2 * H_ae2 * Math.Cos(Bevel_angle2); set => d_ae2 = value; }
        public double S_e1 { get => (0.5 * 3.14 + 2 * X_n1 * Math.Tan(Alpha_n_angle) + X_t1) * M_te_new1; set => s_e1 = value; }
        public double S_e2 { get => 3.14 * M_te_new1 - S_e1; set => s_e2 = value; }
        public double Pin_f1_angle { get => Math.Atan(H_fe1 / R_e); set => pin_f1_angle = value; }
        public double Pin_f2_angle { get => Math.Atan(H_fe2 / R_e); set => pin_f2_angle = value; }
        public double Bevel_a1_angle { get => Bevel_angle1 + Pin_f2_angle; set => bevel_a1_angle = value; }
        public double Bevel_a2_angle { get => Bevel_angle2 + Pin_f2_angle; set => bevel_a2_angle = value; }
        public double Bevel_f1_angle { get => Bevel_angle1 - Pin_f1_angle; set => bevel_f1_angle = value; }
        public double Bevel_f2_angle { get => Bevel_angle2 - Pin_f2_angle; set => bevel_f2_angle = value; }
        public double D_m1 { get => (1 - 0.5 * B / R_e) * d_e1; set => d_m1 = value; }
        public double D_m2 { get => (1 - 0.5 * B / R_e) * d_e2; set => d_m2 = value; }
        public double B1 { get => R_e * Math.Cos(Bevel_angle1) - H_ae1 * Math.Sin(Bevel_angle1); set => b1 = value; }
        public double B2 { get => R_e * Math.Cos(Bevel_angle2) - H_ae2 * Math.Sin(Bevel_angle2); set => b2 = value; }
        public double M_nm { get => (M_te_new1 - B / (Z1 + Z2)) * Math.Cos(Beta_m_angle); set => m_nm = value; }
        public double K_be { get => k_be; set => k_be = value; }
        public double Z1p { get => z1p; set => z1p = value; }
        public double Beta_m_angle { get => beta_m_angle; set => beta_m_angle = value; }
        public double X_n1 { get => x_n1; set => x_n1 = value; }
        public double X_t1 { get => x_t1; set => x_t1 = value; }
        public double Alpha_n_angle { get => alpha_n_angle; set => alpha_n_angle = value; }
        public double M_te_new1 { get => m_te_new1; set => m_te_new1 = value; }
        
    }
}
