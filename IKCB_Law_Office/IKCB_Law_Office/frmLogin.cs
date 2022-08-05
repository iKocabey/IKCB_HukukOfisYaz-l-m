using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace IKCB_Law_Office
{
    public partial class frmLogin : Form
    {
        SqlConnection conSentences = new SqlConnection("Data Source = IKOCABEY\\SQLEXPRESS;Initial Catalog = IKCBHukukBuro; Integrated Security = True");
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
           
        }

        private void btnKullaniciGirisi_Click(object sender, EventArgs e)
        {
            try
            {
                int no = 1;
                DatabaseProcess dp = new DatabaseProcess();
                string adSoyad = txtKullaniciAdi.Text;
                string password = txtPassword.Text;
                string sqlSentence = "select * from tblPersonel where perAdiSoyadi='" + adSoyad + "' and perSifre='" + password + "'";

                string perId = dp.get_Data(sqlSentence).Rows[0][0].ToString();
                string perAdSoyad = dp.get_Data(sqlSentence).Rows[0][1].ToString();
                string perEmail = dp.get_Data(sqlSentence).Rows[0][2].ToString();
                string perTelNo = dp.get_Data(sqlSentence).Rows[0][3].ToString();
                string perAdres = dp.get_Data(sqlSentence).Rows[0][4].ToString();
                string perSifre = dp.get_Data(sqlSentence).Rows[0][5].ToString();
                string perDogTAr = dp.get_Data(sqlSentence).Rows[0][6].ToString();
                string perResim = dp.get_Data(sqlSentence).Rows[0][7].ToString();
                string perTc = dp.get_Data(sqlSentence).Rows[0][8].ToString();
                int perYetkiMaliRapor = Convert.ToInt32(dp.get_Data(sqlSentence).Rows[0][9]);
                int perYetkiAvansMasraf = Convert.ToInt32(dp.get_Data(sqlSentence).Rows[0][10]);
                string perPozisyon = dp.get_Data(sqlSentence).Rows[0][11].ToString();

                frmIcraDosyasi.avukatAdiSoyadi = perAdSoyad;
                frmIcraDosyasi.avukatTc = perTc;
                frmDavaDosyasi.avukatAdiSoyadi = perAdSoyad;
                frmDavaDosyasi.avukatTc = perTc;
                frmMainPage.perId = perId;
                frmMainPage.perAdSoyad = perAdSoyad;
                frmMainPage.perEmail = perEmail;
                frmMainPage.perTelNo = perTelNo;
                frmMainPage.perAdres = perAdres;
                frmMainPage.perSifre = perSifre;
                frmMainPage.perResim = perResim;
                frmMainPage.perTc = perTc;
                frmMainPage.perDogTar = perDogTAr;
                frmMainPage.perPozisyon = perPozisyon;
                frmDosyaIcerikleri.girisYapanAvukatAdi = perAdSoyad;
                frmDosyaIcerikleri.girisYapanAvukatTc = perTc;
                //Buradaki kısım yetkiler için
                frmDosyaIcerikleri.yetkiAvansMasraf = perYetkiAvansMasraf;
                frmDosyaIcerikleri.yetkiMaliRapor = perYetkiMaliRapor;
                


                frmSplash.durum = no;
                frmSplash frm = new frmSplash();
                this.Hide();
                frm.Show();
            }
            catch (Exception ex)
            {
                string message = "Kullanıcı adı veya parola hatalı.";
                frmMessagebox frm = new frmMessagebox();
                frmMessagebox.Message = message;
                frm.Show();
            }
        }

        private void pcbLoginPageExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pcbLoginPageMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnYoneticiGirisi_Click(object sender, EventArgs e)
        {
            int no = 0;
            DatabaseProcess dp = new DatabaseProcess();
            string adSoyad = txtKullaniciAdi.Text;
            string password = txtPassword.Text;
            string sqlSentence = "select * from tblYonetici where yoneticiAdSoyad='" + adSoyad + "' and yoneticiSifre='" + password + "'";
            if (dp.get_Data(sqlSentence).Rows.Count>0)
            {
                frmSplash.durum = no;
                frmSplash frm = new frmSplash();
                frm.Show();
                this.Hide();
            }
            else
            {
               string message = "Kullanıcı adı veya parola hatalı.";
               frmMessagebox frm = new frmMessagebox();
               frmMessagebox.Message = message;
               frm.Show();
            }
        }
    }
}
