using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IKCB_Law_Office
{
    public partial class frmYeniMuvekkilEkle : Form
    {
        public frmYeniMuvekkilEkle()
        {
            InitializeComponent();
        }

        private void pcbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pcbMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMuvekkilEkle_Click(object sender, EventArgs e)
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
                txtAdres.Text = "";
                txtAdSoyad.Text = "";
                txtEposta.Text = "";
                txtSicilNo.Text = "";
                txtTcNo.Text = "";
                txtTelefonNo.Text = "";
                txtVergiNo.Text = "";
                frm.Show();
            }
            else
            {
                try
                {
                    string sqlSentence = "insert into tblMuvekkiller (muvekkilAdSoyad,muvekkilKimlikNo,muvekkilVergiNo,muvekkilSicilNo,muvekkilCinsiyet,muvekkilTelefonNo,muvekkilEposta,muvekkilAdres) values ('" + adSoyad + "','" + kimlikNo + "','" + vergiNo + "','" + sicilNo + "','" + cinsiyet + "','" + telNo + "','" + eposta + "','" + adres + "')";
                    dp.insert_update_delete(sqlSentence);
                    string message = "Müvekkil başarlı bir şekilde eklendi";
                    frmMessagebox frm = new frmMessagebox();
                    frmMessagebox.Message = message;
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
