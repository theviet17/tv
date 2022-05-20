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
    public partial class themnv : UserControl
    {
        private data data = new data();
        public themnv()
        {
            InitializeComponent();
            loadnv();
        }

        private void siticoneLabel1_Click(object sender, EventArgs e)
        {

        }
        private void btsavshow()
        {

            btSave.BringToFront();
            btout.BringToFront();
            btXoa.Hide();

        }
        private void btsavhide()
        {

            btSave.SendToBack();
            btout.SendToBack();
            btXoa.Show();
        }
        private void loadnv()
        {

            DataTable dt = new DataTable();
            StringBuilder query = new StringBuilder("SELECT ten_nv as [Tên Nhân Viên]");
            query.Append(" from tbnv");
            dt = data.execQuery(query.ToString());
            dgnv.DataSource = dt;

        }
        private string tennv;
        private void dgnv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowid = e.RowIndex;
                if (rowid < 0) rowid = 0;
                if (rowid == dgnv.RowCount - 1) rowid = rowid - 1;
                DataGridViewRow row = dgnv.Rows[rowid];
                tbtennv.Text = row.Cells[0].Value.ToString();
                tennv = row.Cells[0].Value.ToString();
                DataTable dt = new DataTable();
                dt = data.execQuery("SELECT * FROM tbnv where ten_nv = N'" + tbtennv.Text + "'");
                tbtaikhoan.DataBindings.Clear();
                tbtaikhoan.DataBindings.Add("Text", dt, "tk", true);
                tbmk.DataBindings.Clear();
                tbmk.DataBindings.Add("Text", dt, "mk", true);
                cbQuyen.DataBindings.Clear();
                cbQuyen.DataBindings.Add("StartIndex", dt, "quyen", true);
                btsavhide();
                btThem.BringToFront();
                btSua.BringToFront();
                btXoa.BringToFront();
                
            }
            catch (Exception)
            {

            }
        }

        private void btSave_Click(object sender, EventArgs e)
        { if (tbtennv.Text != "" & tbmk.Text !="" & cbQuyen.SelectedIndex != -1)
            {
                StringBuilder query = new StringBuilder("INSERT into tbnv (ten_nv,mk, quyen ) ");
                query.Append(" values(  N'" + tbtennv.Text + "',");
                query.Append("N'" + tbmk.Text + "',");
                query.Append("" + cbQuyen.SelectedIndex + ")");
                int result = data.execNonQuery(query.ToString());
                if (result > 0)
                {
                    loadnv();
                    btsavhide();
                    MessageBox.Show("Thêm nhân viên " + tbtennv.Text + " thành công !", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Thêm sách không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btout_Click(object sender, EventArgs e)
        {
            btsavhide();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            btsavshow();
            tbtennv.Text = "";
            tbtaikhoan.Text = "";
            tbmk.Text = "";
            cbQuyen.StartIndex = -1;
        }

        private void themnv_Load(object sender, EventArgs e)
        {

        }

        private void btSua_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Xác nhận thay đổi thông tin nhân viên " + tennv + " ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            { try
                {
                    StringBuilder query = new StringBuilder("update  tbnv ");
                    query.Append(" set ten_nv = N'" + tbtennv.Text + "',");
                    query.Append("mk = N'" + tbmk.Text + "',");
                    query.Append("quyen = " + cbQuyen.SelectedIndex);
                    query.Append("where tk =" + int.Parse(tbtaikhoan.Text) + "");
                    int result = data.execNonQuery(query.ToString());
                    if (result > 0)
                    {
                        loadnv();
                        MessageBox.Show("Sửa thành thông tin nhân viên " + tennv + " thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        MessageBox.Show("Sửa thông tin nhân viên " + tennv + " không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch
                {
                    MessageBox.Show("Không có thông tin để thay đổi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Xác nhận xóa nhân viên "+tennv+" ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (check == DialogResult.Yes)
            {
                try
                {
                    StringBuilder query = new StringBuilder("delete tbnv ");
                    query.Append("where tk =" + int.Parse(tbtaikhoan.Text) + "");
                    int result = data.execNonQuery(query.ToString());
                    if (result > 0)
                    {
                        loadnv();
                        MessageBox.Show("Xóa nhân viên " + tennv + " thành công !", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        MessageBox.Show("Xóa nhân viên " + tennv + " không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch
                {
                    MessageBox.Show("Không có thông tin để xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}