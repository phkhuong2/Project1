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
    public partial class selectViTriAnKhop : Form
    {

        XElement emp2 = XDocument.Load("dataC2.xml").Root.Element("dataC" + trangchu.Self.indexGearData.ToString());

        public selectViTriAnKhop()
        {
            //input3.Self.psi_bd;
            InitializeComponent();
            pictureBox1.Image = new Bitmap(Application.StartupPath + "\\Image\\12.png");
            getdata();

        }
        void getdata()
        {
            textBox1.Text = emp2.Element("d_K_H_beta").Value;
            textBox2.Text = emp2.Element("d_K_F_beta").Value;
            comboBox1.SelectedItem = emp2.Element("d_ViTriAnKhop").Value;
        }
        void setdata()
        {
            emp2.Element("d_K_H_beta").Value = textBox1.Text;
            emp2.Element("d_K_F_beta").Value = textBox2.Text;
            emp2.Element("d_ViTriAnKhop").Value = comboBox1.Text;
        }
        int indexPsi_bd(double psi_bd)
        {
            int count = 0;
            for (int i = 1; i < 8; i++)
            {
                if (psi_bd < i * 0.2)
                {
                    count = i - 1;
                    break;
                }
            }
            return count;
        }
        
        void linearNumber(int col, int row, double psi_bd)
        {
            
        }
        double System_Of_Equation_KHB()
        {
            double bd = double.Parse(input3.Self.textBox18.Text);
            int id = indexPsi_bd(bd);
            int com = int.Parse(comboBox1.Text);
            double x = 0;
            double y = 0;
            if (double.Parse(emp2.Element("d_HB_1").Value) <= 350 && double.Parse(emp2.Element("d_HB_2").Value)<= 350)
            {
                double a1 = (double)this.luanVanDataSet.tbl_6_7_[id - 1][0];
                double a2 = (double)this.luanVanDataSet.tbl_6_7_[id][0];
                double b1 = (double)this.luanVanDataSet.tbl_6_7_[id - 1][com];
                double b2 = (double)this.luanVanDataSet.tbl_6_7_[id][com];
                x = (b1 - b2) / (a1 - a2);
                y = b1 - a1 * x;
            }
            else
            {
                id = id + 8;
                double a1 = (double)this.luanVanDataSet.tbl_6_7_[id - 1][0];
                double a2 = (double)this.luanVanDataSet.tbl_6_7_[id][0];
                double b1 = (double)this.luanVanDataSet.tbl_6_7_[id - 1][com];
                double b2 = (double)this.luanVanDataSet.tbl_6_7_[id][com];
                x = (b1 - b2) / (a1 - a2);
                y = b1 - a1 * x;
            }
            return (bd*x + y);
        }
        double System_Of_Equation_KFB()
        {
            double bd = double.Parse(input3.Self.textBox18.Text);
            int id = indexPsi_bd(bd);
            int com = int.Parse(comboBox1.Text);
            double x = 0;
            double y = 0;
            if (double.Parse(emp2.Element("d_HB_1").Value) <= 350 && double.Parse(emp2.Element("d_HB_2").Value) <= 350)
            {
                double a1 = (double)this.luanVanDataSet.tbl_6_7_[id - 1][0];
                double a2 = (double)this.luanVanDataSet.tbl_6_7_[id][0];
                double b1 = (double)this.luanVanDataSet.tbl_6_7_[id - 1][com+7];
                double b2 = (double)this.luanVanDataSet.tbl_6_7_[id][com+7];
                x = (b1 - b2) / (a1 - a2);
                y = b1 - a1 * x;
            }
            else
            {
                id = id + 8;
                double a1 = (double)this.luanVanDataSet.tbl_6_7_[id - 1][0];
                double a2 = (double)this.luanVanDataSet.tbl_6_7_[id][0];
                double b1 = (double)this.luanVanDataSet.tbl_6_7_[id - 1][com+7];
                double b2 = (double)this.luanVanDataSet.tbl_6_7_[id][com+7];
                x = (b1 - b2) / (a1 - a2);
                y = b1 - a1 * x;
            }
            return (bd * x + y);
        }
        private void selectViTriAnKhop_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'luanVanDataSet.tbl_6_7_' table. You can move, or remove it, as needed.
            this.tbl_6_7_TableAdapter.Fill(this.luanVanDataSet.tbl_6_7_);
            
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            textBox1.Text = System_Of_Equation_KHB().ToString();
            input3.Self.textBox19.Text = System_Of_Equation_KHB().ToString();
            textBox2.Text = System_Of_Equation_KFB().ToString();
            
        }

        private void selectViTriAnKhop_FormClosed(object sender, FormClosedEventArgs e)
        {
            setdata();
            emp2.Save("dataC2.xml");
        }

    }
}
