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
    public partial class Verwyder_Klient : Form
    {
        public Verwyder_Klient()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Verwyder_Klient_Load(object sender, EventArgs e)
        {

        }

        private void btnAanvaar_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=  " + IntekenForm.spath);

            conn.Open();
            if (txtID.Text != "")
            {
                int Geb_ID = Convert.ToInt32(txtID.Text);
                if (MessageBox.Show("Is u seker u wil hierdie klient verwyder: " + Geb_ID + "?", "Bevestig", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // user clicked yes
                    OleDbCommand cmd = new OleDbCommand(@"DELETE FROM Persoon WHERE Persoon_ID = '" + Geb_ID + "'", conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Klient " + Geb_ID + " is verwyder!!");
                }
            }
            else
            {
                MessageBox.Show("Vul 'n klient naam in.");
            }
        }
    }
}
