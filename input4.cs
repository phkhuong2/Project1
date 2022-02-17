using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace luan_van1
{
    public partial class input4 : Form
    {
        string fileName = "dataC2.xml";
        XElement emp2 = XDocument.Load("dataC2.xml").Root;//.Element("dataC0");//.Descendants("dataC2").FirstOrDefault();
        string indexData = trangchu.Self.indexGearData.ToString();

        XElement emp1 = XDocument.Load("dataC1.xml").Descendants("dataC1").FirstOrDefault();

        double VFHmax;
        double[,] tbl_6_16 = { { 38, 42, 48 }, { 47, 53, 64 }, { 56, 61, 73 }, { 73, 82, 100 } };
        double[,] tbl_6_17 = { { 160, 194, 250 }, { 240, 310, 450 }, { 380, 410, 590 }, { 700, 880, 1050 } };
        double[,] tbl_6_14 = { { 2.5, 1.01, 1.05, 1.03, 1.12, 1.05, 1.22, 1.13, 1.37 }, { 5, 1.02, 1.07, 1.05, 1.16, 1.09, 1.27, 1.16, 1.4 }, { 10, 1.03, 1.1, 1.07, 1.22, 1.13, 1.37, 1.19, 1.43 }, { 15, 1.04, 1.13, 1.09, 1.25, 1.17, 1.45, 1.22, 1.46 }, { 20, 1.05, 1.17, 1.12, 1.35, 1.21, 1.53, 1.25, 1.49 }, { 25, 1.06, 1.2, 1.15, 1.45, 1.25, 1.61, 1.28, 1.52 } };
        double[,] tbl_6_18 = { { 12, 3.46, 3.89, 4.26, 4.28, 4.13 }, { 14, 3.42, 3.78, 4.26, 4.28, 4.13 }, { 16, 3.40, 3.72, 4.26, 4.28, 4.13 }, { 17, 3.40, 3.67, 4.26, 4.28, 4.13 }, { 20, 3.39, 3.61, 4.08, 4.28, 4.13 }, { 22, 3.39, 3.59, 4, 4.28, 4.13 }, { 25, 3.39, 3.57, 3.9, 4.28, 4.13 }, { 30, 3.40, 3.54, 3.8, 4.14, 4.13 }, { 40, 3.42, 3.53, 3.7, 3.92, 4.13 }, { 50, 3.44, 3.52, 3.65, 3.81, 3.96 }, { 60, 3.47, 3.53, 3.62, 3.74, 3.84 }, { 80, 3.50, 3.54, 3.61, 3.68, 3.73 }, { 100, 3.52, 3.55, 3.6, 3.65, 3.68 }, { 150, 3.52, 3.55, 3.6, 3.63, 3.63 } };
        public static input4 Self;
        public input4()
        {
            InitializeComponent();
            Self = this;
            getdata();
        }
        double go_vHmax_vFmax(double[,] a, int capchinhxac)
        {
            if (textBox2.Text != "NaN")
            {
                if (to_db(textBox2) <= 3.55)
                {
                    return a[capchinhxac - 6, 0];
                }
                else if (to_db(textBox2) > 3.55 && to_db(textBox2) <= 10)
                {
                    return a[capchinhxac - 6, 1];
                }
                else
                {
                    return a[capchinhxac - 6, 2];
                }
            }
            else return 0;
        }
        void KHalpha_KFalpha(double[,] tbl_6_14, int capchinhxac, double v)
        {
            if (textBox2.Text != "NaN")
            {
                if (to_db(textBox2) <= 2.5)
                {
                    textBox6.Text = tbl_6_14[0, capchinhxac - 6 + 2].ToString();
                    textBox17.Text = tbl_6_14[0, capchinhxac - 6 + 1 + 2].ToString();
                }
                else
                {
                    int id = 0;
                    for (int i = 1; i < 5; i++)
                    {
                        if (v < i * 5)
                        {
                            id = i;
                            break;
                        }
                    }
                    double x = 0;
                    double y = 0;

                    double a1 = tbl_6_14[id - 1, 0];
                    double a2 = tbl_6_14[id, 0];
                    double b1 = tbl_6_14[id - 1, capchinhxac - 6 + 2];
                    double b2 = tbl_6_14[id, capchinhxac - 6 + 2];
                    x = (b1 - b2) / (a1 - a2);
                    y = b1 - a1 * x;
                    textBox6.Text = (v * x + y).ToString();

                    b1 = tbl_6_14[id - 1, capchinhxac - 6 + 1 + 2];
                    b2 = tbl_6_14[id, capchinhxac - 6 + 1 + 2];
                    x = (b1 - b2) / (a1 - a2);
                    y = b1 - a1 * x;
                    textBox17.Text = (v * x + y).ToString();
                }
            }
            
        }

        double Y_F(double[,] tbl_6_18, int z, double heso_x)
        {
            double[] tbl_id2 = { 0.5, 0.3, 0, -0.3, -0.5};
            int id2 = 0;
            int id = 0;  
            for (int i = 0; i < 14; i++)
            {
                if (z < tbl_6_18[i,0])
                {
                    id = i;
                    break;
                }
            }
            foreach (double item in tbl_id2)
            {
                if (heso_x == item)
                {
                    break;
                }
                id2 += 1;
            }
            if (z<=12)
            {
                return tbl_6_18[0, id2];
            }
            else if (z>=150)
            {
                return tbl_6_18[13, id2];
            }
            else
            {
                double x = 0;
                double y = 0;

                double a1 = tbl_6_18[id - 1, 0];
                double a2 = tbl_6_18[id, 0];
                double b1 = tbl_6_18[id - 1, id2+1];
                double b2 = tbl_6_18[id, id2+1];
                x = (b1 - b2) / (a1 - a2);
                y = b1 - a1 * x;
                return (z * x + y);
            }
            
        }
        void compare_VF_VH_VFmax_VHmax()
        {
            textBox5.BackColor = Color.Green;
            textBox20.BackColor = Color.Green;
            if (double.Parse(textBox5.Text) > go_vHmax_vFmax(tbl_6_17, int.Parse(textBox32.Text)))
            {
                textBox11.BackColor = Color.Red;
            }
            if (double.Parse(textBox20.Text) > go_vHmax_vFmax(tbl_6_17, int.Parse(textBox32.Text)))
            {
                textBox20.BackColor = Color.Red;
            }
        }
        void compare_sigma_H_F1_F2_bound()
        {
            XElement emp3 = emp2.Element("dataC"+indexData);
            textBox25.BackColor = Color.Green;
            textBox26.BackColor = Color.Green;
            textBox31.BackColor = Color.Green;
            if (double.Parse(textBox25.Text) > double.Parse(emp3.Element("d_Sigma_H1max_bound").Value))
            {
                textBox25.BackColor = Color.Red;
            }
            if (double.Parse(textBox26.Text) > double.Parse(emp3.Element("d_Sigma_F1max_bound").Value))
            {
                textBox26.BackColor = Color.Red;
            }
            if (double.Parse(textBox31.Text) > double.Parse(emp3.Element("d_Sigma_F2max_bound").Value))
            {
                textBox31.BackColor = Color.Red;
            }
        }
        void setdata()
        {
            XElement emp3 = emp2.Element("dataC"+indexData);
            emp3.Element("d_Beta_b_angle").Value = textBox23.Text;
            emp3.Element("d_Z_H").Value = textBox27.Text;
            emp3.Element("d_Z_M").Value = textBox28.Text;
            emp3.Element("d_Epsilon_alpha").Value = textBox29.Text;
            emp3.Element("d_Epsilon_beta").Value = textBox30.Text;
            emp3.Element("d_Z_epsilon").Value = textBox1.Text;
            emp3.Element("d_V").Value = textBox2.Text;
            emp3.Element("d_g_o").Value = textBox3.Text;
            emp3.Element("d_delta_H").Value = textBox4.Text;
            emp3.Element("d_V_H").Value = textBox5.Text;
            emp3.Element("d_K_H_alpha").Value = textBox6.Text;
            emp3.Element("d_K_H_beta").Value = textBox9.Text;
            emp3.Element("d_K_H_nu").Value = textBox10.Text;
            emp3.Element("d_Sigma_H").Value = textBox11.Text;
            emp3.Element("d_K_H").Value = textBox12.Text;

            emp3.Element("d_Y_epsilon").Value = textBox13.Text;
            emp3.Element("d_Y_beta").Value = textBox14.Text;
            emp3.Element("d_Y_F1").Value = textBox15.Text;
            emp3.Element("d_Y_F2").Value = textBox16.Text;
            emp3.Element("d_K_F_alpha").Value = textBox17.Text;
            emp3.Element("d_K_F_beta").Value = textBox18.Text;
            emp3.Element("d_delta_F").Value = textBox19.Text;
            emp3.Element("d_V_F").Value = textBox20.Text;
            emp3.Element("d_Sigma_F1").Value = textBox21.Text;
            emp3.Element("d_Sigma_F2").Value = textBox22.Text;
            emp3.Element("d_K_qt").Value = textBox24.Text;
            emp3.Element("d_Sigma_Hmax").Value = textBox25.Text;
            emp3.Element("d_Sigma_F1max").Value = textBox26.Text;
            emp3.Element("d_Sigma_F2max").Value = textBox31.Text;

            emp3.Element("d_CapChinhXac").Value = textBox32.Text;
        }
        void getdata()
        {
            XElement emp3 = emp2.Element("dataC"+indexData);
            textBox23.Text = emp3.Element("d_Beta_b_angle").Value;
            textBox27.Text = emp3.Element("d_Z_H").Value;
            textBox28.Text = emp3.Element("d_Z_M").Value;
            textBox29.Text = emp3.Element("d_Epsilon_alpha").Value;
            textBox30.Text = emp3.Element("d_Epsilon_beta").Value;
            textBox1.Text = emp3.Element("d_Z_epsilon").Value;
            textBox2.Text = emp3.Element("d_V").Value;
            textBox3.Text = emp3.Element("d_g_o").Value;
            textBox4.Text = emp3.Element("d_delta_H").Value;
            textBox5.Text = emp3.Element("d_V_H").Value;
            textBox6.Text = emp3.Element("d_K_H_alpha").Value;
            textBox9.Text = emp3.Element("d_K_H_beta").Value;
            textBox10.Text = emp3.Element("d_K_H_nu").Value;
            textBox11.Text = emp3.Element("d_Sigma_H").Value;
            textBox12.Text = emp3.Element("d_K_H").Value;

            textBox13.Text = emp3.Element("d_Y_epsilon").Value;
            textBox14.Text = emp3.Element("d_Y_beta").Value;
            textBox15.Text = emp3.Element("d_Y_F1").Value;
            textBox16.Text = emp3.Element("d_Y_F2").Value;
            textBox17.Text = emp3.Element("d_K_F_alpha").Value;
            textBox18.Text = emp3.Element("d_K_F_beta").Value;
            textBox19.Text = emp3.Element("d_delta_F").Value;
            textBox20.Text = emp3.Element("d_V_F").Value;
            textBox21.Text = emp3.Element("d_Sigma_F1").Value;
            textBox22.Text = emp3.Element("d_Sigma_F2").Value;
            textBox24.Text = emp3.Element("d_K_qt").Value;
            textBox25.Text = emp3.Element("d_Sigma_Hmax").Value;
            textBox26.Text = emp3.Element("d_Sigma_F1max").Value;
            textBox31.Text = emp3.Element("d_Sigma_F2max").Value;

            textBox32.Text = emp3.Element("d_CapChinhXac").Value;
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            XElement emp3 = emp2.Element("dataC"+indexData);
            Dictionary<string, List<double>> inpdict = new Dictionary<string, List<double>>();
            #region add parameter
            List<double> inplist1 = new List<double>();
            inplist1.Add(double.Parse(emp3.Element("d_HB_1").Value));
            inplist1.Add(double.Parse(emp3.Element("d_HB_2").Value));
            inplist1.Add(double.Parse(emp3.Element("d_cond1").Value));
            inplist1.Add(double.Parse(emp3.Element("d_sigma_ch1").Value));
            inplist1.Add(double.Parse(emp3.Element("d_sigma_ch1").Value));
            inplist1.Add(double.Parse(emp3.Element("d_K_FC").Value));
            inpdict.Add("material", inplist1);

            List<double> inplist2 = new List<double>();
            inplist2.Add(double.Parse(emp1.Element("d_t1").Value));
            inplist2.Add(double.Parse(emp1.Element("d_t2").Value));
            inplist2.Add(double.Parse(emp1.Element("d_T1").Value));
            inplist2.Add(double.Parse(emp1.Element("d_T2").Value));
            inplist2.Add(double.Parse(emp1.Element("d_d_per_y").Value));
            inplist2.Add(double.Parse(emp1.Element("d_shift").Value));
            inplist2.Add(double.Parse(emp1.Element("d_working_hours").Value));
            inpdict.Add("working_time", inplist2);

            List<double> inplist3 = new List<double>();
            inplist3.Add(double.Parse(emp1.Element("d_N_truc2").Value));
            inplist3.Add(double.Parse(emp1.Element("d_N_truc3").Value));
            inplist3.Add(double.Parse(emp1.Element("d_u_2").Value));
            inplist3.Add(double.Parse(emp1.Element("d_T_truc2").Value));
            inpdict.Add("N_M_U_shafts", inplist3);

            List<double> inplist4 = new List<double>();
            inplist4.Add(double.Parse(emp3.Element("d_K_a").Value));
            inplist4.Add(double.Parse(emp3.Element("d_K_d").Value));
            inplist4.Add(double.Parse(emp3.Element("d_psi_ba").Value));
            inplist4.Add(double.Parse(emp3.Element("d_cond2").Value));
            inplist4.Add(double.Parse(emp3.Element("d_cond3").Value));
            inplist4.Add(double.Parse(emp3.Element("d_K_H_beta").Value));
            inplist4.Add(double.Parse(emp3.Element("d_x1").Value));
            inplist4.Add(double.Parse(emp3.Element("d_x2").Value));
            inplist4.Add(double.Parse(emp3.Element("d_k_y").Value));
            inplist4.Add(double.Parse(emp3.Element("d_beta_angle_pre").Value));
            inplist4.Add(double.Parse(emp3.Element("d_alpha_angle").Value));
            inplist4.Add(double.Parse(emp3.Element("d_pre_a_w_modify").Value));
            inplist4.Add(double.Parse(emp3.Element("d_m_modify").Value));
            inplist4.Add(double.Parse(emp3.Element("d_a_w_dc_modify").Value));
            inpdict.Add("spur_wheel", inplist4);

            List<double> inplist5 = new List<double>();
            inplist5.Add(double.Parse(textBox28.Text));
            inplist5.Add(double.Parse(textBox6.Text));
            inplist5.Add(double.Parse(textBox4.Text));
            inplist5.Add(double.Parse(textBox3.Text));
            inpdict.Add("contact", inplist5);

            List<double> inplist6 = new List<double>();
            inplist6.Add(double.Parse(textBox15.Text));
            inplist6.Add(double.Parse(textBox16.Text));
            inplist6.Add(double.Parse(textBox17.Text));
            inplist6.Add(double.Parse(textBox18.Text));
            inplist6.Add(double.Parse(textBox19.Text));
            inplist6.Add(double.Parse(emp1.Element("d_Ti_Tmax_engine").Value));
            inpdict.Add("Durability", inplist6);
            #endregion
            Gear gear = new Gear(inpdict);

            textBox23.Text = Convert.ToString(gear.Beta_b_angle);
            textBox27.Text = Convert.ToString(gear.Z_H);
            textBox29.Text = Convert.ToString(gear.Epsilon_alpha);
            textBox30.Text = Convert.ToString(gear.Epsilon_beta);
            textBox1.Text = Convert.ToString(gear.Z_epsilon);
            textBox2.Text = Convert.ToString(gear.V);

            textBox3.Text = Convert.ToString(go_vHmax_vFmax(tbl_6_16, int.Parse(textBox32.Text)));

            textBox5.Text = Convert.ToString(gear.V_H);
            textBox9.Text = Convert.ToString(gear.K_H_beta);
            textBox10.Text = Convert.ToString(gear.K_H_nu);
            textBox11.Text = Convert.ToString(gear.Sigma_H);
            textBox12.Text = Convert.ToString(gear.K_H);

            textBox13.Text = Convert.ToString(gear.Y_epsilon);
            textBox14.Text = Convert.ToString(gear.Y_beta);
            textBox20.Text = Convert.ToString(gear.V_F);
            textBox21.Text = Convert.ToString(gear.Sigma_F1);
            textBox22.Text = Convert.ToString(gear.Sigma_F2);
            textBox24.Text = Convert.ToString(gear.K_qt);
            textBox25.Text = Convert.ToString(gear.Sigma_Hmax);
            textBox26.Text = Convert.ToString(gear.Sigma_F1max);
            textBox31.Text = Convert.ToString(gear.Sigma_F2max);
            //int.Parse(emp3.Element("d_z_1").Value)

            KHalpha_KFalpha(tbl_6_14, int.Parse(textBox32.Text), to_db(textBox2));
            textBox15.Text = Convert.ToString(Y_F(tbl_6_18, int.Parse(emp3.Element("d_z_1").Value), double.Parse(emp3.Element("d_x1").Value)));
            textBox16.Text = Convert.ToString(Y_F(tbl_6_18, int.Parse(emp3.Element("d_z_2").Value), double.Parse(emp3.Element("d_x2").Value)));
            compare_VF_VH_VFmax_VHmax();
            compare_sigma_H_F1_F2_bound();
            setdata();
            emp2.Save(fileName);
        }

        private void input4_Load(object sender, EventArgs e)
        {

        }
        double to_db(TextBox a)
        {
            return double.Parse(a.Text);
        }
        private void input4_FormClosed(object sender, FormClosedEventArgs e)
        {
            setdata();
            emp2.Save(fileName);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            selectCapChinhXac sCCX = new selectCapChinhXac();
            sCCX.BringToFront();
            //sCCX.mydata = new selectVL_BR.GETDATA(GETVALUE1);
            sCCX.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            selectSigmaH_sigmaF sHF = new selectSigmaH_sigmaF();
            sHF.BringToFront();
            //sCCX.mydata = new selectVL_BR.GETDATA(GETVALUE1);
            sHF.ShowDialog();
        }
    }
}
