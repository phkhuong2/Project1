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
    public partial class input5 : Form
    {
        string fileName = "dataC2.xml";

        XElement emp2 = XDocument.Load("dataC2.xml").Root;
        string indexData = trangchu.Self.indexGearData.ToString();

        XElement emp1 = XDocument.Load("dataC1.xml").Descendants("dataC1").FirstOrDefault();

        public input5()
        {
            InitializeComponent();
            getdata(); 
        }
        void setdata()
        {
            XElement emp3 = emp2.Element("dataC" + indexData);
            emp3.Element("K_R_pre").Value = textBox23.Text;
            emp3.Element("R_e_pre").Value = textBox27.Text;
            emp3.Element("D_e1_pre").Value = textBox28.Text;
            emp3.Element("Z1").Value = textBox29.Text;
            emp3.Element("Z2").Value = textBox38.Text;
            emp3.Element("D_m1_pre").Value = textBox30.Text;
            emp3.Element("M_tm").Value = textBox1.Text;
            emp3.Element("M_te").Value = textBox2.Text;
            emp3.Element("M_tm_new1").Value = textBox3.Text;
            emp3.Element("D_m1_new1").Value = textBox4.Text;

            emp3.Element("R_e").Value = textBox5.Text;
            emp3.Element("B").Value = textBox6.Text;
            emp3.Element("R_m").Value = textBox7.Text;
            emp3.Element("D_e1").Value = textBox8.Text;
            emp3.Element("D_e2").Value = textBox9.Text;
            emp3.Element("Bevel_angle1").Value = textBox10.Text;
            emp3.Element("Bevel_angle2").Value = textBox11.Text;
            emp3.Element("H_e").Value = textBox12.Text;
            emp3.Element("H_ae1").Value = textBox13.Text;
            emp3.Element("H_ae2").Value = textBox14.Text;
            emp3.Element("H_fe1").Value = textBox15.Text;
            emp3.Element("H_fe2").Value = textBox16.Text;
            emp3.Element("D_ae1").Value = textBox17.Text;
            emp3.Element("D_ae2").Value = textBox18.Text;

            emp3.Element("S_e1").Value = textBox19.Text;
            emp3.Element("S_e2").Value = textBox20.Text;
            emp3.Element("Pin_f1_angle").Value = textBox21.Text;
            emp3.Element("Pin_f2_angle").Value = textBox22.Text;
            emp3.Element("Bevel_a1_angle").Value = textBox24.Text;
            emp3.Element("Bevel_a2_angle").Value = textBox25.Text;
            emp3.Element("Bevel_f1_angle").Value = textBox26.Text;
            emp3.Element("Bevel_f2_angle").Value = textBox31.Text;
            emp3.Element("D_m1").Value = textBox32.Text;
            emp3.Element("D_m2").Value = textBox33.Text;
            emp3.Element("B1").Value = textBox34.Text;
            emp3.Element("B2").Value = textBox35.Text;
            emp3.Element("M_tm").Value = textBox36.Text;
            emp3.Element("M_nm").Value = textBox37.Text;

            emp3.Element("d_K_be").Value = textBox39.Text;
            emp3.Element("d_z1p").Value = textBox40.Text;
            emp3.Element("d_beta_m_angle").Value = textBox41.Text;
            emp3.Element("d_x_n1").Value = textBox42.Text;
            emp3.Element("d_x_t1").Value = textBox48.Text;
            emp3.Element("d_alpha_n_angle").Value = textBox47.Text;
            emp3.Element("d_K_d").Value = textBox43.Text;
            emp3.Element("d_M_te_new1").Value = textBox44.Text;
        }
        void getdata()
        {
            XElement emp3 = emp2.Element("dataC" + indexData);
            textBox23.Text = emp3.Element("K_R_pre").Value;
            textBox27.Text = emp3.Element("R_e_pre").Value;
            textBox28.Text = emp3.Element("D_e1_pre").Value;
            textBox29.Text = emp3.Element("Z1").Value;
            textBox38.Text = emp3.Element("Z2").Value;
            textBox30.Text = emp3.Element("D_m1_pre").Value;
            textBox1.Text = emp3.Element("M_tm").Value;
            textBox2.Text = emp3.Element("M_te").Value;
            textBox3.Text = emp3.Element("M_tm_new1").Value;
            textBox4.Text = emp3.Element("D_m1_new1").Value;

            textBox5.Text = emp3.Element("R_e").Value;
            textBox6.Text = emp3.Element("B").Value;
            textBox7.Text = emp3.Element("R_m").Value;
            textBox8.Text = emp3.Element("D_e1").Value;
            textBox9.Text = emp3.Element("D_e2").Value;
            textBox10.Text = emp3.Element("Bevel_angle1").Value;
            textBox11.Text = emp3.Element("Bevel_angle2").Value;
            textBox12.Text = emp3.Element("H_e").Value;
            textBox13.Text = emp3.Element("H_ae1").Value;
            textBox14.Text = emp3.Element("H_ae2").Value;
            textBox15.Text = emp3.Element("H_fe1").Value;
            textBox16.Text = emp3.Element("H_fe2").Value;
            textBox17.Text = emp3.Element("D_ae1").Value;
            textBox18.Text = emp3.Element("D_ae2").Value;

            textBox19.Text = emp3.Element("S_e1").Value;
            textBox20.Text = emp3.Element("S_e2").Value;
            textBox21.Text = emp3.Element("Pin_f1_angle").Value;
            textBox22.Text = emp3.Element("Pin_f2_angle").Value;
            textBox24.Text = emp3.Element("Bevel_a1_angle").Value;
            textBox25.Text = emp3.Element("Bevel_a2_angle").Value;
            textBox26.Text = emp3.Element("Bevel_f1_angle").Value;
            textBox31.Text = emp3.Element("Bevel_f2_angle").Value;
            textBox32.Text = emp3.Element("D_m1").Value;
            textBox33.Text = emp3.Element("D_m2").Value;
            textBox34.Text = emp3.Element("B1").Value;
            textBox35.Text = emp3.Element("B2").Value;
            textBox36.Text = emp3.Element("M_tm").Value;
            textBox37.Text = emp3.Element("M_nm").Value;

            textBox39.Text = emp3.Element("d_K_be").Value ;
            textBox40.Text = emp3.Element("d_z1p").Value  ;
            textBox41.Text = emp3.Element("d_beta_m_angle").Value  ;
            textBox42.Text = emp3.Element("d_x_n1").Value ;
            textBox48.Text = emp3.Element("d_x_t1").Value ;
            textBox47.Text = emp3.Element("d_alpha_n_angle").Value ;
            textBox43.Text = emp3.Element("d_K_d").Value;
            textBox44.Text = emp3.Element("d_M_te_new1").Value;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            XElement emp3 = emp2.Element("dataC" + indexData);
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
            inplist6.Add(double.Parse(emp3.Element("d_Ti_Tmax_engine").Value));
            inpdict.Add("Durability", inplist6);

            List<double> inplist7 = new List<double>();
            inplist7.Add(double.Parse(textBox39.Text));
            inplist7.Add(double.Parse(textBox40.Text));
            inplist7.Add(double.Parse(textBox41.Text));
            inplist7.Add(double.Parse(textBox42.Text));
            inplist7.Add(double.Parse(textBox48.Text));
            inplist7.Add(double.Parse(textBox47.Text));
            inplist7.Add(double.Parse(textBox43.Text));
            inplist7.Add(double.Parse(textBox44.Text));
            inpdict.Add("Bevel_Gear", inplist7);
            #endregion
            Bevel_Gear bevel_Gear = new Bevel_Gear(inpdict);
            textBox23.Text = Convert.ToString(bevel_Gear.K_R_pre);
            textBox27.Text = Convert.ToString(bevel_Gear.R_e_pre);
            textBox28.Text = Convert.ToString(bevel_Gear.D_e1_pre);
            textBox29.Text = Convert.ToString(bevel_Gear.Z1);
            textBox38.Text = Convert.ToString(bevel_Gear.Z2);
            textBox30.Text = Convert.ToString(bevel_Gear.D_m1_pre);
            textBox1.Text = Convert.ToString(bevel_Gear.M_tm);
            textBox2.Text = Convert.ToString(bevel_Gear.M_te);
            textBox3.Text = Convert.ToString(bevel_Gear.M_tm_new1);
            textBox4.Text = Convert.ToString(bevel_Gear.D_m1_new1);

            textBox5.Text = Convert.ToString(bevel_Gear.R_e);
            textBox6.Text = Convert.ToString(bevel_Gear.B);
            textBox7.Text = Convert.ToString(bevel_Gear.R_m);
            textBox8.Text = Convert.ToString(bevel_Gear.D_e1);
            textBox9.Text = Convert.ToString(bevel_Gear.D_e2);
            textBox10.Text = Convert.ToString(bevel_Gear.Bevel_angle1);
            textBox11.Text = Convert.ToString(bevel_Gear.Bevel_angle2);
            textBox12.Text = Convert.ToString(bevel_Gear.H_e);
            textBox13.Text = Convert.ToString(bevel_Gear.H_ae1);
            textBox14.Text = Convert.ToString(bevel_Gear.H_ae2);
            textBox15.Text = Convert.ToString(bevel_Gear.H_fe1);
            textBox16.Text = Convert.ToString(bevel_Gear.H_fe2);
            textBox17.Text = Convert.ToString(bevel_Gear.D_ae1);
            textBox18.Text = Convert.ToString(bevel_Gear.D_ae2);

            textBox19.Text = Convert.ToString(bevel_Gear.S_e1);
            textBox20.Text = Convert.ToString(bevel_Gear.S_e2);
            textBox21.Text = Convert.ToString(bevel_Gear.Pin_f1_angle);
            textBox22.Text = Convert.ToString(bevel_Gear.Pin_f2_angle);
            textBox24.Text = Convert.ToString(bevel_Gear.Bevel_a1_angle);
            textBox25.Text = Convert.ToString(bevel_Gear.Bevel_a2_angle);
            textBox26.Text = Convert.ToString(bevel_Gear.Bevel_f1_angle);
            textBox31.Text = Convert.ToString(bevel_Gear.Bevel_f2_angle);
            textBox32.Text = Convert.ToString(bevel_Gear.D_m1);
            textBox33.Text = Convert.ToString(bevel_Gear.D_m2);
            textBox34.Text = Convert.ToString(bevel_Gear.B1);
            textBox35.Text = Convert.ToString(bevel_Gear.B2);
            textBox36.Text = Convert.ToString(bevel_Gear.M_tm);
            textBox37.Text = Convert.ToString(bevel_Gear.M_nm);

            setdata();
            emp2.Save(fileName);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void input5_FormClosed(object sender, FormClosedEventArgs e)
        {
            setdata();
            emp2.Save(fileName);
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "bánh côn răng thẳng")
            {
                textBox43.Text = "100";
            }
            else if (comboBox1.Text == "bánh côn răng tiếp tuyến")
            {
                textBox43.Text = "87";
            }
            else
            {
                textBox43.Text = "83,5";
            }
        }
    }
}
