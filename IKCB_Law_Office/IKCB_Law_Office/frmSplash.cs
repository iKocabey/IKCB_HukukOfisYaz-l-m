using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IKCB_Law_Office
{
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
        }
        int cx = 390, cy = 140, rx = 250, ry = 250 ,startPoint=0;
        float angle;
        public static int durum;
       /* private void frmSplash_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.RotateTransform(angle, System.Drawing.Drawing2D.MatrixOrder.Append);
            g.TranslateTransform(cx, cy, System.Drawing.Drawing2D.MatrixOrder.Append);
            g.DrawImage(image, -rx/2, -ry/2, rx, ry);
        }*/

        private void timer1_Tick(object sender, EventArgs e)
        {
            angle += 4;
            startPoint += 1;
            progressBar.Value = startPoint;
            Invalidate();
            if (progressBar.Value == 100)
            {
                progressBar.Value = 0;
                timer1.Stop();
                if (durum == 0)
                {
                    frmAdminPanel frm = new frmAdminPanel();
                    frm.Show();
                    this.Hide();
                }
                else if (durum == 1)//Durum  1 olduğunda admin panele yönlendiriyor,0 olduğunda mainpage'e.
                {
                    frmMainPage frm = new frmMainPage();
                    this.Hide();
                    frm.Show();
                }
            }
        }
       
        Bitmap image;
        //C:\Users\ismailKocabey\source\repos\IKCB_Law_Office\IKCB_Law_Office\images
        private void frmSplash_Load(object sender, EventArgs e)
        {
            image = (Bitmap)Bitmap.FromFile(@"C:\Users\ismailKocabey\source\repos\IKCB_Law_Office\IKCB_Law_Office\images\hukukfoto3.jpg");
            timer1.Start();
        }
    }
}
