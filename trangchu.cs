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
    
    public partial class trangchu : Form
    {
        //string data_gear_fileName = @"C:\Users\Administrator\Desktop\New folder\CODE\WINFORM\luan_van1\dataC2.xml";
        string data_gear_fileName = "dataC2.xml";
        string data_Perform_fileName = "dataC4.xml";
        create_data creData = new create_data();

         

        int BR_count = 0;
        int TV_count = 0;
        int Flow_Panel_Elements_count = 0;
        public static trangchu Self;
        public string LoaiTruyenDong;
        public int indexGearData = 0;
        public int indexPerformData =0;
        string[] Button_child_names_BR = { "Ứng suât cho phép", "Thông số ăn khớp", "Kiểm nghiệm răng" };


        List<FlowLayoutPanel> flowLayoutPanels_list = new List<FlowLayoutPanel>();
        List<Button> Buttons_title_list = new List<Button>();
        List<Button> Buttons_child_list = new List<Button>();
        List<TableLayoutPanel> TableLayoutPanels_title_list = new List<TableLayoutPanel>();
        List<Button> Buttons_delete_list = new List<Button>();
        

        public trangchu()
        {
            InitializeComponent();
            Self = this;
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel2.Controls.Add(childForm);
            panel2.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openChildForm(new input1());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openChildForm(new output1());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openChildForm(new input2());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openChildForm(new input3());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            openChildForm(new input4());
        }
        public void button6_Click(object sender, EventArgs e)
        {
            Form form = new selectLoaiTruyenDong();
            form.BringToFront();
            form.Show();

        }
        private void button_title_Click(object sender, EventArgs e)
        {
            Button currentButton = (Button)sender;

            int i_button_title = int.Parse(currentButton.Name.Substring(13, 1));

            if (flowLayoutPanels_list[i_button_title].Visible == true)
            {
                flowLayoutPanels_list[i_button_title].Visible = false;
            }
            else
            {
                flowLayoutPanels_list[i_button_title].Visible = true;
            }
            if (currentButton.Text.Substring(3,8) == "Trục vít")
            {
                openChildForm(new input7());
            }

        }
        void remove_button(int i)
        {

            flowLayoutPanel2.Controls.Remove(flowLayoutPanels_list[i]);
            flowLayoutPanel2.Controls.Remove(TableLayoutPanels_title_list[i]);
            flowLayoutPanels_list.RemoveAt(i);
            Buttons_title_list.RemoveAt(i);
            for (int j = i*3; j < i*3+3; j++)
            {
                Buttons_child_list.RemoveAt(j);
            }
            TableLayoutPanels_title_list.RemoveAt(i);
            Buttons_delete_list.RemoveAt(i);

            Flow_Panel_Elements_count--;
        }  
        private void button_delete_Click(object sender, EventArgs e)
        {
            Button currentButton = (Button)sender;

            int i_del_button = int.Parse(currentButton.Name.Remove(0, 14));
            if (Buttons_title_list[i_del_button].Text.Substring(3,9) == "Bánh răng")
            {
                creData.delete_data(data_gear_fileName, i_del_button);
                BR_count--;
                int i_BR_button = int.Parse(Buttons_title_list[i_del_button].Text.Substring(13, 1));
                for (int i = i_BR_button; i < BR_count; i++)
                {
                    creData.rename_data(data_gear_fileName, i + 1, "dataC" + i.ToString());
                    for (int j = 0; j < 3; j++)
                    {
                        Buttons_child_list[j].Name = i.ToString() + Button_child_names_BR[j];
                    }
                }
                //  xoa du lieu va rename lai ten
            }
            else if (Buttons_title_list[i_del_button].Text.Substring(3, 13) == "Bánh răng côn")
            {
                creData.delete_data(data_gear_fileName, i_del_button);
                BR_count--;
                int i_BR_button = int.Parse(Buttons_title_list[i_del_button].Text.Substring(17, 1));
                for (int i = i_BR_button; i < BR_count; i++)
                {
                    creData.rename_data(data_gear_fileName, i + 1, "dataC" + i.ToString());
                    for (int j = 0; j < 3; j++)
                    {
                        Buttons_child_list[j].Name = i.ToString() + Button_child_names_BR[j];
                    }
                }
            }

            remove_button(i_del_button);

            for ( int i = i_del_button; i < flowLayoutPanels_list.Count; i++)
            {
                flowLayoutPanels_list[i].Name = "flow_Panel_" + i.ToString();
                Buttons_title_list[i].Name = "button_title_" + i.ToString();
                //TableLayoutPanels_title_list[i].Name = "button_delete_" + i.ToString();
                Buttons_delete_list[i].Name = "button_delete_" + i.ToString();

                for (int j = i*3; j < i*3+3; j++)
                {
                    Buttons_child_list[j].Name = i.ToString() + Button_child_names_BR[j];
                }

                if (Buttons_title_list[i].Text.Substring(3, 9) == "Bánh răng")
                {
                    string firt_word = Buttons_title_list[i].Text.Substring(0, 1);
                    string last_word = Buttons_title_list[i].Text.Substring(13,1);
                    Buttons_title_list[i].Text = (int.Parse(firt_word) - 1).ToString() + " Bánh răng " + (int.Parse(last_word) - 1).ToString();
                }
                else if (Buttons_title_list[i].Text.Substring(3, 9) == "Bánh răng côn")
                {
                    string firt_word = Buttons_title_list[i].Text.Substring(0, 1);
                    string last_word = Buttons_title_list[i].Text.Substring(17, 1);
                    Buttons_title_list[i].Text = (int.Parse(firt_word) - 1).ToString() + " Bánh răng côn " + (int.Parse(last_word) - 1).ToString();
                }
            }


        }
        private void buttonBRchild_Click(object sender, EventArgs e)
        {
            Button currentButton = (Button)sender;
            indexGearData = int.Parse(currentButton.Name.Substring(0, 1));
            string result = currentButton.Name.Remove(0,1);
            
            if (result == Button_child_names_BR[0])
            {
                openChildForm(new input2());
            }
            else if (result == Button_child_names_BR[1])
            {
                openChildForm(new input3());
            }
            else if (result == Button_child_names_BR[2])
            {
                openChildForm(new input4());
            }  
            
        }
        private void buttonBRCchild_Click(object sender, EventArgs e)
        {
            Button currentButton = (Button)sender;
            indexGearData = int.Parse(currentButton.Name.Substring(0, 1));
            string result = currentButton.Name.Remove(0,1);
            if (result == Button_child_names_BR[0])
            {
                openChildForm(new input2());
            }
            else if (result == Button_child_names_BR[1])
            {
                openChildForm(new input5());
            }
            else if (result == Button_child_names_BR[2])
            {
                openChildForm(new input4());
            }

        }
        Button addbutton(int i)
        {
            Button b = new Button();
            b.BackColor = Color.LightGray;
            b.Font = new Font("Segoe UI", 7);
            b.Width = 110;
            b.Height = 30;
            b.TextAlign = ContentAlignment.MiddleCenter;
            return b;
        }
        void createGearButton_with_parameter(string name, EventHandler sender)
        {
            FlowLayoutPanel Flow_Panel_Elements = new FlowLayoutPanel();
            Flow_Panel_Elements.Name = "flow_Panel_" + Flow_Panel_Elements_count.ToString();
            Flow_Panel_Elements.Width = 110;
            Flow_Panel_Elements.Height = 110;
            flowLayoutPanels_list.Add(Flow_Panel_Elements);

            Button titleButon = new Button();
            titleButon.Text = Flow_Panel_Elements_count.ToString() + ". " + name + " " + BR_count.ToString();
            titleButon.Name = "button_title_" + Flow_Panel_Elements_count.ToString();
            titleButon.TextAlign = ContentAlignment.MiddleCenter;
            titleButon.BackColor = Color.LightGray;
            titleButon.Font = new Font("Segoe UI", 12);
            titleButon.Width = 135;
            titleButon.Height = 31;
            Buttons_title_list.Add(titleButon);
            titleButon.Click += new System.EventHandler(this.button_title_Click);

            Button deleteButton = new Button();
            deleteButton.Text = "X";
            deleteButton.Name = "button_delete_" + Flow_Panel_Elements_count.ToString();
            deleteButton.TextAlign = ContentAlignment.MiddleCenter;
            deleteButton.BackColor = Color.LightGray;
            deleteButton.Font = new Font("Segoe UI", 12);
            deleteButton.Width = 31;
            deleteButton.Height = 31;
            Buttons_delete_list.Add(deleteButton);
            deleteButton.Click += new System.EventHandler(this.button_delete_Click);

            TableLayoutPanel Table_Panel_title_del = new TableLayoutPanel();
            Table_Panel_title_del.ColumnCount = 2;
            Table_Panel_title_del.RowCount = 1;
            Table_Panel_title_del.Size = new System.Drawing.Size(201, 40);
            Table_Panel_title_del.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            Table_Panel_title_del.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
            Table_Panel_title_del.Controls.Add(titleButon, 0, 0);
            Table_Panel_title_del.Controls.Add(deleteButton, 1, 0);
            TableLayoutPanels_title_list.Add(Table_Panel_title_del);

            flowLayoutPanel2.Controls.Add(Table_Panel_title_del);

            flowLayoutPanel2.Controls.Remove(button6);

            for (int i = 0; i < 3; i++)
            {
                Button b = addbutton(i);
                b.Name = BR_count.ToString() + Button_child_names_BR[i];
                b.Text = Button_child_names_BR[i];
                Flow_Panel_Elements.Controls.Add(b);
                b.Anchor = AnchorStyles.None;
                Buttons_child_list.Add(b);
                b.Click += sender;
            }
            flowLayoutPanel2.Controls.Add(Flow_Panel_Elements);
            flowLayoutPanel2.Controls.Add(button6);

            creData.Gear_create_data(data_gear_fileName, Flow_Panel_Elements_count);

            Flow_Panel_Elements_count ++;
            BR_count++;
            flowLayoutPanel2.Height += 130;
        }
        
        public void createGearButton()
        {
            createGearButton_with_parameter("Bánh răng", this.buttonBRchild_Click);
        }
        public void createBevelGearButton()
        {

            createGearButton_with_parameter("Bánh răng côn", this.buttonBRCchild_Click);
        }
        public void createWormGearButton()
        {
            FlowLayoutPanel Flow_Panel_Elements = new FlowLayoutPanel();
            Flow_Panel_Elements.Name = "flow_Panel_" + Flow_Panel_Elements_count.ToString();
            Flow_Panel_Elements.Width = 110;
            Flow_Panel_Elements.Height = 5;
            flowLayoutPanels_list.Add(Flow_Panel_Elements);

            Button titleButon = new Button();
            titleButon.Text = Flow_Panel_Elements_count.ToString() + ". " + "Trục vít" + " " + TV_count.ToString();
            titleButon.Name = "button_title_" + Flow_Panel_Elements_count.ToString();
            titleButon.TextAlign = ContentAlignment.MiddleCenter;
            titleButon.BackColor = Color.LightGray;
            titleButon.Font = new Font("Segoe UI", 12);
            titleButon.Width = 135;
            titleButon.Height = 31;
            Buttons_title_list.Add(titleButon);
            titleButon.Click += new System.EventHandler(this.button_title_Click);

            Button deleteButton = new Button();
            deleteButton.Text = "X";
            deleteButton.Name = "button_delete_" + Flow_Panel_Elements_count.ToString();
            deleteButton.TextAlign = ContentAlignment.MiddleCenter;
            deleteButton.BackColor = Color.LightGray;
            deleteButton.Font = new Font("Segoe UI", 12);
            deleteButton.Width = 31;
            deleteButton.Height = 31;
            Buttons_delete_list.Add(deleteButton);
            deleteButton.Click += new System.EventHandler(this.button_delete_Click);

            TableLayoutPanel Table_Panel_title_del = new TableLayoutPanel();
            Table_Panel_title_del.ColumnCount = 2;
            Table_Panel_title_del.RowCount = 1;
            Table_Panel_title_del.Size = new System.Drawing.Size(201, 40);
            Table_Panel_title_del.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            Table_Panel_title_del.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
            Table_Panel_title_del.Controls.Add(titleButon, 0, 0);
            Table_Panel_title_del.Controls.Add(deleteButton, 1, 0);
            TableLayoutPanels_title_list.Add(Table_Panel_title_del);

            flowLayoutPanel2.Controls.Add(Table_Panel_title_del);

            flowLayoutPanel2.Controls.Remove(button6);

            flowLayoutPanel2.Controls.Add(Flow_Panel_Elements);
            flowLayoutPanel2.Controls.Add(button6);

            creData.Gear_create_data(data_gear_fileName, Flow_Panel_Elements_count);

            Flow_Panel_Elements_count++;
            TV_count++;
            flowLayoutPanel2.Height += 40;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            openChildForm(new input6());
        }

        private void trangchu_FormClosed(object sender, FormClosedEventArgs e)
        {
            creData.All_delete_data(data_gear_fileName);
            creData.All_delete_data(data_Perform_fileName);
        }
        
    }
}
