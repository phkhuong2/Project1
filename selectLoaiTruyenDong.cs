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
    public partial class selectLoaiTruyenDong : Form
    {
        string data_Perform_fileName = "dataC4.xml";
        create_data creData = new create_data();


        public selectLoaiTruyenDong()
        {
            InitializeComponent();
            pictureBox6.Image = new Bitmap(Application.StartupPath + "\\Image\\2.png");
            pictureBox2.Image = new Bitmap(Application.StartupPath + "\\Image\\4.png");
            pictureBox7.Image = new Bitmap(Application.StartupPath + "\\Image\\10.png");
            pictureBox8.Image = new Bitmap(Application.StartupPath + "\\Image\\9.png");
            pictureBox1.Image = new Bitmap(Application.StartupPath + "\\Image\\3.png");
        }

        
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            int BR_count = selectLoaiTruyenDong2.Self.BR_count;
            trangchu.Self.createGearButton();
            selectLoaiTruyenDong2.Self.addRow(BR_count.ToString()+". Bánh răng trụ", "0.96-0.98", 0.96);
            selectLoaiTruyenDong2.Self.BR_count++;
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            int truc_count = selectLoaiTruyenDong2.Self.truc_count;
            trangchu.Self.createWormGearButton();
            selectLoaiTruyenDong2.Self.addRow(truc_count.ToString()+". Trục vít", "0.7-0.92", 0.7);
            selectLoaiTruyenDong2.Self.truc_count++;
            this.Close();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            int dai_xich_count = selectLoaiTruyenDong2.Self.dai_xich_count;
            //trangchu.Self.createBevelGearButton();
            selectLoaiTruyenDong2.Self.addRow(dai_xich_count.ToString()+". Đai", "0.95-0.96", 0.95);
            selectLoaiTruyenDong2.Self.dai_xich_count++;
            this.Close();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            int dai_xich_count = selectLoaiTruyenDong2.Self.dai_xich_count;
            //trangchu.Self.createBevelGearButton();
            selectLoaiTruyenDong2.Self.addRow(dai_xich_count.ToString()+". Xích", "0.9-0.93", 0.9) ;
            selectLoaiTruyenDong2.Self.dai_xich_count++;
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int BR_count = selectLoaiTruyenDong2.Self.BR_count;
            trangchu.Self.createBevelGearButton();
            selectLoaiTruyenDong2.Self.addRow(BR_count.ToString()+". bánh răng côn", "0.95-0.97", 0.95);
            selectLoaiTruyenDong2.Self.BR_count++;
            this.Close();
        }
    }
}
