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
    public partial class frmDosyaIcerikleri : Form
    {
        public frmDosyaIcerikleri()
        {
            InitializeComponent();
        }
        DatabaseProcess dp = new DatabaseProcess();
        void eskiKonum()
        {
            panel2.Location = new Point(3, 195);
            panel3.Location = new Point(3, 238);
            panel7.Location = new Point(3, 282);
            btnDosyalarim.Location = new Point(8, 195);
            btnVekaletler.Location = new Point(8, 238);
            btnIctihatlar.Location = new Point(8, 282);
        }
        void yenikonum()
        {
            panel2.Location = new Point(3, 322);
            panel3.Location = new Point(3, 364);
            panel7.Location = new Point(3, 408);
            btnDosyalarim.Location = new Point(8, 322);
            btnVekaletler.Location = new Point(8, 364);
            btnIctihatlar.Location = new Point(8, 408);
        }
        public static string dosyaId, esas, dosyaTuru, muvekkilAdi,
            KarsiTarafAdi, davaVeyaTakipTuru, mahkemeTuru, dosyaDurum,
            mahkemeTurAltKirilim, lehdeAleyhde, tarafimiz, klasorNo,
            dosyaNo, mahkemeVeyaDaire, davaVeyaIcraKonusu, davaAcmaTarihi,
            isKabulTarihi, avukatAdi, girisYapanAvukatAdi, girisYapanAvukatTc;
        private void btnOfisIciNot_Click(object sender, EventArgs e)
        {
            gbxAraKarar.Visible = false;
            gbxAvansMasraf.Visible = false;
            gbxDosyBilgileri.Visible = false;
            gbxIsplani.Visible = false;
            gbxDurusmaPlani.Visible = false;
            gbxOfisIciNot.Visible = true;

            lblPlanYapilan.Text = muvekkilAdi;
            string sqlSentece = "select perAdiSoyadi from tblPersonel";
            dp.fillCombo(cbxNotAvukatAdi, sqlSentece, 0);
        }
        public static int yetkiMaliRapor, yetkiAvansMasraf;
        private void btnOfisIciNotEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNotBaslik.Text=="" || txtOfisIciNot.Text==""
                    ||cbxNotAvukatAdi.Text==""||dtpNotTarihi.Text=="")
                {
                    string mesaj = "Lütfen Formda Boş Alan Bırakmayın";
                    frmMessagebox.Message = mesaj;
                    frmMessagebox frm = new frmMessagebox();
                    frm.Show();
                }
                else
                {
                    string notBaslik = txtNotBaslik.Text;
                    DateTime notTarih = Convert.ToDateTime(dtpNotTarihi.Text);
                    string notAvukatAdi = cbxNotAvukatAdi.Text;
                    string notIcerik = txtOfisIciNot.Text;
                    string notDurum = "Yapılmadı";
                    string sqlSentence = "insert into tblOfisIciNotlar (dosyaId,notBaslik,notuAlan,notTarih,notIcerik,notDurum) values " +
                        "('" + dosyaId + "','" + notBaslik + "','" + notAvukatAdi + "','" + notTarih + "','" + notIcerik + "','" + notDurum + "')";
                    dp.insert_update_delete(sqlSentence);
                    string mesaj = "Not Başarılı Bir Şekilde Oluşturuldu.";
                    txtNotBaslik.Text = "";txtOfisIciNot.Text = "";cbxNotAvukatAdi.Text = "";
                    frmMessagebox.Message = mesaj;
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

        private void btnDurusmaPlani_Click(object sender, EventArgs e)
        {
            gbxAraKarar.Visible = false;
            gbxAvansMasraf.Visible = false;
            gbxDosyBilgileri.Visible = false;
            gbxIsplani.Visible = false;
            gbxOfisIciNot.Visible = false;
            gbxDurusmaPlani.Visible = true;
            rbtnSehirIci.Checked = true;

            lblDurusmaDosyaNo.Text = dosyaNo;
            lblDurusmaMuvekkil.Text = muvekkilAdi;
            lblDurusmaMahkemeAdi.Text = mahkemeVeyaDaire;

            string sqlSentence = "select * from tblPersonel";
            dp.fillCombo(cbxDurusmaPlaniAvukatAdi, sqlSentence, 1);
            dp.fillListBox(lbxDurusmaPlaniAvukatlar, sqlSentence, 1);
        }

        private void btnVekaletler_Click(object sender, EventArgs e)
        {
            if (pnlYeniDosya.Visible == true)
                pnlYeniDosya.Visible = false;
            eskiKonum();
        }

        private void btnIctihatlar_Click(object sender, EventArgs e)
        {
            if (pnlYeniDosya.Visible == true)
                pnlYeniDosya.Visible = false;
            eskiKonum();
        }

        private void lbxDurusmaPlaniAvukatlar_Click(object sender, EventArgs e)
        {
            if (lbxDurusmaPlaniAvukatlar.SelectedIndex != -1)
            {
                lbxDurusmaPlaniSecilenAvukatlar.Items.Add(lbxDurusmaPlaniAvukatlar.SelectedItem);
                lbxDurusmaPlaniAvukatlar.Items.Remove(lbxDurusmaPlaniAvukatlar.SelectedItem);
                
            }
            else
            {
                if (lbxDurusmaPlaniAvukatlar.Items.Count==0)
                {
                    string message = "Tüm Avukatları Seçtiniz. Başka seçim Yapamazsınız.";
                    frmMessagebox.Message = message;
                    frmMessagebox frm = new frmMessagebox();
                    frm.Show();
                }
                else
                {
                    string message = "Lütfen Seçmek İstediğiniz Avukatın Üstüne Tıklayın.";
                    frmMessagebox.Message = message;
                    frmMessagebox frm = new frmMessagebox();
                    frm.Show();
                }
            }
        }

        private void lbxDurusmaPlaniSecilenAvukatlar_Click(object sender, EventArgs e)
        {
            if (lbxDurusmaPlaniSecilenAvukatlar.SelectedIndex != -1)
            {
                lbxDurusmaPlaniAvukatlar.Items.Add(lbxDurusmaPlaniSecilenAvukatlar.SelectedItem);
                lbxDurusmaPlaniSecilenAvukatlar.Items.Remove(lbxDurusmaPlaniSecilenAvukatlar.SelectedItem);
            }
            else
            {
                if (lbxDurusmaPlaniSecilenAvukatlar.Items.Count == 0)
                {
                    string message = "Tüm Avukatları Geri Aldınız. Başka Geri Alım Yapamazsınız.";
                    frmMessagebox.Message = message;
                    frmMessagebox frm = new frmMessagebox();
                    frm.Show();
                }
                else
                {
                    string message = "Lütfen Geri Almak İstediğiniz Avukatın Üstüne Tıklayın.";
                    frmMessagebox.Message = message;
                    frmMessagebox frm = new frmMessagebox();
                    frm.Show();
                }
            }
        }

        private void btnMaliRapor_Click(object sender, EventArgs e)
        {
            string message = "";
            if (yetkiMaliRapor == 1)
                message = "Okey";
            else if (yetkiMaliRapor == 0)
                message = "Bu işlemi gerçekleştirmeye yetkiniz yok";
            frmMessagebox.Message = message;
            frmMessagebox frm = new frmMessagebox();
            frm.Show();
        }

        private void btnTahsilat_Click(object sender, EventArgs e)
        {
            pnlTahsilat.Visible = true;
            pnlMasraf.Visible = false;
        }

        private void btnMasraf_Click(object sender, EventArgs e)
        {
            pnlTahsilat.Visible = false;
            pnlMasraf.Visible = true;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string tDosyaNo = cbxDosyasi.Text;
            string tPersonelTc = girisYapanAvukatTc;
            string tPersonelAdSoyad = girisYapanAvukatAdi;
            string tMuvekkil = cbxMuvekkil.Text;
            DateTime tTarih = Convert.ToDateTime(dtpIslemDate.Text);
            string tTutar = txtOdemeTutari.Text;
            string tTahsilatTuru = cbxTahsilatTuru.Text;
            string tAciklama = txtAciklama.Text;
            try
            {
                string sqlSentence = "insert into tblTahsilatBilgileri (tahDosyaNo,tahPersonelTc,tahPersonelAdSoyad,tahMuvekkil,tahTarih,tahTutar,tahTahsilatTuru,tahAciklama) values " +
                    "('" + tDosyaNo + "','" + tPersonelTc + "','" + tPersonelAdSoyad + "','" + tMuvekkil + "','" + tTarih + "','" + tTutar + "','" + tTahsilatTuru + "','" + tAciklama + "')";
                dp.insert_update_delete(sqlSentence);
                frmMessagebox.Message = "Tahsilat bilgileri başarıyla kaydedildi";
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

        private void cbxDosyasi_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string sqlSentence = "select dosyaNo,klasorNo,mahkemesiVeyaDairesi,avukatAdi,esas from tblDosyalar where dosyaNo='" + cbxDosyasi.Text + "'";
                string dosyaNo = dp.get_Data(sqlSentence).Rows[0][0].ToString();
                string klasorNo = dp.get_Data(sqlSentence).Rows[0][1].ToString();
                string mahkemeVeyaDaire = dp.get_Data(sqlSentence).Rows[0][2].ToString();
                string avukatAdi = dp.get_Data(sqlSentence).Rows[0][3].ToString();
                string esas = dp.get_Data(sqlSentence).Rows[0][4].ToString();
                string dosyaBilgi = "Dosya No:" + dosyaNo + " ,Klasor No:" + klasorNo + ", Mahkeme:" + mahkemeVeyaDaire + ", Avukat Adı:" + avukatAdi + ", Esas:" + esas + ".";
                lblDosyaBilgileri.Text = dosyaBilgi;
            }
            catch (Exception)
            {
                frmMessagebox.Message = "Dosya bulunamadı";
                frmMessagebox frm = new frmMessagebox();
                frm.Show();
                
            }
        }

        private void rbtnBelgesiz_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnBelgesiz.Checked == true)
            {
                linklblDosyaEkle.Visible = false;
                mFilePath = "";
            }
               
            else if (rbtnBelgesiz.Checked == false)
                linklblDosyaEkle.Visible = true;
        }

        private void btnDosyayiKapat_Click(object sender, EventArgs e)
        {
            if (pnlDosyaKapat.Visible == false)
                pnlDosyaKapat.Visible = true;
            else
                pnlDosyaKapat.Visible = false;
        }
       

        private void btnKaybedildi_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlSentence = "update tblDosyalar set dosyaDurum='Kapalı',davaDurum='Kaybedildi' where dosyaId='" + dosyaId + "'";
                dp.insert_update_delete(sqlSentence);
                frmMessagebox.Message = "Dosya kapatıldı.";
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

        private void btnKazanildi_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlSentence = "update tblDosyalar set dosyaDurum='Kapalı',davaDurum='Kazanıldı' where dosyaId='" + dosyaId + "'";
                dp.insert_update_delete(sqlSentence);
                frmMessagebox.Message = "Dosya kapatıldı.";
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
        string mFileLocation = "", mFileName = "", mDosyaAdi = "", mFilePath = "";
        private void linklblDosyaEkle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Dosya Seç";
            if(ofd.ShowDialog()==DialogResult.OK)
            {
                mFileLocation = ofd.FileName;
                mFileName = Path.GetFileName(mFileLocation);
                mDosyaAdi = girisYapanAvukatTc + "+" + cbxDosyasi.Text + "+" + mFileName;
                mFilePath = Path.Combine(Application.StartupPath + "\\files\\" + mDosyaAdi);
            }
        }

        private void btnMasrafKaydet_Click(object sender, EventArgs e)
        {
            string mDosyaNo = cbxDosyasi.Text;
            string mTcNo = girisYapanAvukatTc;
            string mPersonelAdi = girisYapanAvukatAdi;
            string mMuvekkil = cbxMuvekkil.Text;
            DateTime mIslemTarih = Convert.ToDateTime(dtpIslemDate.Text);
            string mTuru = cbxMasrafTuru.Text;
            string mDetay = cbxMasrafDetayi.Text;
            int adet = Convert.ToInt32(txtMasrafAdet.Text);
            double tutar = Convert.ToDouble(txtMasrafTutar.Text);
            string mToplamTutar = Convert.ToString(adet * tutar);
            string mBelgeDurum = "";
            if (rbtnBelgeli.Checked == true)
                mBelgeDurum = rbtnBelgeli.Text;
            else if (rbtnBelgesiz.Checked == true)
                mBelgeDurum = rbtnBelgesiz.Text;
            string mAciklama = txtMasrafAciklama.Text;
            try
            {
                if (rbtnBelgeli.Checked == true)
                    File.Copy(mFileLocation, mFilePath, true);
                string sqlSentence = "insert into tblMasrafBilgileri (masrafDosyaNo,masrafPersonelTc,masrafPersonelAdiSoyadi,masrafMuvekkilAdi,masrafTarih,masrafTuru,masrafDetay,masrafAdet,masrafTutar,masrafToplamTutar,masrafBelgeDurum,masrafAciklama,masrafDosyaYolu) values " +
                    "('" + mDosyaNo + "','" + mTcNo + "','" + mPersonelAdi + "','" + mMuvekkil + "','" + mIslemTarih + "','" + mTuru + "','" + mDetay + "','" + adet.ToString() + "','" + tutar.ToString() + "','" + mToplamTutar + "','" + mBelgeDurum + "','" + mAciklama + "','" + mFilePath + "')";
                dp.insert_update_delete(sqlSentence);
                frmMessagebox.Message = "Masraf bilgileri başarlı bir şekilde kaydedildi.";
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

        private void cbxMuvekkil_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxDosyasi.Text = "";
            string sqlSentence = "select dosyaNo from tblDosyalar where muvekkilAdi='" + cbxMuvekkil.Text + "'";
            dp.fillCombo(cbxDosyasi, sqlSentence, 0);
        }

        private void btnDurusmaPlaniDurusmaEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxDurusmaIslemTipi.Text==""||txtDurusmaSaat.Text==""||
                    cbxDurusmaPlaniAvukatAdi.Text==""||txtDurusmaNot.Text==""||
                    lbxDurusmaPlaniSecilenAvukatlar.Items.Count==0)
                    
                {
                    string message = "Lütfen Formda Boş Alan Bırakmayın ";
                    frmMessagebox.Message = message;
                    frmMessagebox frm = new frmMessagebox();
                    frm.Show();
                }
                else
                {
                    string dosyaNo = lblDurusmaDosyaNo.Text;
                    string muvekkil = lblDurusmaMuvekkil.Text;
                    string mahkemeAdi = lblDurusmaMahkemeAdi.Text;
                    string islemTipi = cbxDurusmaIslemTipi.Text;
                    DateTime durusmaPlanTarihi = Convert.ToDateTime(dtpDurusmaTarih.Text);
                    string durusmaPlanSaati = txtDurusmaSaat.Text;
                    string durusmaYeri="";
                    if (rbtnSehirDisi.Checked == true)
                        durusmaYeri = rbtnSehirDisi.Text;
                    else if (rbtnSehirIci.Checked == true)
                        durusmaYeri = rbtnSehirIci.Text;
                    string avukatAdi = cbxDurusmaPlaniAvukatAdi.Text;
                    string secilenAvukat="";
                    string[] secilenAvukatlar=new string[lbxDurusmaPlaniSecilenAvukatlar.Items.Count];
                    
                    for (int i = 0; i < lbxDurusmaPlaniSecilenAvukatlar.Items.Count; i++)
                    {
                        secilenAvukat += lbxDurusmaPlaniSecilenAvukatlar.Items[i].ToString()+",";
                        //secilenAvukatlar[i] = lbxDurusmaPlaniSecilenAvukatlar.Items[i].ToString();
                        //secilenAvukat += secilenAvukatlar[i].ToString() + ",";
                    }
                    string durusmaPlaniNot = txtDurusmaNot.Text;
                    string durusmaDurum = "Yapılmadı";
                    string sqlSentence = "insert into tblDurusmaPlanlari (dosyaId,dosyaNo,muvekkil,mahkemeAdi,islemTipi,durusmaPlaniTarih,durusmaPlaniSaat,durusmaYeri,avukatAdi,secilenAvukatlar,durusmaPlaniNot,durusmaDurum) values " +
                        "('" + dosyaId + "','" + dosyaNo + "','" + muvekkil + "','" + mahkemeAdi + "','" + islemTipi + "','" + durusmaPlanTarihi + "','" + durusmaPlanSaati + "','" + durusmaYeri + "','" + avukatAdi + "','" + secilenAvukat + "','" + durusmaPlaniNot + "','" + durusmaDurum + "')";
                    dp.insert_update_delete(sqlSentence);
                    cbxDurusmaIslemTipi.Text = "";cbxDurusmaPlaniAvukatAdi.Text = "";
                    txtDurusmaSaat.Text = "";txtDurusmaNot.Text = "";
                    lbxDurusmaPlaniSecilenAvukatlar.Items.Clear();
                    string sqlSentence2 = "select * from tblPersonel";
                    dp.fillListBox(lbxDurusmaPlaniAvukatlar, sqlSentence2, 1);
                    string message = "Duruşma Planı Başarı İle Oluşturuldu ";
                    frmMessagebox.Message = message;
                    frmMessagebox frm = new frmMessagebox();
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                frmMessagebox frm = new frmMessagebox();
                frmMessagebox.Message = ex.Message;
                frm.Show();
            }
        }

        private void btnAraKararEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblAraKararDosyaNo.Text==""||lblAraKararEsas.Text==""
                    ||lblAraKararMahkemeAdi.Text==""||lblAraKararMuvekkil.Text==""
                    ||txtAraKararYapilacakIslem.Text=="")
                {
                    string message = "Lütfen Formda Boş Alan Bırakmayın ";
                    frmMessagebox.Message = message;
                    frmMessagebox frm = new frmMessagebox();
                    frm.Show();
                }
                else
                {
                    string dosyaNo = lblAraKararDosyaNo.Text;
                    string esas = lblAraKararEsas.Text;
                    string mahkemeAdi = lblAraKararMahkemeAdi.Text;
                    string muvekkilAdi = lblAraKararMuvekkil.Text;
                    DateTime tarih = Convert.ToDateTime(dtpAraKararTarih.Text);
                    string islem = txtAraKararYapilacakIslem.Text;
                    string durum = "Yapılmadı";
                    string sqlSentence = "insert into tblAraKarar (dosyaId,esas,dosyaNo,muvekkilAdi,mahkemeAdi,araKararTarih,yapilacakIslem,durum) values " +
                        "('" + dosyaId + "','" + esas + "','" + dosyaNo + "','" + muvekkilAdi + "','" + mahkemeAdi + "','" + tarih + "','" + islem + "','" + durum + "')";
                    dp.insert_update_delete(sqlSentence);
                    string message = "Ara Karar Başarıyla Kaydedildi";
                    txtAraKararYapilacakIslem.Text = "";
                    frmMessagebox.Message = message;
                    frmMessagebox frm = new frmMessagebox();
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                frmMessagebox frm = new frmMessagebox();
                frmMessagebox.Message = ex.Message;
                frm.Show();
            }
        }

        private void btnAvansMasraf_Click(object sender, EventArgs e)
        {
            string message = "";
            if (yetkiAvansMasraf == 1)
            {
                gbxDosyBilgileri.Visible = false;
                gbxAvansMasraf.Visible = true;
                gbxIsplani.Visible = false;
                gbxAraKarar.Visible = false;
                gbxOfisIciNot.Visible = false;
                gbxDurusmaPlani.Visible = false;

                rbtnBelgeli.Checked = true;
                string sqlSentence = "select muvekkilAdSoyad from tblMuvekkiller";
                dp.fillCombo(cbxMuvekkil, sqlSentence, 0);
            }
            else if (yetkiAvansMasraf == 0)
            {
                message = "Bu işlemi gerçekleştirmeye yetkiniz yok";
                frmMessagebox.Message = message;
                frmMessagebox frm = new frmMessagebox();
                frm.Show();
            }
        }

        private void btnAraKararIslemleri_Click_1(object sender, EventArgs e)
        {
            gbxDosyBilgileri.Visible = false;
            gbxIsplani.Visible = false;
            gbxAvansMasraf.Visible = false;
            gbxAraKarar.Visible = true;
            gbxDurusmaPlani.Visible = false;
            gbxOfisIciNot.Visible = false;

            lblAraKararDosyaNo.Text = dosyaNo;
            lblAraKararEsas.Text = esas;
            lblAraKararMahkemeAdi.Text = mahkemeVeyaDaire;
            lblAraKararMuvekkil.Text = muvekkilAdi;
        }

        private void btnIsPlaniniKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIsAdi.Text=="" || txtIsinYapilacagiYer.Text==""||txtYapilacakIs.Text==""||cbxIsOnemi.Text==""||cbxPlaniYapan.Text=="")
                {
                    string message = "Lütfen Formda Boş Alan Bırakmayın ";
                    frmMessagebox.Message = message;
                    frmMessagebox frm = new frmMessagebox();
                    frm.Show();
                }
                else
                {
                    string isAdi = txtIsAdi.Text;
                    DateTime isTarih = Convert.ToDateTime(dtpIsinYapilacagiTarih.Text);
                    string planiYapan = cbxPlaniYapan.Text;
                    string planYapilan = lblPlanYapilan.Text;
                    string isYapilacakYer = txtIsinYapilacagiYer.Text;
                    string isOnemi = cbxIsOnemi.Text;
                    string yapilacakIs = txtYapilacakIs.Text;
                    string isDurum = "Yapılmadı";
                    string sqlSentence = "insert into tblisPlanlari (dosyaId,isAdi,isYapilacakTarih,planiYapan,planYapilan,isYapilacakYer,isOnemi,yapilacakis,isDurum) values" +
                        " ('" + dosyaId + "','" + isAdi + "','" + isTarih + "','" + planiYapan + "','" + planYapilan + "','" + isYapilacakYer + "','" + isOnemi + "','" + yapilacakIs + "','" + isDurum + "')";
                    dp.insert_update_delete(sqlSentence);
                    string message = "iş Planı Başarıyla Kaydedildi";
                    txtIsAdi.Text = "";txtIsinYapilacagiYer.Text = "";
                    txtYapilacakIs.Text = "";cbxIsOnemi.Text = "";cbxPlaniYapan.Text = "";
                    frmMessagebox.Message = message;
                    frmMessagebox frm = new frmMessagebox();
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                frmMessagebox frm = new frmMessagebox();
                frmMessagebox.Message = ex.Message;
                frm.Show();
            }
        }

        private void btnIsPlani_Click(object sender, EventArgs e)
        {
            gbxIsplani.Visible = true;
            gbxDosyBilgileri.Visible = false;
            gbxAraKarar.Visible = false;
            gbxOfisIciNot.Visible = false;
            gbxDurusmaPlani.Visible = false;
            gbxAvansMasraf.Visible = false;
                

            lblPlanYapilan.Text = muvekkilAdi;
            string sqlSentece = "select perAdiSoyadi from tblPersonel";
            dp.fillCombo(cbxPlaniYapan, sqlSentece, 0);
        }

        private void btnDosyaBilgileri_Click(object sender, EventArgs e)
        {
            gbxDosyBilgileri.Visible = true;
            gbxAvansMasraf.Visible = false;
            gbxIsplani.Visible = false;
            gbxAraKarar.Visible = false;
            gbxOfisIciNot.Visible = false;
            gbxDurusmaPlani.Visible = false;
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDosyalarim_Click(object sender, EventArgs e)
        {
            frmDosyalar frm = new frmDosyalar();
            this.Hide();
            frm.Show();
        }

        private void btnDavaDosyasi_Click(object sender, EventArgs e)
        {
            frmDavaDosyasi frm = new frmDavaDosyasi();
            this.Hide();
            frm.Show();
        }

        private void btnIcraDosyasi_Click(object sender, EventArgs e)
        {
            frmIcraDosyasi frm = new frmIcraDosyasi();
            this.Hide();
            frm.Show();
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

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void panel1_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void pcbGeriDon_Click(object sender, EventArgs e)
        {
            frmDosyalar frm = new frmDosyalar();
            this.Hide();
            frm.Show();
        }

        private void frmDosyaIcerikleri_Load(object sender, EventArgs e)
        {
            pnlDosyaKapat.Visible = false;
            pnlYeniDosya.Visible = false;
            lblDosyaTuru.Text = dosyaTuru;
            lblMuvekkilAdi.Text = muvekkilAdi;
            lblKarsiTarafAdi.Text = KarsiTarafAdi;
            lblDavaTuru.Text = davaVeyaTakipTuru;
            lblMahkemeTuru.Text = mahkemeTuru;
            lblMahkemeTuruAltKirilim.Text = mahkemeTurAltKirilim;
            lblLehAleyh.Text = lehdeAleyhde;
            lblTarafimiz.Text = tarafimiz;
            lblKlasorNo.Text = klasorNo;
            lblDosyaNo.Text = dosyaNo;
            lblMahkemesi.Text = mahkemeVeyaDaire;
            lblDavaKonusu.Text = davaVeyaIcraKonusu;
            lblDavaAcmaTarihi.Text = davaAcmaTarihi;
            lblisKabulTarihi.Text = isKabulTarihi;
            lblAvukatAdi.Text = avukatAdi;
            lbliliskilendirilenPersonel.Text = girisYapanAvukatAdi;

            gbxDosyBilgileri.Visible = false;
            gbxIsplani.Visible = true;
            gbxAraKarar.Visible = false;
            gbxOfisIciNot.Visible = false;
            gbxDurusmaPlani.Visible = false;
            gbxAvansMasraf.Visible = false;

            if (dosyaDurum=="Kapalı")
            {
                btnDosyayiKapat.Enabled = false;
                btnDosyayiKapat.Text = "Bu dosya kapalı";
            }
        }
    }
}
