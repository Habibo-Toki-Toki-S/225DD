using BMW_Production_Calculator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NG_Klerebank
{
    public partial class Tuisblad : Form
    {
        public Tuisblad()
        {
            InitializeComponent();
        }

        private void Tuisblad_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'kerkbankDataSet1.Kliënt' table. You can move, or remove it, as needed.
            this.kliëntTableAdapter1.Fill(this.kerkbankDataSet1.Kliënt);
            // TODO: This line of code loads data into the 'kerkbankDataSet.Kliënt' table. You can move, or remove it, as needed.
            this.kliëntTableAdapter.Fill(this.kerkbankDataSet.Kliënt);

        }

        private void klienteVerslagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataKliente.Visible = true;
        }

        private void nuweKlientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUser user = new AddUser();
            user.Show();
        }
    }
}
