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
    public partial class Nuwe_Gebruiker : Form
    {
        public Nuwe_Gebruiker()
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
            int tel = Convert.ToInt32(txtTel.Text);
            string kerk = txtKerk.Text;
            string adres = txtAdres.Text;
            String username = textBox1.Text;
            String password = textBox2.Text;


            bool admin;

            if (radioButton1.Checked == true)
            {
                admin = true;
            }
            else
            {
                admin = false;
            }

            insert("INSERT INTO Persoon ([Naam],[Van],[Adres],[Telefoon_Nommer],[Kerkverband]) VALUES ('" + naam + "','" + van + "','" + adres + "'," + tel + ",'" + kerk + "')");
            int Persoon_ID = readInt(0, "Select Persoon_ID FROM Persoon Where Persoon.Naam = '" + naam + "'");
            insert("INSERT INTO LOGIN ([Username],[Password],[Admin],[Persoon_ID]) values ('" + username + "','" + password + "','" + admin + "'," + Persoon_ID + " )");
            MessageBox.Show("Gebruiker suskesvol bygevoeg!");
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
    }
}
