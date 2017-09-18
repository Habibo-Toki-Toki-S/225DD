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
    public partial class Kombers_Uit : Form
    {
        public Kombers_Uit()
        {
            InitializeComponent();
        }

        private void btnKanseleer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAanvaar_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=  " + IntekenForm.spath);

            conn.Open();
            if (txtKombersID.Text != "" && txtKlientID.Text != "")
            {
                string kombersID = txtKombersID.Text;
                string klientID = txtKlientID.Text;
                if (MessageBox.Show("Is u seker u wil hierdie kombers verwyder: " + kombersID + "?", "Bevestig", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // user clicked yes
                    OleDbCommand cmd = new OleDbCommand(@"DELETE FROM Persoon WHERE Persoon_ID = '" + kombersID + "'", conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Klient " + kombersID + " is verwyder!!");
                }
            }
            else
            {
                MessageBox.Show("Vul 'n klient naam in.");
            }
        }
    }
}
