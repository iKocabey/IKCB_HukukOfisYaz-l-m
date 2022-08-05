using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IKCB_Law_Office
{
    public partial class frmDosyalar : Form
    {
        public frmDosyalar()
        {
            InitializeComponent();
        }
        void eskiKonum()
        {
            panel2.Location = new Point(3, 195);
            panel3.Location = new Point(3, 238);
            panel7.Location = new Point(3, 282);
            btnDosyalarim.Location = new Point(8, 195);
            btnVekaletler.Location = new Point(8, 238);
            btnDosyalarIctihatlar.Location = new Point(8, 282);
        }
        void yenikonum()
        {
            panel2.Location = new Point(3, 322);
            panel3.Location = new Point(3, 364);
            panel7.Location = new Point(3, 408);
            btnDosyalarim.Location = new Point(8, 322);
            btnVekaletler.Location = new Point(8, 364);
            btnDosyalarIctihatlar.Location = new Point(8, 408);
        }
        DatabaseProcess dp = new DatabaseProcess();
        private void pcbGeriDon_Click(object sender, EventArgs e)
        {
            frmMainPage frm = new frmMainPage();
            this.Hide();
            frm.Show();
        }

        private void pcbMax_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void pcbMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pcbClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void btnDavaDosyasi_Click(object sender, EventArgs e)
        {
            frmDavaDosyasi frm = new frmDavaDosyasi();
            this.Hide();
            frm.Show();
        }
        
        private void frmDosyalar_Load(object sender, EventArgs e)
        {
            pnlYeniDosya.Visible = false;
            string sqlSentence = "select * from tblDosyalar";
            dp.fillGridView(dgvDosyalar, sqlSentence);

            string sqlSentence1 = "select * from tblPersonel";
            dp.fillCombo(cbxAvukatAdi, sqlSentence1,1);

            string sqlSentence2 = "select * from tblMuvekkiller";
            dp.fillCombo(cbxMuvekkilAdi, sqlSentence2, 1);

            string sqlSentence3 = "select * from tblKarsiTaraf";
            dp.fillCombo(cbxKarsiTarafAdi, sqlSentence3, 1);
        }

        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void cbxMuvekkilAdi_TextChanged(object sender, EventArgs e)
        {
            dgvDosyalar.DataSource = "";
            string sqlSentence = "select * from tblDosyalar where muvekkilAdi = '" + cbxMuvekkilAdi.Text + "'";
            dp.fillGridView(dgvDosyalar, sqlSentence);
            cbxAvukatAdi.Text = ""; cbxKarsiTarafAdi.Text = ""; txtKlasorNo.Text = ""; txtDosyaNo.Text = "";
        }
        private void cbxAvukatAdi_TextChanged(object sender, EventArgs e)
        {
            dgvDosyalar.DataSource = "";
            string sqlSentence = "select * from tblDosyalar where avukatAdi='" + cbxAvukatAdi.Text + "'";
            dp.fillGridView(dgvDosyalar, sqlSentence);
            cbxMuvekkilAdi.Text = ""; cbxKarsiTarafAdi.Text = ""; txtKlasorNo.Text = ""; txtDosyaNo.Text = "";
        }

        private void cbxKarsiTarafAdi_TextChanged(object sender, EventArgs e)
        {
            dgvDosyalar.DataSource = "";
            string sqlSentence = "select * from tblDosyalar where karsiTarafAdi='" + cbxKarsiTarafAdi + "'";
            dp.fillGridView(dgvDosyalar, sqlSentence);
            cbxAvukatAdi.Text = ""; cbxMuvekkilAdi.Text = ""; txtKlasorNo.Text = ""; txtDosyaNo.Text = "";
        }

        private void txtKlasorNo_TextChanged(object sender, EventArgs e)
        {
            dgvDosyalar.DataSource = "";
            string sqlSentence = "select * from tblDosyalar where klasorNo='" + txtKlasorNo.Text + "'";
            dp.fillGridView(dgvDosyalar, sqlSentence);
            cbxAvukatAdi.Text = ""; cbxMuvekkilAdi.Text = ""; cbxKarsiTarafAdi.Text = ""; txtDosyaNo.Text = "";
        }

        private void lnklblTemizle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dgvDosyalar.DataSource = "";
            cbxAvukatAdi.Text = "";
            cbxKarsiTarafAdi.Text = "";
            cbxMuvekkilAdi.Text = "";
            txtDosyaNo.Text = "";
            txtKlasorNo.Text = "";
            string sqlSentence = "select * from tblDosyalar";
            dp.fillGridView(dgvDosyalar, sqlSentence);
        }

        private void txtDosyaNo_TextChanged(object sender, EventArgs e)
        {
            dgvDosyalar.DataSource = "";
            string sqlSentence = "select * from tblDosyalar where dosyaNo='" + txtDosyaNo.Text + "'";
            dp.fillGridView(dgvDosyalar, sqlSentence);
            cbxAvukatAdi.Text = ""; cbxMuvekkilAdi.Text = ""; cbxKarsiTarafAdi.Text = ""; txtKlasorNo.Text = "";
        }

        private void dgvDosyalar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvDosyalar.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dgvDosyalar.CurrentRow.Selected = true;
                    frmDosyaIcerikleri.dosyaId = dgvDosyalar.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                    frmDosyaIcerikleri.dosyaTuru = dgvDosyalar.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                    frmDosyaIcerikleri.muvekkilAdi = dgvDosyalar.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                    frmDosyaIcerikleri.KarsiTarafAdi = dgvDosyalar.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
                    frmDosyaIcerikleri.davaVeyaTakipTuru = dgvDosyalar.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
                    frmDosyaIcerikleri.mahkemeTuru = dgvDosyalar.Rows[e.RowIndex].Cells[5].FormattedValue.ToString();
                    frmDosyaIcerikleri.mahkemeTurAltKirilim = dgvDosyalar.Rows[e.RowIndex].Cells[6].FormattedValue.ToString();
                    frmDosyaIcerikleri.lehdeAleyhde = dgvDosyalar.Rows[e.RowIndex].Cells[7].FormattedValue.ToString();
                    frmDosyaIcerikleri.tarafimiz = dgvDosyalar.Rows[e.RowIndex].Cells[8].FormattedValue.ToString();
                    frmDosyaIcerikleri.klasorNo = dgvDosyalar.Rows[e.RowIndex].Cells[9].FormattedValue.ToString();
                    frmDosyaIcerikleri.dosyaNo = dgvDosyalar.Rows[e.RowIndex].Cells[10].FormattedValue.ToString();
                    frmDosyaIcerikleri.mahkemeVeyaDaire = dgvDosyalar.Rows[e.RowIndex].Cells[11].FormattedValue.ToString();
                    frmDosyaIcerikleri.davaVeyaIcraKonusu = dgvDosyalar.Rows[e.RowIndex].Cells[12].FormattedValue.ToString();
                    frmDosyaIcerikleri.davaAcmaTarihi = dgvDosyalar.Rows[e.RowIndex].Cells[13].FormattedValue.ToString();
                    frmDosyaIcerikleri.isKabulTarihi = dgvDosyalar.Rows[e.RowIndex].Cells[14].FormattedValue.ToString();
                    frmDosyaIcerikleri.avukatAdi = dgvDosyalar.Rows[e.RowIndex].Cells[15].FormattedValue.ToString();
                    frmDosyaIcerikleri.esas = dgvDosyalar.Rows[e.RowIndex].Cells[16].FormattedValue.ToString();
                    frmDosyaIcerikleri.dosyaDurum = dgvDosyalar.Rows[e.RowIndex].Cells[18].FormattedValue.ToString();
                    frmDosyaIcerikleri frm = new frmDosyaIcerikleri();
                    this.Hide();
                    frm.Show();
                }
            }
            catch (Exception)
            {
                string message = "Başlık satırını seçemezsiniz";
                frmMessagebox.Message = message;
                frmMessagebox frm = new frmMessagebox();
                frm.Show();
            }
        }

        private void kazanıldıToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //Kodları yazmaya buradan devam edeceğiz.
            string dosyaId = dgvDosyalar.SelectedRows[0].Cells[0].FormattedValue.ToString();
            MessageBox.Show(dosyaId);
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

        private void kaybedildiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string dosyaId = dgvDosyalar.SelectedRows[0].Cells[0].FormattedValue.ToString();
            MessageBox.Show(dosyaId);
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
    }
}
