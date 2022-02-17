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
    public partial class selectVL_BR : Form
    {
        public selectVL_BR()
        {
            InitializeComponent();
        }
        #region
        public delegate void GETDATA(string[] data);
        public GETDATA mydata;
        #endregion
        private void tbl_6_2_BindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tbl_6_2_BindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.luanVanDataSet);

        }

        private void selectVL_BR_Load(object sender, EventArgs e)
        {
            //// TODO: This line of code loads data into the 'luanVanDataSet.tbl_NhietLuyen_' table. You can move, or remove it, as needed.
            //this.tbl_NhietLuyen_TableAdapter.Fill(this.luanVanDataSet.tbl_NhietLuyen_);
            // TODO: This line of code loads data into the 'luanVanDataSet.tbl_6_2_' table. You can move, or remove it, as needed.
            this.tbl_6_2_TableAdapter.Fill(this.luanVanDataSet.tbl_6_2_);

        }

        private void tbl_6_2_DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow dgvRow = tbl_6_2_DataGridView.Rows[e.RowIndex];
                string[] str = new string[5];
                for (int i = 0; i < 5; i++)
                {
                    str[i] = dgvRow.Cells[i].Value.ToString();
                }
                mydata(str);
            }
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            this.tbl_6_2_BindingSource.Filter = string.Format("NhanHieuThep LIKE '*{0}*'", toolStripTextBox1.Text);
        }

    }
}
