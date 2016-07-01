using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fangliste_2016
{
    public partial class Frm_LinksBearbeiten : Form
    {
        public Frm_LinksBearbeiten()
        {
            InitializeComponent();
        }

        private void linkBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.linkBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.fanglisteDBDataSet);

        }

        private void Frm_LinksBearbeiten_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'fanglisteDBDataSet.Link' table. You can move, or remove it, as needed.
            this.linkTableAdapter.Fill(this.fanglisteDBDataSet.Link);

        }
    }
}
