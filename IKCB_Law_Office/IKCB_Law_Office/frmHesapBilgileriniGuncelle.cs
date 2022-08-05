using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IKCB_Law_Office
{
    public partial class frmHesapBilgileriniGuncelle : Form
    {
        public frmHesapBilgileriniGuncelle()
        {
            InitializeComponent();
        }
        public static string perId, perAdiSoyadi, perEmailAdres, perTelNo, perAdres, perSifre, perDogTar, perTc, perPozisyon;
        DatabaseProcess dp = new DatabaseProcess();
        private void pcbProfileClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pcbProfileMinimize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pcbProfileMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void btnBilgilerimiGuncelle_Click(object sender, EventArgs e)
        {
            string adSoyad = txtAdSoyad.Text;
            string emailAdres = txtEmailAdres.Text;
            string telNo = txttelNo.Text;
            string adres = txtAdres.Text;
            string sifre = txtSifre.Text;
            string dogTar = dtpDogumTarihi.Text;
            string pozisyon = lblPozizyon.Text;
            
            try
            {
                string sqlSentence = "update tblPersonel set perAdiSoyadi='" + adSoyad + "',perEmailAdres='" + emailAdres + "',perTelNo='" + telNo + "',perAdres='" + adres + "',perSifre='" + sifre + "',perDogTar='" + dogTar + "',perPozisyon='" + pozisyon + "' where perId=" + perId;
                dp.insert_update_delete(sqlSentence);
                frmMessagebox.Message = "Bilgilerinizi başarılı bir şekilde güncellendi.";
                frmMessagebox frm = new frmMessagebox();
                frm.Show();
            }
            catch (Exception ex)
            {
                frmMessagebox.Message = ex.Message;
                frmMessagebox frm = new frmMessagebox();
                frm.Show();
            }
            
        }

       

       

        private void txtAdSoyad_Click(object sender, EventArgs e)
        {
            txtAdSoyad.Text = "";
        }

        private void txtSifre_Click(object sender, EventArgs e)
        {
            txtSifre.Text = "";
        }

        private void txtEmailAdres_Click(object sender, EventArgs e)
        {
            txtEmailAdres.Text = "";
        }

        private void txtTelNo_TextChanged(object sender, EventArgs e)
        {
            txttelNo.Text = "";
        }

        private void txtAdres_Click(object sender, EventArgs e)
        {
            txtAdres.Text = "";
        }

        private void frmHesapBilgileriniGuncelle_Load(object sender, EventArgs e)
        {
            txtAdres.Text = perAdres;
            txtAdSoyad.Text = perAdiSoyadi;
            txtEmailAdres.Text = perEmailAdres;
            txtSifre.Text = perSifre;
            lblTcNo.Text = perTc;
            txttelNo.Text = perTelNo;
            dtpDogumTarihi.Text = perDogTar;
            lblPozizyon.Text = perPozisyon;
        }
    }
}
