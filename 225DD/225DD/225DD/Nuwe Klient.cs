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

        public int readInt(int kol, string sql)
        {
            int result = 0;
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=  " + IntekenForm.spath);
            conn.Open();
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            OleDbDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                result = Convert.ToInt32(reader.GetValue(kol));
            }

            return result;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string naam = txtUsername.Text;
            string van = txtVan.Text;
            int tel = Convert.ToInt32(txtTel.Text);
            string kerk = txtKerk.Text;
            string adres = txtAdres.Text;
            int Grootte_ID = cbGrootte.SelectedIndex + 1;
            int Geslag_ID = cbGeslag.SelectedIndex + 1;
            DateTime geboorte = dateTimePicker1.Value;
            string email = txtEmail.Text;

            insert("INSERT INTO Persoon ([Naam],[Van],[Adres],[Telefoon_Nommer],[Kerkverband],[Geslag_ID]) VALUES ('" + naam + "','" + van + "','" + adres + "'," + tel + ",'" + kerk + "'," + Geslag_ID + ")");
            int Persoon_ID = readInt(0, "Select Persoon_ID FROM Persoon Where Persoon.Naam = '" + naam + "'");

            
            label9.Text = Convert.ToString(Persoon_ID);
            insert("INSERT INTO Klient ([Klere_Grootte_ID],[Geboorte_datum],[Persoon_ID],[Email]) values (" + Grootte_ID +  ",'" + geboorte + "'," + Persoon_ID + ",'" + email  + "' )");
            MessageBox.Show("Klient suskesvol bygevoeg!");
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
