using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IKCB_Law_Office
{
    public partial class frmDavaDosyasi : Form
    {
        public frmDavaDosyasi()
        {
            InitializeComponent();
        }
        public static string avukatAdiSoyadi, avukatTc;
        void eskiKonum()
        {
            panel2.Location = new Point(3, 195);
            panel3.Location = new Point(3, 238);
            panel7.Location = new Point(3, 282);
            btnDosyalarim.Location = new Point(8, 195);
            btnVekaletler.Location = new Point(8, 238);
            btnDavaDosyasiIctihatlar.Location = new Point(8, 282);
        }
        void yenikonum()
        {
            panel2.Location = new Point(3, 322);
            panel3.Location = new Point(3, 364);
            panel7.Location = new Point(3, 408);
            btnDosyalarim.Location = new Point(8, 322);
            btnVekaletler.Location = new Point(8, 364);
            btnDavaDosyasiIctihatlar.Location = new Point(8, 408);
        }
        DatabaseProcess dp = new DatabaseProcess();
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void pictureBox8min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox10exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmMainPage frm = new frmMainPage();
            this.Hide();
            frm.Show();
        }

        private void btnMuvekkil_Click(object sender, EventArgs e)
        {
            frmYeniMuvekkilEkle frm = new frmYeniMuvekkilEkle();
            frm.Show();
        }

        private void frmDavaDosyasi_Load(object sender, EventArgs e)
        {
            pnlYeniDosya.Visible = false;
            comboBox1.Enabled = false;
            string sqlSentece = "select muvekkilAdSoyad from tblMuvekkiller";
            dp.fillCombo(cbxMuvekkil, sqlSentece, 0);

            string sqlSentence2 = "select karsiTarafAdSoyad from tblKarsiTaraf";
            dp.fillCombo(cbxKarsiTaraf, sqlSentence2, 0);

            string sqlSentence3 = "select * from tblDavaDosyalari";
            dp.fillCombo(cbxDavaTuru, sqlSentence3, 1);
            
        }

        private void btnKarsiTaraf_Click(object sender, EventArgs e)
        {
            frmKarsiTarafEkle frm = new frmKarsiTarafEkle();
            frm.Show();
        }

        private void cbxDavaTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sqlSentence = "select davaDosyasiAltDal from tblDavaDosyasiAltDal where davaDosyasiAdi='" + cbxDavaTuru.SelectedItem + "'";
            dp.fillCombo(cbxMahkemeTuru, sqlSentence, 0);
            cbxMahkemeTuru.Text = "";
        }

        private void cbxAltkirilim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxMahkemeTuru.Text != "Bölge İdare Mahkemesi")
                comboBox1.Enabled = false;
            else 
            {
                comboBox1.Enabled = true;
                comboBox1.Text = "";
                string sqlSentence = "select idariYargiMahkemesiAltDal from tblidariYargiMahkemesi where idariYargiMahkemesiAdi='" + cbxMahkemeTuru.SelectedItem + "'";
                dp.fillCombo(comboBox1, sqlSentence, 0);
            }
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
        private void btnIcraDosyasi_Click(object sender, EventArgs e)
        {
            frmIcraDosyasi frm = new frmIcraDosyasi();
            this.Hide();
            frm.Show();
        }

        private void btnYeniDosyaEkle_Click(object sender, EventArgs e)
        {
            
            string dosyaTuru = "Dava Dosyası";
            string muvekkilAdi = cbxMuvekkil.Text;
            string karsiTarafAdi = cbxKarsiTaraf.Text;
            string davaTuru = cbxDavaTuru.Text;
            string mahkemeTuru = cbxMahkemeTuru.Text;
            string mahkemeTuruAltKirilim = comboBox1.Text;
            string lehAleyh = cbxLehAleyh.Text;
            string tarafimiz = cbxTarafimiz.Text;
            string klasorNo = txtKlasorNo.Text;
            string dosyaNo = txtDosyaNo.Text;
            string mahkemesi = txtMahkemesi.Text;
            string davaKonusu = txtDavaKonusu.Text;
            string davaAcmaTarihi = dtpDavaAcmaTaihi.Text;
            string isKabulTarihi = dtpIsKabulTeblig.Text;
            string avukatAdi = avukatAdiSoyadi;
            string avukatTcNo = avukatTc;
            string esas = textBox3.Text;
            string dosyaDurum = "Açık";
            string davaDurum = "Bilinmiyor";

            try
            {
                if (cbxMuvekkil.Text == "" || cbxKarsiTaraf.Text == "" || cbxDavaTuru.Text == "" || cbxMahkemeTuru.Text == "" ||
                    cbxLehAleyh.Text == "" || cbxTarafimiz.Text == "" || txtKlasorNo.Text == "" || txtDosyaNo.Text == "" ||
                    txtMahkemesi.Text == "" || txtDavaKonusu.Text == "" ||textBox3.Text==""|| cbxLehAleyh.Text==""||textBox3.Text=="")
                {
                    string message2 = "Lütfen Formda Boş Alan Bırakmayınız.";
                    frmMessagebox frm2 = new frmMessagebox();
                    frmMessagebox.Message = message2;
                    frm2.Show();
                }
                else
                {
                   //bu sorgular veri daha önce girilmişmi kontrol etmek için. 
                    string sqlSentence2 = "select klasorNo from tblDosyalar";
                    string sqlSentence3 = "select dosyaNo from tblDosyalar";
                    if(dp.kontrolEt(sqlSentence2,txtKlasorNo)==false && dp.kontrolEt(sqlSentence3, txtDosyaNo) == false)
                    {
                        string message2 = txtKlasorNo.Text + " numaralı klasor ve "+txtDosyaNo.Text+" numaralı dosya"+Environment.NewLine+" daha önce oluşturuldu.";
                        frmMessagebox.Message = message2;
                        frmMessagebox frm2 = new frmMessagebox();
                        frm2.Show();
                        
                    }
                    else if(dp.kontrolEt(sqlSentence2,txtKlasorNo)==false && dp.kontrolEt(sqlSentence3,txtDosyaNo)==true)
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
                    else if(dp.kontrolEt(sqlSentence2,txtKlasorNo)==true && dp.kontrolEt(sqlSentence3,txtDosyaNo)==true)
                    {
                        string sqlSentence = "insert into tblDosyalar (dosyaTuru,muvekkilAdi,karsiTarafAdi,davaVeyaTakipTuru,mahkemeTuruVeyatakipYolu,mahkemeTuruAltKirilim,leyhdeAleyhde,tarafimiz,klasorNo,dosyaNo,mahkemesiVeyaDairesi,davaVeyaIcraKonusu,davaAcmaTarihi,isKabulTarihi,avukatAdi,esas,avukatTc,dosyaDurum,davaDurum) values " +
                            "('" + dosyaTuru + "','" + muvekkilAdi + "','" + karsiTarafAdi + "','" + davaTuru + "','" + mahkemesi + "','" + mahkemeTuruAltKirilim + "','" + lehAleyh + "','" + tarafimiz + "','" + klasorNo + "','" + dosyaNo + "','" + mahkemesi + "','" + davaKonusu + "','" + davaAcmaTarihi + "','" + isKabulTarihi + "','" + avukatAdi + "','" + esas + "','" + avukatTcNo + "','" + dosyaDurum + "','" + davaDurum + "')";
                        dp.insert_update_delete(sqlSentence);
                        string message = "Dosya Başarılı Bir Şekilde Oluşturuldu.";
                        txtDavaKonusu.Text = ""; txtDosyaNo.Text = "";
                        txtKlasorNo.Text = ""; txtMahkemesi.Text = "";
                        cbxDavaTuru.Text = ""; cbxKarsiTaraf.Text = "";
                        cbxMahkemeTuru.Text = ""; cbxTarafimiz.Text = "";
                        cbxMuvekkil.Text = ""; textBox3.Text = ""; cbxLehAleyh.Text = "";
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

        private void btnDosyalarim_Click(object sender, EventArgs e)
        {
            if (pnlYeniDosya.Visible == true)
                pnlYeniDosya.Visible = false;
            eskiKonum();
            frmDosyalar frm = new frmDosyalar();
            this.Hide();
            frm.Show();
        }

        private void btnDavaDosyasi_Click(object sender, EventArgs e)
        {

        }

        private void pnMenuVertical_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnVekaletler_Click(object sender, EventArgs e)
        {
            if (pnlYeniDosya.Visible == true)
                pnlYeniDosya.Visible = false;
            eskiKonum();
        }

        private void btnDavaDosyasiIctihatlar_Click(object sender, EventArgs e)
        {
            if (pnlYeniDosya.Visible == true)
                pnlYeniDosya.Visible = false;
            eskiKonum();
        }
    }
}
