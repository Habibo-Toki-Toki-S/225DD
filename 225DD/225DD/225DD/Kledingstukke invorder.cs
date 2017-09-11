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
        string user = "Gerrie";

        public Kledingstukke_invorder()
        {
            InitializeComponent();
        }

        private void Kledingstukke_invorder_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'kerkbankDataSet3.Tipe_Kledingstuk' table. You can move, or remove it, as needed.
            this.tipe_KledingstukTableAdapter1.Fill(this.kerkbankDataSet3.Tipe_Kledingstuk);
            // TODO: This line of code loads data into the 'kerkbankDataSet2.Tipe_Kledingstuk' table. You can move, or remove it, as needed.
            this.tipe_KledingstukTableAdapter.Fill(this.kerkbankDataSet2.Tipe_Kledingstuk);
            // TODO: This line of code loads data into the 'kerkbankDataSet1.Geslag' table. You can move, or remove it, as needed.
            this.geslagTableAdapter.Fill(this.kerkbankDataSet1.Geslag);
            // TODO: This line of code loads data into the 'kerkbankDataSet.Groottes' table. You can move, or remove it, as needed.
            this.groottesTableAdapter.Fill(this.kerkbankDataSet.Groottes);


            //Set user and Date
            lblGebruiker.Text = user;
            lblDatum.Text = DateTime.Now.ToString();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAanvaar_Click(object sender, EventArgs e)
        {
            //OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=  " + LoginForm.spath);
            //conn.Open();
            //OleDbDataAdapter adapt = new OleDbDataAdapter(@"SELECT TotalTime FROM BMW WHERE Code = '" + model + "'", conn);
            //DataTable dt = new DataTable();
            //adapt.Fill(dt);
        }
    }
}
