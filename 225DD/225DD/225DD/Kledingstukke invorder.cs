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
        int kID = 4;

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
            OleDbDataAdapter adapt = new OleDbDataAdapter(@"SELECT * FROM Kledingstuk_Transaksie", conn);
            DataTable ds = new DataTable();
            adapt.Fill(ds);
            kID = (ds.Rows.Count) + 1;
            lblK_ID.Text = kID.ToString();
        }

        public void insert(string sql)      //Check hier, n method om enige query te doen
        {
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=  " + IntekenForm.spath);
            conn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            MessageBox.Show("An Item has been successfully added");
            conn.Close();
            this.Close();
        }

        private void btnAanvaar_Click(object sender, EventArgs e)
        {
            int user_id;
            Int32.TryParse(user,out user_id);
            insert("insert into Kledingstuk_Transaksie ([Datum_In],[Kledingstuk_ID],[User_ID],[Klient_ID]) values ('"+DateTime.Now+"',"+kID+","+ user_id +","+kID+")");
            //insert("insert into Kledingstuk_Transaksie ([Datum_In],[Kledingstuk_ID],[Datum_Uit],[User_ID],[Klient_ID]) values ('" + DateTime.Now + "','" + kID + "','" + user + "','" + kID + "','" + kID + "')");
        }

        private void btnKanseleer_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
