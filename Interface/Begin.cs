using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface
{
    public partial class Begin : Form
    {
        public int ID;
        ProfileClient profile;


        public Begin(int ID)
        {
            this.ID = ID;
            profile = new ProfileClient();
            profile.GetData(ID);
            InitializeComponent();
            ShowInfor();
            
        }

        public void ShowInfor()
        {
            textBox1.Text = profile.name;
            textBox2.Text = Convert.ToString(profile.birthday);
            textBox3.Text = profile.identityNumber;
            textBox4.Text = profile.address;
            textBox5.Text = profile.nation;
            textBox6.Text = profile.religion;
            label17.Text = profile.name;
            textBox7.Text = "Đọc kĩ quy chế trước khi bắt đầu thi. \r\n Thời gian cho mỗi kĩ năng là 45 phút. \r\n Để vượt qua bài thi cần thối" +
                "thiểu 75% bài thi. \r\n Với mỗi câu hỏi, thí sinh có 3 lần tối đa nộp câu trả lời. \r\n Thí sinh cần giữ gìn trật tự, không làm ảnh hưởng đến thí sinh khác \r\n ...  ";
        }

        int index;
        List<Panel> listPanel = new List<Panel>();
        private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if (e.Column == 0 && e.Row == index)
            {
                e.Graphics.FillRectangle(Brushes.White, e.CellBounds);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (index < 3)
            {
                index++;
                for (int i = 0; i < 4; i++)
                {
                    if (i == index)
                    {
                        listPanel[i].Visible = true;
                    }
                    else listPanel[i].Visible = false;
                }
                tableLayoutPanel1.Refresh();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (index > 0)
            {
                index--;
                for (int i = 0; i < 4; i++)
                {
                    if (i == index)
                    {
                        listPanel[i].Visible = true;
                    }
                    else listPanel[i].Visible = false;
                }
                tableLayoutPanel1.Refresh();
            }

        }

        private void Begin_Load(object sender, EventArgs e)
        {
            listPanel.Add(panel1);
            listPanel.Add(panel2);
            listPanel.Add(panel3);
            listPanel.Add(panel4);
            for (int i=0;i<4;i++)
            {
                if (i == index)
                {
                    listPanel[i].Visible = true;
                }
                else listPanel[i].Visible = false;
            }
        }

        private void label18_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }
    }
}
