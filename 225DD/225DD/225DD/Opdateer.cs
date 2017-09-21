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

            //int Aankoop_ID = Convert.ToInt32(txtSoek.Text);
            //int Bedrag = Convert.ToInt32(txt1.Text);
           //// int User_Id = Convert.ToInt32(txt2.Text);
            //int Kledingstuk_ID = Convert.ToInt32(txt3.Text);

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
            query("Select * from Grootte");

            lblSoek.Text = "Groottes:";
            lbl1.Text = "Groottes:";

            

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

            MessageBox.Show("Ry suksesvol by gevoeg");

        }


       
        private void button3_Click(object sender, EventArgs e)
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


            if (soek == "Aankope")
            {
                int Aankoop_ID = Convert.ToInt32(txtSoek.Text);
                int Bedrag = Convert.ToInt32(txt1.Text);
                int User_Id = Convert.ToInt32(txt2.Text);
                int Kledingstuk_ID = Convert.ToInt32(txt3.Text);

                insert("UPDATE Aankope SET [Bedrag] = (" + Bedrag + "),[User_Id] = (" + User_Id + "),[Kledingstuk_ID] = (" + Kledingstuk_ID + ") Where Aankoop_ID = " + Aankoop_ID + "");
                MessageBox.Show("Ry suksesvol by gevoeg");
            }
            else if (soek == "Geslag")
            {
                int Geslag_ID = Convert.ToInt32(txtSoek.Text);
                String Geslag = txt1.Text;

                insert("UPDATE Geslag SET [Geslag] =  ('" + Geslag + "') Where Geslag_ID = " + Geslag_ID +"");
                MessageBox.Show("Ry suksesvol verander");
            }
            else if (soek == "Grootte")
            {
                int Grootte_ID = Convert.ToInt32(txtSoek.Text);
                String Grootte_Size = txt1.Text;
                insert("UPDATE Grootte SET [Grootte] =  ('" + Grootte_Size + "') Where Grootte_ID = " + Grootte_ID + "");
                MessageBox.Show("Ry suksesvol verander");

            }
            else if (soek == "Kledingstuk")
            {
                int Kledingstuk_ID = Convert.ToInt32(txtSoek.Text);
                int Tipe_Kledingstuk_ID = Convert.ToInt32(txt1.Text);
                int Grootte_ID = Convert.ToInt32(txt2.Text);
                int Geslag_ID = Convert.ToInt32(txt3.Text);
                String Beskrywing = txt4.Text;

                insert("UPDATE Kledingstuk SET [Tipe_Kledingstuk_ID] = (" + Tipe_Kledingstuk_ID + "),[Grootte_ID] = (" + Grootte_ID + "),[Geslag_ID] = (" + Geslag_ID + "),[Beskrywing] = ('" + Beskrywing + "')  Where Kledingstuk_ID = " + Kledingstuk_ID + "");
                MessageBox.Show("Ry suksesvol by gevoeg");
            }
            else if (soek == "Kledingstuk_Transaksie")
            {
                int Kledingstuk_Transaksie_ID = Convert.ToInt32(txtSoek.Text);
                String Datum_In = txt1.Text;
                int Kledingstuk_ID = Convert.ToInt32(txt2.Text);
                String Datum_Uit = txt3.Text;
                int User_ID = Convert.ToInt32(txt4.Text);
                int Klient_ID = Convert.ToInt32(txt5.Text);

                insert("UPDATE Kledingstuk_Transaksie SET [Datum_In] = ('" + Datum_In + "'),[Kledingstuk_ID] = (" + Kledingstuk_ID + "),[Datum_Uit] = ('" + Datum_Uit + "'),[User_ID] = (" + User_ID + "), [Klient_ID] = (" + Klient_ID + ") Where Kledingstuk_Transaksie_ID = " + Kledingstuk_Transaksie_ID + " ");
                MessageBox.Show("Ry suksesvol by gevoeg");
            }
            else if (soek == "Kontant_Donasies")
            {
                int Kontant_ID = Convert.ToInt32(txtSoek.Text);
                String Naam = txt1.Text;
                String Van = txt2.Text;
                int Bedrag = Convert.ToInt32(txt3.Text);
                int User_ID = Convert.ToInt32(txt4.Text);

                insert("UPDATE Kontant_Donasies SET [Naam] = ('" + Naam + "'),[Van] = ('" + Van + "'),[Bedrag] = (" + Bedrag + "),[User_ID] = (" + User_ID + ")  Where Kontant_ID = " + Kontant_ID + "");
                MessageBox.Show("Ry suksesvol by gevoeg");
            }
            else if (soek == "Login")
            {
                int User_ID = Convert.ToInt32(txtSoek.Text);
                String Username = txt1.Text;
                String Password = txt2.Text;
                String Admin = txt3.Text;
                int Persoon_ID = Convert.ToInt32(txt4.Text);

                insert("UPDATE Login SET [Username] = ('" + Username + "'),[Password] = ('" + Password + "'),[Admin] = ('" + Admin + "'),[Persoon_ID] = (" + Persoon_ID + ")  Where User_ID = " + User_ID + "");
                MessageBox.Show("Ry suksesvol by gevoeg");
            }
            else if (soek == "Persoon")
            {
                int Persoon_ID = Convert.ToInt32(txtSoek.Text);
                String Naam = txt1.Text;
                String Van = txt2.Text;
                String Adres = txt3.Text;
                int Telefoon_Nommer = Convert.ToInt32(txt4.Text);
                String KerkVerband = txt5.Text;
                int Geslag_ID = Convert.ToInt32(txt6.Text);

                insert("UPDATE Persoon SET [Naam] = ('" + Naam + "'),[Van] = ('" + Van + "'),[Adres] = ('" + Adres + "'),[Telefoon_Nommer] = (" + Telefoon_Nommer + "),[KerkVerband] = ('" + KerkVerband + "'),[Geslag_ID] = (" + Geslag_ID + ")  Where Persoon_ID = " + Persoon_ID + "");
                MessageBox.Show("Ry suksesvol by gevoeg");
            }
            else if (soek == "Klient")
            {
                int Klient_ID = Convert.ToInt32(txtSoek.Text);
                int Klere_Grootte_ID = Convert.ToInt32(txt1.Text);
                String Geboorte_Datum = txt2.Text;
                int Persoon_ID = Convert.ToInt32(txt3.Text);
                String Email = txt4.Text;

                insert("UPDATE Klient SET [Klere_Grootte_ID] = (" + Klere_Grootte_ID + "),[Geboorte_Datum] = ('" + Geboorte_Datum + "'),[Persoon_ID] = (" + Persoon_ID + "),[Email] = ('" + Email + "')  Where Klient_ID = " + Klient_ID + "");
                MessageBox.Show("Ry suksesvol by gevoeg");
            }
            else if (soek == "Tipe_Kledingstuk")
            {
                int Tipe_Kledingstuk_ID = Convert.ToInt32(txtSoek.Text);
                String Tipe_Kledingstuk = txt1.Text;

                insert("UPDATE Tipe_Kledingstuk SET [Tipe_Kledingstuk] =  ('" + Tipe_Kledingstuk + "') Where Tipe_Kledingstuk_ID = " + Tipe_Kledingstuk_ID + "");
                MessageBox.Show("Ry suksesvol by gevoeg");
            }
            else
                MessageBox.Show("Hy wil nie werk nie");
        }

        private void btnAanvaar_Click(object sender, EventArgs e)
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


            if (soek == "Aankope")
            {
                int Bedrag = Convert.ToInt32(txt1.Text);
                int User_Id = Convert.ToInt32(txt2.Text);
                int Kledingstuk_ID = Convert.ToInt32(txt3.Text);
                insert("INSERT INTO Aankope ([Bedrag],[User_ID],[Kledingstuk_ID]) Values (" + Bedrag + "," +User_Id + "," +Kledingstuk_ID + " )" );
                MessageBox.Show("Ry suksesvol by gevoeg");
            }
            else if (soek == "Geslag")
            {
                //int Geslag_ID = Convert.ToInt32(txtSoek.Text);
                String Geslag = txt1.Text;

                insert("INSERT INTO Geslag ([Geslag]) Values ('" + Geslag + "')");
                MessageBox.Show("Ry suksesvol by gevoeg");
            }
            else if (soek == "Grootte")
            {
                //int Grootte_ID = Convert.ToInt32(txtSoek.Text);
                String Grootte_Size = txt1.Text;
                insert("INSERT INTO Grootte ([Grootte]) Values ('" + Grootte_Size + "')");
                MessageBox.Show("Ry suksesvol by gevoeg");

            }
            else if (soek == "Kledingstuk")
            {
                //int Kledingstuk_ID = Convert.ToInt32(txtSoek.Text);
                int Tipe_Kledingstuk_ID = Convert.ToInt32(txt1.Text);
                int Grootte_ID = Convert.ToInt32(txt2.Text);
                int Geslag_ID = Convert.ToInt32(txt3.Text);
                String Beskrywing = txt4.Text;

                insert("INSERT INTO Kledingstuk ([Tipe_Kledingstuk_ID],[Grootte_ID],[GeslagID],[Beskrywing]) Values (" + Tipe_Kledingstuk_ID + "," + Grootte_ID + "," + Geslag_ID + ",'" + Beskrywing + "' )");
                MessageBox.Show("Ry suksesvol by gevoeg");
            }
            else if (soek == "Kledingstuk_Transaksie")
            {
                //int Kledingstuk_Transaksie_ID = Convert.ToInt32(txtSoek.Text);
                String Datum_In = txt1.Text;
                int Kledingstuk_ID = Convert.ToInt32(txt2.Text);
                String Datum_Uit = txt3.Text;
                int User_ID = Convert.ToInt32(txt4.Text);
                int Klient_ID = Convert.ToInt32(txt5.Text);

                insert("INSERT INTO Kledingstuk_Transaksie ([Datum_In],[Kledingstuk_ID],[Datum_Uit],[User_ID],[Klient_ID]) Values ('" + Datum_In + "'," + Kledingstuk_ID + ",'" + Datum_Uit + "'," + User_ID + "," + Klient_ID + " )");
                MessageBox.Show("Ry suksesvol by gevoeg");
            }
            else if (soek == "Kontant_Donasies")
            {
                //int Kontant_ID = Convert.ToInt32(txtSoek.Text);
                String Naam = txt1.Text;
                String Van = txt2.Text;
                int Bedrag = Convert.ToInt32(txt3.Text);
                int User_ID = Convert.ToInt32(txt4.Text);

                insert("INSERT INTO Kontant_Donasies ([Naam],[Van],[Bedrag],[User_ID]) Values ('" + Naam + "','" + Van + "'," + Bedrag + ","+ User_ID + " )");
                MessageBox.Show("Ry suksesvol by gevoeg");
            }
            else if (soek == "Login")
            {
                //int User_ID = Convert.ToInt32(txtSoek.Text);
                String Username = txt1.Text;
                String Password = txt2.Text;
                String Admin = txt3.Text;
                int Persoon_ID = Convert.ToInt32(txt4.Text);

                insert("INSERT INTO Login ([Username],[Password],[Admin],[Persoon_ID]) Values ('" + Username + "','" + Password + "','" + Admin + "',"+ Persoon_ID + " )");
                MessageBox.Show("Ry suksesvol by gevoeg");
            }
            else if (soek == "Persoon")
            {
                //int Persoon_ID = Convert.ToInt32(txtSoek.Text);
                String Naam = txt1.Text;
                String Van = txt2.Text;
                String Adres = txt3.Text;
                int Telefoon_Nommer = Convert.ToInt32(txt4.Text);
                String KerkVerband = txt5.Text;
                int Geslag_ID = Convert.ToInt32(txt6.Text);

                insert("INSERT INTO Persoon_ID ([Naam],[Van],[Datum_Uit],[Telefoon_Nommer],[KerkVerband],[Geslag_ID]) Values ('" + Naam + "','" + Van + "','" + Adres + "'," + Telefoon_Nommer + ",'" + KerkVerband + "',"+ Geslag_ID + " )");
                MessageBox.Show("Ry suksesvol by gevoeg");
            }
            else if (soek == "Klient")
            {
                //int Klient_ID = Convert.ToInt32(txtSoek.Text);
                int Klere_Grootte_ID = Convert.ToInt32(txt1.Text);
                String Geboorte_Datum = txt2.Text;
                int Persoon_ID = Convert.ToInt32(txt3.Text);
                String Email = txt4.Text;

                insert("INSERT INTO Klient ([Klere_Grootte_ID],[Geboorte_Datum],[Persoon_ID],[Email]) Values (" + Klere_Grootte_ID + ",'" + Geboorte_Datum + "'," + Persoon_ID + ",'"+ Email + "' )");
                MessageBox.Show("Ry suksesvol by gevoeg");
            }
            else if (soek == "Tipe_Kledingstuk")
            {
                //int Tipe_Kledingstuk_ID = Convert.ToInt32(txtSoek.Text);
                String Tipe_Kledingstuk = txt1.Text;

                insert("INSERT INTO Tipe_Kledingstuk ([Tipe_Kledingstuk]) Values ('" + Tipe_Kledingstuk +" )");
                MessageBox.Show("Ry suksesvol by gevoeg");
            }
            else
            MessageBox.Show("Hy wil nie werk nie");
            //insert(@"INSERT INTO "+ soek + "  " + soek + " WHERE " + id + " = " + txtSoek.Text);

        }
    }
    
}
