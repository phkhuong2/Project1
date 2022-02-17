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
    public partial class selectCapChinhXac : Form
    {
        string fileName = "dataC2.xml";
        XElement emp2 = XDocument.Load("dataC2.xml").Root;//.Element("dataC0");//.Descendants("dataC2").FirstOrDefault();
        string indexData = trangchu.Self.indexGearData.ToString();
        public selectCapChinhXac()
        {
            XElement emp3 = emp2.Element("dataC" + indexData);
            InitializeComponent();
            pictureBox1.Image = new Bitmap(Application.StartupPath + "\\Image\\1.png");
            comboBox1.Text = emp3.Element("d_CapChinhXac").Value;
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            input4.Self.textBox32.Text = comboBox1.Text;
        }

        private void selectCapChinhXac_FormClosed(object sender, FormClosedEventArgs e)
        {
            XElement emp3 = emp2.Element("dataC" + indexData);
            emp3.Element("d_CapChinhXac").Value = comboBox1.Text;
            emp2.Save("dataC2.xml");
        }
    }
}
