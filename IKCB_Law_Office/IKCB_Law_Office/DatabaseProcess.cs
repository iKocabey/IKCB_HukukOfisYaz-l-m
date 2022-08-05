using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace IKCB_Law_Office
{

    class DatabaseProcess
    {
        SqlConnection conSentences = new SqlConnection("Data Source = IKOCABEY\\SQLEXPRESS;Initial Catalog = IKCBHukukBuro; Integrated Security = True");

        public DataTable get_Data(string sqlSentence)
        {
            if (conSentences.State != ConnectionState.Open)
                conSentences.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlSentence, conSentences);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conSentences.Close();
            return dt;
            
        }
        public bool kontrolEt(string sqlSentence, TextBox txt)
        {
            for (int i = 0; i < get_Data(sqlSentence).Rows.Count; i++)
            {
                if (get_Data(sqlSentence).Rows[i][0].ToString() == txt.Text)
                {
                    return false;
                    break;
                }
            }
            return true;

        }
        public void insert_update_delete(string sqlSentence)
        {
            SqlCommand cmd = new SqlCommand(sqlSentence, conSentences);
            conSentences.Open();
            cmd.ExecuteNonQuery();
            conSentences.Close();
        }
        public void fillCombo(ComboBox cbx,string sqlSentence,int i)
        {
            cbx.Items.Clear();
            SqlDataReader r;
            if (conSentences.State != ConnectionState.Open)
                conSentences.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conSentences;
            cmd.CommandText = sqlSentence;
            r = cmd.ExecuteReader();
            while (r.Read())
            {
                cbx.Items.Add(r[i].ToString());
            }
            r.Close();
            conSentences.Close();
        }
        public void fillListBox(ListBox lbx,string sqlSentence,int i)
        {
            lbx.Items.Clear();
            SqlDataReader r;
            if (conSentences.State != ConnectionState.Open)
                conSentences.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conSentences;
            cmd.CommandText = sqlSentence;
            r = cmd.ExecuteReader();
            while (r.Read())
            {
                lbx.Items.Add(r[i].ToString());
            }
            r.Close();
            conSentences.Close();
        }
        public void fillGridView(DataGridView dgv,string sqlSentence)
        {
            if (conSentences.State != ConnectionState.Open)
                conSentences.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlSentence, conSentences);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgv.DataSource = dt;
            conSentences.Close();
        }
    }
}
