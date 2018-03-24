using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsBankingApplication
{
    public partial class frmMDI : Form
    {
        public frmMDI()
        {
            InitializeComponent();
        }


        /// <summary>
        /// given
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClients instClients = new frmClients();
            instClients.MdiParent = this;
            instClients.Show();
        }

        /// <summary>
        /// given
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void batchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBatch instBatch = new frmBatch();
            instBatch.MdiParent = this;
            instBatch.Show();
        }

        /// <summary>
        /// given
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// given
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal);

        }

        /// <summary>
        /// given
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void layerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileVertical);

        }

        /// <summary>
        /// given
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void casacdeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);

        }


    }
}
