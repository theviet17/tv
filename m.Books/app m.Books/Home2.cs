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
    public partial class Home2 : UserControl
    {
        public Home2()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        int i;
        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rd = new Random();
            i = rd.Next(1, 5);
            if ( i == 1)
            {
                pictureBox1.ImageLocation = @"C:\Users\Viet\Downloads\m.Books\image\363107_05.jpg";
            }
            if (i == 2)
            {
                pictureBox1.ImageLocation = @"C:\Users\Viet\Downloads\m.Books\image\363109_04.jpg";
            }
            if (i == 3)
            {
                pictureBox1.ImageLocation = @"C:\Users\Viet\Downloads\m.Books\image\363192_nextflix.jpg";
            }
            if (i == 4)
            {
                pictureBox1.ImageLocation = @"C:\Users\Viet\Downloads\m.Books\image\363488_final1511.jpg";
            }
            if (i == 5)
            {
                pictureBox1.ImageLocation = @"C:\Users\Viet\Downloads\m.Books\image\363501_15.jpg";
            }
        }
    }
}
