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
        int kID = 0;

        public Kledingstukke_invorder()
        {
            InitializeComponent();
        }

        private void Kledingstukke_invorder_Load(object sender, EventArgs e)
        {
            //Set user and Date
            user = IntekenForm.name;
            lblGebruiker.Text = user;
            lblDatum.Text = DateTime.Now.ToString("d/MM/yyyy");

            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=  " + IntekenForm.spath);
            conn.Open();
            OleDbDataAdapter adapt = new OleDbDataAdapter(@"SELECT * FROM KledingstukOntvangs", conn);
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
            insert("insert into KledingstukOntvangs ([KledingstukOntvangsID],[Datum],[UserUserID],[KledingstukID], [Beskrywing]) values ('" + kID + "','" + lblDatum.Text + "','" + user + "','" + kID + "','" + txtBeskrywing.Text + "')");
        }
    }
}
