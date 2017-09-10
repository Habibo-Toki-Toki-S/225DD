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
    public partial class Kledingstukke_invorder : Form
    {
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

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
