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
    public partial class hd : UserControl
    {
        private data data = new data();
        private int thang;
        private int nam;
        private int mahd;
        public hd()
        {
            InitializeComponent();
            lodacbngay();
            loadcbnam();
            loadcbthang();
            loadcbngay();
        }

        private void siticoneLabel3_Click(object sender, EventArgs e)
        {

        }
        private void loaddgKho()
        {

            DataTable dt = new DataTable();
            StringBuilder query = new StringBuilder("select ma_hoadon as [Mã hóa đơn], CONVERT(time, ngay)as [Thời gian],tong_tien as [Tổng tiền] from tbhoadon");
            query.Append(" where DAY(ngay) = '"+cbngay.Text+"' and month(ngay) = '"+cbthang.Text+"'  and year (ngay) ='"+cbnam.Text+ "' and trang_thai = 1 ORDER BY [Mã hóa đơn] DESC");
            dt = data.execQuery(query.ToString());
            dghd.DataSource = dt;
        }
        private void loaddgct()
        {

            DataTable dt = new DataTable();
            StringBuilder query = new StringBuilder("select tbsach.ten_sach as [Tên sách] , tbchitiethd.so_luong as [Số lượng] from tbsach ,tbchitiethd ");
            query.Append(" where tbsach.ma_sach = tbchitiethd.ma_sach and  tbchitiethd.ma_hoadon = " +mahd + "");
            dt = data.execQuery(query.ToString());
            dgct.DataSource = dt;
            dgct.Columns[0].Width = 180;
            dgct.Columns[1].Width = 79;
        }
        private void lodacbngay()
        {
            for (int i = 0; i <= 30; i++)
            {
                cbngay.Items.Add(i);
            }
        }
        private void hd_Load(object sender, EventArgs e)
        {

        }
        private void loadcbnam()
        {
            DataTable dt = new DataTable();
            dt = data.execQuery("select YEAR(ngay) as nam from tbhoadon group by YEAR(ngay) ORDER BY YEAR(ngay) DESC;");
            cbnam.ValueMember = "nam";
            //cbnam.DisplayMember = "nam";
            cbnam.DataSource = dt;
            loaddgKho();
        }
        private void loadcbthang()
        {
            DateTime now = DateTime.Now;
            cbthang.StartIndex = now.Month - 1;
        }
        private void loadcbngay()
        {
            DateTime now = DateTime.Now;
            cbngay.StartIndex = now.Day-1;
        }


        private void cbthang_SelectedIndexChanged(object sender, EventArgs e)
        {
            //();

            cbngay.Items.Clear();
            int thang = cbthang.SelectedIndex;
            if (thang == 0 | thang == 2 | thang == 4 | thang == 6 | thang == 7 | thang == 9 | thang == 11)
            {
                for (int i = 1; i <= 31; i++)
                {
                    
                    cbngay.Items.Add(i);
                    
                }
            }
            if (thang == 3 | thang == 5 | thang == 8 | thang == 10)
            {
                for (int i = 1; i <= 30; i++)
                {
                   
                    cbngay.Items.Add(i);
                    
                }
            }
            if (thang == 1)
            {
                if ((nam % 4 == 0 & nam % 100 != 0) | nam % 400 == 0)
                {
                    for (int i = 1; i <= 29; i++)
                    {

                        cbngay.Items.Add(i);

                    }
                }
                else
                {
                    for (int i = 1; i <= 28; i++)
                    {

                        cbngay.Items.Add(i);

                    }
                }
            }
            
           // loaddgKho();
        }
      
        private void cbnam_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            nam = int.Parse(comboBox.Text);
           // loaddgKho();
        }

        private void cbnam_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void cbngay_SelectedIndexChanged(object sender, EventArgs e)
        {
            loaddgKho(); 
        }

        private void dghd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dghd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowid = e.RowIndex;
                if (rowid < 0) rowid = 0;
                if (rowid == dghd.RowCount - 1) rowid = rowid - 1;
                DataGridViewRow row = dghd.Rows[rowid];
                mahd = (int)row.Cells[0].Value;
                //tac_gia,The_loai,nha_xb,so_luong,gia_ban,hinh,ma_sach
                DataTable dt = new DataTable();
                StringBuilder query = new StringBuilder("select tbhoadon.ten_kh as kh , tbnv.ten_nv as nv from tbhoadon ,tbnv");
                query.Append(" where tbhoadon.ma_nv = tbnv.tk and  tbhoadon.ma_hoadon = " + mahd + "");
                dt = data.execQuery(query.ToString());
                tbkh.DataBindings.Clear();
                tbkh.DataBindings.Add("Text", dt, "kh", true);
                tbnv.DataBindings.Clear();
                tbnv.DataBindings.Add("Text", dt, "nv", true);
                loaddgct();
                btcthd.Text = "Chi tiết hóa đơn "+ mahd.ToString();


            }
            catch (Exception)
            {

            }
        }

        private void siticoneGradientButton2_Click(object sender, EventArgs e)
        {

        }
    }
}
