using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace IKCB_Law_Office
{
    public partial class frmAdminPanel : Form
    {
        public frmAdminPanel()
        {
            InitializeComponent();
        }
        DatabaseProcess dp = new DatabaseProcess();
        
        private void pcbAdminPanelExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pcbAdminPanelMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pcbAdminPanelMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void frmAdminPanel_Load(object sender, EventArgs e)
        {
            gbxPersonelEkle.Visible = true;
            gbxPersonelGuncelle.Visible = false;
            gbxPersonelSil.Visible = false;
        }

        private void pcbShutDown_Click(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            frm.Show();
            this.Hide();
        }

        private void btnKayitYap_Click(object sender, EventArgs e)
        {
            int avansMasrafDurum = 0;
            int maliRaporDurum = 0;
            try
            {
                string tcNo = txtTcNo.Text;
                string adSoyad = txtAdSoyad.Text;
                string sifre = txtSifre.Text;
                string eMailAdres = txtEmailAdres.Text;
                string telNo = txtTelNo.Text;
                DateTime dogumTarihi = Convert.ToDateTime(dtpDogumTarihi.Text);
                string adres = txtAdres.Text;
                string pozisyon = cbxPozisyon.Text;
                if (cbxAvansMasraf.Checked == true)
                    avansMasrafDurum = 1;
                if (cbxMaliRapor.Checked == true)
                    maliRaporDurum = 1;

                string imagePath = Application.StartupPath + "\\images\\" + "defaultImage.png";

                string sqlSentenceTcKontrol = "select perTc from tblPersonel";
                string sqlSentenceAdKontrol = "select perAdiSoyadi from tblPersonel";
                string sqlSentenceTelNoKontrolEt = "select perTelNo from tblPersonel";
                string sqlSentenceSifreKontrolEt = "select perSifre from tblPersonel";
                string sqlSentence = "insert into tblPersonel (perAdiSoyadi,perEmailAdres,perTelNo,perAdres,perSifre,perDogTar,perProfilFoto,perTc,perYetkiMaliRapor,perYetkiAvansMasraf,perPozisyon) values " +
                    "('" + adSoyad + "','" + eMailAdres + "','" + telNo + "','" + adres + "','" + sifre + "','" + dogumTarihi + "','" + imagePath + "','" + tcNo + "'," + maliRaporDurum + "," + avansMasrafDurum + ",'" + pozisyon + "')";
                if (dp.kontrolEt(sqlSentenceTcKontrol, txtTcNo) == false)
                {
                    string message = txtTcNo.Text + " T.C. numaralı kayıt daha önce oluşturuldu";
                    frmMessagebox.Message = message;
                    frmMessagebox frm = new frmMessagebox();
                    frm.Show();
                }
                else if(dp.kontrolEt(sqlSentenceAdKontrol,txtAdSoyad)==false)
                {
                    string message = txtAdSoyad.Text + " adlı kayıt daha önce oluşturuldu";
                    frmMessagebox.Message = message;
                    frmMessagebox frm = new frmMessagebox();
                    frm.Show();
                }
                else if (dp.kontrolEt(sqlSentenceTelNoKontrolEt,txtTelNo)==false)
                {
                    string message = txtTelNo.Text + " numaralı kayıt daha önce oluşturuldu";
                    frmMessagebox.Message = message;
                    frmMessagebox frm = new frmMessagebox();
                    frm.Show();
                }
                else if(dp.kontrolEt(sqlSentenceSifreKontrolEt,txtSifre)==false)
                {
                    string message = txtSifre.Text + " şifresi kayıt daha önce oluşturuldu";
                    frmMessagebox.Message = message;
                    frmMessagebox frm = new frmMessagebox();
                    frm.Show();
                }
                else if (dp.kontrolEt(sqlSentenceTcKontrol, txtTcNo) == true)
                {
                    dp.insert_update_delete(sqlSentence);
                    string message = "Kayıt başarı ile oluşturuldu";
                    frmMessagebox.Message = message;
                    frmMessagebox frm = new frmMessagebox();
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                frmMessagebox.Message = ex.Message;
                frmMessagebox frm = new frmMessagebox();
                frm.Show();
            }
        }

        private void btnAvukatEkle_Click(object sender, EventArgs e)
        {
            gbxPersonelGuncelle.Visible = false;
            gbxPersonelEkle.Visible = true;
            gbxPersonelSil.Visible = false;
        }

        private void btnAvukatBilgileriniGuncelle_Click(object sender, EventArgs e)
        {
            gbxPersonelEkle.Visible = false;
            gbxPersonelGuncelle.Visible = true;
            gbxPersonelSil.Visible = false;
        }

        private void pcbAvukatBilgileriniGetir_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlSentence = "select * from tblPersonel where perTc='" + txtGuncelleTcAra.Text + "'";
                txtGuncelleAdSoyad.Text = dp.get_Data(sqlSentence).Rows[0][1].ToString();
                txtGuncelleEposta.Text = dp.get_Data(sqlSentence).Rows[0][2].ToString();
                txtGuncelleTelefonNo.Text = dp.get_Data(sqlSentence).Rows[0][3].ToString();
                txtGuncelleAdres.Text = dp.get_Data(sqlSentence).Rows[0][4].ToString();
                txtGuncelleSifre.Text = dp.get_Data(sqlSentence).Rows[0][5].ToString();
                dtpGuncelleDogTar.Text = dp.get_Data(sqlSentence).Rows[0][6].ToString();
                string guncelleYetkiMaliRapor = dp.get_Data(sqlSentence).Rows[0][9].ToString();
                string guncelleYetkiAvansMasraf = dp.get_Data(sqlSentence).Rows[0][10].ToString();
                if (guncelleYetkiMaliRapor == "0")
                    cbxGuncelleMaliRapor.Checked = false;
                else if (guncelleYetkiMaliRapor == "1")
                    cbxGuncelleMaliRapor.Checked = true;
                if (guncelleYetkiAvansMasraf == "0")
                    cbxGuncelleAvansMasraf.Checked = false;
                else if (guncelleYetkiAvansMasraf == "1")
                    cbxGuncelleAvansMasraf.Checked = true;
                cbxGuncellePozisyon.Text = dp.get_Data(sqlSentence).Rows[0][11].ToString();
            }
            catch (Exception)
            {
                frmMessagebox.Message = "Böyle bir kayıt yok.";
                frmMessagebox frm = new frmMessagebox();
                frm.Show();
            }
        }

        private void btnKayitGuncelle_Click(object sender, EventArgs e)
        {
            if (txtGuncelleTcAra.Text == "")
            {
                frmMessagebox.Message = "T.C numarasını girmediniz";
                frmMessagebox frm = new frmMessagebox();
                frm.Show();
            }
            else
            {
                string adSoyad = txtGuncelleAdSoyad.Text;
                string emailAdres = txtGuncelleEposta.Text;
                string telNo = txtGuncelleTelefonNo.Text;
                string adres = txtGuncelleAdres.Text;
                string sifre = txtGuncelleSifre.Text;
                string dogTar = dtpGuncelleDogTar.Text;
                string pozisyon = cbxGuncellePozisyon.Text;
                int guncelleAvansMasrafDurum = 0;
                int guncelleMaliRaporDurum = 0;
                if (cbxGuncelleAvansMasraf.Checked == true)
                    guncelleAvansMasrafDurum = 1;
                else if (cbxGuncelleAvansMasraf.Checked == false)
                    guncelleAvansMasrafDurum = 0;
                if (cbxGuncelleMaliRapor.Checked == true)
                    guncelleMaliRaporDurum = 1;
                else if (cbxGuncelleMaliRapor.Checked == false)
                    guncelleMaliRaporDurum = 0;
                try
                {
                    string sqlSentence = "update tblPersonel set perAdiSoyadi='" + adSoyad + "',perEmailAdres='" + emailAdres + "',perTelNo='" + telNo + "',perAdres='" + adres + "',perSifre='" + sifre + "',perDogTar='" + dogTar + "',perYetkiMaliRapor=" + guncelleMaliRaporDurum + ",perYetkiAvansMasraf=" + guncelleAvansMasrafDurum + ",perPozisyon='" + pozisyon + "' where perTc='" + txtGuncelleTcAra.Text + "'";
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
        }
        private void btnAvukatSil_Click(object sender, EventArgs e)
        {
            gbxPersonelEkle.Visible = false;
            gbxPersonelGuncelle.Visible = false;
            gbxPersonelSil.Visible = true;
            txtSilAdSoyad.Enabled = false;
            txtSilAdres.Enabled = false;
            txtSilEposta.Enabled = false;
            txtSilSifre.Enabled = false;
            txtSilTelefonNo.Enabled = false;
            dtpSilDogTar.Enabled = false;
            cbxSilAvansMasraf.Enabled = false;
            cbxSilMarliRapor.Enabled = false;
            cbxSilPozisyon.Enabled = false;
        }

        private void pcbSilTcAra_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlSentence = "select * from tblPersonel where perTc='" + txtSilTcNo.Text + "'";
                txtSilAdSoyad.Text = dp.get_Data(sqlSentence).Rows[0][1].ToString();
                txtSilEposta.Text = dp.get_Data(sqlSentence).Rows[0][2].ToString();
                txtSilTelefonNo.Text = dp.get_Data(sqlSentence).Rows[0][3].ToString();
                txtSilAdres.Text = dp.get_Data(sqlSentence).Rows[0][4].ToString();
                txtSilSifre.Text = dp.get_Data(sqlSentence).Rows[0][5].ToString();
                dtpSilDogTar.Text = dp.get_Data(sqlSentence).Rows[0][6].ToString();
                string silYetkiMaliRapor = dp.get_Data(sqlSentence).Rows[0][9].ToString();
                string silYetkiAvansMasraf = dp.get_Data(sqlSentence).Rows[0][10].ToString();
                if (silYetkiMaliRapor == "0")
                    cbxSilMarliRapor.Checked = false;
                else if (silYetkiMaliRapor == "1")
                    cbxSilMarliRapor.Checked = true;
                if (silYetkiAvansMasraf == "0")
                    cbxSilAvansMasraf.Checked = false;
                else if (silYetkiAvansMasraf == "1")
                    cbxSilAvansMasraf.Checked = true;
                cbxSilPozisyon.Text = dp.get_Data(sqlSentence).Rows[0][11].ToString();
            }
            catch (Exception)
            {
                frmMessagebox.Message = "Böyle bir kayıt yok";
                frmMessagebox frm = new frmMessagebox();
                frm.Show();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if(txtSilTcNo.Text=="")
            {
                frmMessagebox.Message = "T.C numarasını girmediniz";
                frmMessagebox frm = new frmMessagebox();
                frm.Show();
            }
            else
            {
                try
                {
                    string sqlAdresGetir = "select perProfilFoto from tblPersonel where  perTc='" + txtSilTcNo.Text + "'";
                    string resimAdres = dp.get_Data(sqlAdresGetir).Rows[0][0].ToString();
                    string sqlSentence = "delete from tblPersonel where perTc='" + txtSilTcNo.Text + "'";
                    string sqlDosyaSil = "delete from tblDosyalar where avukatTc='" + txtSilTcNo.Text + "'";
                    dp.insert_update_delete(sqlSentence);
                    dp.insert_update_delete(sqlDosyaSil);

                    File.Delete(resimAdres);
                    frmMessagebox.Message = "Kayıt başarılı bir şekilde silindi";
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
        }

        private void btnPerIstatistikleriniGoster_Click(object sender, EventArgs e)
        {
            frmPersonelistatistikleri frm = new frmPersonelistatistikleri();
            frm.Show();
        }
    }
}
