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
    public partial class Kledingstukke_invorder : Form
    {
        static string user;
        OleDbConnection conn;
        DataTable ds = new DataTable();
        int iKledingstuk_ID = 0;

        public Kledingstukke_invorder()
        {
            InitializeComponent();
        }

        private void Kledingstukke_invorder_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'kerkbankDataSet.Grootte' table. You can move, or remove it, as needed.
            this.grootteTableAdapter.Fill(this.kerkbankDataSet.Grootte);
            // TODO: This line of code loads data into the 'kerkbankDataSet.Tipe_Kledingstuk' table. You can move, or remove it, as needed.
            this.tipe_KledingstukTableAdapter.Fill(this.kerkbankDataSet.Tipe_Kledingstuk);
            // TODO: This line of code loads data into the 'kerkbankDataSet.Geslag' table. You can move, or remove it, as needed.
            this.geslagTableAdapter.Fill(this.kerkbankDataSet.Geslag);
            //Set user and Date
            user = IntekenForm.name;
            lblGebruiker.Text = user;
            lblDatum.Text = DateTime.Now.ToString("d/MM/yyyy");

            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=  " + IntekenForm.spath);
            conn.Open();
            OleDbDataAdapter adapt = new OleDbDataAdapter(@"SELECT * FROM Kledingstuk", conn);
            DataTable ds = new DataTable();
            adapt.Fill(ds);
            iKledingstuk_ID = (ds.Rows.Count) + 1;
            String sKledingstuk_ID = Convert.ToString(iKledingstuk_ID);
            lblK_ID.Text = sKledingstuk_ID;

            query(@"SELECT K.Kledingstuk_ID, K.Beskrywing, T.Tipe_Kledingstuk,G.Grootte_Size, Ge.Geslag
                  FROM (((Kledingstuk AS K
                  INNER JOIN  Tipe_Kledingstuk AS T
                  ON K.Tipe_Kledingstuk_ID = T.Tipe_Kledingstuk_ID)
                  INNER JOIN  Grootte AS G
                  ON K.Grootte_ID = G.Grootte_ID)
                  INNER JOIN  Geslag AS Ge
                  ON K.Geslag_ID = Ge.Geslag_ID);");
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

        public String readString(int kol, string sql)
        {
            String result = "";
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=  " + IntekenForm.spath);
            conn.Open();
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            OleDbDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                result = reader.GetValue(kol).ToString();
            }

            return result;
        }

        public void query(string sql)      
        {
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=  " + IntekenForm.spath);
            conn.Open();
            OleDbDataAdapter adapt = new OleDbDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            dataGridViewKledingstuk_invorder.Visible = true;
            dataGridViewKledingstuk_invorder.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void btnAanvaar_Click(object sender, EventArgs e)
        {   
            //String Tipe_Kledingstuk = readString(1, "Select Tipe_Kledingstuk FROM Tipe_Kledingstuk Where Tipe_Kledingstuk_ID = " + Convert.ToString(Tipe_Kledingstuk_ID) + "");           
            //String Grootte_Size = readString(1, "Select Grootte_Size FROM Grootte  Where Grootte_ID = " + Convert.ToString(Grootte_ID) + "");
            //String Geslag = readString(1, "Select Geslag FROM Geslag Where Geslag_ID = " + Convert.ToString(Tipe_Kledingstuk_ID) + "");

            int Grootte_ID = comboBox2.SelectedIndex + 1;
            int Geslag_ID = comboBox3.SelectedIndex + 1;
            int Tipe_Kledingstuk_ID = comboBox1.SelectedIndex + 1;
            String Beskrywing = txtBeskrywing.Text;
            insert("INSERT INTO Kledingstuk ([Tipe_Kledingstuk_ID],[Grootte_ID],[Geslag_ID],[Beskrywing]) values (" + Tipe_Kledingstuk_ID + "," + Grootte_ID + "," + Geslag_ID + ",'" + Beskrywing + "') ");
            insert("INSERT INTO Kledingstuk_Transaksie ([Datum_In],[Kledingstuk_ID]) values ('" + DateTime.Now + "'," + iKledingstuk_ID + ")");
            MessageBox.Show("An Item has been successfully added");
        }

        private void btnKanseleer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label4.Text = Convert.ToString(comboBox1.SelectedIndex);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int Kledingstuk_ID = 0;
            Kledingstuk_ID = Convert.ToInt32(textBox1.Text);
            insert("INSERT INTO Kledingstuk_Transaksie ([Datum_In],[Kledingstuk_ID]) values ('" + DateTime.Now  + "'," + Kledingstuk_ID + ")");
           
        }
    }
}
