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
    public partial class Kontant_In : Form
    {
        static string user; 
        public Kontant_In()
        {
            user = IntekenForm.name;
            InitializeComponent();
        }

        private void txtTel_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtVan_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string gebruiker = lblGebruiker.Text;
            string kombersID = lblK_ID.Text;
            string datum = lblDatum.Text;
            string naam = txtUsername.Text;
            string van = txtVan.Text;
            int bedrag = Convert.ToInt32(txtGeld.Text);

            insert("INSERT INTO Kontant_Donasies ([Naam],[Van],[Bedrag],[User_ID]) values ('" + naam + "','" + van + "'," + bedrag + "," + user + ") ");
            //insert("INSERT INTO Kledingstuk_Transaksie ([Datum_In],[Kledingstuk_ID]) values ('" + DateTime.Now + "'," + iKledingstuk_ID + ")");*/
            MessageBox.Show("Kontant suksesvol by gevoeg");
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
    }
}
