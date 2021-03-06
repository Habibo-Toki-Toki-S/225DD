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
    public partial class IntekenForm : Form
    {
        public static string spath;
        public static string name;

        public IntekenForm()
        {
            InitializeComponent();
            txtWagwoord.PasswordChar = '*';
        }

        private void IntekenForm_Load(object sender, EventArgs e)
        {
            btnAanvaar.Visible = false;
            btnKanseleer.Visible = false;
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

                name = txtNaam.Text;
                string pass = txtWagwoord.Text;

                if (name != "" && pass != "")
                {
                    OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=  " + spath);
                    conn.Open();
                    OleDbDataAdapter adapt = new OleDbDataAdapter("select * from Login where Username = '" + name + "' and Password = '" + pass + "'", conn);
                    DataTable dt = new DataTable();
                    adapt.Fill(dt);

                    if (dt.Rows.Count == 1)
                    {
                        MessageBox.Show("Suksesvol, Gaan gerus voort");
                        this.Hide();
                        Tuisblad tuisB = new Tuisblad(conn, name);
                        tuisB.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Probeer Weer");
                    }
                }
                else
                {
                    MessageBox.Show("Probeer Weer");
                }
            }
            else
            {
                MessageBox.Show("Probeer Weer");
            }
        }

        private void txtNaam_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnKanseleer_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
