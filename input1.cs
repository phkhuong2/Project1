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
using luan_van1;

namespace luan_van1
{
    public partial class input1 : Form
    {
        
        string fileName = "dataC1.xml";
        XElement emp = XDocument.Load("dataC1.xml").Descendants("dataC1").FirstOrDefault();

        public static input1 Self;

        public string Ti_Tmax_engine;
        public input1()
        {
            InitializeComponent();
            Self = this;
            getdata();
        }
        double to_db(TextBox a)
        {
            return double.Parse(a.Text);
        }
        void setdata()
        {
            emp.Element("d_F").Value = txt1.Text;
            emp.Element("d_v").Value = txt2.Text;
            emp.Element("d_z").Value = txt3.Text;
            emp.Element("d_Pxt").Value = txt4.Text;
            emp.Element("d_L").Value = txt5.Text;
            emp.Element("d_t1").Value = txt6.Text;
            emp.Element("d_t2").Value = txt7.Text;
            emp.Element("d_T1").Value = txt8.Text; 
            emp.Element("d_T2").Value = txt9.Text;

            emp.Element("d_P_lv").Value = txt10.Text;
            emp.Element("d_P_td").Value = txt11.Text;
            emp.Element("d_hsuat").Value = txt12.Text;
            emp.Element("d_P_ct").Value = txt13.Text;
            emp.Element("d_N_lv").Value = txt14.Text;
            emp.Element("d_U_sb").Value = txt15.Text;
            emp.Element("d_N_sb").Value = txt16.Text;
            emp.Element("d_N_dc").Value = txt17.Text;
            emp.Element("d_P_dc").Value = txt18.Text;
            emp.Element("d_u_1").Value = txt19.Text;
            emp.Element("d_u_2").Value = txt20.Text;
            emp.Element("d_u_d").Value = txt21.Text;
            emp.Element("d_hsuat_1").Value = txt22.Text;
            emp.Element("d_hsuat_2").Value = txt23.Text;
            emp.Element("d_hsuat_3").Value = txt24.Text;
            emp.Element("d_hsuat_4").Value = txt25.Text;
            emp.Element("d_hsuat_5").Value = txt26.Text;
            emp.Element("d_hsuat_6").Value = txt27.Text;

            emp.Element("d_d_per_y").Value = txt28.Text;
            emp.Element("d_shift").Value = txt29.Text;
            emp.Element("d_working_hours").Value = txt30.Text;

        }
        void getdata()
        {
            txt1.Text = emp.Element("d_F").Value;
            txt2.Text = emp.Element("d_v").Value;
            txt3.Text = emp.Element("d_z").Value;
            txt4.Text = emp.Element("d_Pxt").Value;
            txt5.Text = emp.Element("d_L").Value;
            txt6.Text = emp.Element("d_t1").Value;
            txt7.Text = emp.Element("d_t2").Value;
            txt8.Text = emp.Element("d_T1").Value;
            txt9.Text = emp.Element("d_T2").Value;

            txt10.Text = emp.Element("d_P_lv").Value;
            txt11.Text = emp.Element("d_P_td").Value;
            txt12.Text = emp.Element("d_hsuat").Value;
            txt13.Text = emp.Element("d_P_ct").Value;
            txt14.Text = emp.Element("d_N_lv").Value;
            txt15.Text = emp.Element("d_U_sb").Value;
            txt16.Text = emp.Element("d_N_sb").Value;
            txt17.Text = emp.Element("d_N_dc").Value;
            txt18.Text = emp.Element("d_P_dc").Value;
            txt19.Text = emp.Element("d_u_1").Value;
            txt20.Text = emp.Element("d_u_2").Value;
            txt21.Text = emp.Element("d_u_d").Value;
            txt22.Text = emp.Element("d_hsuat_1").Value;
            txt23.Text = emp.Element("d_hsuat_2").Value;
            txt24.Text = emp.Element("d_hsuat_3").Value;
            txt25.Text = emp.Element("d_hsuat_4").Value;
            txt26.Text = emp.Element("d_hsuat_5").Value;
            txt27.Text = emp.Element("d_hsuat_6").Value;

            txt28.Text = emp.Element("d_d_per_y").Value;
            txt29.Text = emp.Element("d_shift").Value;
            txt30.Text = emp.Element("d_working_hours").Value;
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            List<double> inplist = new List<double>();
            inplist.Add(to_db(txt1));
            inplist.Add(to_db(txt2));
            inplist.Add(to_db(txt3));
            inplist.Add(to_db(txt4));
            inplist.Add(to_db(txt6));
            inplist.Add(to_db(txt7));
            inplist.Add(to_db(txt8));
            inplist.Add(to_db(txt9));
            inplist.Add(to_db(txt12));
            inplist.Add(to_db(txt15));
            inplist.Add(to_db(txt19));
            inplist.Add(to_db(txt20));
            inplist.Add(to_db(txt21));
            inplist.Add(to_db(txt22));
            inplist.Add(to_db(txt23));
            inplist.Add(to_db(txt26));
            inplist.Add(to_db(txt17));
            inplist.Add(to_db(txt18));


            dongco_tst tst = new dongco_tst(inplist);

            emp.Element("d_P_truc1").Value = Convert.ToString(tst.P_truc1);
            emp.Element("d_P_truc2").Value = Convert.ToString(tst.P_truc2);
            emp.Element("d_P_truc3").Value = Convert.ToString(tst.P_truc3);
            emp.Element("d_N_truc1").Value = Convert.ToString(tst.N_truc1);
            emp.Element("d_N_truc2").Value = Convert.ToString(tst.N_truc2);
            emp.Element("d_N_truc3").Value = Convert.ToString(tst.N_truc3);
            emp.Element("d_T_dc").Value = Convert.ToString(tst.T_dc);
            emp.Element("d_T_truc1").Value = Convert.ToString(tst.T_truc1);
            emp.Element("d_T_truc2").Value = Convert.ToString(tst.T_truc2);
            emp.Element("d_T_truc3").Value = Convert.ToString(tst.T_truc3);

            txt10.Text = Convert.ToString(tst.P_lv);
            txt11.Text = Convert.ToString(tst.P_td);
            txt12.Text = Convert.ToString(tst.Hsuat);
            txt13.Text = Convert.ToString(tst.P_ct);
            txt14.Text = Convert.ToString(tst.N_lv);
            txt15.Text = Convert.ToString(tst.U_sb);
            txt16.Text = Convert.ToString(tst.N_sb);
            setdata();
            emp.Save(fileName);

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void input1_FormClosed(object sender, FormClosedEventArgs e)
        {
            setdata();
            emp.Save(fileName);
        }

        private void input1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            selectDC slDC = new selectDC();
            slDC.BringToFront();
            slDC.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            selectLoaiTruyenDong2 slLTD = new selectLoaiTruyenDong2();
            slLTD.BringToFront();
            slLTD.ShowDialog();
        }
    }
}
