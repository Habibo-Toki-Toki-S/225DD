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
    public partial class Kledingstuk_Uit : Form
    {
        private String user;
        private int User_ID;

        public Kledingstuk_Uit()
        {
            InitializeComponent();
            user = IntekenForm.name;
            lblGebruiker.Text = user;
            lblDate.Text = DateTime.Now.ToString("d/MM/yyyy");
            
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

        private void btnAanvaar_Click(object sender, EventArgs e)
        {
            int Klient_ID; // = Convert.ToInt32(textBox1.Text);
            int Kledingstuk_ID; // = Convert.ToInt32(txtKID.Text);

            if (int.TryParse(textBox1.Text, out Klient_ID))
            {
                if (int.TryParse(txtKID.Text, out Kledingstuk_ID))
                {
                    insert("Update Kledingstuk_Transaksie SET Datum_Uit = '" + DateTime.Now + "',User_ID = " + User_ID + ",Klient_ID = " + Klient_ID + " WHERE Kledingstuk_ID = " + Kledingstuk_ID + ";"); // SET ('" + DateTime.Now + "'," + User_ID + "," + Klient_ID + ") WHERE Kledingstuk_ID = "+Kledingstuk_ID+";");
                    MessageBox.Show("Kledingstuk is uit");
                }
                else
                {
                    MessageBox.Show("Please enter a number");
                }
            }
            else
            {
                MessageBox.Show("Please enter a number");
            }
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

        public void query(string sql)
        {
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=  " + IntekenForm.spath);
            conn.Open();
            OleDbDataAdapter adapt = new OleDbDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            //dataGridViewKledingstuk_invorder.Visible = true;
            //dataGridViewKledingstuk_invorder.DataSource = ds.Tables[0];
            conn.Close();
        }
    }
}
