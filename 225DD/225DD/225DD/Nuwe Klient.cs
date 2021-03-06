﻿using System;
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
            int tel;
            string kerk = txtKerk.Text;
            string adres = txtAdres.Text;
            int Grootte_ID = cbGrootte.SelectedIndex + 1;
            int Geslag_ID = cbGeslag.SelectedIndex + 1;
            DateTime geboorte = dateTimePicker1.Value;
            string email = txtEmail.Text;

            if (IsAllLetters(naam) == true)
            {
                if (IsAllLetters(van) == true)
                {
                    if (IsAllLetters(kerk) == true)
                    {
                        if (IsAllLetters(adres) == true)
                        {
                            if (int.TryParse(txtTel.Text, out tel))
                            {
                                insert("INSERT INTO Persoon ([Naam],[Van],[Adres],[Telefoon_Nommer],[Kerkverband],[Geslag_ID]) VALUES ('" + naam + "','" + van + "','" + adres + "'," + tel + ",'" + kerk + "'," + Geslag_ID + ")");
                                int Persoon_ID = readInt(0, "Select Persoon_ID FROM Persoon Where Persoon.Naam = '" + naam + "'");
                                insert("INSERT INTO Klient ([Klere_Grootte_ID],[Geboorte_datum],[Persoon_ID],[Email]) values (" + Grootte_ID + ",'" + geboorte + "'," + Persoon_ID + ",'" + email + "' )");
                                MessageBox.Show("Klient suskesvol bygevoeg!");
                            }
                            else
                            {
                                MessageBox.Show("Vul asb n nommer in vir Telefoon");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Slegs letters by adres asseblief");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Slegs letters by Kerk verband asseblief");
                    }
                }
                else
                {
                    MessageBox.Show("Slegs letters by Van asseblief");
                }
            }
            else
            {
                MessageBox.Show("Slegs letters by Naam asseblief");
            }
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

        public static bool IsAllLetters(string s)
        {
            foreach (char c in s)
            {
                if (!Char.IsLetter(c))
                    return false;
            }
            return true;
        }
    }
}
