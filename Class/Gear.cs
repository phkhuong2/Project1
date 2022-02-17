using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luan_van1
{
    class Gear
    {
        //void array_constructor();tinh lam cap phat dong mang 2d (bo qua di)
        #region 1 xac dinh ung suat cho phep
        //1 xac dinh ung suat cho phep
        double sigma_Hlim1, sigma_Hlim2, sigma_Flim1, sigma_Flim2;
        double n_HO1;
        double n_HO2;
        double n_HE1;
        double n_HE2;
        double n_FE1;
        double n_FE2;
        //float m_F(int); // thay doi m_F theo HB
        double k_HL1;
        double k_HL2;
        double k_FL1;
        double k_FL2;
        double sigma_H1_bound; //[oH1]
        double sigma_H2_bound;
        double sigma_H_average_bound; //[oH] (sigma_H1_bound + sigma_H2_bound)/2
        double sigma_F1_bound; //[oF1]
        double sigma_F2_bound;
        double sigma_H1max_bound;//toi thep c 2.8sigma_ch , thep tham c va N 40HRCm
        double sigma_H2max_bound; //[oH2max]
        double sigma_F1max_bound; //[oF1max]
        double sigma_F2max_bound;             //OK
        #endregion

        #region 2,3 xac dinh thong so co ban cua bo truyen/ cac thong so an khop (kich thuoc so bo)
        //2,3 xac dinh thong so co ban cua bo truyen/ cac thong so an khop (kich thuoc so bo)
        double psi_bd; //Ybd 
        //void Ka_Kd_ZM;//bang 6.5 trang 96 ; cond == 0 1 2 3 4 5 (vat lieu banh nho va lon)
        string a_w_pre; 
        double a_w_pre_modify; //a_w so bo
        string m;// module m (tra bang nen chua hoan thien)
        double m_modify;
        double z1;
        double z2;
        double beta_angle; // rad, goc beta tinh lai
        string a_w; // a_w tinh lai
        double a_w_modify;
        double k_x;
        double delta_y;
        double a_w_dc;// a_w khi co dich chinh
                          //(kich thuoc thuc te)
        //double a;// tuong tu a_w
        double d1;
        double d2;
        double d_w1;
        double d_w2;
        double d_a1;
        double d_a2;
        double d_f1;
        double d_f2;
        double d_b1;
        double d_b2;
        double alpha_t_angle;//rad
        double alpha_tw_angle;//rad OK
        #endregion

        #region 4 tinh toan kiem nghiem gia tri ung suat tiep xuc
        //4 tinh toan kiem nghiem gia tri ung suat tiep xuc
        double beta_b_angle;//rad
        double z_H;
        double b_w;
        double epsilon_alpha; //lam tron lai z1 thanh int
        double epsilon_beta;
        double z_epsilon;
        double sigma_H;
        double k_H;
        double v;
        double v_H;
        double k_H_nu;//KHv
        #endregion

        #region 5 kiem ngiem ve do ben uon
        //5 kiem ngiem ve do ben uon
        double y_beta;
        double y_epsilon;
        double z_v1;//Zv1
        double z_v2;
        double k_F;
        double sigma_F1;
        double sigma_F2;
        double v_F;
        double k_F_nu;//KFv
        #endregion

        #region 6 kiem nghiem rang ve qua tai (chua xong )
        //6 kiem nghiem rang ve qua tai (chua xong )
        double k_qt; //Ti/Tmax trong catalogue dong co
        double sigma_Hmax;// sigma_H1max = sigma
        double sigma_F1max;
        double sigma_F2max;
        #endregion

        //input
        //vat lieu
        double hB_1, hB_2, cond1, sigma_ch1, sigma_ch2; //do cung banh rang 1, 2, dieu kien cho bang 6.2, och1, och2

        //thong so N_M_U cua truc (2 cap banh rang thi moment chia doi)
        double n_shaft1, n_shaft2, u_shaft, m_shaft; //vong quay truc thu nhat, vong quay truc thu 2, ti so truyen 2 truc, moment

        //thoi gian lam viec
        double tgian_1, tgian_2, chuky_1, chuky_2, d_per_y, shift, working_hours;

        //xac dinh thong so co ban bo truyen
        double K_FC = 1, S_H, S_F; //K_FC = 1 dat tai 1 phia; K_FC = 0.7-0.8 --2 phia (0.8 khi HB_>350)

        //banh rang tru
        double k_a, k_d, psi_ba, cond2,  k_H_beta, x1, x2, k_y, beta_angle_pre, alpha_angle; //psi_ba=Yba, cond2=dieu kieu xac dinh psi_ba
        int cond3;
        //banh rang con
        double K_be = 0, z1p = 0, beta_m_angle = 0, x_n1, x_t1, alpha_n_angle;
        //K_be (banh rang con) 0.25 - 0.3 , nho khi u > 3, lon khi u <= 3

        //kiem nghiem gia tri ung suat tiep xuc
        double z_M, k_H_alpha, delta_H, g_o;

        //kiem nghiem rang ve do ben uon
        double y_F1, y_F2, k_F_beta, k_F_alpha, delta_F, ti_Tmax_engine;
        #region 1 xac dinh ung suat cho phep
        public double N_HO1 { get => (30 * Math.Pow(HB_1, 2.4)); set => n_HO1 = value; }
        public double N_HO2 { get => (30 * Math.Pow(HB_2, 2.4)); set => n_HO2 = value; }
        public double N_HE1 { get => (60 * N_shaft1 * Ti_Tmax(3)); set => n_HE1 = value; }
        public double N_HE2 { get => (60 * N_shaft2 * Ti_Tmax(3)); set => n_HE2 = value; }
        public double N_FE1 { get => (60 * N_shaft1 * Ti_Tmax(m_F(HB_1))); set => n_FE1 = value; }
        public double N_FE2 { get => (60 * N_shaft2 * Ti_Tmax(m_F(HB_2))); set => n_FE2 = value; }
        public double Sigma_Hlim1 { get => sigma_Hlim1; set => sigma_Hlim1 = value; }
        public double Sigma_Hlim2 { get => sigma_Hlim2; set => sigma_Hlim2 = value; }
        public double Sigma_Flim1 { get => sigma_Flim1; set => sigma_Flim1 = value; }
        public double Sigma_Flim2 { get => sigma_Flim2; set => sigma_Flim2 = value; }
        public double K_HL1 { get => Math.Pow(N_HO1 / N_HE1, 1.0 / 6.0); set => k_HL1 = value; }
        public double K_HL2 { get => Math.Pow(N_HO2 / N_HE2, 1.0 / 6.0); set => k_HL2 = value; }
        public double K_FL1 { get => Math.Pow(4e6 / N_FE1, 1.0 / m_F(HB_1)); set => k_FL1 = value; }
        public double K_FL2 { get => Math.Pow(4e6 / N_FE2, 1.0 / m_F(HB_2)); set => k_FL2 = value; }
        public double Sigma_H1_bound { get => (Sigma_Hlim1 * K_HL1 / S_H); set => sigma_H1_bound = value; }
        public double Sigma_H2_bound { get => (Sigma_Hlim1 * K_HL2 / S_H); set => sigma_H2_bound = value; }
        public double Sigma_H_average_bound { get => (Sigma_H1_bound + Sigma_H2_bound) / 2; set => sigma_H_average_bound = value; }
        public double Sigma_F1_bound { get => (Sigma_Flim1 * K_FC * K_FL1 / S_F); set => sigma_F1_bound = value; }
        public double Sigma_F2_bound { get => (Sigma_Flim1 * K_FC * K_FL2 / S_F); set => sigma_F2_bound = value; }
        public double Sigma_H1max_bound { get => 2.8 * sigma_ch1; set => sigma_H1max_bound = value; }
        public double Sigma_H2max_bound { get => 2.8 * sigma_ch2; set => sigma_H2max_bound = value; }
        public double Sigma_F1max_bound { get => sigma_Fmax_bound(HB_1, sigma_ch1); set => sigma_F1max_bound = value; }
        public double Sigma_F2max_bound { get => sigma_Fmax_bound(HB_2, sigma_ch2); set => sigma_F2max_bound = value; }
        #endregion

        #region 2,3 xac dinh thong so co ban cua bo truyen/ cac thong so an khop (kich thuoc so bo)
        public double K_a { get => k_a; set => k_a = value; }
        public double K_d { get => k_d; set => k_d = value; }
        public double Psi_ba { get => psi_ba; set => psi_ba = value; }
        public double Psi_bd { get => 0.53*in_external()*Psi_ba; set => psi_bd = value; }
        public double K_H_beta { get => k_H_beta; set => k_H_beta = value; }
        public string A_w_pre { get => ">= "+Convert.ToString(K_a * in_external() * Math.Pow(M_shaft * K_H_beta / (Math.Pow(Sigma_H_average_bound, 2) * U_shaft * Psi_ba), 1.0 / 3.0)); set => a_w_pre = value; }
        public double A_w_pre_modify { get => a_w_pre_modify; set => a_w_pre_modify = value; }
        public string M { get => Convert.ToString(0.01 * A_w_pre_modify) + " : " + Convert.ToString(0.02 * A_w_pre_modify); set => m = value; }
        public double M_modify { get => m_modify; set => m_modify = value; }
        public double Beta_angle_pre { get => beta_angle_pre; set => beta_angle_pre = value; }
        public double Z1 { get => Math.Ceiling(2 * A_w_pre_modify * Math.Cos(deg_to_rad(beta_angle_pre)) / (M_modify * (U_shaft + 1))); set => z1 = value; }
        public double Z2 { get => Math.Floor(U_shaft * Z1); set => z2 = value; }
        public double Beta_angle { 
            get
            {
                if (Beta_angle_pre != 0)
                    return deg_to_rad(rad_to_deg(Math.Acos(M_modify * (Z1 + Z2) / (2 * A_w_pre_modify))));
                else
                    return 0;
            }
            set {beta_angle = value; } 
        }
        public string A_w { get => Convert.ToString(M_modify * (Z1 + Z2) / (2 * Math.Cos(deg_to_rad(Beta_angle)))); set => a_w = value; }
        public double A_w_modify { get => a_w_modify; set => a_w_modify = value; }
        public double K_x { get => 1000 * (X1 + X2) / (Z1 + Z2); set => k_x = value; }
        public double X1 { get => x1; set => x1 = value; }
        public double X2 { get => x2; set => x2 = value; }
        public double Delta_y { get => K_y * (Z1 + Z2) / 1000; set => delta_y = value; }
        public double K_y { get => k_y; set => k_y = value; }
        public double A_w_dc { get => ((0.5 * (Z1 + Z2) / Math.Cos(deg_to_rad(Beta_angle))) + (X1 + X2) - Delta_y) * M_modify; set => a_w_dc = value; }
        
        public double D1 { get => M_modify * Z1 / Math.Cos(deg_to_rad(Beta_angle)); set => d1 = value; }
        public double D2 { get => M_modify * Z2 / Math.Cos(deg_to_rad(Beta_angle)); set => d2 = value; }
        public double D_w1 { get => 2 * A_w_dc / (U_shaft + 1); set => d_w1 = value; }
        public double D_w2 { get => D_w1 * U_shaft; set => d_w2 = value; }
        public double D_a1 { get => D1 + 2 * M_modify * (1 + X1 - Delta_y); set => d_a1 = value; }
        public double D_a2 { get => D2 + 2 * M_modify * (1 + X2 - Delta_y); set => d_a2 = value; }
        public double D_f1 { get => D1 - (2.5 - 2 * X1) * M_modify; set => d_f1 = value; }
        public double D_f2 { get => D2 - (2.5 - 2 * X2) * M_modify; set => d_f2 = value; }
        public double D_b1 { get => D1 * Math.Cos(deg_to_rad(Alpha_angle)); set => d_b1 = value; }
        public double D_b2 { get => D2 * Math.Cos(deg_to_rad(Alpha_angle)); set => d_b2 = value; }
        public double Alpha_t_angle { get => rad_to_deg(Math.Atan(Math.Tan(deg_to_rad(Alpha_angle)) / Math.Cos(deg_to_rad(Beta_angle)))); set => alpha_t_angle = value; }
        public double Alpha_tw_angle { get => rad_to_deg(Math.Acos(A_w_modify * Math.Cos(deg_to_rad(Alpha_t_angle)) / A_w_dc)); set => alpha_tw_angle = value; }
        public double Alpha_angle { get => alpha_angle; set => alpha_angle = value; }

        #endregion

        #region 4 do ben ung suat tiep xuc
        public double Beta_b_angle { get => Math.Atan(Math.Cos(deg_to_rad(Alpha_t_angle)) * Math.Tan(deg_to_rad(Beta_angle))); set => beta_b_angle = value; }
        public double Z_H { get => Math.Sqrt(2 * Math.Cos(beta_b_angle / Math.Sin(2 * Alpha_tw_angle))); set => z_H = value; }
        public double B_w { get => Psi_ba * A_w_dc; set => b_w = value; }
        public double Epsilon_alpha { get => (1.88 - 3.2 * ((1 / Z1) + (1 / Z2))) * Math.Cos(Beta_angle); set => epsilon_alpha = value; }
        public double Epsilon_beta { get => B_w * Math.Sin(Beta_angle) / (M_modify * 3.14); set => epsilon_beta = value; }
        public double Z_epsilon {
            get
            {
                if (Epsilon_beta == 0)
                    return Math.Sqrt((4 - Epsilon_alpha) / 3);
                else if (Epsilon_beta < 0)
                    return Math.Sqrt((4 - Epsilon_alpha) * (1 - Epsilon_beta) / 3);
                else
                    return Math.Sqrt(1 / Epsilon_alpha);
            }
            set { z_epsilon = value; }  
        }
        public double Sigma_H { get => (Z_M * Z_H * Z_epsilon / D_w1) * Math.Sqrt(2 * M_shaft * K_H * (U_shaft + 1) / (B_w * U_shaft)); set => sigma_H = value; }
        public double K_H { get => K_H_beta * K_H_alpha * K_H_nu; set => k_H = value; }
        public double V { get => 3.14 * D_w1 * N_shaft1 / 6000; set => v = value; }
        public double V_H { get => Delta_H * G_o * V * Math.Sqrt(A_w_dc / U_shaft); set => v_H = value; }
        public double K_H_nu { get => 1 + (V_H * B_w * D_w1) / (2 * M_shaft * K_H_beta * K_H_alpha); set => k_H_nu = value; }
        public double Z_M { get => z_M; set => z_M = value; }
        public double K_H_alpha { get => k_H_alpha; set => k_H_alpha = value; }
        public double Delta_H { get => delta_H; set => delta_H = value; }
        public double G_o { get => g_o; set => g_o = value; }
        #endregion

        #region 5,6 kiem ngiem ve do ben uon, kiem nghiem rang ve qua tai
        public double Y_beta { 
            get
            {
                if (Beta_angle_pre == 0)
                    return 1;
                else
                    return 1 - rad_to_deg(Beta_angle) / 140;
            }
            set {beta_angle = value; }         
        }
        public double Y_epsilon { get => 1 / Epsilon_alpha; set => y_epsilon = value; }
        public double Z_v1 { get => Z1 / Math.Pow(Math.Cos(Beta_angle), 3); set => z_v1 = value; }
        public double Z_v2 { get => Z2 / Math.Pow(Math.Cos(Beta_angle), 3); set => z_v2 = value; }
        public double K_F { get => K_F_beta * K_F_alpha * K_F_nu; set => k_F = value; }
        public double Sigma_F1 { get => 2 * M_shaft * K_F * Y_epsilon * Y_beta * Y_F1 / (B_w * D_w1 * M_modify); set => sigma_F1 = value; }
        public double Sigma_F2 { get => Sigma_F1 * Y_F2 / Y_F1; set => sigma_F2 = value; }
        public double V_F { get => Delta_F * g_o * V * Math.Sqrt(A_w_dc / U_shaft); set => v_F = value; }
        public double K_F_nu { get => 1 + (V_F * B_w * D_w1) / (2 * M_shaft * K_F_beta * K_F_alpha); set => k_F_nu = value; }
        public double Delta_F { get => delta_F; set => delta_F = value; }
        public double Y_F1 { get => y_F1; set => y_F1 = value; }
        public double Y_F2 { get => y_F2; set => y_F2 = value; }
        public double K_F_beta { get => k_F_beta; set => k_F_beta = value; }
        public double K_F_alpha { get => k_F_alpha; set => k_F_alpha = value; }
        public double Ti_Tmax_engine { get => ti_Tmax_engine; set => ti_Tmax_engine = value; }
        public double K_qt { get => ti_Tmax_engine; set => K_qt = value; }
        public double Sigma_Hmax
        {
            get
            {
                return Sigma_H * Math.Sqrt(K_qt);
            }
            set { sigma_Hmax = value; }
        }
        public double Sigma_F1max
        {
            get
            {
                return Sigma_F1 * K_qt;
            }
            set { sigma_F1max = value; }
        }
        public double Sigma_F2max
        {
            get
            {
                return Sigma_F2 * K_qt;
            }
            set { sigma_F1max = value; }
        }


        #endregion

        public double N_shaft1 { get => n_shaft1; set => n_shaft1 = value; }
        public double N_shaft2 { get => n_shaft2; set => n_shaft2 = value; }
        public double U_shaft { get => u_shaft; set => u_shaft = value; }
        public double M_shaft { get => m_shaft; set => m_shaft = value; }
        public double HB_1 { get => hB_1; set => hB_1 = value; }
        public double HB_2 { get => hB_2; set => hB_2 = value; }


        public  Gear(Dictionary<string, List<double>> hash)
        {
            HB_1 = hash["material"][0];
            HB_2 = hash["material"][1];
            cond1 = hash["material"][2];
            sigma_ch1 = hash["material"][3]; 
            sigma_ch2 = hash["material"][4];
            K_FC = hash["material"][0];

            tgian_1 = hash["working_time"][0];
            tgian_2 = hash["working_time"][1];
            chuky_1 = hash["working_time"][2];
            chuky_2 = hash["working_time"][3];
            d_per_y = hash["working_time"][4];
            shift = hash["working_time"][5];
            working_hours = hash["working_time"][6];

            N_shaft1 = hash["N_M_U_shafts"][0];
            N_shaft2 = hash["N_M_U_shafts"][1];
            U_shaft = hash["N_M_U_shafts"][2];
            M_shaft = hash["N_M_U_shafts"][3];

            k_a = hash["spur_wheel"][0];
            k_d = hash["spur_wheel"][1];
            psi_ba = hash["spur_wheel"][2];
            cond2 = Convert.ToInt32(hash["spur_wheel"][3]);
            cond3 = Convert.ToInt32(hash["spur_wheel"][4]);
            K_H_beta = hash["spur_wheel"][5];
            X1 = hash["spur_wheel"][6];
            X2 = hash["spur_wheel"][7];
            K_y = hash["spur_wheel"][8];
            Beta_angle_pre = hash["spur_wheel"][9];
            Alpha_angle = hash["spur_wheel"][10];
            A_w_pre_modify = hash["spur_wheel"][11];
            M_modify = hash["spur_wheel"][12];
            A_w_modify = hash["spur_wheel"][13];


            Z_M = hash["contact"][0];
            K_H_alpha = hash["contact"][1];
            delta_H = hash["contact"][2];
            g_o = hash["contact"][3];

            Y_F1 = hash["Durability"][0];
            Y_F2 = hash["Durability"][1];
            K_F_alpha = hash["Durability"][2];
            K_F_beta = hash["Durability"][3];
            delta_F = hash["Durability"][4];
            Ti_Tmax_engine = hash["Durability"][5];

            sigma_Hlim_Flim();
            Ka_Kd_ZM();
        }
     
        public double Ti_Tmax(double num)// ham tinh (Ti/Tmax)^int cho may cong thuc khac
        {
            return (d_per_y * shift * working_hours * 10) * (((tgian_1 * chuky_1) / (tgian_1 + tgian_2)) + ((tgian_2 * Math.Pow(chuky_2, num) / (tgian_1 + tgian_2))));
        }
        void sigma_Hlim_Flim() // cond 0,1,2,3,4,5,6,7,8; bang 6.2 trang 94
        {
            if (cond1 == 0)
            {
                Sigma_Hlim1 = 2 * HB_1 + 70;
                Sigma_Hlim2 = 2 * HB_2 + 70;
                Sigma_Flim1 = 1.8 * HB_1;
                Sigma_Flim2 = 1.8 * HB_2;
                S_H = 1.1;
                S_F = 1.75;
            }
            else if (cond1 == 1)
            {
                Sigma_Hlim1 = 18 * HB_1 + 150;
                Sigma_Hlim2 = 18 * HB_2 + 150;
                Sigma_Flim1 = 550;
                Sigma_Flim2 = 550;
                S_H = 1.1;
                S_F = 1.75;
            }
            else if (cond1 == 2)
            {
                Sigma_Hlim1 = 17 * HB_1 + 200;
                Sigma_Hlim2 = 17 * HB_2 + 200;
                Sigma_Flim1 = 900;
                Sigma_Flim2 = 900;
                S_H = 1.2;
                S_F = 1.75;
            }
            else if (cond1 == 3)
            {
                Sigma_Hlim1 = 17 * HB_1 + 200;
                Sigma_Hlim1 = 17 * HB_2 + 200;
                Sigma_Flim1 = 550;
                Sigma_Flim2 = 550;
                S_H = 1.2;
                S_F = 1.75;
            }
            else if (cond1 == 4)
            {
                Sigma_Hlim1 = 1050;
                Sigma_Hlim1 = 1050;
                Sigma_Flim1 = 12 * HB_1 + 30;
                Sigma_Flim2 = 12 * HB_2 + 30;
                S_H = 1.2;
                S_F = 1.75;
            }
            else if (cond1 == 5)
            {
                Sigma_Hlim1 = 23 * HB_1;
                Sigma_Hlim1 = 23 * HB_2;
                Sigma_Flim1 = 750;
                Sigma_Flim2 = 750;
                S_H = 1.2;
                S_F = 1.55;
            }
            else if (cond1 == 6)
            {
                Sigma_Hlim1 = 23 * HB_1;
                Sigma_Hlim1 = 23 * HB_2;
                Sigma_Flim1 = 1000;
                Sigma_Flim2 = 1000;
                S_H = 1.2;
                S_F = 1.55;
            }
            else if (cond1 == 7)
            {
                Sigma_Hlim1 = 23 * HB_1;
                Sigma_Hlim1 = 23 * HB_2;
                Sigma_Flim1 = 750;
                Sigma_Flim2 = 750;
                S_H = 1.2;
                S_F = 1.55;
            }
        }
        public double m_F(double HB) // thay doi m_F theo HB
        {
            if (HB <= 350)
                return 6.0;
            else
                return 9.0;
        }
        public double sigma_Fmax_bound(double a, double b)
        {
            if (a <= 350)
                return 0.8 * b;
            else
                return 0.6 * b;
        }
        void Ka_Kd_ZM()
        {
            double[,] spur_wheel = new double[,] { { 49.5, 77 }, { 44.5, 70 }, { 43, 68 }, { 41.5, 64.5 }, { 20, 41 }, { 15.5, 24 } };
            double[,] helical_gear = new double[,] { { 43, 67.5 }, { 39, 61 }, { 37.5, 60 }, { 36, 56.5 }, { 17, 27 }, { 13.5, 21 } };
            double[] ZM = { 274, 234, 225, 209, 69.5, 47.5 };
            if (Beta_angle_pre == 0)
            {
                K_a = spur_wheel[cond3,0];
                K_d = spur_wheel[cond3,1];
            }
            else
            {
                K_a = helical_gear[cond3,0];
                K_d = helical_gear[cond3,1];
            }
            Z_M = ZM[cond3];
        }
        public double in_external()//cond == 1 "an khop trong" ; 0 "an khop ngoai"
        {
            if (cond2 == 1)
                return U_shaft + 1;
            else
                return U_shaft - 1;
        }
        public double deg_to_rad(double a)
        {
            return a * (3.14 / 180.0);
        }
        public double rad_to_deg(double a)
        {
            return a * (180.0 / 3.14);
        }

    }
}
