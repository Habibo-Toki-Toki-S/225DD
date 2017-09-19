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
    public partial class Kontant_Aankope : Form
    {
        static string user;
        static int User_ID;
        public Kontant_Aankope()
        {
            user = IntekenForm.name;
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string gebruiker = lblGebruiker.Text;
            string kombersID = lblK_ID.Text;
            string datum = lblDatum.Text;
            string bedrag = txtGeld.Text;
            int Grootte_ID = comboBox2.SelectedIndex + 1;
            int Geslag_ID = comboBox3.SelectedIndex + 1;
            int Tipe_Kledingstuk_ID = comboBox1.SelectedIndex + 1;
            string beskrywing = txtBeskrywing.Text;

            /*insert("INSERT INTO Kledingstuk ([Tipe_Kledingstuk_ID],[Grootte_ID],[Geslag_ID],[Beskrywing]) values (" + Tipe_Kledingstuk_ID + "," + Grootte_ID + "," + Geslag_ID + ",'" + Beskrywing + "') ");
            insert("INSERT INTO Kledingstuk_Transaksie ([Datum_In],[Kledingstuk_ID]) values ('" + DateTime.Now + "'," + iKledingstuk_ID + ")");*/
            MessageBox.Show("Kontant aankope suksesvol by gevoeg");

            //String Tipe_Kledingstuk = readString(1, "Select Tipe_Kledingstuk FROM Tipe_Kledingstuk Where Tipe_Kledingstuk_ID = " + Convert.ToString(Tipe_Kledingstuk_ID) + "");           
            //String Grootte_Size = readString(1, "Select Grootte_Size FROM Grootte  Where Grootte_ID = " + Convert.ToString(Grootte_ID) + "");
            //String Geslag = readString(1, "Select Geslag FROM Geslag Where Geslag_ID = " + Convert.ToString(Tipe_Kledingstuk_ID) + "");

            
                insert("INSERT INTO Kledingstuk ([Tipe_Kledingstuk_ID],[Grootte_ID],[Geslag_ID],[Beskrywing]) values (" + Tipe_Kledingstuk_ID + "," + Grootte_ID + "," + Geslag_ID + ",'" + Beskrywing + "') ");
                //insert("INSERT INTO Kledingstuk_Transaksie ([Datum_In],[Kledingstuk_ID]) values ('" + DateTime.Now + "'," + iKledingstuk_ID + ")");
                MessageBox.Show("Kledingstuk suksesvol by gevoeg");
           
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

        private void Kontant_Aankope_Load(object sender, EventArgs e)
        {
            User_ID = readInt(0, ("Select User_ID FROM Login Where Username = '" + user + "'"));
        }

        public int readInt(int kol, string sql)
        {
            int result = 0;
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=  " + IntekenForm.spath);
            conn.Open();
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            OleDbDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                result = Convert.ToInt32(reader.GetValue(kol));
            }

            return result;
        }
    }
}
