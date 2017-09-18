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
    public partial class Nuwe_Klient : Form
    {
        public Nuwe_Klient()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string naam = txtUsername.Text;
            string van = txtVan.Text;
            string tel = txtTel.Text;
            string kerk = txtKerk.Text;
            string adres = txtAdres.Text;
            int Grootte_ID = cbGrootte.SelectedIndex + 1;
            int Geslag_ID = cbGeslag.SelectedIndex + 1;
            string geboorte = dateTimePicker1.Text;

            insert("INSERT INTO Kledingstuk ([Tipe_Kledingstuk_ID],[Grootte_ID],[Geslag_ID],[Beskrywing]) values (" + Grootte_ID + "," + Grootte_ID + "," + Geslag_ID + ",'" + Grootte_ID + "') ");
            insert("INSERT INTO Kledingstuk_Transaksie ([Datum_In],[Kledingstuk_ID]) values ('" + DateTime.Now + "'," + Grootte_ID + ")");
            MessageBox.Show("Klient suskesvol by gevoeg!");
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

        private void Nuwe_Klient_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'kerkbankDataSet.Geslag' table. You can move, or remove it, as needed.
            this.geslagTableAdapter.Fill(this.kerkbankDataSet.Geslag);
            // TODO: This line of code loads data into the 'kerkbankDataSet.Grootte' table. You can move, or remove it, as needed.
            this.grootteTableAdapter.Fill(this.kerkbankDataSet.Grootte);

        }
    }
}
