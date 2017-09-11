using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _225DD
{
    public partial class Tuisblad : Form
    {
        public Tuisblad()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void invorderToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void nuweKlientToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void invorderToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Kledingstukke_invorder k_IN = new Kledingstukke_invorder();
            k_IN.Show();
        }

        private void Tuisblad_Load(object sender, EventArgs e)
        {
            
        }
    }
}
