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
    public partial class Kontant_Aankope : Form
    {
        public Kontant_Aankope()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string gebruiker = lblGebruiker.Text;
            string kombersID = lblK_ID.Text;
            string datum = lblDatum.Text;
            string bedrag = txtGeld.Text;
            int Grootte_ID = comboBox2.SelectedIndex + 1;
            int Geslag_ID = comboBox3.SelectedIndex + 1;
            int Tipe_Kledingstuk_ID = comboBox1.SelectedIndex + 1;
            string beskrywing = txtBeskrywing.Text;

            /*insert("INSERT INTO Kledingstuk ([Tipe_Kledingstuk_ID],[Grootte_ID],[Geslag_ID],[Beskrywing]) values (" + Tipe_Kledingstuk_ID + "," + Grootte_ID + "," + Geslag_ID + ",'" + Beskrywing + "') ");
            insert("INSERT INTO Kledingstuk_Transaksie ([Datum_In],[Kledingstuk_ID]) values ('" + DateTime.Now + "'," + iKledingstuk_ID + ")");*/
            MessageBox.Show("Kontant aankope suksesvol by gevoeg");

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
    }
}
