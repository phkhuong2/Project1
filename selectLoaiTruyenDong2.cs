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
    public partial class selectLoaiTruyenDong2 : Form
    {
        //C:\Users\Administrator\Desktop\New folder\CODE\WINFORM\luan_van1\dataC4.xml
        //string data_Perform_fileName = Application.StartupPath + "\\dataC4.xml";
        //XElement emp2 = XDocument.Load(Application.StartupPath + "\\dataC4.xml").Root;
        //string data_Perform_fileName = @"C:\Users\Administrator\Desktop\New folder\CODE\WINFORM\luan_van1\dataC4.xml";
        //XElement emp2 = XDocument.Load(@"C:\Users\Administrator\Desktop\New folder\CODE\WINFORM\luan_van1\dataC4.xml").Root;
        string data_Perform_fileName = "dataC4.xml";
        XElement emp2 = XDocument.Load("dataC4.xml").Root;

        create_data creData = new create_data();
        int RowCount = trangchu.Self.indexPerformData;
        int RowIndexToDel = 0;
        public int BR_count = 0;
        public int dai_xich_count = 0;
        public int truc_count = 0;
        string name_del_element;

        public static selectLoaiTruyenDong2 Self;
        public selectLoaiTruyenDong2()
        {
            InitializeComponent();
            Self = this;
            
            getdata();
        }
        void setdata()
        {
            emp2 = XDocument.Load("dataC4.xml").Root;
            for (int i = 0; i < RowCount; i++)
            {
                XElement emp3 = emp2.Element("dataC" + i.ToString());
                emp3.Element("stt").Value = dataGridView1.Rows[i].Cells[0].Value.ToString();     
                emp3.Element("Name").Value = dataGridView1.Rows[i].Cells[1].Value.ToString();
                emp3.Element("n_bound").Value = dataGridView1.Rows[i].Cells[2].Value.ToString();
                emp3.Element("n").Value = dataGridView1.Rows[i].Cells[3].Value.ToString();
                
            }

        }
        void getdata()
        {
            for (int i = 0; i < RowCount; i++)
            {
                XElement emp3 = emp2.Element("dataC"+i.ToString());
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[i].Clone();
                row.Cells[0].Value = emp3.Element("stt").Value; ;
                row.Cells[1].Value = emp3.Element("Name").Value;
                row.Cells[2].Value = emp3.Element("n_bound").Value;
                row.Cells[3].Value = emp3.Element("n").Value;
                dataGridView1.Rows.Add(row);
            }

        }
        public void addRow(string name, string n_bound, double n)
        {
            DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[RowCount].Clone();
            row.Cells[0].Value = "η" + RowCount.ToString();
            row.Cells[1].Value = name;
            row.Cells[2].Value = n_bound;
            row.Cells[3].Value = n;
            dataGridView1.Rows.Add(row);
            creData.Perform_create_data(data_Perform_fileName, RowCount);
            
            RowCount++;
        }
        public void delRow()
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            RowIndexToDel = rowIndex;
            name_del_element = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            dataGridView1.Rows.RemoveAt(rowIndex);
            updateElementCount(name_del_element);
            creData.delete_data(data_Perform_fileName, rowIndex);
            RowCount--;
        }
        public void updateElement()
        {
            for (int i = RowIndexToDel; i < RowCount; i++)
            {
                string nameElement = dataGridView1.Rows[i].Cells[1].Value.ToString();
                dataGridView1.Rows[i].Cells[0].Value = "η" + i.ToString();
                creData.rename_data(data_Perform_fileName, i + 1, "dataC" + i.ToString());
                //doi ten index element rieng biet
                if (nameElement.Remove(0,3) == name_del_element.Remove(0,3))
                {
                    dataGridView1.Rows[i].Cells[1].Value = ((int.Parse(nameElement.Substring(0, 1)) - 1).ToString() + nameElement.Remove(0, 1));
                }
            }
        }
        private void updateElementCount (string name)
        {
            if (name.Remove(0,3) == "Bánh răng côn"|| name.Remove(0,3) == "Bánh răng trụ")
            {
                BR_count--;
            }
            else if (name.Remove(0,3) == "Trục vít")
            {
                truc_count--;
            }
            else if (name.Remove(0,3) == "Xích" )
            {
                dai_xich_count--;
            }
            else if (name.Remove(0, 3) == "Đai")
            {
                dai_xich_count--;
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            selectLoaiTruyenDong slLTD = new selectLoaiTruyenDong();
            slLTD.BringToFront();
            slLTD.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int rowindex = dataGridView1.CurrentCell.RowIndex;
            if (dataGridView1.Rows[rowindex].Cells[0].Value != null)
            {
                delRow();
                updateElement();
            }
        }

        private void selectLoaiTruyenDong2_FormClosed(object sender, FormClosedEventArgs e)
        {
            setdata();
            trangchu.Self.indexPerformData = RowCount;
            emp2.Save(data_Perform_fileName);
        }
    }
}
