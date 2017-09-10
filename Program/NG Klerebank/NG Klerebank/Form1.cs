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

namespace NG_Klerebank
{
    public partial class Form1 : Form
    {
        public static string spath;
        public Form1()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            /*if (txtUserName.Text != "" || txtPassword.Text != "")
            {

                string name = txtUserName.Text;
                string pass = txtPassword.Text;

                if (name != "" && pass != "")
                {
                    OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=  " + Form1.spath);
                    conn.Open();
                    OleDbDataAdapter adap = new OleDbDataAdapter("select * from Login where Username='" + name + "' and Password='" + pass + "'", conn);
                    DataTable dt = new DataTable();
                    adap.Fill(dt);

                    if (dt.Rows.Count == 1)
                    {
                        MessageBox.Show("Login successful");
                        this.Hide();
                        Tuisblad tuisB = new Tuisblad();
                        tuisB.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("User name or Password is invalid.");
                    }
                }
                else
                {
                    MessageBox.Show("User name or Password is invalid.");
                }
            }*/

            MessageBox.Show("Login successful");
            this.Hide();
            Tuisblad tuisB = new Tuisblad();
            tuisB.ShowDialog();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            btnLogin.Visible = true;
            btnExit.Visible = true;

            calculatePath();
        }

        public void calculatePath()
        {
            do
            {
                OpenFileDialog opf = new OpenFileDialog();
                if (opf.ShowDialog() == DialogResult.OK)
                {
                    spath = opf.FileName;
                }
                else
                {
                    MessageBox.Show("ERROR");
                }
            }
            while (spath == "");
        }
    }
}
