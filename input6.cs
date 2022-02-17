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
    public partial class input6 : Form
    {
        string fileName = "dataC3.xml";
        XElement emp2 = XDocument.Load("dataC3.xml").Root;

        XElement emp1 = XDocument.Load("dataC1.xml").Descendants("dataC1").FirstOrDefault();



        public static input6 Self;
        public input6()
        {
            InitializeComponent();
            Self = this;
            getdata();
        }

        private void input6_Load(object sender, EventArgs e)
        {
            
        }
        void setdata()
        {
            XElement emp3 = emp2.Element("dataC" + "0");
            emp3.Element("loaidai").Value = dataGridView1.Rows[0].Cells[0].Value.ToString();
            emp3.Element("kyhieudai").Value = dataGridView1.Rows[0].Cells[1].Value.ToString();
            emp3.Element("b_t").Value = dataGridView1.Rows[0].Cells[2].Value.ToString();
            emp3.Element("b_belt").Value = dataGridView1.Rows[0].Cells[3].Value.ToString();
            emp3.Element("h").Value = dataGridView1.Rows[0].Cells[4].Value.ToString();
            emp3.Element("y0").Value = dataGridView1.Rows[0].Cells[5].Value.ToString();
            emp3.Element("area").Value = dataGridView1.Rows[0].Cells[6].Value.ToString();
            emp3.Element("d1_bound").Value = dataGridView1.Rows[0].Cells[7].Value.ToString();
            emp3.Element("l_bound").Value = dataGridView1.Rows[0].Cells[8].Value.ToString();
            emp3.Element("l0").Value = dataGridView1.Rows[0].Cells[9].Value.ToString();

            emp3.Element("d1").Value = textBox9.Text;
            emp3.Element("d1_modify").Value = textBox43.Text;
            emp3.Element("v").Value = textBox1.Text;
            emp3.Element("epxilon").Value = textBox2.Text;
            emp3.Element("d2").Value = textBox3.Text;
            emp3.Element("d2_modify").Value = textBox23.Text;
            emp3.Element("a_d2").Value = textBox4.Text;
            emp3.Element("a_pre").Value = textBox5.Text;
            emp3.Element("a_bound").Value = textBox10.Text;
            emp3.Element("l_pre").Value = textBox22.Text;
            emp3.Element("a").Value = textBox7.Text;
            emp3.Element("l").Value = textBox6.Text;
            emp3.Element("alpha1_angle").Value = textBox8.Text;
            emp3.Element("z").Value = textBox17.Text;
            emp3.Element("p0").Value = textBox11.Text;
            emp3.Element("k_d").Value = textBox12.Text;
            emp3.Element("c_alpha").Value = textBox13.Text;
            emp3.Element("c_l").Value = textBox14.Text;
            emp3.Element("c_u").Value = textBox15.Text;
            emp3.Element("c_z").Value = textBox16.Text;
            emp3.Element("t").Value = dataGridView3.Rows[0].Cells[2].Value.ToString();
            emp3.Element("e").Value = dataGridView3.Rows[0].Cells[3].Value.ToString();
            emp3.Element("h0").Value = dataGridView3.Rows[0].Cells[1].Value.ToString();
            emp3.Element("b_belt_whee").Value = dataGridView4.Rows[0].Cells[1].Value.ToString();
            emp3.Element("d_a1").Value = dataGridView4.Rows[0].Cells[2].Value.ToString();
            emp3.Element("d_a2").Value = dataGridView4.Rows[0].Cells[3].Value.ToString();
            emp3.Element("q_m").Value = textBox18.Text;
            emp3.Element("f_v").Value = textBox19.Text;
            emp3.Element("f_o").Value = textBox20.Text;
            emp3.Element("f_r").Value = textBox21.Text;

        }
        void getdata()
        {
            XElement emp3 = emp2.Element("dataC" + "0");

            dataGridView1.Rows[0].Cells[0].Value = emp3.Element("loaidai").Value;
            dataGridView1.Rows[0].Cells[1].Value = emp3.Element("kyhieudai").Value;
            dataGridView1.Rows[0].Cells[2].Value = emp3.Element("b_t").Value;
            dataGridView1.Rows[0].Cells[3].Value = emp3.Element("b_belt").Value;
            dataGridView1.Rows[0].Cells[4].Value = emp3.Element("h").Value;
            dataGridView1.Rows[0].Cells[5].Value = emp3.Element("y0").Value;
            dataGridView1.Rows[0].Cells[6].Value = emp3.Element("area").Value;
            dataGridView1.Rows[0].Cells[7].Value = emp3.Element("d1_bound").Value;
            dataGridView1.Rows[0].Cells[8].Value = emp3.Element("l_bound").Value;
            dataGridView1.Rows[0].Cells[9].Value = emp3.Element("l0").Value;

            textBox9.Text = emp3.Element("d1").Value;
            textBox43.Text = emp3.Element("d1_modify").Value;
            textBox1.Text = emp3.Element("v").Value;
            textBox2.Text = emp3.Element("epxilon").Value;
            textBox3.Text = emp3.Element("d2").Value;
            textBox23.Text = emp3.Element("d2_modify").Value;
            textBox4.Text = emp3.Element("a_d2").Value;
            textBox5.Text = emp3.Element("a_pre").Value;
            textBox10.Text = emp3.Element("a_bound").Value;
            textBox7.Text = emp3.Element("a").Value;
            textBox6.Text = emp3.Element("l").Value;
            textBox8.Text = emp3.Element("alpha1_angle").Value;
            textBox17.Text = emp3.Element("z").Value;
            textBox11.Text = emp3.Element("p0").Value;
            textBox12.Text = emp3.Element("k_d").Value;
            textBox13.Text = emp3.Element("c_alpha").Value;
            textBox14.Text = emp3.Element("c_l").Value;
            textBox15.Text = emp3.Element("c_u").Value;
            textBox16.Text = emp3.Element("c_z").Value;
            dataGridView3.Rows[0].Cells[0].Value = emp3.Element("kyhieudai").Value;
            dataGridView3.Rows[0].Cells[2].Value = emp3.Element("t").Value;
            dataGridView3.Rows[0].Cells[3].Value = emp3.Element("e").Value;
            dataGridView3.Rows[0].Cells[1].Value = emp3.Element("h0").Value;
            dataGridView4.Rows[0].Cells[0].Value = emp3.Element("z").Value;
            dataGridView4.Rows[0].Cells[1].Value = emp3.Element("b_belt_whee").Value;
            dataGridView4.Rows[0].Cells[2].Value = emp3.Element("d_a1").Value;
            dataGridView4.Rows[0].Cells[3].Value = emp3.Element("d_a2").Value;
            textBox18.Text = emp3.Element("q_m").Value;
            textBox19.Text = emp3.Element("f_v").Value;
            textBox20.Text = emp3.Element("f_o").Value;
            textBox21.Text = emp3.Element("f_r").Value;

            dataGridView2.Rows[0].Cells[0].Value = emp3.Element("d1_modify").Value;
            dataGridView2.Rows[0].Cells[1].Value = emp3.Element("d2").Value;
            dataGridView2.Rows[0].Cells[2].Value = emp3.Element("a").Value;
            dataGridView2.Rows[0].Cells[3].Value = emp3.Element("l").Value;
            dataGridView2.Rows[0].Cells[4].Value = emp3.Element("alpha1_angle").Value;
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            Dictionary<string, double> inpdict = new Dictionary<string, double>();
            #region add parameter

            inpdict.Add("l0", double.Parse(dataGridView1.Rows[0].Cells[9].Value.ToString()));
            inpdict.Add("d1_modify", double.Parse(textBox43.Text));
            inpdict.Add("t_shaft", double.Parse(emp1.Element("d_T_truc1").Value));
            inpdict.Add("n_shaft", double.Parse(emp1.Element("d_N_dc").Value));
            inpdict.Add("u_shaft", double.Parse(emp1.Element("d_u_d").Value));
            inpdict.Add("a_d2", double.Parse(textBox4.Text));
            inpdict.Add("epxilon", double.Parse(textBox2.Text));
            inpdict.Add("d2_modify", double.Parse(textBox23.Text));
            inpdict.Add("l", double.Parse(textBox6.Text));
            inpdict.Add("p_dc", double.Parse(emp1.Element("d_P_dc").Value));
            inpdict.Add("p0", double.Parse(textBox11.Text));
            inpdict.Add("k_d", double.Parse(textBox12.Text));
            inpdict.Add("c_alpha", double.Parse(textBox13.Text));
            inpdict.Add("c_l", double.Parse(textBox14.Text));
            inpdict.Add("c_u", double.Parse(textBox15.Text));
            inpdict.Add("c_z", double.Parse(textBox16.Text));
            inpdict.Add("t", double.Parse(dataGridView3.Rows[0].Cells[2].Value.ToString()));
            inpdict.Add("e", double.Parse(dataGridView3.Rows[0].Cells[3].Value.ToString()));
            inpdict.Add("h0", double.Parse(dataGridView3.Rows[0].Cells[1].Value.ToString()));
            inpdict.Add("q_m", double.Parse(textBox18.Text));
            #endregion
            Belt_Drive belt_Drive = new Belt_Drive(inpdict);
            textBox9.Text = belt_Drive.D1;
            textBox1.Text = Convert.ToString(belt_Drive.V);
            textBox3.Text = Convert.ToString(belt_Drive.D2);
            textBox10.Text = Convert.ToString(belt_Drive.A_bound);
            textBox5.Text = Convert.ToString(belt_Drive.A_pre);
            textBox22.Text = Convert.ToString(belt_Drive.L_pre);
            textBox7.Text = Convert.ToString(belt_Drive.A);
            textBox8.Text = Convert.ToString(belt_Drive.Alpha1_angle);

            dataGridView2.Rows[0].Cells[0].Value = belt_Drive.D1_modify;
            dataGridView2.Rows[0].Cells[1].Value = belt_Drive.D2;
            dataGridView2.Rows[0].Cells[2].Value = belt_Drive.A;
            dataGridView2.Rows[0].Cells[3].Value = belt_Drive.L;
            dataGridView2.Rows[0].Cells[4].Value = belt_Drive.Alpha1_angle;

            textBox17.Text = Convert.ToString(belt_Drive.Z);
            dataGridView4.Rows[0].Cells[0].Value = belt_Drive.Z;
            dataGridView4.Rows[0].Cells[1].Value = belt_Drive.B_belt_wheel;
            dataGridView4.Rows[0].Cells[2].Value = belt_Drive.D_a1;
            dataGridView4.Rows[0].Cells[3].Value = belt_Drive.D_a2;

            textBox19.Text = Convert.ToString(belt_Drive.F_v);
            textBox20.Text = Convert.ToString(belt_Drive.F_o);
            textBox21.Text = Convert.ToString(belt_Drive.F_r);

            setdata();
            emp2.Save(fileName);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void input6_FormClosed(object sender, FormClosedEventArgs e)
        {
            emp2.Save(fileName);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            selectLoaiDai sLD = new selectLoaiDai();
            sLD.BringToFront();
            sLD.ShowDialog();
        }
    }
}
