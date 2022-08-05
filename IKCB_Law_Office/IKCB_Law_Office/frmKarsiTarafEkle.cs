using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IKCB_Law_Office
{
    public partial class frmKarsiTarafEkle : Form
    {
        public frmKarsiTarafEkle()
        {
            InitializeComponent();
        }

        private void frmKarsiTarafEkle_Load(object sender, EventArgs e)
        {
           
        }

        private void pcbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pcbMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnKarsiTarafEkle_Click(object sender, EventArgs e)
        {
            string adSoyad = txtAdSoyad.Text;
            string kimlikNo = txtTcNo.Text;
            string vergiNo = txtVergiNo.Text;
            string sicilNo = txtSicilNo.Text;
            string cinsiyet = cbxCinsiyet.Text;
            string telNo = txtTelefonNo.Text;
            string eposta = txtEposta.Text;
            string adres = txtAdres.Text;
            DatabaseProcess dp = new DatabaseProcess();

            if (txtAdres.Text == "" || txtAdSoyad.Text == "" || txtEposta.Text == "" || txtSicilNo.Text == "" || txtTcNo.Text == "" || txtTelefonNo.Text == "" || txtVergiNo.Text == "")
            {
                string message = "Tüm Alanların Doldurulduğundan Emin Olun.";
                frmMessagebox frm = new frmMessagebox();
                frmMessagebox.Message = message;
                frm.Show();
            }
            else
            {
                try
                {
                    string sqlSentence = "insert into tblKarsiTaraf (karsiTarafAdSoyad,karsiTarafKimlikNo,karsiTarafVergiNo,karsiTarafSicilNo,karsiTarafCinsiyet,karsiTarafTelefonNo,karsiTarafEposta,karsiTarafAdres) values ('" + adSoyad + "','" + kimlikNo + "','" + vergiNo + "','" + sicilNo + "','" + cinsiyet + "','" + telNo + "','" + eposta + "','" + adres + "')";
                    dp.insert_update_delete(sqlSentence);
                    string message = "Karşı taraf başarlı bir şekilde eklendi";
                    frmMessagebox frm = new frmMessagebox();
                    frmMessagebox.Message = message;
                    txtAdres.Text = "";
                    txtAdSoyad.Text = "";
                    txtEposta.Text = "";
                    txtSicilNo.Text = "";
                    txtTcNo.Text = "";
                    txtTelefonNo.Text = "";
                    txtVergiNo.Text = "";

                    frm.Show();
                }
                catch (Exception ex)
                {
                    string message = ex.Message;
                    frmMessagebox frm = new frmMessagebox();
                    frmMessagebox.Message = message;
                    frm.Show();
                }
            }
        }
    }
}
