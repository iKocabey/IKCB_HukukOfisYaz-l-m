using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IKCB_Law_Office
{
    public partial class frmIcraDosyasi : Form
    {
        public static string avukatAdiSoyadi, avukatTc;
        public frmIcraDosyasi()
        {
            InitializeComponent();
        }
        void eskiKonum()
        {
            panel2.Location = new Point(0, 222);
            panel3.Location = new Point(0, 265);
            panel7.Location = new Point(0, 309);
            btnDosyalarim.Location = new Point(5, 222);
            btnVekaletler.Location = new Point(5, 265);
            btnIcraDosyasiIctihatlar.Location = new Point(5, 309);
        }
        void yenikonum()
        {
            panel2.Location = new Point(3, 348);
            panel3.Location = new Point(3, 390);
            panel7.Location = new Point(3, 434);
            btnDosyalarim.Location = new Point(8, 348);
            btnVekaletler.Location = new Point(8, 390);
            btnIcraDosyasiIctihatlar.Location = new Point(8, 434);
        }
        DatabaseProcess dp = new DatabaseProcess();
        private void pnlTop_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void pcbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pcbMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pcbMax_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }
        private void pcbReturn_Click(object sender, EventArgs e)
        {
            frmMainPage frm = new frmMainPage();
            this.Hide();
            frm.Show();
        }

        private void frmIcraDosyasi_Load(object sender, EventArgs e)
        {
            pnlYeniDosya.Visible = false;
            string sqlSentece = "select muvekkilAdSoyad from tblMuvekkiller";
            dp.fillCombo(cbxMuvekkil, sqlSentece, 0);

            string sqlSentence2 = "select karsiTarafAdSoyad from tblKarsiTaraf";
            dp.fillCombo(cbxKarsiTaraf, sqlSentence2, 0);

            string sqlSentence3 = "select * from tblTakipTuru";
            dp.fillCombo(cbxTakipTuru, sqlSentence3, 1);
        }

        private void btnYeniDosya_Click(object sender, EventArgs e)
        {
            if (pnlYeniDosya.Visible == false)
            {
                pnlYeniDosya.Visible = true;
                yenikonum();
            }
            else
            {
                pnlYeniDosya.Visible = false;
                eskiKonum();
            }
        }
        private void btnDavaDosyasi_Click(object sender, EventArgs e)
        {
            frmDavaDosyasi frm = new frmDavaDosyasi();
            this.Hide();
            frm.Show();
        }

        private void cbxTakipTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sqlSentence = "select takipYoluAdi from tblTakipYolu where takipTuruAdi='" + cbxTakipTuru.SelectedItem + "'";
            dp.fillCombo(cbxTakipYolu, sqlSentence, 0);
        }

        private void btnYeniDosyaEkle_Click(object sender, EventArgs e)
        {
            string dosyaTuru = "İcra Dosyası";
            string muvekkilAdi = cbxMuvekkil.Text;
            string karsiTarafAdi = cbxKarsiTaraf.Text;
            string takipTuru = cbxTakipTuru.Text;
            string takipYolu = cbxTakipYolu.Text;
            string mahkemeTuruAltKirilim = "";
            string lehAleyh = cbxLehAleyh.Text;
            string tarafimiz = cbxTarafimiz.Text;
            string klasorNo = txtKlasorNo.Text;
            string dosyaNo = txtDosyaNo.Text;
            string dairesi = txtDairesi.Text;
            string davaKonusu = txtIcraKonusu.Text;
            string davaAcmaTarihi = dtpDavaAcmaTaihi.Text;
            string isKabulTarihi = dtpIsKabulTeblig.Text;
            string avukatAdi = avukatAdiSoyadi;
            string avukatTcNo = avukatTc;
            string esas = txtEsas.Text;
            string dosyaDurum = "Açık";
            string davaDurum = "Bilinmiyor";

            try
            {
                if (cbxMuvekkil.Text == "" || cbxKarsiTaraf.Text == "" || cbxTakipYolu.Text == "" || cbxTakipTuru.Text == "" ||
                    cbxLehAleyh.Text == "" || cbxTarafimiz.Text == "" || txtKlasorNo.Text == "" || txtDosyaNo.Text == "" ||
                    txtDairesi.Text == "" || txtIcraKonusu.Text == ""||txtEsas.Text=="")
                {
                    string message2 = "Lütfen Formda Boş Alan Bırakmayınız.";
                    frmMessagebox frm2 = new frmMessagebox();
                    frmMessagebox.Message = message2;
                    frm2.Show();
                }
                else
                {
                    //Bu sorugular veri daha önce eklenmişmi kontrol için.
                    string sqlSentence2 = "select klasorNo from tblDosyalar";
                    string sqlSentence3 = "select dosyaNo from tblDosyalar";
                    if (dp.kontrolEt(sqlSentence2, txtKlasorNo) == false && dp.kontrolEt(sqlSentence3, txtDosyaNo) == false)
                    {
                        string message2 = txtKlasorNo.Text + " numaralı klasor ve " + txtDosyaNo.Text + " numaralı dosya" + Environment.NewLine + " daha önce oluşturuldu.";
                        frmMessagebox.Message = message2;
                        frmMessagebox frm2 = new frmMessagebox();
                        frm2.Show();

                    }
                    else if (dp.kontrolEt(sqlSentence2, txtKlasorNo) == false && dp.kontrolEt(sqlSentence3, txtDosyaNo) == true)
                    {
                        string message2 = txtKlasorNo.Text + " numaralı klasor daha önce oluşturuldu";
                        frmMessagebox.Message = message2;
                        frmMessagebox frm2 = new frmMessagebox();
                        frm2.Show();
                    }
                    else if (dp.kontrolEt(sqlSentence2, txtKlasorNo) == true && dp.kontrolEt(sqlSentence3, txtDosyaNo) == false)
                    {
                        string message2 = txtDosyaNo.Text + " numaralı dosya daha önce oluşturuldu";
                        frmMessagebox.Message = message2;
                        frmMessagebox frm2 = new frmMessagebox();
                        frm2.Show();
                    }
                    else if (dp.kontrolEt(sqlSentence2, txtKlasorNo) == true && dp.kontrolEt(sqlSentence3, txtDosyaNo) == true)
                    {
                        string sqlSentence = "insert into tblDosyalar (dosyaTuru,muvekkilAdi,karsiTarafAdi,davaVeyaTakipTuru,mahkemeTuruVeyatakipYolu,mahkemeTuruAltKirilim,leyhdeAleyhde,tarafimiz,klasorNo,dosyaNo,mahkemesiVeyaDairesi,davaVeyaIcraKonusu,davaAcmaTarihi,isKabulTarihi,avukatAdi,esas,avukatTc,dosyaDurum,davaDurum) values " +
                            "('" + dosyaTuru + "','" + muvekkilAdi + "','" + karsiTarafAdi + "','" + takipYolu + "','" + takipTuru + "','" + mahkemeTuruAltKirilim + "','" + lehAleyh + "','" + tarafimiz + "','" + klasorNo + "','" + dosyaNo + "','" + dairesi + "','" + davaKonusu + "','" + davaAcmaTarihi + "','" + isKabulTarihi + "','" + avukatAdi + "','" + esas + "','" + avukatTcNo + "','" + dosyaDurum + "','" + davaDurum + "')";
                        dp.insert_update_delete(sqlSentence);
                        string message = "Dosya Başarılı Bir Şekilde Oluşturuldu.";
                        txtDairesi.Text = ""; txtDosyaNo.Text = ""; txtEsas.Text = "";
                        txtIcraKonusu.Text = ""; txtKlasorNo.Text = "";
                        cbxKarsiTaraf.Text = ""; cbxLehAleyh.Text = ""; cbxMuvekkil.Text = "";
                        cbxTakipTuru.Text = ""; cbxTakipYolu.Text = ""; cbxTarafimiz.Text = "";
                        frmMessagebox frm = new frmMessagebox();
                        frmMessagebox.Message = message;
                        frm.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                frmMessagebox frm = new frmMessagebox();
                frmMessagebox.Message = ex.Message;
                frm.Show();
            }
        }

        private void btnNewFile_Click(object sender, EventArgs e)
        {
            frmYeniMuvekkilEkle frm = new frmYeniMuvekkilEkle();
            frm.Show();
        }

        private void btnKarsiTarafEkle_Click(object sender, EventArgs e)
        {
            frmKarsiTarafEkle frm = new frmKarsiTarafEkle();
            frm.Show();
        }

        private void btnDosyalarim_Click(object sender, EventArgs e)
        {
            if (pnlYeniDosya.Visible == true)
                pnlYeniDosya.Visible = false;
            frmDosyalar frm = new frmDosyalar();
            this.Hide();
            frm.Show();
        }
    }
}
