using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace app_m.Books
{
    public partial class taohoadon : UserControl
    {
        private data data = new data();
        public int mahoadon;
        public int masach;
        public int manv;
        public taohoadon()
        {
            InitializeComponent();
            
            dgfind.Height = 4;
            loadmahd();
            kiemtrachuatt();
            loaddgKho();
        }
      
        private void loadmahd()
        {
            //DataTable dt = new DataTable();
            //dt = data.execQuery("SELECT * FROM tbhoadon where trang_thai = 0");
            //mahd.DataBindings.Clear();
            // mahd.DataBindings.Add("value", dt, "ma_hoadon", true);
            //if (mahd.Value == 0)
            // {
            //   siticoneButton2.Hide();
            //}
            // loaddgKho();
            try
            {
                DataTable dt = new DataTable();
                StringBuilder query = new StringBuilder("SELECT * FROM tbhoadon where trang_thai = 0");
                dt = data.execQuery(query.ToString());
                dgmahd.DataSource = dt;
                mahoadon = (int)dgmahd.Rows[0].Cells[0].Value;
                //mahd.Value = mahoadon;
            }
            catch
            {
            }

        }
        private void kiemtrachuatt()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-RMNTRKR\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=mb");
            try
            {

                conn.Open();
                //int tk = int.Parse(tb_tk.Text);

                string sql = "SELECT * FROM tbhoadon where trang_thai = 0";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dta = cmd.ExecuteReader();
                if (dta.Read() == true)
                {
                    siticoneButton2.Hide();
                    loadtenkh();
                }
                else
                {

                }
            }
            catch (Exception)
            {

            }
        }
        private void loadtenkh()
        {
            DataTable dt = new DataTable();
            dt = data.execQuery("SELECT * FROM tbhoadon where ma_hoadon =" + mahoadon + "");
            tenKH.DataBindings.Clear();

            tenKH.DataBindings.Add("Text", dt, "ten_kh", true);



        }
        private void loadnb1()
        {
            DataTable dt = new DataTable();
            dt = data.execQuery("SELECT * FROM tbsach where ten_sach  = N'" + tb_tens.Text + "'");
            nb1.DataBindings.Clear();

            nb1.DataBindings.Add("Maximum", dt, "so_luong", true);



        }
        private void loaddgKho()
        {

            DataTable dt = new DataTable();
            StringBuilder query = new StringBuilder("SELECT ma_hoadon, ma_sach,[Tên sách], [Giá bán], [Số lượng] as [Số lượng]  from CTHD15 ");

            query.Append(" where ma_hoadon =" + mahoadon);
            dt = data.execQuery(query.ToString());
            dgcthd.DataSource = dt;

            dgcthd.Columns[0].Width = 0;
            dgcthd.Columns[1].Width = 0;
            dgcthd.Columns[2].Width = 230;
            //  DataGridView3.Columns[2].Width = 0;
            // DataGridView3.Columns[3].Width = 0;
            // DataGridView3.Columns[4].Width = 0;
            // DataGridView3.Columns[5].Width = 0;
            // DataGridView3.Columns[6].Width = 0;
            // DataGridView3.Columns[7].Width = 0;
            //DataGridView1.Columns[1].DefaultCellStyle.ForeColor = Color.White;

        }

        private void loadCbloc()
        {
            DataTable dt = new DataTable();
            StringBuilder query = new StringBuilder("SELECT Ten_Sach as [Tên Sách],ma_sach");
            query.Append(" from tbsach where ten_sach like N'%" + TextBox1.Text + "%'");
            dt = data.execQuery(query.ToString());
            dgfind.DataSource = dt;

            dgfind.Columns[0].Width = 286;
            dgfind.Columns[1].Width = 0;
        }
        private void taohoadon_Load(object sender, EventArgs e)
        {
            btx.Hide();

        }

        private void tbf_TextChanged(object sender, EventArgs e)
        {
            if (tbf.Text == "")
            {
                TextBox1.Text = "ádasdasdádasdasafafeasda";
                btx.Hide();

            }
            else
            {
                TextBox1.Text = tbf.Text;
                btx.Show();
                btx.BringToFront();
            }
            // loadCbloc();
            // dgfind.Height = 4 + (dgfind.Rows[0].Height) * (dgfind.Rows.Count - 1);

        }

        private void cblo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // tb_tens.Text = cblo.Text;
        }

        private void btx_Click(object sender, EventArgs e)
        {

            tbf.Text = "";
            dgfind.DataBindings.Clear();
            btx.Hide();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tb_tens_TextChanged(object sender, EventArgs e)
        {
            //loadCbloc();

        }

        private void tbf_Click(object sender, EventArgs e)
        {
            loadnb1();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            // if (tbf.Text=="")
            //{
            //  TextBox1.Text = "ádasdasdasda";

            // }
            // else
            // {
            //     //TextBox1.Text = tbf.Text;
            //}
            loadCbloc();
            dgfind.Height = 4 + (dgfind.Rows[0].Height) * (dgfind.Rows.Count - 1);
        }

        private void dgfind_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void loadmas()
        {
            //DataTable dt = new DataTable();
            //dt = data.execQuery("SELECT * FROM tbsach where ten_sach = '" + tb_tens.Text + "'");
            //mas.DataBindings.Clear();
            //mas.DataBindings.Add("Value", dt, "ma_sach", true);
        }
        private void dgfind_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowid = e.RowIndex;
                if (rowid < 0) rowid = 0;
                if (rowid == dgfind.RowCount - 1) rowid = rowid - 1;
                DataGridViewRow row = dgfind.Rows[rowid];
                tb_tens.Text = row.Cells[0].Value.ToString();
                masach = (int)row.Cells[1].Value;
                tbf.Text = "";
                loadnb1();
                //DataTable dt = new DataTable();
                //dt = data.execQuery("SELECT * FROM tbsach where ten_sach = '"+tb_tens.Text+"'");
                //mas.DataBindings.Clear();
                // mas.DataBindings.Add("Value", dt, "ma_sach", true);
                //  loadmas();

            }
            catch (Exception)
            {

            }
        }
        public int Mahd;
        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            StringBuilder query = new StringBuilder("INSERT into tbhoadon (ten_kh,trang_Thai, ngay,ma_nv ) ");
            query.Append(" values(  N'" + tenKH.Text + "', 0, '"+dtngay.Value+"',"+manv+")");

            int result = data.execNonQuery(query.ToString());
            if (result > 0)
            {
                loadmahd();
                kiemtrachuatt();
            }
            else
            {
                MessageBox.Show("Tạo hóa đơn không thành công thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void siticoneTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void siticoneLabel1_Click(object sender, EventArgs e)
        {

        }

        private void siticoneLabel2_Click(object sender, EventArgs e)
        {

        }

        private void siticoneButton6_Click(object sender, EventArgs e)
        {
            //  SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-RMNTRKR\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=mb");
            //try
            // {

            /// conn.Open();
            //int tk = int.Parse(tb_tk.Text);

            // string sql = "SELECT * FROM tbhoadon where ma_hoadon="+mahoadon+"and ma_sach="+masach+"";
            //  SqlCommand cmd = new SqlCommand(sql, conn);
            // SqlDataReader dta = cmd.ExecuteReader();
            // if (dta.Read() == true)
            // {
            //StringBuilder query = new StringBuilder("update from tbchitiethd");
            //query.Append("set so_luong =" + nb1.Value + ")");

            // int result = data.execNonQuery(query.ToString());
            //  if (result > 0)
            // {
            //  loaddgKho();
            //    // MessageBox.Show("Cập nhật " + tb_tens.Text + " vào hóa đơn !", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            // }
            // else
            // {
            // /    // MessageBox.Show("Thêm sách không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            // }
            // }
            // else

            StringBuilder query = new StringBuilder("EXEC proc_themchitiethoadon6");
            query.Append(" @maHoadon= " + mahoadon + ",");
            query.Append("@maSach = " + masach + ",");
            query.Append("@soLuong =" + nb1.Value);

            int result = data.execNonQuery(query.ToString());
            if (result > 0)
            {
                tb_tens.Text = "";
                nb1.Value = 0;
                loaddgKho();
                bttt.BringToFront();
                MessageBox.Show("Đã thêm sách" + tb_tens.Text + " vào hóa đơn !", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Thêm sách không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //  }
            // }
            // catch (Exception)
            // {

            // }


        }
        private void loadsoluongsach()
        {
            StringBuilder query = new StringBuilder(" exec proc_capnhatsoluongsach1 ");
            query.Append("@maHoadon= " + mahoadon);

            int result = data.execNonQuery(query.ToString());
            if (result > 0)
            {
            }
            else
            {
            }
   
        }

        private void siticoneButton4_Click(object sender, EventArgs e)
        {
            StringBuilder query = new StringBuilder("update tbhoadon set trang_thai = 1 ,tong_tien = "+nbtt.Value+" where ma_hoadon = " +mahoadon+"");
            
            int result = data.execNonQuery(query.ToString());
            if (result > 0)
            {
                loadsoluongsach();
                tenKH.Text = "";
                tb_tens.Text = "";
                nb1.Value = 0;
                siticoneButton2.Show();
                mahoadon = 1;
                kiemtrachuatt();
                loaddgKho();
                bttt.BringToFront();
                MessageBox.Show("Thanh toán hóa đơn thành công !", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Thêm sách không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            loadmahd();
            kiemtrachuatt();
        }

        private void dgcthd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowid = e.RowIndex;
                if (rowid < 0) rowid = 0;
                if (rowid == dgcthd.RowCount - 1) rowid = rowid - 1;
                DataGridViewRow row = dgcthd.Rows[rowid];
                tb_tens.Text = row.Cells[2].Value.ToString();
                // tbTg.Text = row.Cells[1].Value.ToString();
                masach = (int)row.Cells[1].Value;
                nb1.Value = (int)row.Cells[4].Value;
                // tbNXB.Text = row.Cells[3].Value.ToString();
                
            }
            catch (Exception)
            {

            }
        }

        private void dgcthd_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void siticoneButton7_Click(object sender, EventArgs e)
        {
            
                StringBuilder query = new StringBuilder("EXEC proc_xoasachkhoicthd ");
                query.Append("@maHoadon = "+mahoadon+", @maSach = "+masach);
                int result = data.execNonQuery(query.ToString());
                if (result > 0)
                {
                    loaddgKho();
                bttt.BringToFront();
                   // MessageBox.Show("Xóa thành công !", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                   // MessageBox.Show("Xóa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            

        }

        private void siticoneButton3_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                StringBuilder query = new StringBuilder("select[dbo].[fn_tinhtienhoadon](" + mahoadon + ") as tt");
                dt = data.execQuery(query.ToString());
                dgtt.DataSource = dt;
                nbtt.Value = (int)dgtt.Rows[0].Cells[0].Value;
                bttt1.BringToFront();
            }
            catch
            {

            }

         
        }

        private void siticonePanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
              }
    }
}
