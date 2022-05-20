using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app_m.Books
{
    public partial class Form1 : Form
    {
        //public delegate void laymnv (int manvmanv);
        //public laymnv lm;
        private data data = new data();
        public int manvnv;
        public int quyen;
        public string tennv;

        public Form1(int manv)
        {
            this.manvnv = manv;
            InitializeComponent();
            home21.BringToFront();
            loadnv();
            ui();
        }
        
        private void loadnv()
        {
            try
            {
                DataTable dt = new DataTable();
                StringBuilder query = new StringBuilder("SELECT * FROM tbnv where tk = "+manvnv+"");
                dt = data.execQuery(query.ToString());
                dataGridView1.DataSource = dt;
                quyen = (int)dataGridView1.Rows[0].Cells[2].Value;
                // tennv = dataGridView1.Rows[0].Cells[3].ToString();
                nv.DataBindings.Clear();
                nv.DataBindings.Add("Text", dt, "ten_nv", true);
                //mahd.Value = mahoadon;
            }
            catch
            {
            }

        }
        private void ui()
        {
           if (quyen == 1)
            {
                siticoneButton3.Hide();
            }
            if (quyen == 0)
            {
                siticoneButton3.Show();
                siticoneButton2.Hide();
                siticoneButton4.Hide();
                siticoneButton5.Hide();
                siticoneButton7.Hide();
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            siticoneShadowForm1.SetShadowForm(this);
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void siticonePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void siticoneGradientButton1_Click(object sender, EventArgs e)
        {

        }

        private void siticonePictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void siticoneButton1_CheckedChanged(object sender, EventArgs e)
        {
           // if (siticoneButton1.Checked) home1.BringToFront();
        }

        private void siticoneButton2_CheckedChanged(object sender, EventArgs e)
        {
           // if (siticoneButton2.Checked) kho1.BringToFront();
        }

        private void kho1_Load(object sender, EventArgs e)
        {

        }

        private void siticoneTileButton1_Click(object sender, EventArgs e)
        {

        }

        private void siticoneTileButton2_Click(object sender, EventArgs e)
        {

        }

        private void kho1_Load_1(object sender, EventArgs e)
        {
             
        }

        private void siticoneButton6_Click(object sender, EventArgs e)
        {
         
        }

        private void siticoneButton1_Click_1(object sender, EventArgs e)
        {
            
            home21.BringToFront();
        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            home1.BringToFront();

        }

        private void siticoneButton3_Click(object sender, EventArgs e)
        {
            taohoadon1.BringToFront();
        }

        private void siticoneButton6_Click_1(object sender, EventArgs e)
        {
           
            Login lg = new Login();
            this.Hide();
            lg.ShowDialog();
            this.Show();
        }

        private void siticoneControlBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void siticonePanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void siticoneButton7_Click(object sender, EventArgs e)
        {
            themnv1.BringToFront();
        }

        private void siticoneButton1_Click_2(object sender, EventArgs e)
        {
            home21.BringToFront();

        }

        private void siticoneButton2_Click_1(object sender, EventArgs e)
        {
            if (quyen == 1)
            {
                home1.BringToFront();
            }
            else

            {
                lỗi1.BringToFront();
            }
        }

        private void siticoneButton3_Click_1(object sender, EventArgs e)
        {
            if (quyen == 0)

            {
                taohoadon1.BringToFront();
                
            }
            else

            {
                lỗi1.BringToFront();
            }
        }

        private void siticoneButton7_Click_1(object sender, EventArgs e)
        {
            if (quyen == 1)
            {
                themnv1.BringToFront();
            }
            else

            {
                lỗi1.BringToFront();
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            siticoneShadowForm1.SetShadowForm(this);
        }

        private void siticoneButton6_Click_2(object sender, EventArgs e)
        {
            Login lg = new Login();
            this.Hide();
            lg.ShowDialog();
            this.Show();
        }

        private void siticoneControlBox3_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void nv_Click(object sender, EventArgs e)
        {

        }

        private void siticoneButton4_Click(object sender, EventArgs e)
        {
            if (quyen == 1)
            {
                thongkeUserControl11.BringToFront();
            }
            else

            {
                lỗi1.BringToFront();
            }
        }

        private void siticoneButton5_Click(object sender, EventArgs e)
        {
            if (quyen == 1)
            {
                hd1.BringToFront();
            }
            else

            {
                lỗi1.BringToFront();
            }
        }

        private void hd1_Load(object sender, EventArgs e)
        {

        }

        private void taohoadon1_Load(object sender, EventArgs e)
        {
            taohoadon1.manv = this.manvnv;
        }

        private void siticonePanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
