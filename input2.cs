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
    public partial class input2 : Form
    {

        string fileName = "dataC2.xml" ;
        XElement emp2 = XDocument.Load("dataC2.xml").Root;
        string indexData = trangchu.Self.indexGearData.ToString();

        XElement emp1 = XDocument.Load("dataC1.xml").Descendants("dataC1").FirstOrDefault();
        public input2()
        {
            InitializeComponent();
            getdata();
        }
        void setdata()
        {
            XElement emp3 = emp2.Element("dataC"+indexData);
            emp3.Element("d_VL1").Value = textBox33.Text;
            emp3.Element("d_NhietLuyen1").Value = textBox34.Text;
            emp3.Element("d_VL2").Value = textBox35.Text;
            emp3.Element("d_NhietLuyen2").Value = textBox36.Text;

            emp3.Element("d_HB_1").Value = textBox1.Text;
            emp3.Element("d_HB_2").Value = textBox4.Text;
            emp3.Element("d_sigma_b1").Value = textBox2.Text;
            emp3.Element("d_sigma_b2").Value = textBox5.Text;
            emp3.Element("d_sigma_ch1").Value = textBox3.Text;
            emp3.Element("d_sigma_ch2").Value = textBox6.Text;
            emp3.Element("d_K_FC").Value = textBox32.Text;
            emp3.Element("d_K_FC_cond").Value = comboBox1.Text;

            //emp3.Element("d_cond1").Value = textBox31.Text;
            emp3.Element("d_sigma_Hlim1").Value = textBox7.Text;
            emp3.Element("d_sigma_Hlim2").Value = textBox8.Text;
            emp3.Element("d_sigma_Flim1").Value = textBox9.Text;
            emp3.Element("d_sigma_Flim2").Value = textBox10.Text;
            emp3.Element("d_N_HO1").Value = textBox11.Text;
            emp3.Element("d_N_HO2").Value = textBox12.Text;
            emp3.Element("d_N_FO1").Value = textBox13.Text;
            emp3.Element("d_N_FO2").Value = textBox14.Text;
            emp3.Element("d_N_HE1").Value = textBox15.Text;
            emp3.Element("d_N_HE2").Value = textBox16.Text;
            emp3.Element("d_N_FE1").Value = textBox17.Text;
            emp3.Element("d_N_FE2").Value = textBox18.Text;

            emp3.Element("d_K_HL1").Value = textBox19.Text;
            emp3.Element("d_K_HL2").Value = textBox20.Text;
            emp3.Element("d_K_FL1").Value = textBox21.Text;
            emp3.Element("d_K_FL2").Value = textBox22.Text;
            emp3.Element("d_Sigma_H1_bound").Value = textBox23.Text;
            emp3.Element("d_Sigma_H2_bound").Value = textBox24.Text;
            emp3.Element("d_Sigma_F1_bound").Value = textBox25.Text;
            emp3.Element("d_Sigma_F2_bound").Value = textBox26.Text;
            emp3.Element("d_Sigma_H1max_bound").Value = textBox27.Text;
            emp3.Element("d_Sigma_H2max_bound").Value = textBox28.Text;
            emp3.Element("d_Sigma_F1max_bound").Value = textBox29.Text;
            emp3.Element("d_Sigma_F2max_bound").Value = textBox30.Text;
        }
        void getdata()
        {
            XElement emp3 = emp2.Element("dataC"+indexData);
            textBox33.Text = emp3.Element("d_VL1").Value;
            textBox34.Text = emp3.Element("d_NhietLuyen1").Value;
            textBox35.Text = emp3.Element("d_VL2").Value;
            textBox36.Text = emp3.Element("d_NhietLuyen2").Value;

            textBox1.Text = emp3.Element("d_HB_1").Value;
            textBox4.Text = emp3.Element("d_HB_2").Value;
            textBox2.Text = emp3.Element("d_sigma_b1").Value;
            textBox5.Text = emp3.Element("d_sigma_b2").Value;
            textBox3.Text = emp3.Element("d_sigma_ch1").Value;
            textBox6.Text = emp3.Element("d_sigma_ch2").Value;
            textBox32.Text = emp3.Element("d_K_FC").Value;
            comboBox1.Text = emp3.Element("d_K_FC_cond").Value;

            //textBox31.Text = emp3.Element("d_cond1").Value;
            textBox7.Text = emp3.Element("d_sigma_Hlim1").Value;
            textBox8.Text = emp3.Element("d_sigma_Hlim2").Value;
            textBox9.Text = emp3.Element("d_sigma_Flim1").Value;
            textBox10.Text = emp3.Element("d_sigma_Flim2").Value;
            textBox11.Text = emp3.Element("d_N_HO1").Value;
            textBox12.Text = emp3.Element("d_N_HO2").Value;
            textBox13.Text = emp3.Element("d_N_FO1").Value;
            textBox14.Text = emp3.Element("d_N_FO2").Value;
            textBox15.Text = emp3.Element("d_N_HE1").Value;
            textBox16.Text = emp3.Element("d_N_HE2").Value;
            textBox17.Text = emp3.Element("d_N_FE1").Value;
            textBox18.Text = emp3.Element("d_N_FE2").Value;

            textBox19.Text = emp3.Element("d_K_HL1").Value;
            textBox20.Text = emp3.Element("d_K_HL2").Value;
            textBox21.Text = emp3.Element("d_K_FL1").Value;
            textBox22.Text = emp3.Element("d_K_FL2").Value;
            textBox23.Text = emp3.Element("d_Sigma_H1_bound").Value;
            textBox24.Text = emp3.Element("d_Sigma_H2_bound").Value;
            textBox25.Text = emp3.Element("d_Sigma_F1_bound").Value;
            textBox26.Text = emp3.Element("d_Sigma_F2_bound").Value;
            textBox27.Text = emp3.Element("d_Sigma_H1max_bound").Value;
            textBox28.Text = emp3.Element("d_Sigma_H2max_bound").Value;
            textBox29.Text = emp3.Element("d_Sigma_F1max_bound").Value;
            textBox30.Text = emp3.Element("d_Sigma_F2max_bound").Value;
        }

        public double cond1()
        {
            string text33 = textBox33.Text;
            string text34 = textBox34.Text;
            if ((text33 == "40" || text33 == "45" || text33 == "40X" || text33 == "40XH" || text33 == "35XM") && (text34 == "Thường hoá" || text34 == "Tôi cải thiện")) return 0;
            else if ((text33 != "40" || text33 != "45" || text33 != "50") && (text34 == "Tôi thể tích")) return 1;
            else if ((text33 != "40" || text33 != "45" || text33 != "50") && (text34 == "Tôi bề mặt (mn >= 3mmm)")) return 2;
            else if ((text33 != "40" || text33 != "45" || text33 != "50") && (text34 == "Tôi bề mặt (mn < 3mmm)")) return 3;
            else if ((text33 != "40" || text33 != "45" || text33 != "50") && (text34 == "Thấm nitơ")) return 4;
            else if ((text33 != "40" || text33 != "45" || text33 != "50") && (text34 == "Thấm cacbon, Tôi")) return 5;
            else if ((text33 != "40" || text33 != "45" || text33 != "50") && (text34 == "Thấm cacbon, Thấm nitơ, Tôi")) return 6;
            else if ((text33 != "40" || text33 != "45" || text33 != "50") && (text34 == "Thấm cacbon, Thấm nitơ, Tôi")) return 7;
            else return 0;
        }
        
        public void GETVALUE1(string[] value)
        {
            textBox33.Text = value[0];
            textBox34.Text = value[1];
            textBox1.Text = value[2];
            textBox2.Text = value[3];
            textBox3.Text = value[4];
        }
        public void GETVALUE2(string[] value)
        {
            textBox35.Text = value[0];
            textBox36.Text = value[1];
            textBox4.Text = value[2];
            textBox5.Text = value[3];
            textBox6.Text = value[4];
        }
        private void btn1_Click(object sender, EventArgs e)
        {

            XElement emp3 = emp2.Element("dataC"+indexData);
            Dictionary<string, List<double>> inpdict = new Dictionary<string, List<double>>();
            #region add parameter
            List<double> inplist1 = new List<double>();
            inplist1.Add(to_db(textBox1));
            inplist1.Add(to_db(textBox4));
            inplist1.Add(cond1());
            inplist1.Add(to_db(textBox3));
            inplist1.Add(to_db(textBox6));
            inplist1.Add(to_db(textBox32));
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
            inplist3.Add(double.Parse(emp1.Element("d_u_1").Value));
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
            inplist6.Add(double.Parse(emp1.Element("d_Ti_Tmax_engine").Value));
            inpdict.Add("Durability", inplist6);
            #endregion
            Gear gear = new Gear(inpdict);

            textBox7.Text = Convert.ToString(gear.Sigma_Hlim1);
            textBox8.Text = Convert.ToString(gear.Sigma_Hlim2);
            textBox9.Text = Convert.ToString(gear.Sigma_Flim1);
            textBox10.Text = Convert.ToString(gear.Sigma_Flim2);
            textBox11.Text = Convert.ToString(gear.N_HO1);
            textBox12.Text = Convert.ToString(gear.N_HO2);
            textBox15.Text = Convert.ToString(gear.N_HE1);
            textBox16.Text = Convert.ToString(gear.N_HE2);
            textBox17.Text = Convert.ToString(gear.N_FE1);
            textBox18.Text = Convert.ToString(gear.N_FE2);

            textBox19.Text = Convert.ToString(gear.K_HL1);
            textBox20.Text = Convert.ToString(gear.K_HL2);
            textBox21.Text = Convert.ToString(gear.K_FL1);
            textBox22.Text = Convert.ToString(gear.K_FL2);
            textBox23.Text = Convert.ToString(gear.Sigma_H1_bound);
            textBox24.Text = Convert.ToString(gear.Sigma_H2_bound);
            textBox25.Text = Convert.ToString(gear.Sigma_F1_bound);
            textBox26.Text = Convert.ToString(gear.Sigma_F2_bound);
            textBox27.Text = Convert.ToString(gear.Sigma_H1max_bound);
            textBox28.Text = Convert.ToString(gear.Sigma_H2max_bound);
            textBox29.Text = Convert.ToString(gear.Sigma_F1max_bound);
            textBox30.Text = Convert.ToString(gear.Sigma_F2max_bound);
            setdata();
            emp2.Save(fileName);
        }

        double to_db(TextBox a)
        {
            return double.Parse(a.Text);
        }
        private void button2_Click(object sender, EventArgs e)
        {            
            this.Close();
        }

        private void input2_FormClosed(object sender, FormClosedEventArgs e)
        {
            XElement emp3 = emp2.Element("dataC"+indexData);
            setdata();
            emp2.Save(fileName);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            selectVL_BR slVL = new selectVL_BR();
            slVL.BringToFront();
            slVL.mydata = new selectVL_BR.GETDATA(GETVALUE1);
            slVL.ShowDialog();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            selectVL_BR slVL = new selectVL_BR();
            slVL.BringToFront();
            slVL.mydata = new selectVL_BR.GETDATA(GETVALUE2);
            slVL.ShowDialog();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == "Tải một phía")
            {
                textBox32.Text = "0,7";
            }
            else textBox32.Text = "0,8";

        }
    }
}
