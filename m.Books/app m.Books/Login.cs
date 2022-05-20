using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace app_m.Books
{
    public partial class Login : Form
    {
        private data data = new data();
        public int manv;
        public Login()
        {
            InitializeComponent();
            tb_tk.Text = "";
            mk.Text = "";
        
        }
        public void laymanv()
        {
          
           //  DataTable dt = new DataTable();
            //dt = data.execQuery("SELECT * FROM tbnv where tk = " + int.Parse(tb_tk.Text) + "");
            //numericUpDown1.DataBindings.Clear();
            //numericUpDown1.DataBindings.Add("Value", dt, "quyen", true);
            //manv = (int)numericUpDown1.Value;

        }


        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-RMNTRKR\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=mb");
            try
            {

                conn.Open();
                int tk = int.Parse(tb_tk.Text);

                string sql = "select * from tbnv where tk = " + tk + " and mk ='" + mk.Text + "' COLLATE SQL_Latin1_General_CP1_CS_AS ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dta = cmd.ExecuteReader();
                if (dta.Read() == true)
                {
                manv = tk;
                Form1 fr = new Form1( manv);
                //
                //conn.Close();
                    
                    this.Hide();
                    fr.ShowDialog();
                    //this.Show();
                    }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu");
                }
           }
         catch (Exception)
           {
              MessageBox.Show("Sai tài khoản hoặc mật khẩu");
          }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            siticoneShadowForm1.SetShadowForm(this);
        }

        private void siticoneLabel1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
