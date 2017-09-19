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
    public partial class Verwyder_Klient : Form
    {
        public Verwyder_Klient()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Verwyder_Klient_Load(object sender, EventArgs e)
        {

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

        private void btnAanvaar_Click(object sender, EventArgs e)
        {


            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=  " + IntekenForm.spath);

            conn.Open();
            if (txtID.Text != "")
            {
                int Geb_ID;
                if (int.TryParse(txtID.Text, out Geb_ID))
                {
                    if (MessageBox.Show("Is u seker u wil hierdie klient verwyder: " + Geb_ID + "?", "Bevestig", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // user clicked yes
                        //OleDbCommand cmd = new OleDbCommand(@"DELETE FROM Klient WHERE Klient_ID = '" + Geb_ID + "'", conn);
                        insert("Delete from Klient WHERE Klient_ID = " + Geb_ID + "");
                        //int Persoon_ID = readInt(0, "Select Persoon_ID FROM Persoon Where Persoon.Naam = '" + naam + "'");
                        //OleDbCommand cmd1 = new OleDbCommand(@"DELETE FROM Klient WHERE Persoon_ID = '" + Geb_ID + "'", conn);
                        //////cmd.ExecuteNonQuery();
                        //cmd1.ExecuteNonQuery();
                        MessageBox.Show("Klient " + Geb_ID + " is verwyder!!");
                    }
                }
                else
                {
                    MessageBox.Show("Vul asb n nommer in");
                }
            }
            else
            {
                MessageBox.Show("Vul 'n klient naam in.");
            }
        }
    }
}
