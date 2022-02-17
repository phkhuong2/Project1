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
    
    public partial class selectKa_Kd_ZM : Form
    {
        XElement emp2 = XDocument.Load("dataC2.xml").Root.Element("dataC"+ trangchu.Self.indexGearData.ToString());
        public selectKa_Kd_ZM()
        {
            InitializeComponent();
        }

        private void tbl_6_5_BindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tbl_6_5_BindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.luanVanDataSet);

        }

        private void selectKa_Kd_ZM_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'luanVanDataSet.tbl_6_5_' table. You can move, or remove it, as needed.
            this.tbl_6_5_TableAdapter.Fill(this.luanVanDataSet.tbl_6_5_);

        }

        private void tbl_6_5_DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1)
            {
                DataGridViewColumn dgvColumn = tbl_6_5_DataGridView.Columns[e.ColumnIndex];
                input3.Self.cond3 = (dgvColumn.Index-1).ToString(); //////////////////////////////////////////////////////////////
                input3.Self.textBox21.Text = (dgvColumn.Index - 1).ToString();
                emp2.Element("d_cond3").Value = dgvColumn.Index.ToString();
                
            }
        } 
    }
}
