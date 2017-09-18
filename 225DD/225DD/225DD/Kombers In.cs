using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace _225DD
{
    public partial class Kombers_In : Form
    {
        public Kombers_In()
        {
            InitializeComponent();
        }

        private void btnAanvaar_Click(object sender, EventArgs e)
        {
            string gebruiker = lblGebruiker.Text;
            string kombersID = lblK_ID.Text;
            string datum = lblDatum.Text;
            String Beskrywing = txtBeskrywing.Text;

            /*insert("INSERT INTO Kledingstuk ([Tipe_Kledingstuk_ID],[Grootte_ID],[Geslag_ID],[Beskrywing]) values (" + Tipe_Kledingstuk_ID + "," + Grootte_ID + "," + Geslag_ID + ",'" + Beskrywing + "') ");
            insert("INSERT INTO Kledingstuk_Transaksie ([Datum_In],[Kledingstuk_ID]) values ('" + DateTime.Now + "'," + iKledingstuk_ID + ")");
            MessageBox.Show("Kombers suksesvol in geteken");*/
        }
        public void insert(string sql)
        {
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=  " + IntekenForm.spath);
            conn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            conn.Close();
            this.Close();
        }

        private void btnKanseleer_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
