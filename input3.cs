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
    public partial class input3 : Form
    {
        string fileName = "dataC2.xml";
        XElement emp2 = XDocument.Load("dataC2.xml").Root;//.Element("dataC0");//.Descendants("dataC2").FirstOrDefault();
        string indexGearData = trangchu.Self.indexGearData.ToString();

        XElement emp1 = XDocument.Load("dataC1.xml").Descendants("dataC1").FirstOrDefault();

        public string cond2;
        public string cond3;
        public string psi_bd;
        public string K_H_beta;
        public static input3 Self;
        public input3()
        {
            
            InitializeComponent();
            Self = this;
            getdata();
        }
        void selectHeSoDichChinh()
        {
            if (double.Parse(textBox3.Text) >= 20)
            {
                textBox9.Text = "0";
                textBox10.Text = "0";
            }
            else if (double.Parse(textBox3.Text) <= 20 && double.Parse(textBox3.Text) >= 14 && double.Parse(emp1.Element("d_u_2").Value) >= 3.5)
            {
                textBox9.Text = "0.3";
                textBox10.Text = "-0.3";
            }
            else if (double.Parse(textBox3.Text) <= 10 && double.Parse(textBox3.Text) >= 30)
            {
                textBox9.Text = "0.5";
                textBox10.Text = "-0.5";
            }
        } 
        double tbl_6_10b(double kx)
        {
            int id = 0;
            double x = 0;
            double y = 0;
            double[] tbl = { 0.009, 0.032, 0.064, 0.122, 0.191, 0.265, 0.350, 0.445, 0.568, 0.702, 0.844, 1.02, 1.18, 1.354, 1.542, 1.752, 1.97, 2.24, 2.445, 2.67, 2.93, 3.215, 3.475, 3.767, 4.07, 4.43, 4.76, 5.07, 5.42, 5.76, 6.12, 6.47, 6.84, 7.19, 7.60, 8.01, 8.4, 8.81, 9.41, 9.67};
            for (int i = 0; i < 40; i++)
            {
                if (kx < tbl[i])
                {
                    id = i + 1;
                    break;
                }
            }
            double a1 = tbl[id - 1];
            double a2 = tbl[id];
            double b1 = id - 1;
            double b2 = id;
            x = (b1 - b2) / (a1 - a2);
            y = b1 - a1 * x;


            return (kx * x + y)*0.01;
        }
        void setdata()
        {
            XElement emp3 = emp2.Element("dataC"+indexGearData);
            emp3.Element("d_K_a").Value = textBox15.Text;
            emp3.Element("d_K_d").Value = textBox16.Text;
            emp3.Element("d_psi_ba").Value = textBox17.Text;
            emp3.Element("d_in_external").Value = comboBox1.Text;
            emp3.Element("d_cond3").Value = textBox21.Text;
            emp3.Element("d_psi_bd").Value = textBox18.Text;
            emp3.Element("d_K_H_beta").Value = textBox19.Text;
            emp3.Element("d_pre_a_w").Value = textBox24.Text;
            emp3.Element("d_pre_a_w_modify").Value = textBox20.Text;

            emp3.Element("d_beta_angle_pre").Value = textBox1.Text;
            emp3.Element("d_m").Value = textBox2.Text;
            emp3.Element("d_m_modify").Value = textBox25.Text;
            emp3.Element("d_z_1").Value = textBox3.Text;
            emp3.Element("d_z_2").Value = textBox4.Text;
            emp3.Element("d_beta_angle").Value = textBox5.Text;
            emp3.Element("d_a_w").Value = textBox6.Text;
            emp3.Element("d_a_w_modify").Value = textBox26.Text;

            emp3.Element("d_x1").Value = textBox9.Text;
            emp3.Element("d_x2").Value = textBox10.Text;
            emp3.Element("d_k_x").Value = textBox11.Text;
            emp3.Element("d_k_y").Value = textBox12.Text;
            emp3.Element("d_delta_y").Value = textBox13.Text;
            emp3.Element("d_a_w_dc").Value = textBox14.Text;
            //
            emp3.Element("d_D_1").Value = textBox31.Text;
            emp3.Element("d_D_2").Value = textBox32.Text;
            emp3.Element("d_D_w1").Value = textBox33.Text;
            emp3.Element("d_D_w2").Value = textBox34.Text;
            emp3.Element("d_D_a1").Value = textBox35.Text;
            emp3.Element("d_D_a2").Value = textBox36.Text;
            emp3.Element("d_D_f1").Value = textBox37.Text;
            emp3.Element("d_D_f2").Value = textBox38.Text;
            emp3.Element("d_D_b1").Value = textBox39.Text;
            emp3.Element("d_D_b2").Value = textBox40.Text;

            textBox23.Text = textBox26.Text;
            textBox27.Text = textBox14.Text;
            emp3.Element("d_alpha_angle").Value = textBox28.Text;
            emp3.Element("d_alpha_t_angle").Value = textBox29.Text;
            emp3.Element("d_alpha_tw_angle").Value = textBox30.Text;
        }
        void getdata()
        {
            XElement emp3 = emp2.Element("dataC"+indexGearData);
            textBox15.Text = emp3.Element("d_K_a").Value;
            textBox16.Text = emp3.Element("d_K_d").Value;
            textBox17.Text = emp3.Element("d_psi_ba").Value;
            comboBox1.Text = emp3.Element("d_in_external").Value;
            textBox21.Text = emp3.Element("d_cond3").Value;
            cond3 = emp3.Element("d_cond3").Value;
            textBox18.Text = emp3.Element("d_psi_bd").Value;
            textBox19.Text = emp3.Element("d_K_H_beta").Value;
            textBox24.Text = emp3.Element("d_pre_a_w").Value;
            textBox20.Text = emp3.Element("d_pre_a_w_modify").Value;

            textBox1.Text = emp3.Element("d_beta_angle_pre").Value;
            textBox2.Text = emp3.Element("d_m").Value;
            textBox25.Text = emp3.Element("d_m_modify").Value;
            textBox3.Text = emp3.Element("d_z_1").Value;
            textBox4.Text = emp3.Element("d_z_2").Value;
            textBox5.Text = emp3.Element("d_beta_angle").Value;
            textBox6.Text = emp3.Element("d_a_w").Value;
            textBox26.Text = emp3.Element("d_a_w_modify").Value;

            textBox9.Text = emp3.Element("d_x1").Value;
            textBox10.Text = emp3.Element("d_x2").Value;
            textBox11.Text = emp3.Element("d_k_x").Value;
            textBox12.Text = emp3.Element("d_k_y").Value;
            textBox13.Text = emp3.Element("d_delta_y").Value;
            textBox14.Text = emp3.Element("d_a_w_dc").Value;
            //
            textBox23.Text = textBox26.Text;
            textBox27.Text = textBox14.Text;
            textBox31.Text = emp3.Element("d_D_1").Value;
            textBox32.Text = emp3.Element("d_D_2").Value;
            textBox33.Text = emp3.Element("d_D_w1").Value;
            textBox34.Text = emp3.Element("d_D_w2").Value;
            textBox35.Text = emp3.Element("d_D_a1").Value;
            textBox36.Text = emp3.Element("d_D_a2").Value;
            textBox37.Text = emp3.Element("d_D_f1").Value;
            textBox38.Text = emp3.Element("d_D_f2").Value;
            textBox39.Text = emp3.Element("d_D_b1").Value;
            textBox40.Text = emp3.Element("d_D_b2").Value;

            textBox28.Text = emp3.Element("d_alpha_angle").Value;
            textBox29.Text = emp3.Element("d_alpha_t_angle").Value;
            textBox30.Text = emp3.Element("d_alpha_tw_angle").Value;
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            XElement emp3 = emp2.Element("dataC"+indexGearData);
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
            inplist4.Add(double.Parse(textBox15.Text));
            inplist4.Add(double.Parse(textBox16.Text));
            inplist4.Add(double.Parse(textBox17.Text));
            inplist4.Add(double.Parse(cond2));
            inplist4.Add(double.Parse(cond3));
            inplist4.Add(double.Parse(textBox19.Text));
            inplist4.Add(double.Parse(textBox9.Text));
            inplist4.Add(double.Parse(textBox10.Text));
            inplist4.Add(double.Parse(textBox12.Text));
            inplist4.Add(double.Parse(textBox1.Text));
            inplist4.Add(double.Parse(textBox28.Text));
            inplist4.Add(double.Parse(textBox20.Text));
            inplist4.Add(double.Parse(textBox25.Text));
            inplist4.Add(double.Parse(textBox26.Text));
            inpdict.Add("spur_wheel", inplist4);

            List<double> inplist5 = new List<double>();
            inplist5.Add(double.Parse(emp3.Element("d_Z_M").Value));
            inplist5.Add(double.Parse(emp3.Element("d_K_H_alpha").Value));
            inplist5.Add(double.Parse(emp3.Element("d_delta_H").Value));
            inplist5.Add(double.Parse(emp3.Element("d_g_o").Value));
            inpdict.Add("contact", inplist5);

            List<double> inplist6 = new List<double>();
            inplist6.Add(double.Parse(emp3.Element("d_Y_F1").Value));
            inplist6.Add(double.Parse(emp3.Element("d_Y_F2").Value));
            inplist6.Add(double.Parse(emp3.Element("d_K_F_alpha").Value));
            inplist6.Add(double.Parse(emp3.Element("d_K_F_beta").Value));
            inplist6.Add(double.Parse(emp3.Element("d_delta_F").Value));
            inplist6.Add(double.Parse(emp1.Element("d_Ti_Tmax_engine").Value));
            inpdict.Add("Durability", inplist6);
            #endregion
            Gear gear = new Gear(inpdict);
            //selectHeSoDichChinh();
            textBox15.Text = Convert.ToString(gear.K_a);
            textBox16.Text = Convert.ToString(gear.K_d);
            textBox17.Text = Convert.ToString(gear.Psi_ba);
            textBox18.Text = Convert.ToString(gear.Psi_bd);
            textBox19.Text = Convert.ToString(gear.K_H_beta);
            textBox24.Text = gear.A_w_pre;
            textBox1.Text = Convert.ToString(gear.Beta_angle_pre);
            textBox2.Text = gear.M;
            textBox3.Text = Convert.ToString(gear.Z1);
            textBox4.Text = Convert.ToString(gear.Z2);
            textBox5.Text = Convert.ToString(gear.Beta_angle);
            textBox6.Text = gear.A_w;
            textBox11.Text = Convert.ToString(gear.K_x);
            
            textBox13.Text = Convert.ToString(gear.Delta_y);
            textBox14.Text = Convert.ToString(gear.A_w_dc);
            //
            textBox23.Text = textBox26.Text;
            textBox27.Text = textBox14.Text;
            textBox31.Text = Convert.ToString(gear.D1);
            textBox32.Text = Convert.ToString(gear.D2);
            textBox33.Text = Convert.ToString(gear.D_w1);
            textBox34.Text = Convert.ToString(gear.D_w2);
            textBox35.Text = Convert.ToString(gear.D_a1);
            textBox36.Text = Convert.ToString(gear.D_a2);
            textBox37.Text = Convert.ToString(gear.D_f1);
            textBox38.Text = Convert.ToString(gear.D_f2);
            textBox39.Text = Convert.ToString(gear.D_b1);
            textBox40.Text = Convert.ToString(gear.D_b2);

            textBox29.Text = Convert.ToString(gear.Alpha_t_angle);
            textBox30.Text = Convert.ToString(gear.Alpha_tw_angle);
            //

            //textBox12.Text = Convert.ToString(tbl_6_10b(double.Parse(textBox11.Text)));
            psi_bd = textBox18.Text;
            setdata();
            emp2.Save(fileName);
        }

        private void input3_Load(object sender, EventArgs e)
        {
        }
        double to_db(TextBox a)
        {
            return double.Parse(a.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void input3_FormClosed(object sender, FormClosedEventArgs e)
        {
            setdata();
            emp2.Save(fileName);
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            XElement emp3 = emp2.Element("dataC"+indexGearData);
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == "Ăn khớp ngoài") 
            {
                cond2 = "0";
                emp3.Element("d_cond2").Value = cond2;
            }  
            else 
            {
                cond2 = "1";
                emp3.Element("d_cond2").Value = cond2;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            selectKa_Kd_ZM slVL = new selectKa_Kd_ZM();
            slVL.BringToFront();
            slVL.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            selectViTriAnKhop slVL = new selectViTriAnKhop();
            slVL.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PartModel getSolidworks = new PartModel();
            getSolidworks.CreatePart();
        }
    }
}
