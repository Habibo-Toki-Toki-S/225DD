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
    public partial class Tuisblad : Form
    {
        string username;
        OleDbConnection conn;

        public Tuisblad(OleDbConnection con, string user)
        {
            InitializeComponent();
            username = user;
            conn = con;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void invorderToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void nuweKlientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nuwe_Klient nuwe_klient = new Nuwe_Klient();
            nuwe_klient.Show();
        }

        private void invorderToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Kledingstukke_invorder kleding_IN = new Kledingstukke_invorder();
            kleding_IN.Show();
        }

        private void Tuisblad_Load(object sender, EventArgs e)
        {
            adminToolStripMenuItem.Visible = false;
            OleDbDataAdapter adapt = new OleDbDataAdapter(@"SELECT * FROM Login WHERE Admin = Yes AND userName = '" + username + "'", conn);
            DataTable ds = new DataTable();
            adapt.Fill(ds);
            if (ds.Rows.Count == 1)
                adminToolStripMenuItem.Visible = true;
        }

        private void verwyderKlientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Verwyder_Klient v_k = new Verwyder_Klient();
            v_k.Show();
        }

        private void uitgeeToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Kledingstuk_Uit kleding_Uit = new Kledingstuk_Uit();
            kleding_Uit.Show();
        }

        private void nuweGebruikerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nuwe_Gebruiker n_Gebruiker = new Nuwe_Gebruiker();
            n_Gebruiker.Show();
        }

        private void verwyderGebruikerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Verwyder_Gebruiker v_Gebruiker = new Verwyder_Gebruiker();
            v_Gebruiker.Show();
        }

        private void kombersInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kombers_In kombers_IN = new Kombers_In();
            kombers_IN.Show();
        }

        private void kombersUitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kombers_Uit kombers_UIT = new Kombers_Uit();
            kombers_UIT.Show();
        }

        private void invorderToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Kontant_In kontant_IN = new Kontant_In();
            kontant_IN.Show();
        }

        private void aankopeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Kontant_Aankope kontant_Aankope = new Kontant_Aankope();
            kontant_Aankope.Show();
        }
    }
}
