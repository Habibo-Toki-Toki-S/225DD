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
    public partial class IntekenForm : Form
    {
        string spath;

        public IntekenForm()
        {
            InitializeComponent();
        }

        private void IntekenForm_Load(object sender, EventArgs e)
        {
               
        }

        private void btnDB_Click(object sender, EventArgs e)
        {
            btnAanvaar.Visible = true;
            btnKanseleer.Visible = true;

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

        private void btnAanvaar_Click(object sender, EventArgs e)
        {
            if (txtNaam.Text != "" || txtWagwoord.Text != "")
            {

                string name = txtNaam.Text;
                string pass = txtWagwoord.Text;

                if (name != "" && pass != "")
                {
                    OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=  " + spath);
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
            }
        }
    }
}
