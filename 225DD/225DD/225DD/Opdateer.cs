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
    public partial class Opdateer : Form
    {
        OleDbConnection conn;
        string soek = "";
        string id = "";

        public Opdateer(OleDbConnection con)
        {
            InitializeComponent();
            conn = con;
        }

        public void query(string sql)
        {
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=  " + IntekenForm.spath);
            conn.Open();
            OleDbDataAdapter adapt = new OleDbDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            dataGridViewAlles.Visible = true;
            dataGridViewAlles.DataSource = ds.Tables[0];
            conn.Close();
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
        }

        private void rbGeslag_CheckedChanged(object sender, EventArgs e)
        {
            query("Select * from Geslag");

            lblSoek.Text = "Geslag_ID:";
            lbl1.Text = "Geslag:";

            int Geslag_ID = Convert.ToInt32(txtSoek.Text);
            String Geslag = txt1.Text;

            lbl1.Visible = true;
            lbl2.Visible = false;
            lbl3.Visible = false;
            lbl4.Visible = false;
            lbl5.Visible = false;
            lbl6.Visible = false;
            lbl7.Visible = false;

            txt1.Visible = true;
            txt2.Visible = false;
            txt3.Visible = false;
            txt4.Visible = false;
            txt5.Visible = false;
            txt6.Visible = false;
            txt7.Visible = false;
        }

        private void rbAankope_CheckedChanged(object sender, EventArgs e)
        {
            query("Select * from Aankope");

            lblSoek.Text = "Aankoop ID:";
            lbl1.Text = "Bedrag:";
            lbl2.Text = "Gebruiker:";
            lbl3.Text = "Kledingstuk ID:";

            int Aankoop_ID = Convert.ToInt32(txtSoek.Text);
            int Bedrag = Convert.ToInt32(txt1.Text);
            int User_Id = Convert.ToInt32(txt2.Text);
            int Kledingstuk_ID = Convert.ToInt32(txt3.Text);

            lbl1.Visible = true;
            lbl2.Visible = true;
            lbl3.Visible = true;
            lbl4.Visible = false;
            lbl5.Visible = false;
            lbl6.Visible = false;
            lbl7.Visible = false;

            txt1.Visible = true;
            txt2.Visible = true;
            txt3.Visible = true;
            txt4.Visible = false;
            txt5.Visible = false;
            txt6.Visible = false;
            txt7.Visible = false;
        }

        private void rbGroottes_CheckedChanged(object sender, EventArgs e)
        {
            query("Select * from Grootte_ID");

            lblSoek.Text = "Groottes:";
            lbl1.Text = "Groottes:";

            int Grootte_ID = Convert.ToInt32(txtSoek.Text);
            String Grootte_Size = txt1.Text;

            lbl1.Visible = true;
            lbl2.Visible = false;
            lbl3.Visible = false;
            lbl4.Visible = false;
            lbl5.Visible = false;
            lbl6.Visible = false;
            lbl7.Visible = false;

            txt1.Visible = true;
            txt2.Visible = false;
            txt3.Visible = false;
            txt4.Visible = false;
            txt5.Visible = false;
            txt6.Visible = false;
            txt7.Visible = false;
        }

        private void rbKledingstukke_CheckedChanged(object sender, EventArgs e)
        {
            query("Select * from Kledingstuk");

            lblSoek.Text = "Kledingstuk ID:";
            lbl1.Text = "Tipe Kledingstuk:";
            lbl2.Text = "Grootte:";
            lbl3.Text = "Geslag";
            lbl4.Text = "Beskrywing";

            int Kledingstuk_ID = Convert.ToInt32(txtSoek.Text);
            int Tipe_Kledingstuk_ID = Convert.ToInt32(txt1.Text);
            int Grootte_ID = Convert.ToInt32(txt2.Text);
            int Geslag_ID = Convert.ToInt32(txt3.Text);
            String Beskrywing = txt4.Text;

            lbl1.Visible = true;
            lbl2.Visible = true;
            lbl3.Visible = true;
            lbl4.Visible = true;
            lbl5.Visible = false;
            lbl6.Visible = false;
            lbl7.Visible = false;

            txt1.Visible = true;
            txt2.Visible = true;
            txt3.Visible = true;
            txt4.Visible = true;
            txt5.Visible = false;
            txt6.Visible = false;
            txt7.Visible = false;
        }

        private void rbK_Transaksies_CheckedChanged(object sender, EventArgs e)
        {
            query("Select * from Kledingstuk_Transaksie");

            lblSoek.Text = "Kledingstuk Transaksie_ID:";
            lbl1.Text = "Datum In:";
            lbl2.Text = "Kledingstuk ID:";
            lbl3.Text = "Datum Uit:";
            lbl4.Text = "Gebruiker:";
            lbl5.Text = "Kliënt:";

            int Kledingstuk_Transaksie_ID = Convert.ToInt32(txtSoek.Text);
            String Datum_In = txt1.Text;
            int Kledingstuk_ID = Convert.ToInt32(txt2.Text);
            String Datum_Uit = txt3.Text ;
            int User_ID = Convert.ToInt32(txt4.Text);
            int Klient_ID = Convert.ToInt32(txt5.Text);

            lbl1.Visible = true;
            lbl2.Visible = true;
            lbl3.Visible = true;
            lbl4.Visible = true;
            lbl5.Visible = true;
            lbl6.Visible = false;
            lbl7.Visible = false;

            txt1.Visible = true;
            txt2.Visible = true;
            txt3.Visible = true;
            txt4.Visible = true;
            txt5.Visible = true;
            txt6.Visible = false;
            txt7.Visible = false;
        }

        private void rbKomberse_CheckedChanged(object sender, EventArgs e)
        {
            query("Select * from Kombers");

            lblSoek.Text = "Kombers ID:";
            lbl1.Text = "Beskrywing";

            lbl1.Visible = true;
            lbl2.Visible = false;
            lbl3.Visible = false;
            lbl4.Visible = false;
            lbl5.Visible = false;
            lbl6.Visible = false;
            lbl7.Visible = false;

            txt1.Visible = true;
            txt2.Visible = false;
            txt3.Visible = false;
            txt4.Visible = false;
            txt5.Visible = false;
            txt6.Visible = false;
            txt7.Visible = false;
        }

        private void rbKombers_Trans_CheckedChanged(object sender, EventArgs e)
        {
            query("Select * from Kombers_transaksie");

            lblSoek.Text = "Kombers Transaksie_ID:";
            lbl1.Text = "Datum In:";
            lbl2.Text = "Kombers ID:";
            lbl3.Text = "Datum Uit:";
            lbl4.Text = "Gebruiker:";
            lbl5.Text = "Kliënt:";

            lbl1.Visible = true;
            lbl2.Visible = true;
            lbl3.Visible = true;
            lbl4.Visible = true;
            lbl5.Visible = true;
            lbl6.Visible = false;
            lbl7.Visible = false;

            txt1.Visible = true;
            txt2.Visible = true;
            txt3.Visible = true;
            txt4.Visible = true;
            txt5.Visible = true;
            txt6.Visible = false;
            txt7.Visible = false;
        }

        private void rbKontantDonasies_CheckedChanged(object sender, EventArgs e)
        {
            query("Select * from Kontant_donasies");

            lblSoek.Text = "Kontant Donasies_ID:";
            lbl1.Text = "Naam:";
            lbl2.Text = "Van:";
            lbl3.Text = "Bedrag:";
            lbl4.Text = "Gebruiker";

            int Kontant_ID = Convert.ToInt32(txtSoek.Text);
            String Naam = txt1.Text;
            String Van = txt2.Text;
            int Bedrag = Convert.ToInt32(txt3.Text);
            int User_ID = Convert.ToInt32(txt4.Text);

            lbl1.Visible = true;
            lbl2.Visible = true;
            lbl3.Visible = true;
            lbl4.Visible = true;
            lbl5.Visible = false;
            lbl6.Visible = false;
            lbl7.Visible = false;

            txt1.Visible = true;
            txt2.Visible = true;
            txt3.Visible = true;
            txt4.Visible = true;
            txt5.Visible = false;
            txt6.Visible = false;
            txt7.Visible = false;
        }

        private void rbLogin_CheckedChanged(object sender, EventArgs e)
        {
            query("Select * from Login");

            lblSoek.Text = "Aanteken ID:"; //HELP
            lbl1.Text = "Gebruiker:"; //HELP
            lbl2.Text = "Wagwoord:"; //HELP
            lbl3.Text = "Admin:"; //HELP
            lbl4.Text = "Persoon ID:"; //HELP

            int User_ID = Convert.ToInt32(txtSoek.Text);
            String Username = txt1.Text;
            String Password = txt2.Text;
            //Boolean Admin = txt3.Text;
            int Persoon_ID = Convert.ToInt32(txt4.Text);

            lbl1.Visible = true;
            lbl2.Visible = true;
            lbl3.Visible = true;
            lbl4.Visible = true;
            lbl5.Visible = false;
            lbl6.Visible = false;
            lbl7.Visible = false;

            txt1.Visible = true;
            txt2.Visible = true;
            txt3.Visible = true;
            txt4.Visible = true;
            txt5.Visible = false;
            txt6.Visible = false;
            txt7.Visible = false;
        }

        private void rbPersoon_CheckedChanged(object sender, EventArgs e)
        {
            query("Select * from Persoon");

            lblSoek.Text = "Persoon ID:";
            lbl1.Text = "Naam:";
            lbl2.Text = "Van:";
            lbl3.Text = "Adres";
            lbl4.Text = "Telefoon Nr:";
            lbl5.Text = "Kerkverband:";
            lbl6.Text = "Geslag:";

            int Persoon_ID = Convert.ToInt32(txtSoek.Text);
            String Naam = txt1.Text;
            String Van = txt2.Text;
            String Adres = txt3.Text;
            int Telefoon_Nommer = Convert.ToInt32(txt4.Text);
            String KerkVerband = txt5.Text;
            int Geslag_ID = Convert.ToInt32(txt6.Text);

            lbl1.Visible = true;
            lbl2.Visible = true;
            lbl3.Visible = true;
            lbl4.Visible = true;
            lbl5.Visible = true;
            lbl6.Visible = true;
            lbl7.Visible = false;

            txt1.Visible = true;
            txt2.Visible = true;
            txt3.Visible = true;
            txt4.Visible = true;
            txt5.Visible = true;
            txt6.Visible = true;
            txt7.Visible = false;
        }

        private void rbKliente_CheckedChanged(object sender, EventArgs e)
        {
            query("Select * from Klient");

            lblSoek.Text = "Kliënte ID:";
            lbl1.Text = "Kleding Grootte:";
            lbl2.Text = "Ouderdom";
            lbl3.Text = "Persoon ID:";
            lbl4.Text = "Epos Adress";

            int Klient_ID = Convert.ToInt32(txtSoek.Text);
            int Klere_Grootte_ID = Convert.ToInt32(txt1.Text);
            String Geboorte_Datum = txt2.Text;
            int Persoon_ID = Convert.ToInt32(txt3.Text);
            String Email = txt4.Text;

            lbl1.Visible = true;
            lbl2.Visible = true;
            lbl3.Visible = true;
            lbl4.Visible = true;
            lbl5.Visible = false;
            lbl6.Visible = false;
            lbl7.Visible = false;

            txt1.Visible = true;
            txt2.Visible = true;
            txt3.Visible = true;
            txt4.Visible = true;
            txt5.Visible = false;
            txt6.Visible = false;
            txt7.Visible = false;
        }

        private void rbTipeKledingstuk_CheckedChanged(object sender, EventArgs e)
        {
            query("Select * from Tipe_Kledingstuk");

            lblSoek.Text = "Tipe Kledingstuk_ID:";
            lbl1.Text = "Tipe Kledingstuk";

            int Tipe_Kledingstuk_ID = Convert.ToInt32(txtSoek.Text);
            String Tipe_Kledingstuk = txt1.Text;

            lbl1.Visible = true;
            lbl2.Visible = false;
            lbl3.Visible = false;
            lbl4.Visible = false;
            lbl5.Visible = false;
            lbl6.Visible = false;
            lbl7.Visible = false;

            txt1.Visible = true;
            txt2.Visible = false;
            txt3.Visible = false;
            txt4.Visible = false;
            txt5.Visible = false;
            txt6.Visible = false;
            txt7.Visible = false;
        }

        private void btnSoek_Click(object sender, EventArgs e)
        {
            if (rbAankope.Checked)
            {
                soek = "Aankope";
                id = "Aankoop_ID";
            }
            else if (rbGeslag.Checked)
            {
                soek = "Geslag";
                id = "Geslag_ID";
            }
            else if (rbGroottes.Checked)
            {
                soek = "Grootte";
                id = "Grootte_Size";
            }
            else if (rbKledingstukke.Checked)
            {
                soek = "Kledingstuk";
                id = "Kledingstuk_ID";
            }
            else if (rbK_Transaksies.Checked)
            {
                soek = "Kledingstuk_Transaksie";
                id = "Kledingstuk_Transaksie_ID";
            }
            else if (rbKontantDonasies.Checked)
            {
                soek = "Kontant_Donasies";
                id = "Kontant_Donasies_ID";
            }
            else if (rbLogin.Checked)
            {
                soek = "Login";
                id = "Username";
            }
            else if (rbPersoon.Checked)
            {
                soek = "Persoon";
                id = "Persoon_ID";
            }
            else if (rbKliente.Checked)
            {
                soek = "Klient";
                id = "Klient_ID";
            }
            else if (rbTipeKledingstuk.Checked)
            {
                soek = "Tipe_Kledingstuk";
                id = "Tipe_Kledingstuk_ID";
            }
            else
                MessageBox.Show("Probeer weer");

            query(@"SELECT * FROM " + soek + " WHERE " + id + " = " + txtSoek.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtSoek.Text = "";
            dataGridViewAlles.DataBindings.Clear();
        }

        private void btnKanseleer_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (rbAankope.Checked)
            {
                soek = "Aankope";
                id = "Aankoop_ID";
            }
            else if (rbGeslag.Checked)
            {
                soek = "Geslag";
                id = "Geslag_ID";
            }
            else if (rbGroottes.Checked)
            {
                soek = "Grootte";
                id = "Grootte_Size";
            }
            else if (rbKledingstukke.Checked)
            {
                soek = "Kledingstuk";
                id = "Kledingstuk_ID";
            }
            else if (rbK_Transaksies.Checked)
            {
                soek = "Kledingstuk_Transaksie";
                id = "Kledingstuk_Transaksie_ID";
            }
            else if (rbKontantDonasies.Checked)
            {
                soek = "Kontant_Donasies";
                id = "Kontant_Donasies_ID";
            }
            else if (rbLogin.Checked)
            {
                soek = "Login";
                id = "Username";
            }
            else if (rbPersoon.Checked)
            {
                soek = "Persoon";
                id = "Persoon_ID";
            }
            else if (rbKliente.Checked)
            {
                soek = "Klient";
                id = "Klient_ID";
            }
            else if (rbTipeKledingstuk.Checked)
            {
                soek = "Tipe_Kledingstuk";
                id = "Tipe_Kledingstuk_ID";
            }
            else
                MessageBox.Show("Probeer weer");

            insert(@"Delete FROM " + soek + " WHERE " + id + " = " + txtSoek.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnAanvaar_Click(object sender, EventArgs e)
        {
            if (soek == "Aankope")
            {
                //insert(@"INSERT INTO " + soek + " ([],[],[],[]) Values " + id + " = " + txtSoek.Text);
            }
            else if (soek == "Aankope")
            {

            }

                insert(@"INSERT INTO "+ soek + "  " + soek + " WHERE " + id + " = " + txtSoek.Text);
        }
    }
    
}
