using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace app_m.Books
{
    public partial class Kho : UserControl
    {
        private data data = new data();

        public Kho()
        {
            InitializeComponent();
            init();
           
        }
        private void init()
        {
            initkho();
        }
        private void initkho()
        {
            loaddgKho();
        }
        private void loaddgKho()
        {
           // DataTable dt = new DataTable();
            //StringBuilder query = new StringBuilder("SELECT Ten_Sach as [Tên Sách],The_Loai,Nha_xb,So_lUONG,gIA_bAN");
            
            //query.Append(" from tbl_Sach");
            //dt = data.execQuery(query.ToString());
            //dgKho.DataSource = dt;
            
            //dgKho.Columns[0].Width = 251;
            //dgKho.Columns[1].Width = 0;
            //dgKho.Columns[2].Width = 0;
            //dgKho.Columns[3].Width = 0;
           // dgKho.Columns[4].Width = 0;
        }

       
        private void Kho_Load(object sender, EventArgs e)
        {

        }

        private void siticonePanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void siticoneLabel1_Click(object sender, EventArgs e)
        {

        }

        private void siticoneLabel2_Click(object sender, EventArgs e)
        {

        }

        private void siticoneLabel5_Click(object sender, EventArgs e)
        {

        }

        private void siticoneGradientButton1_Click(object sender, EventArgs e)
        {

        }

       
        private void siticoneDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void siticoneGradientButton3_Click(object sender, EventArgs e)
        {

        }

        private void siticonePanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void siticoneLabel3_Click(object sender, EventArgs e)
        {

        }

        private void siticoneLabel4_Click(object sender, EventArgs e)
        {

        }
        private void Hinh_DoubleClick(object sender, EventArgs e)
        {
           // openFileDialog1.ShowDialog();
           // string file = openFileDialog1.FileName;
           // if (string.IsNullOrEmpty(file))
            //    return;
            ////Image myim = Image.FromFile(file);
            //Hinh.Image = myim;
        }
        private void siticoneGradientButton2_Click(object sender, EventArgs e)
        {
           // MemoryStream stream = new MemoryStream();
           // Hinh.Image.Save(stream, ImageFormat.Jpeg);
            
           // StringBuilder query = new StringBuilder("INSERT INTO tbl_Sach (Ten_Sach , hIN) ");
           // query.Append(" values(  N'" + tbTenS.Text + "')");
           // query.Append("'"+stream.ToArray()+"')");
           /// int result = data.execNonQuery(query.ToString());
           // if (result > 0)
            //{
               // loaddgKho();
              //  MessageBox.Show("Thêm sách thành công !", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
           // }
           // else
            //{
             //   MessageBox.Show("Thêm sách không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
           // }
        }

        private void siticoneGradientButton3_Click_1(object sender, EventArgs e)
        {

        }

        private void dgKho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //int rowid = e.RowIndex;
           // if (rowid < 0) rowid = 0;
           // if (rowid == dgKho.RowCount - 1) rowid = rowid - 1;
           // DataGridViewRow row = dgKho.Rows[rowid];
            //tbTenS.Text = row.Cells[0].Value.ToString();
            //tbTl.Text = row.Cells[1].Value.ToString();
            //tbNXB.Text= row.Cells[2].Value.ToString();


        }
        private void siticoneLabel6_Click(object sender, EventArgs e)
        {

        }

        private void dgKho_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           // DataTable dt = new DataTable();
            //StringBuilder query = new StringBuilder("SELECT * from tbl_Sach where Ten_Sach = '"+tbTenS.Text+"'");
          
            //dt = data.execQuery(query.ToString());
            //dgKho.DataSource = dt;
            //tbTl.DataBindings.Clear();
            //tbTl.DataBindings.Add("text", dt, "The_Loai");



        }

        private void siticoneLabel7_Click(object sender, EventArgs e)
        {

        }

        private void Hinh_Click(object sender, EventArgs e)
        {
          

        }
    }
}
