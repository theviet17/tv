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
    public partial class THONGKEUserControl1 : UserControl
    {
        private data data = new data();
        public THONGKEUserControl1()
        {
            InitializeComponent();
            loadcbnam();
            loadcbthang();
            loaddthumnay();
            loaddgthongke();
        }

        private void THONGKEUserControl1_Load(object sender, EventArgs e)
        {

        }
        private void loadcbnam()
        {
            DataTable dt = new DataTable();
            dt = data.execQuery("select YEAR(ngay) as nam from tbhoadon group by YEAR(ngay) ORDER BY YEAR(ngay) DESC;");
            cbnam.ValueMember = "nam";
            cbnam.DataSource = dt;
        }
        private void loadcbthang()
        {
            DateTime now = DateTime.Now;
            cbthang.StartIndex = now.Month - 1;
        }
        private void loaddthumnay()
        {
            DataTable dt = new DataTable();
            dt = data.execQuery("select sum (tong_tien) as ds from tbhoadon where day(ngay) = day(GETDATE()) and MONTH(ngay) = month(GETDATE()) and YEAR(ngay)=year(GETDATE())");
            tbdthn.DataBindings.Clear();
            tbdthn.DataBindings.Add("Text", dt, "ds", true);
        }
        private void loaddgthongke()
        {

            DataTable dt = new DataTable();
            StringBuilder query = new StringBuilder("select CONVERT(date, ngay) as [Ngày] ,sum (tong_tien) as [Tổng doanh số]");
            query.Append("from tbhoadon ");
            query.Append("where MONTH(ngay) ='"+cbthang.Text+"' and YEAR(ngay) ='"+cbnam.Text+"'");
            //query.Append("Nam(ngay) = '" + cbnam.Text +"'");
            query.Append("group by CONVERT(date, ngay)");
            dt = data.execQuery(query.ToString());
            dgthongke.DataSource = dt;
            dgthongke.Height = 20 + (dgthongke.Rows[0].Height) * (dgthongke.Rows.Count);
            siticonePanel1.Height = dgthongke.Height + 4;


            //DataGridView3.Columns[0].Width = 286;
            //DataGridView3.Columns[1].Width = 0;
            //DataGridView3.Columns[2].Width = 0;
            //btThem.BringToFront();
            // btSua.BringToFront();
            //btXoa.BringToFront();

        }

        private void cbthang_SelectedIndexChanged(object sender, EventArgs e)
        {
            loaddgthongke();
        }

        private void cbnam_SelectedIndexChanged(object sender, EventArgs e)
        {
            loaddgthongke();
        }
    }
}
