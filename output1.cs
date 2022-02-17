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
    public partial class output1 : Form
    {

        XElement emp = XDocument.Load("dataC1.xml").Descendants("dataC1").FirstOrDefault();

        public output1()
        {
            InitializeComponent();
            textBox1.Text = emp.Element("d_P_dc").Value;
            textBox2.Text = emp.Element("d_P_truc1").Value;
            textBox3.Text = emp.Element("d_P_truc2").Value;
            textBox4.Text = emp.Element("d_P_truc3").Value;
            textBox5.Text = emp.Element("d_u_d").Value;
            textBox6.Text = emp.Element("d_u_1").Value;
            textBox7.Text = emp.Element("d_u_2").Value;
            textBox8.Text = emp.Element("d_N_dc").Value;
            textBox9.Text = emp.Element("d_N_truc1").Value;
            textBox10.Text = emp.Element("d_N_truc2").Value;
            textBox11.Text = emp.Element("d_N_truc3").Value;
            textBox12.Text = emp.Element("d_T_dc").Value;
            textBox13.Text = emp.Element("d_T_truc1").Value;
            textBox14.Text = emp.Element("d_T_truc2").Value;
            textBox15.Text = emp.Element("d_T_truc3").Value;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }  
}
