using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using SpeechLib;
using System.Speech;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Threading;
using System.Diagnostics;//Bir program açtırmak istediğimizde bu kütüphaneyi ekliyoruz.

namespace IKCB_Law_Office
{
    public partial class frmMainPage : Form
    {
        public frmMainPage()
        {
            InitializeComponent();
        }
        public static string perId, perDogTar, perPozisyon, perAdSoyad, perEmail, perTelNo, perAdres, perSifre, perYetki, perResim, perTc;
        public static DialogResult cevap;
        public static int geriDeger;
        void eskiKonum()
        {
            panel2.Location = new Point(3, 195);
            panel3.Location = new Point(3, 238);
            panel7.Location = new Point(3, 282);
            btnDosyalarim.Location = new Point(8, 195);
            btnVekaletler.Location = new Point(8, 238);
            btnAnaSayfaIctihatlar.Location = new Point(8, 282);
        }
        void yenikonum()
        {
            panel2.Location = new Point(3, 322);
            panel3.Location = new Point(3, 364);
            panel7.Location = new Point(3, 408);
            btnDosyalarim.Location = new Point(8, 322);
            btnVekaletler.Location = new Point(8, 364);
            btnAnaSayfaIctihatlar.Location = new Point(8, 408);
        }
        DatabaseProcess dp = new DatabaseProcess();
        process mp = new process();
        private void btnDosyalarim_Click(object sender, EventArgs e)
        {
            if (pnlYeniDosya.Visible == true)
                pnlYeniDosya.Visible = false;
            frmDosyalar frm = new frmDosyalar();
            this.Hide();
            frm.Show();
        }
        
        private void btnVekaletler_Click(object sender, EventArgs e)
        {
            if (pnlYeniDosya.Visible == true)
                pnlYeniDosya.Visible = false;
            eskiKonum();
        }

        private void pnlTop_DoubleClick(object sender, EventArgs e)
        {
           // if (lblBildirimler.Anchor == System.Windows.Forms.AnchorStyles.None)
           //     lblBildirimler.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
           // else if (lblBildirimler.Anchor == System.Windows.Forms.AnchorStyles.Bottom)
           //     lblBildirimler.Anchor = System.Windows.Forms.AnchorStyles.None;

            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                lblBildirimler.Location = new Point(lblBildirimler.Location.X, 1200);
                
            }
            else if (this.WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;
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

        private void btnIsler_Click(object sender, EventArgs e)
        {
            pnlIsler.Visible = true;
            pnlAraKarar.Visible = false;
        }

        private void btnAraKarar_Click(object sender, EventArgs e)
        {
            pnlIsler.Visible = false;
            pnlAraKarar.Visible = true;
        }

        private void btnAnaSayfaIctihatlar_Click(object sender, EventArgs e)
        {
            if (pnlYeniDosya.Visible == true)
                pnlYeniDosya.Visible = false;
            eskiKonum();
        }

        private void pcbDosyaAra_Click(object sender, EventArgs e)
        {
            //string metin = "Hello. My name is bruce lee.";
            //SpVoice spv = new SpVoice();
            //spv.Speak(metin);
            try
            {
                string sqlSentence = "select * from tblDosyalar where dosyaNo='" + txtDosyaAra.Text + "'";
                frmDosyaIcerikleri.dosyaId = dp.get_Data(sqlSentence).Rows[0][0].ToString();
                frmDosyaIcerikleri.dosyaTuru = dp.get_Data(sqlSentence).Rows[0][1].ToString();
                frmDosyaIcerikleri.muvekkilAdi = dp.get_Data(sqlSentence).Rows[0][2].ToString();
                frmDosyaIcerikleri.KarsiTarafAdi = dp.get_Data(sqlSentence).Rows[0][3].ToString();
                frmDosyaIcerikleri.davaVeyaTakipTuru = dp.get_Data(sqlSentence).Rows[0][4].ToString();
                frmDosyaIcerikleri.mahkemeTuru = dp.get_Data(sqlSentence).Rows[0][5].ToString();
                frmDosyaIcerikleri.mahkemeTurAltKirilim = dp.get_Data(sqlSentence).Rows[0][6].ToString();
                frmDosyaIcerikleri.lehdeAleyhde = dp.get_Data(sqlSentence).Rows[0][7].ToString();
                frmDosyaIcerikleri.tarafimiz = dp.get_Data(sqlSentence).Rows[0][8].ToString();
                frmDosyaIcerikleri.klasorNo = dp.get_Data(sqlSentence).Rows[0][9].ToString();
                frmDosyaIcerikleri.dosyaNo = dp.get_Data(sqlSentence).Rows[0][10].ToString();
                frmDosyaIcerikleri.mahkemeVeyaDaire = dp.get_Data(sqlSentence).Rows[0][11].ToString();
                frmDosyaIcerikleri.davaVeyaIcraKonusu = dp.get_Data(sqlSentence).Rows[0][12].ToString();
                frmDosyaIcerikleri.davaAcmaTarihi = dp.get_Data(sqlSentence).Rows[0][13].ToString();
                frmDosyaIcerikleri.isKabulTarihi = dp.get_Data(sqlSentence).Rows[0][14].ToString();
                frmDosyaIcerikleri.avukatAdi = dp.get_Data(sqlSentence).Rows[0][15].ToString();
                frmDosyaIcerikleri.esas = dp.get_Data(sqlSentence).Rows[0][16].ToString();
                frmDosyaIcerikleri.dosyaDurum = dp.get_Data(sqlSentence).Rows[0][18].ToString();
                frmDosyaIcerikleri frm = new frmDosyaIcerikleri();
                this.Hide();
                frm.Show();
                txtDosyaAra.Text = "";
            }
            catch (Exception ex)
            {
                frmMessagebox.Message = "Dosya Bulunamadı.";
                frmMessagebox frm = new frmMessagebox();
                frm.Show();
            }
        }

        private void pcbProfileFoto_Click(object sender, EventArgs e)
        {
            string resimEski = perResim;
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "Resim Seç";
               
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string sqlAdresGetir = "select perProfilFoto from tblPersonel where  perId=" + perId;
                    string resimAdres = dp.get_Data(sqlAdresGetir).Rows[0][0].ToString();
                    pcbProfileFoto.ImageLocation = ofd.FileName;
                    string imageFile = Path.GetFileName(pcbProfileFoto.ImageLocation);
                    string resimAdi = perTc + "++" + imageFile;
                    string imagePath = Path.Combine(Application.StartupPath + "\\images\\" + resimAdi);
                    string sqlSentence = "update tblPersonel set perProfilFoto='" + imagePath + "' where perId=" + perId;
                    dp.insert_update_delete(sqlSentence);
                    
                    //MessageBox.Show(resimAdres);
                    if (perResim != Application.StartupPath + "\\images\\" + "defaultImage.png")
                        File.Delete(resimAdres);
                    File.Copy(pcbProfileFoto.ImageLocation, imagePath, true);
                }
            }
            catch (Exception ex)
            {
                frmMessagebox.Message = ex.Message;
                frmMessagebox frm = new frmMessagebox();
                frm.Show();
            }
        }
        
        SpeechSynthesizer synt = new SpeechSynthesizer();
        PromptBuilder pBuilt = new PromptBuilder();
        SpeechRecognitionEngine rEngine = new SpeechRecognitionEngine();
       
        private void pcbSpeak_Click(object sender, EventArgs e)
        {
            Choices list = new Choices();
            list.Add(new string[] {"exit"});
            Grammar g = new Grammar(new GrammarBuilder(list));
            try
            {
                rEngine.RequestRecognizerUpdate();
                rEngine.LoadGrammar(g);
                rEngine.SpeechRecognized += rEngine_SpeechRecognized;
                rEngine.SetInputToDefaultAudioDevice();
                rEngine.RecognizeAsync(RecognizeMode.Multiple);
                //rEngine.Dispose();
            }
            catch
            {
                return;
            }
        }

        void rEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text)
            {
                case "exit":
                    frmLogin frm = new frmLogin();
                    this.Hide();
                    frm.Show();
                    pBuilt.ClearContent();
                    pBuilt.AppendText("succesfully");
                    synt.Speak(pBuilt);
                    break;
            }
        }
        int x = 1170, y = 602;

        private void timerAltYazi_Tick(object sender, EventArgs e)
        {
            x--;
            lblBildirimler.Location = new Point(x, y);
            if (x == -950)
                x = 1170;
        }

        private void btnCikisYap_Click(object sender, EventArgs e)
        {
           
            frmLogin loginPage = new frmLogin();
            loginPage.Show();
            this.Hide();
        }

        private void btnHesapAyarlari_Click(object sender, EventArgs e)
        {
            pnlProfileMenu.Visible = false;
            frmHesapBilgileriniGuncelle.perId = perId;
            frmHesapBilgileriniGuncelle.perAdiSoyadi = perAdSoyad;
            frmHesapBilgileriniGuncelle.perEmailAdres = perEmail;
            frmHesapBilgileriniGuncelle.perTelNo = perTelNo;
            frmHesapBilgileriniGuncelle.perAdres = perAdres;
            frmHesapBilgileriniGuncelle.perSifre = perSifre;
            frmHesapBilgileriniGuncelle.perDogTar = perDogTar;
            frmHesapBilgileriniGuncelle.perTc = perTc;
            frmHesapBilgileriniGuncelle.perPozisyon = perPozisyon;
            frmHesapBilgileriniGuncelle frm = new frmHesapBilgileriniGuncelle();
            frm.Show();
        }

        private void btnProfileName_Click(object sender, EventArgs e)
        {
            if (pnlProfileMenu.Visible == false)
                pnlProfileMenu.Visible = true;
            else
                pnlProfileMenu.Visible = false;
        }

        private void btnNewFile_Click(object sender, EventArgs e)
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

        private void pcbMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void pcbMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pcbClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        void sesMetin(string metin)
        {
            SpVoice spv = new SpVoice();
            spv.Speak(metin);
        }
        private void frmMainPage_Load(object sender, EventArgs e)
        {
            //tblDosyalar tablosuna dosyayı oluşturan avukatın tcsinide ekle.
            //Daha sonra toplam dosya sorgusunu o tc ye göre yap.
            
            timerAltYazi.Start();
            
            string sqlToplamDosya = "select * from tblDosyalar";
            int toplamDosya = dp.get_Data(sqlToplamDosya).Rows.Count;

            string sqlAcikDosya = "select * from tblDosyalar where dosyaDurum='Açık'";
            int acikDosya = dp.get_Data(sqlAcikDosya).Rows.Count;
            int kapaliDosya = toplamDosya - acikDosya;
            lblAcikDosyaSayisi.Text = acikDosya.ToString();
            lblKapaliDosyaSayisi.Text = kapaliDosya.ToString();
            cgAcikDosyalar.Value = (acikDosya * 100) / toplamDosya;

            string sqlKazanilanDavaAdeti = "select  * from tblDosyalar where davaDurum='Kazanıldı'";
            string sqlKaybedilenDavaAdeti = "select  * from tblDosyalar where davaDurum='Kaybedildi'";
            int kazanilanDavaAdeti = dp.get_Data(sqlKazanilanDavaAdeti).Rows.Count;
            int kaybedilenDavaAdeti = dp.get_Data(sqlKaybedilenDavaAdeti).Rows.Count;
            lblKazanilanDavaSayisi.Text = kazanilanDavaAdeti.ToString();
            lblKaybedilenDavaSayisi.Text = kaybedilenDavaAdeti.ToString();
            cgKazanılanDava.Value = (kazanilanDavaAdeti * 100) / (kazanilanDavaAdeti + kaybedilenDavaAdeti);

            //ileride başka dosya türü olduğunda buradaki kısımları düzenle.
            string sqlIcraDosyaAdeti = "select * from tblDosyalar where dosyaTuru='İcra Dosyası'";
            string sqlDavaDosyaSayisi = "select * from tblDosyalar where dosyaTuru='Dava Dosyası'";
            int icraDosyaAdeti = dp.get_Data(sqlIcraDosyaAdeti).Rows.Count;
            int davaDosyaAdeti = dp.get_Data(sqlDavaDosyaSayisi).Rows.Count;
            lblicraDosyaSayisi.Text = icraDosyaAdeti.ToString();
            lblDavaDosyaSayisi.Text = davaDosyaAdeti.ToString();
            cgIcraDosyasi.Value = (icraDosyaAdeti * 100) / (icraDosyaAdeti + davaDosyaAdeti);

            string sqlLehdeDosyaAdeti = "select * from tblDosyalar where leyhdeAleyhde='Lehde'";
            string sqlAleyhdeDosyaSayisi = "select * from tblDosyalar where leyhdeAleyhde='Aleyhde'";
            int lehdeDosyaAdeti = dp.get_Data(sqlLehdeDosyaAdeti).Rows.Count;
            int aleyhdeDosyaAdeti = dp.get_Data(sqlAleyhdeDosyaSayisi).Rows.Count;
            lblLehdeDosyaSayisi.Text = icraDosyaAdeti.ToString();
            lblAleyhdeDosyaSayisi.Text = davaDosyaAdeti.ToString();
            cgLehdeDosyaSayisi.Value = (lehdeDosyaAdeti * 100) / (lehdeDosyaAdeti + aleyhdeDosyaAdeti);

            string sqlKullaniciAcikDosyaSayisi = "select * from tblDosyalar where dosyaDurum='Açık' and avukatTc='" + perTc + "'";
            string sqlKullaniciKapaliDosyaSayisi= "select * from tblDosyalar where dosyaDurum='Kapalı' and avukatTc='" + perTc + "'";
            int kullaniciAcikDosyaSayisi = dp.get_Data(sqlKullaniciAcikDosyaSayisi).Rows.Count;
            int kullaniciKapaliDosyaSayisi = dp.get_Data(sqlKullaniciKapaliDosyaSayisi).Rows.Count;
            lblKullaniciAcikDosya.Text = kullaniciAcikDosyaSayisi.ToString();
            lblKullaniciKapaliDosya.Text = kullaniciKapaliDosyaSayisi.ToString();
            if (kullaniciAcikDosyaSayisi == 0 && kullaniciKapaliDosyaSayisi == 0)
                cgKullaniciAcikDosya.Value = (kullaniciAcikDosyaSayisi * 100) / 1;
            else
                cgKullaniciAcikDosya.Value = (kullaniciAcikDosyaSayisi * 100) / (kullaniciAcikDosyaSayisi + kullaniciKapaliDosyaSayisi);


            string sqlKullaniciKazanilanDavaSayisi = "select * from tblDosyalar where davaDurum='Kazanıldı' and avukatTc='" + perTc + "'";
            string sqlKullaniciKaybedilenDavaSayisi= "select * from tblDosyalar where davaDurum='Kaybedildi' and avukatTc='" + perTc + "'";
            int kullaniciKazanilanDavaSayisi = dp.get_Data(sqlKullaniciKazanilanDavaSayisi).Rows.Count;
            int kullaniciKaybedilenDavaSayisi = dp.get_Data(sqlKullaniciKaybedilenDavaSayisi).Rows.Count;
            lblKullaniciKazanilanDosya.Text = kullaniciKazanilanDavaSayisi.ToString();
            lblKullaniciKaybedilenDosya.Text = kullaniciKaybedilenDavaSayisi.ToString();
            if (kullaniciKazanilanDavaSayisi == 0 || kullaniciKaybedilenDavaSayisi == 0)
                cgKullaniciKazanilanDosya.Value = (kullaniciKazanilanDavaSayisi * 100) / 1;
            else
                cgKullaniciKazanilanDosya.Value = (kullaniciKazanilanDavaSayisi * 100) / (kullaniciKazanilanDavaSayisi + kullaniciKaybedilenDavaSayisi);

            string sqlKullaniciIcraDosyaSayisi = "select * from tblDosyalar where dosyaTuru='İcra Dosyası' and avukatTc='" + perTc + "'";
            string sqlKullaniciDavaDosyaSayisi = "select * from tblDosyalar where dosyaTuru='Dava Dosyası' and avukatTc='" + perTc + "'";
            int kullaniciIcraDosyaSayisi = dp.get_Data(sqlKullaniciIcraDosyaSayisi).Rows.Count;
            int kullaniciDavaDosyaSayisi = dp.get_Data(sqlKullaniciDavaDosyaSayisi).Rows.Count;
            lblKullaniciIcraDosya.Text = kullaniciIcraDosyaSayisi.ToString();
            lblKullaniciDavaDosya.Text = kullaniciDavaDosyaSayisi.ToString();
            if (kullaniciIcraDosyaSayisi == 0 && kullaniciDavaDosyaSayisi == 0)
                cgKullaniciDavaDosya.Value = (kullaniciIcraDosyaSayisi * 100) / 1;
            else
                cgKullaniciDavaDosya.Value = (kullaniciIcraDosyaSayisi * 100) / (kullaniciIcraDosyaSayisi + kullaniciDavaDosyaSayisi);

            string sqlKullaniciLehdeDosyaSayisi = "select * from tblDosyalar where leyhdeAleyhde='Lehde' and avukatTc='" + perTc + "'";
            string sqlKullaniciAleyhdeDosyaSayisi = "select * from tblDosyalar where leyhdeAleyhde='Aleyhde' and avukatTc='" + perTc + "'";
            int kullaniciLehdeDosyaSayisi = dp.get_Data(sqlKullaniciLehdeDosyaSayisi).Rows.Count;
            int kullaniciAleyhdeDosyaSayisi = dp.get_Data(sqlKullaniciAleyhdeDosyaSayisi).Rows.Count;
            lblKullaniciLehdeDosya.Text = kullaniciLehdeDosyaSayisi.ToString();
            lblKullaniciAleyhdeDosya.Text = kullaniciAleyhdeDosyaSayisi.ToString();
            if (kullaniciLehdeDosyaSayisi == 0 && kullaniciAleyhdeDosyaSayisi == 0)
                cgKullaniciLehdeDosya.Value = (kullaniciLehdeDosyaSayisi * 100) / 1;
            else
                cgKullaniciLehdeDosya.Value = (kullaniciLehdeDosyaSayisi * 100) / (kullaniciLehdeDosyaSayisi + kullaniciAleyhdeDosyaSayisi);


            string sqlAvukatinDavaAdedi = "select * from tblDosyalar where avukatTc='" + perTc + "'";
            int avukatinToplamDosyasi = dp.get_Data(sqlAvukatinDavaAdedi).Rows.Count;
            string altYazi = "Sayın " + perAdSoyad + ". Hoşgeldiniz.Toplam Dosya Sayisi '" + toplamDosya + "' adet. Sizin baktığınız dosya sayısı '" + avukatinToplamDosyasi.ToString() + "' adet.Kazandığınız dava sayısı '" + kullaniciKazanilanDavaSayisi + "' adet.Kaybettiğiniz dava sayısı '" + kullaniciKaybedilenDavaSayisi + "' adet.";
            //sesMetin(altYazi);
            lblBildirimler.Text = altYazi;
            pnlYeniDosya.Visible = false;
            pnlIsler.Visible = true;
            pnlAraKarar.Visible = false;
            pnlProfileMenu.Visible = false;
            btnProfileName.Text = perAdSoyad;
            pcbProfileFoto.ImageLocation = perResim;

            var bugun = DateTime.Now.Date;
            string sqlSentence1 = "select * from tblisPlanlari where isYapilacakTarih='" + bugun + "'";
            dp.fillListBox(lbxYapilacakIsler, sqlSentence1, 2);
            string sqlSentence2 = "select * from tblisPlanlari where isYapilacakTarih<'" + bugun + "'";
            dp.fillListBox(lbxGecmisIsler, sqlSentence2, 2);
            string sqlSentence3 = "select * from tblisPlanlari where isYapilacakTarih>'" + bugun + "'";
            dp.fillListBox(lbxYaklasanIsler, sqlSentence3, 2);
            string sqlSentence4 = "select * from tblAraKarar where araKararTarih='" + bugun + "'";
            dp.fillListBox(lbxAraKarar, sqlSentence4, 4);
            string sqlSentence5 = "select * from tblAraKarar where araKararTarih<'" + bugun + "'";
            dp.fillListBox(lbxGecmisAraKarar, sqlSentence5, 4);
            string sqlSentence6 = "select * from tblAraKarar where araKararTarih>'" + bugun + "'";
            dp.fillListBox(lbxYaklasanAraKarar, sqlSentence6, 4);

        }
    }
}
