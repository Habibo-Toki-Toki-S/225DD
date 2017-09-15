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

        private void rbGeslag_CheckedChanged(object sender, EventArgs e)
        {
            lblSoek.Text = "Geslag:";
        }

        private void rbAankope_CheckedChanged(object sender, EventArgs e)
        {
            lblSoek.Text = "Aankoop ID:";
        }

        private void rbGroottes_CheckedChanged(object sender, EventArgs e)
        {
            lblSoek.Text = "Groottes:";
        }

        private void rbKledingstukke_CheckedChanged(object sender, EventArgs e)
        {
            lblSoek.Text = "Kledingstuk ID:";
        }

        private void rbK_Transaksies_CheckedChanged(object sender, EventArgs e)
        {
            lblSoek.Text = "Kledingstuk Transaksie:";
        }

        private void rbKomberse_CheckedChanged(object sender, EventArgs e)
        {
            lblSoek.Text = "Kombers ID:";
        }

        private void rbKombers_Trans_CheckedChanged(object sender, EventArgs e)
        {
            lblSoek.Text = "Kombers Transaksie:";
        }

        private void rbKontantDonasies_CheckedChanged(object sender, EventArgs e)
        {
            lblSoek.Text = "Kontant Donasies:";
        }

        private void rbLogin_CheckedChanged(object sender, EventArgs e)
        {
            lblSoek.Text = "Aanteken ID:";
        }

        private void rbPersoon_CheckedChanged(object sender, EventArgs e)
        {
            lblSoek.Text = "Persoon ID:";
        }

        private void rbKliente_CheckedChanged(object sender, EventArgs e)
        {
            lblSoek.Text = "Kliënte ID:";
        }

        private void rbTipeKledingstuk_CheckedChanged(object sender, EventArgs e)
        {
            lblSoek.Text = "Tipe Kledingstuk:";
        }

        public void query(string sql)      //Check hier, n method om enige query te doen
        {
            OleDbDataAdapter adapt = new OleDbDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            dataGridView1.Visible = true;
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
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
            else if (rbKomberse.Checked)
            {
                soek = "Komberse";
                id = "Klient_ID";
            }
            else if (rbKombers_Trans.Checked)
            {
                soek = "Kombers_Transaksie";
                id = "Kombers_Transaksie_";
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
            dataGridView1.DataBindings.Clear();
        }
    }
}
