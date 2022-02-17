using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace luan_van1
{
    public partial class selectLoaiDai : Form
    {
        string[] lo = { "400", "(425)", "450", "(475)", "500", "(530)", "560", "(600)", "630", "(670)", "710", "(750)", "800", "(850)", "1000", "(1060)", "1120", "(1180)", "1250", "(1320)", "1400", "(1500)", "1600", "(1700)", "1800", "(1900)", "2000", "(2120)", "2240", "(2360)", "2500", "(2650)", "2800", "(3000)", "3150", "(3350)", "3550", "(3750)", "4000", "(4250)", "4500", "5000", "5600", "6800", "7100", "8000", "9000", "10000", "11200", "12500", "14000" };
        public selectLoaiDai()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(Application.StartupPath + "\\Image\\11.png");
        }

        private void selectLoaiDai_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'luanVanDataSet.tbl_4_13_' table. You can move, or remove it, as needed.
            this.tbl_4_13_TableAdapter.Fill(this.luanVanDataSet.tbl_4_13_);

        }

        private void tbl_4_13_BindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tbl_4_13_BindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.luanVanDataSet);
        }

        private void tbl_4_13_DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string l_bound = string.Empty;
            string l_bound_max_min = string.Empty;
            List<string> l_bound_max_mins = new List<string>();

            comboBox1.Items.Clear();
            comboBox1.Text = null;

            if (e.RowIndex != -1)
            {
                DataGridViewRow dgvRow = tbl_4_13_DataGridView.Rows[e.RowIndex];
                for (int i = 0; i < 9; i++)
                {
                    input6.Self.dataGridView1.Rows[0].Cells[i].Value = dgvRow.Cells[i].Value ;
                    dgvRow.Cells[1].Value.ToString();
                }
                
                //emp3.Element("d_Ti_Tmax_engine").Value = dgvRow.Cells[5].Value.ToString();


                l_bound = dgvRow.Cells[8].Value.ToString();
            }
            
            for (int i = 0; i < l_bound.Length; i++)
            {
                if (l_bound[i] == '-')
                {
                    l_bound_max_mins.Add(l_bound_max_min);
                    l_bound_max_min = string.Empty;
                    continue;
                }
                if (Char.IsDigit(l_bound[i]))
                    l_bound_max_min += l_bound[i];
            }
            l_bound_max_mins.Add(l_bound_max_min);


            string temp;
            for (int i = 0; i < lo.Length; i++)
            {
                if (lo[i][0] == '(')
                {
                    temp = lo[i].Substring(1, lo[i].Length - 2);
                    if (double.Parse(temp) >= double.Parse(l_bound_max_mins[0]) && double.Parse(temp) <= double.Parse(l_bound_max_mins[1]))
                    {
                        comboBox1.Items.Add(lo[i]);
                    }
                }
                else 
                {
                    if (double.Parse(lo[i]) >= double.Parse(l_bound_max_mins[0]) && double.Parse(lo[i]) <= double.Parse(l_bound_max_mins[1]))
                    {
                        comboBox1.Items.Add(lo[i]);
                    }
                } 
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text[0] == '(')
            {
                input6.Self.dataGridView1.Rows[0].Cells[9].Value = comboBox1.Text.Substring(1, comboBox1.Text.Length - 2);
            }
            else input6.Self.dataGridView1.Rows[0].Cells[9].Value = comboBox1.Text;
        }
    }
}
