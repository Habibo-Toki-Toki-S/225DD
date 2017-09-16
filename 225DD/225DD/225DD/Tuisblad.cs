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
            dataToolStripMenuItem.Visible = false;
            OleDbDataAdapter adapt = new OleDbDataAdapter(@"SELECT * FROM Login WHERE Admin = Yes AND userName = '" + username + "'", conn);
            DataTable ds = new DataTable();
            adapt.Fill(ds);
            if (ds.Rows.Count == 1)
            {
                adminToolStripMenuItem.Visible = true;
                dataToolStripMenuItem.Visible = true;
            }

            lblHeading.Visible = false;
            lblSearch.Visible = false;
            cmbVerslae.Visible = false;
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

        private void klienteVerslagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            query(@"SELECT K.Klient_ID, P.Naam, P.Van, P.Adres, P.Telefoon_Nommer, P.Kerkverband, Ge.Geslag, G.Grootte_Size, K.Geboorte_datum, K.Email
                  FROM (((Persoon AS P
                  LEFT JOIN  Geslag AS Ge
                  ON P.Geslag_ID = Ge.Geslag_ID)
                  LEFT JOIN  Klient AS K 
                  ON P.Persoon_ID = K.Persoon_ID )
                  LEFT JOIN  Grootte AS G
                  ON K.Klere_Grootte_ID = G.Grootte_ID)
                  WHERE K.Klient_ID IS NOT NULL;");

            lblHeading.Visible = true;
            lblHeading.Text = "Kliënte Verslag";

        }

        private void verslagToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            //query(@"SELECT Grootte_Size FROM Grootte");
            query(@"SELECT K.Kledingstuk_ID, K.Beskrywing, T.Tipe_Kledingstuk,G.Grootte_Size, Ge.Geslag
                  FROM (((Kledingstuk AS K
                  INNER JOIN  Tipe_Kledingstuk AS T
                  ON K.Tipe_Kledingstuk_ID = T.Tipe_Kledingstuk_ID)
                  INNER JOIN  Grootte AS G
                  ON K.Grootte_ID = G.Grootte_ID)
                  INNER JOIN  Geslag AS Ge
                  ON K.Geslag_ID = Ge.Geslag_ID);");
            lblHeading.Visible = true;
            lblHeading.Text = "Klere Verslag";
            lblSearch.Visible = true;
            cmbVerslae.Visible = true;
        }

        public void query(string sql)      //Check hier, n method om enige query te doen
        {
            OleDbDataAdapter adapt = new OleDbDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            //adapt.Fill(ds);
            dataGridViewHoof.Visible = true;
            dataGridViewHoof.DataSource = ds.Tables;
            conn.Close();
        }

        private void verslagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            query(@"SELECT * FROM Kombers");
            lblHeading.Visible = true;
            lblHeading.Text = "Komberse Verslag";
        }

        private void verslagToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            query(@"SELECT * FROM Kontant_Donasies");
            lblHeading.Visible = true;
            lblHeading.Text = "Kontant en Aankope Verslag";
        }

        private void gebruikersVerslagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            query(@"SELECT P.Naam, P.Van, P.Adres, P.Telefoon_Nommer, P.Kerkverband, L.Username, L.Admin 
                    FROM Persoon P
                    INNER JOIN Login L
                    ON P.Persoon_ID = L.Persoon_ID;");
            lblHeading.Visible = true;
            lblHeading.Text = "Gebruikers Verslag";
        }

        private void raportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridViewHoof.Hide();
            lblHeading.Visible = false;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void opToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Opdateer opD = new Opdateer(conn);
            opD.Show();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
