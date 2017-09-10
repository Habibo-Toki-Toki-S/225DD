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
using NG_Klerebank;

namespace BMW_Production_Calculator
{
    public partial class AddUser : Form
    {
        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=  " + Form1.spath);
        public string naam;
        public string pass;
        public string pass2;
        public int admin = 0;
        public string van;
        public string tel;
        public string kerk;
        public string adres;
        public string grootte;
        public string geslag;
        public string geboorte;
        public string skoen;

        public AddUser()
        {
            InitializeComponent();
            txtVan.PasswordChar = '*';
            txtTel.PasswordChar = '*';
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            naam = txtUsername.Text;
            pass = txtPass.Text;
            pass2 = txtPass2.Text;
            van = txtVan.Text;
            tel = txtTel.Text;
            kerk = txtKerk.Text;
            adres = txtAdres.Text;
            grootte = cbGrootte.Text;
            geslag = cbGeslag.Text;
            geboorte = txtOuderdom.Text;
            skoen = txtSkoen.Text;
            Boolean exists = false;


            if (rbYes.Checked == true)
            {
                admin = 1;
            }
            else
                admin = 0;

            // checks to see if the username exists.
            OleDbDataAdapter check = new OleDbDataAdapter(@"SELECT * FROM login WHERE username LIKE '" + naam + "'", conn);
            DataTable usernameCheck = new DataTable();
            check.Fill(usernameCheck);
            if (usernameCheck.Rows.Count == 1)
            {
                MessageBox.Show("Username already exists.");
                exists = true;
            }

            // check to see if the passwords entered are the same if the username exists or not.
            // if one of the conditions are false an error message wil display.
            if ((pass == pass2) && (exists == false))
            {
                // insert the new user into the login table of the database.
                conn.Close();
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(@"INSERT Into login(Klere Grootte,Skoen Grootte,Ouderdom) values('" + grootte + "','" + skoen + "','" + geboorte + "')", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("The user: " + naam + " was sucsesfully added!");
                this.Close();
            }
            else
            {
                if (pass != pass2)
                {
                    MessageBox.Show("The passwords is not the same.");
                }
                else
                {
                    MessageBox.Show("Username already exists.");
                }
            }

            /*string wagwoord = txtP1.Text;
            int admin = 1;
            string naam = txtUsername.Text;
            

            OleDbDataAdapter adapter = new OleDbDataAdapter(@"SELECT * FROM DVD", conn);
            OleDbCommand cmd = new OleDbCommand(@"INSERT Into login(Username, [Password], Admin) values('" + naam + "','" + wagwoord + "','" + admin + "')", conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("User has beem succesfully added");*/
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            conn.Open();
        }
    }
}
