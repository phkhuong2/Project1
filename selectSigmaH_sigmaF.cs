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
    public partial class selectSigmaH_sigmaF : Form
    {
        public selectSigmaH_sigmaF()
        {
            InitializeComponent();
        }

        private void tbl_6_15_BindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tbl_6_15_BindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.luanVanDataSet);

        }

        private void selectSigmaH_sigmaF_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'luanVanDataSet.tbl_6_15_' table. You can move, or remove it, as needed.
            this.tbl_6_15_TableAdapter.Fill(this.luanVanDataSet.tbl_6_15_);

        }

        private void tbl_6_15_DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow dgvRow = tbl_6_15_DataGridView.Rows[e.RowIndex];
                input4.Self.textBox4.Text = dgvRow.Cells[2].Value.ToString();
                input4.Self.textBox19.Text = dgvRow.Cells[3].Value.ToString();
            }
        }
    }
}
