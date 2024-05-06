using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
namespace AutoPartsStore
{
    public partial class OrderInfoForm : Form
    {
        NpgsqlConnection con;
        public OrderInfoForm(NpgsqlConnection con)
        {
            InitializeComponent();
            this.con = con; 
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
