using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app_m.Books
{
    public partial class Home : UserControl
    {
        private data data = new data();
        private int maSach;
        
        public int maLoaiSach;
        public Home()
        

        {
            InitializeComponent();
            st5.Hide();
            btsth.Hide();
            tbtl.Hide();
            Init();


        }
        private void Init()
        {
            initkho();
            loaddFind();
        }
        private void initkho()
        {

            loaddFind();
            loadcbSachLoaiSach();
            loadcbloctheloai();
            loaddgKho();
        }
        private void loadcbloctheloai()
        {
            DataTable dt = new DataTable();
            dt = data.execQuery("SELECT * FROM tbtheloai");
            cbloc.DisplayMember = "ten_theloai";
            cbloc.ValueMember = "ma_theloai";
            cbloc.DataSource = dt;
        }
        private void loadcbSachLoaiSach()
        {
            DataTable dt = new DataTable();
            dt = data.execQuery("SELECT * FROM tbtheloai");
            cbSachLoaiSach.DisplayMember = "ten_theloai";
            cbSachLoaiSach.ValueMember = "ma_theloai";
            cbSachLoaiSach.DataSource = dt;
        }
        private void loaddFind()
        {

            DataTable dt = new DataTable();
            StringBuilder query = new StringBuilder("SELECT Ten_Sach as [Tên Sách],ma_sach,ten_theloai");
            query.Append(" from tbsach, tbtheloai where tbsach.ma_theloai = tbtheloai.ma_theloai and tbsach.ten_sach like N'%" + tbf.Text + "%'");
            dt = data.execQuery(query.ToString());
            DataGridView3.DataSource = dt;

            DataGridView3.Columns[0].Width = 286;
           DataGridView3.Columns[1].Width = 0;
           DataGridView3.Columns[2].Width = 0;
            btThem.BringToFront();
            btSua.BringToFront();
            btXoa.BringToFront();

        }
        private void loaddLoc()
        {

            DataTable dt = new DataTable();
            StringBuilder query = new StringBuilder("SELECT Ten_Sach as [Tên Sách],ma_sach,ten_theloai");
            query.Append(" from tbsach, tbtheloai where tbsach.ma_theloai = tbtheloai.ma_theloai and tbtheloai.ten_theloai like N'%" + cbloc.Text+ "%'");
            dt = data.execQuery(query.ToString());
            DataGridView3.DataSource = dt;

            DataGridView3.Columns[0].Width = 286;
            DataGridView3.Columns[1].Width = 0;
            DataGridView3.Columns[2].Width = 0;
            btThem.BringToFront();
            btSua.BringToFront();
            btXoa.BringToFront();

        }

        private void loaddgKho()
        {

            DataTable dt = new DataTable();
            StringBuilder query = new StringBuilder("SELECT Ten_Sach as [Tên Sách],ma_sach,ten_theloai ");
            query.Append(" from tbsach, tbtheloai where tbsach.ma_theloai = tbtheloai.ma_theloai");
            dt = data.execQuery(query.ToString());
            DataGridView3.DataSource = dt;

            DataGridView3.Columns[0].Width = 286;
            DataGridView3.Columns[1].Width = 0;
            DataGridView3.Columns[2].Width = 0;
            btThem.BringToFront();
            btSua.BringToFront();
            btXoa.BringToFront();
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
           // DataTable dt = new DataTable();
           // dt = data.execQuery("SELECT * FROM tbsach where ten_sach like N'%" + siticoneTextBox1.Text + "%'");
           // cblo.DisplayMember = "Ten_Sach";
           // cblo.ValueMember = "ma_Sach";
           // cblo.DataSource = dt;
        }
        private void cbSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            maSach = (int)comboBox.SelectedValue;
        }

        private void siticoneDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void siticoneDataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Hinh_Click(object sender, EventArgs e)
        {

            //Hinh.Width = 112;
            //Hinh.Height = 155;
            Hinh.ShadowDecoration.Enabled = false;
        }


        private void btThem_Click(object sender, EventArgs e)
        {

            btwhite.BringToFront();
            //btts.BringToFront();
            btSave.BringToFront();
            btout.BringToFront();
            tbTg.DataBindings.Clear();
            
            cbSachLoaiSach.StartIndex = 0;
            
            tbNXB.DataBindings.Clear();
            
            txtHinh.DataBindings.Clear();
           
            nbSL.DataBindings.Clear();
            
            nbGiaBan.DataBindings.Clear();
            
            //btMa.Text.DataBindings.Clear();
            //nbGiaBan.DataBindings.Add("Value", dt, "gia_ban", true);
            Hinh.ImageLocation = txtHinh.Text;
            pi5.ImageLocation = txtHinh.Text;
            tbTenS.Text = "";
            tbTg.Text = "";
            txtHinh.Text = "";
            btMa.Text = "";
            Hinh.ImageLocation = txtHinh.Text;
            //tbTl.Text = "";
            tbNXB.Text = "";
            nbSL.Value = 0;
            nbGiaBan.Value = 0;

            //StringBuilder query = new StringBuilder("INSERT into tbsach (ten_sach,tac_gia,The_loai,nha_xb,so_luong,gia_ban,hinh ) ");
            //query.Append(" values(  N'" + tbTenS.Text + "',");
            //query.Append("N'" + tbTg.Text + "',");
            //query.Append("N'" + tbTl.Text + "',");
            // query.Append("N'" + tbNXB.Text + "',");
            //query.Append(+nbSL.Value);
            //query.Append("," +nbGiaBan.Value);
            //query.Append(",N'" + txtHinh.Text + "')");
            //int result = data.execNonQuery(query.ToString());
            //if (result > 0)
            //{
            // loaddgKho();
            // MessageBox.Show("Thêm sách thành công !", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            // }
            // else
            // {
            // MessageBox.Show("Thêm sách không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            // }
        }
        //[Tên Sách],tac_gia,The_loai,nha_xb,so_luong,gia_ban,hinh,ma_sach
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowid = e.RowIndex;
                if (rowid < 0) rowid = 0;
                if (rowid == DataGridView3.RowCount - 1) rowid = rowid - 1;
                DataGridViewRow row = DataGridView3.Rows[rowid];
                tbTenS.Text = row.Cells[0].Value.ToString();
                // tbTg.Text = row.Cells[1].Value.ToString();
                cbSachLoaiSach.Text = row.Cells[2].Value.ToString();
                // tbNXB.Text = row.Cells[3].Value.ToString();
                // nbSL.Value = (int)row.Cells[4].Value;
                // nbGiaBan.Value = (int)row.Cells[5].Value;
                // txtHinh.Text = row.Cells[6].Value.ToString();
                btMa.Text = row.Cells[1].Value.ToString();
                //tac_gia,The_loai,nha_xb,so_luong,gia_ban,hinh,ma_sach
                DataTable dt = new DataTable();
                dt = data.execQuery("SELECT * FROM tbsach where ten_sach like N'" + tbTenS.Text + "'");
                tbTg.DataBindings.Clear();
                tbTg.DataBindings.Add("Text", dt, "Tac_gia", true);
                //tbTl.DataBindings.Clear();
                // tbTl.DataBindings.Add("Text", dt, "The_loai", true);
                tbNXB.DataBindings.Clear();
                tbNXB.DataBindings.Add("Text", dt, "nha_xb", true);
                txtHinh.DataBindings.Clear();
                txtHinh.DataBindings.Add("Text", dt, "hinh", true);
                nbSL.DataBindings.Clear();
                nbSL.DataBindings.Add("Value", dt, "so_luong", true);
                nbGiaBan.DataBindings.Clear();
                nbGiaBan.DataBindings.Add("Value", dt, "gia_ban", true);
                //btMa.Text.DataBindings.Clear();
                //nbGiaBan.DataBindings.Add("Value", dt, "gia_ban", true);
                Hinh.ImageLocation = txtHinh.Text;
                pi5.ImageLocation = txtHinh.Text;
                st5.Hide();
               // Hinh.Width = 112;
                //Hinh.Height = 155;
                Hinh.ShadowDecoration.Enabled = false;

                //btts.BringToFront();
                btMa.BringToFront();
                siticoneGradientButton1.BringToFront();
                btThem.BringToFront();
                btSua.BringToFront();
                btXoa.BringToFront();
               // tbf.Text = "";
            }
            catch(Exception)
            {

            }
        }

        private void siticoneButton3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = openFileDialog1.Filter = "JPG files (*.jpg)|*.jpg|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.ReadOnlyChecked = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Hinh.ImageLocation = openFileDialog1.FileName;
                pi5.ImageLocation = openFileDialog1.FileName;
                txtHinh.Text = openFileDialog1.FileName;
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {

            DialogResult check = MessageBox.Show("Xác nhận chỉnh sửa ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                try {
                    StringBuilder query = new StringBuilder("update  tbsach ");
                    query.Append(" set ten_sach = N'" + tbTenS.Text + "',");
                    query.Append("tac_gia = N'" + tbTg.Text + "',");
                    query.Append("ma_theloai= " + maLoaiSach);
                    query.Append(",nha_xb = N'" + tbNXB.Text + "',");
                    query.Append("so_luong=" + nbSL.Value);
                    query.Append(",gia_ban=" + nbGiaBan.Value);
                    query.Append(",hinh = N'" + txtHinh.Text + "' where ma_sach =" + btMa.Text.ToString() + "");
                    int result = data.execNonQuery(query.ToString());
                    if (result > 0)
                    {
                        loaddgKho();
                        MessageBox.Show("Sửa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        MessageBox.Show("Sửa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch
                {
                    MessageBox.Show("Không có sách để chỉnh sửa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


        }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Xóa sách " + tbTenS.Text + " sẽ không thể khôi phục?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                try
                {
                    StringBuilder query = new StringBuilder("delete  tbsach  where ma_sach =" + btMa.Text.ToString() + "");

                    int result = data.execNonQuery(query.ToString());
                    if (result > 0)
                    {
                        loaddgKho();
                        MessageBox.Show("Xóa thành công !", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        MessageBox.Show("Xóa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch
                {
                    MessageBox.Show("Không có sách để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void siticoneGradientButton2_Click(object sender, EventArgs e)
        {

        }

        private void siticoneGradientButton3_Click(object sender, EventArgs e)
        {
            //loaddFind();
        }

        private void siticoneGradientButton4_Click(object sender, EventArgs e)
        {
            loadcbloctheloai();
            loaddgKho();
            tbf.Text = "";
            cbloc.Text ="";
        }

        private void Hinh_DoubleClick_1(object sender, EventArgs e)
        {
            st5.Show();


        }

        private void Hinh_Click_1(object sender, EventArgs e)
        {
            //Hinh.Width = 112;
            //Hinh.Height = 155;
            //Hinh.ShadowDecoration.Enabled = false;
        }

        private void siticonePanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btSave_Click(object sender, EventArgs e)
        { if (tbTenS.Text != "")
            {
                StringBuilder query = new StringBuilder("INSERT into tbsach (ten_sach,tac_gia,ma_theloai,nha_xb,so_luong,gia_ban,hinh ) ");
                query.Append(" values(  N'" + tbTenS.Text + "',");
                query.Append("N'" + tbTg.Text + "',");
                query.Append(maLoaiSach);
                query.Append(",N'" + tbNXB.Text + "',");
                query.Append(+nbSL.Value);
                query.Append("," + nbGiaBan.Value);
                query.Append(",N'" + txtHinh.Text + "')");
                int result = data.execNonQuery(query.ToString());
                if (result > 0)
                {
                    loaddgKho();
                    MessageBox.Show("Thêm sách thành công !", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Thêm sách không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên sách!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbf_TabIndexChanged(object sender, EventArgs e)
        {
            loaddFind();

        }

        private void tbf_TextChanged(object sender, EventArgs e)
        {
            //cbloc.SelectedIndex = -1;
            loaddFind();
            st5.Hide();
            x.Show();
            x.BringToFront();
           // DataGridView3.Height = 4+(DataGridView3.Rows[0].Height)*(DataGridView3.Rows.Count-1);
        }

        private void btout_Click(object sender, EventArgs e)
        {
            //btts.BringToFront();
            btMa.BringToFront();
            siticoneGradientButton1.BringToFront();
            btThem.BringToFront();
            btSua.BringToFront();
            btXoa.BringToFront();
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int rowid = e.RowIndex;
            if (rowid < 0) rowid = 0;
            if (rowid == DataGridView3.RowCount - 1) rowid = rowid - 1;
            DataGridViewRow row = DataGridView3.Rows[rowid];
            tbTenS.Text = row.Cells[0].Value.ToString();
            tbTg.Text = row.Cells[1].Value.ToString();
            maLoaiSach = (int)row.Cells[2].Value;
            tbNXB.Text = row.Cells[3].Value.ToString();
            nbSL.Value = (int)row.Cells[4].Value;
            nbGiaBan.Value = (int)row.Cells[5].Value;
            txtHinh.Text = row.Cells[6].Value.ToString();
            btMa.Text = row.Cells[7].Value.ToString();
            // Hinh.ImageLocation = txtHinh.Text;
            pi5.ImageLocation = txtHinh.Text;

            //// Hinh.Width = 112;
            //Hinh.Height = 155;
            //Hinh.ShadowDecoration.Enabled = false;
            st5.Hide();
            //btts.BringToFront();
            btMa.BringToFront();
            siticoneGradientButton1.BringToFront();
            btThem.BringToFront();
            btSua.BringToFront();
            btXoa.BringToFront();
        }



        private void cblo_TextChanged(object sender, EventArgs e)
        {

        }

        private void siticoneTextBox1_TextChanged(object sender, EventArgs e)
        {
            loadCbloc();
            //siticonePanel1.Height = 18;


        }

        private void nbSL_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cblo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cblo.StartIndex = -1;
            //siticoneTextBox1.Text = cblo.Text;
        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            // st5.Show();
        }

        private void pi5_Click(object sender, EventArgs e)
        {
            st5.Hide();
        }

        private void siticonePanel2_Click(object sender, EventArgs e)
        {
            st5.Hide();
        }

        private void Home_Click(object sender, EventArgs e)
        {
            st5.Hide();
        }

        private void siticonePanel3_Click(object sender, EventArgs e)
        {
            st5.Hide();
        }

        private void tbTenS_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbSachLoaiSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            maLoaiSach = (int)comboBox.SelectedValue;
        }

        private void siticoneButton2_Click_1(object sender, EventArgs e)
        {
            loadcbloctheloai();
            btsth.Show();
            tbtl.Show();
        }

        private void btsth_Click(object sender, EventArgs e)
        {
            StringBuilder query = new StringBuilder("INSERT into tbtheloai (ten_theloai ) ");
            query.Append(" values(  N'" + tbtl.Text + "')");
   
            int result = data.execNonQuery(query.ToString());
            if (result > 0)
            {
                loadcbloctheloai();
                loadcbSachLoaiSach();
                MessageBox.Show("Thêm thể loại "+tbtl.Text+" thành công !", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                tbtl.Text = "";
                tbtl.Hide();
                btsth.Hide();
            }
            else
            {
                MessageBox.Show("Thêm thể loại không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbloc_SelectedValueChanged(object sender, EventArgs e)
        {
            //ComboBox comboBox = sender as ComboBox;
            tbf.Text = "";
            x.Hide();
            loaddLoc();
        }

        private void cbloc_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }

        private void siticoneCirclePictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void x_Click(object sender, EventArgs e)
        {
            tbf.Text = "";
            x.Hide();
        }
    }
}
