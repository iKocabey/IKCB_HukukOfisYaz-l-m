using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IKCB_Law_Office
{
    public partial class frmMessagebox : Form
    {
        public static string Message;
        public static DialogResult cevap;
        public static int deger = 0;
        public frmMessagebox()
        {
            InitializeComponent();
        }

        private void pcbMessageClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMessagebox_Load(object sender, EventArgs e)
        {
            lblMessage.Text = Message;
        }
        
        private void btnTamam_Click(object sender, EventArgs e)
        {
            this.Close();
                
            //frmMainPage.cevap = DialogResult.OK;
            //dialog result u araştır
            /*if (deger == 0)
                this.Close();
            else
            {
                frmMainPage.geriDeger = 1;
                this.Close();
            }*/
        }
    }
}
