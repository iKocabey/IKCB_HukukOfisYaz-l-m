using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IKCB_Law_Office
{
    public partial class frmPersonelistatistikleri : Form
    {
        DatabaseProcess dp = new DatabaseProcess();
        public frmPersonelistatistikleri()
        {
            InitializeComponent();
        }

        private void pcbKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPersonelistatistikleri_Load(object sender, EventArgs e)
        {
            string sqlSentece = "select perAdiSoyadi from tblPersonel";
            dp.fillCombo(cbxAvukatSec, sqlSentece, 0);
        }

        private void cbxAvukatSec_TextChanged(object sender, EventArgs e)
        {
            string sqlKapaliDosya = "select * from tblDosyalar where dosyaDurum='Kapalı' and avukatAdi='" + cbxAvukatSec.Text + "'";
            string sqlAçikDosya = "select * from tblDosyalar where dosyaDurum='Açık' and avukatAdi='" + cbxAvukatSec.Text + "'";
            int acikDosyaSayisi = dp.get_Data(sqlAçikDosya).Rows.Count;
            int kapaliDosyaSayisi = dp.get_Data(sqlKapaliDosya).Rows.Count;
            lblAcikDosyaSayisi.Text = acikDosyaSayisi.ToString();
            lblKapaliDosyaSayisi.Text = kapaliDosyaSayisi.ToString();
            if (acikDosyaSayisi == 0 && kapaliDosyaSayisi == 0)
                cgAcikDosyalar.Value = 0;
            else
                cgAcikDosyalar.Value = (acikDosyaSayisi * 100) / (acikDosyaSayisi + kapaliDosyaSayisi);

            string sqlKazanilanDosya = "select * from tblDosyalar where davaDurum='Kazanıldı' and avukatAdi='" + cbxAvukatSec.Text + "'";
            string sqlKaybedilenDosya = "select * from tblDosyalar where davaDurum='Kaybedildi' and avukatAdi='" + cbxAvukatSec.Text + "'";
            int kazanilanDavaSayisi = dp.get_Data(sqlKazanilanDosya).Rows.Count;
            int kaybedilenDavaSayisi = dp.get_Data(sqlKaybedilenDosya).Rows.Count;
            lblKazanilanDavaSayisi.Text = kazanilanDavaSayisi.ToString();
            lblKaybedilenDavaSayisi.Text = kaybedilenDavaSayisi.ToString();
            if (kazanilanDavaSayisi == 0 && kaybedilenDavaSayisi == 0)
                cgKazanılanDava.Value = 0;
            else
                cgKazanılanDava.Value = (kazanilanDavaSayisi * 100) / (kazanilanDavaSayisi + kaybedilenDavaSayisi);

            string sqlIcraDosya = "select * from tblDosyalar where dosyaTuru='İcra Dosyası' and avukatAdi='" + cbxAvukatSec.Text + "'";
            string sqlDavaDosya = "select * from tblDosyalar where dosyaTuru='Dava Dosyası' and avukatAdi='" + cbxAvukatSec.Text + "'";
            int icraDosyaSayisi = dp.get_Data(sqlIcraDosya).Rows.Count;
            int davaDosyaSayisi = dp.get_Data(sqlDavaDosya).Rows.Count;
            lblicraDosyaSayisi.Text = icraDosyaSayisi.ToString();
            lblDavaDosyaSayisi.Text = davaDosyaSayisi.ToString();
            if (icraDosyaSayisi == 0 && davaDosyaSayisi == 0)
                cgIcraDosyasi.Value = 0;
            else
                cgIcraDosyasi.Value = (icraDosyaSayisi * 100) / (icraDosyaSayisi + davaDosyaSayisi);

            string sqlLehdeDosya = "select * from tblDosyalar where leyhdeAleyhde='Lehde' and avukatAdi='" + cbxAvukatSec.Text + "'";
            string sqlAleyhdeDosya = "select * from tblDosyalar where leyhdeAleyhde='Aleyhde' and avukatAdi='" + cbxAvukatSec.Text + "'";
            int lehdeDosyaSayisi = dp.get_Data(sqlLehdeDosya).Rows.Count;
            int aleyhdeDosyaSayisi = dp.get_Data(sqlAleyhdeDosya).Rows.Count;
            lblLehdeDosyaSayisi.Text = lehdeDosyaSayisi.ToString();
            lblAleyhdeDosyaSayisi.Text = aleyhdeDosyaSayisi.ToString();
            if (lehdeDosyaSayisi == 0 && aleyhdeDosyaSayisi == 0)
                cgLehdeDosyaSayisi.Value = 0;
            else
                cgLehdeDosyaSayisi.Value = (lehdeDosyaSayisi * 100) / (lehdeDosyaSayisi + aleyhdeDosyaSayisi);
        }

        private void cgAcikDosyalar_Click(object sender, EventArgs e)
        {
            frmIstatistikDetay frm = new frmIstatistikDetay();
            frm.Show();
        }
    }
}
