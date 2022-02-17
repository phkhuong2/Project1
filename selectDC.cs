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
    public partial class selectDC : Form
    {
        //string fileName = "dataC2xml";

        string fileName = "dataC1.xml";
        XElement emp1 = XDocument.Load("dataC1.xml").Descendants("dataC1").FirstOrDefault();
        public selectDC()
        {
            InitializeComponent();
        }

        private void p1_3_BindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.p1_3_BindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.luanVanDataSet);

        }

        private void selectDC_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'luanVanDataSet.P1_3_' table. You can move, or remove it, as needed.
            this.p1_3_TableAdapter.Fill(this.luanVanDataSet.P1_3_);
        }

        private void p1_3_DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //XElement emp3 = emp2.Element("dataC" + indexData);
            if (e.RowIndex != -1)
            {
                DataGridViewRow dgvRow = p1_3_DataGridView.Rows[e.RowIndex];
                input1.Self.txt18.Text = dgvRow.Cells[1].Value.ToString();
                input1.Self.txt17.Text = dgvRow.Cells[2].Value.ToString();
                emp1.Element("d_Ti_Tmax_engine").Value = dgvRow.Cells[5].Value.ToString();
                //emp3.Element("d_Ti_Tmax_engine").Value = dgvRow.Cells[5].Value.ToString();

            }
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            this.p1_3_BindingSource.Filter = string.Format("KieuDC LIKE '*{0}*'", toolStripTextBox1.Text);
        }

        private void selectDC_FormClosed(object sender, FormClosedEventArgs e)
        {
            emp1.Save(fileName);
        }
    }
}
