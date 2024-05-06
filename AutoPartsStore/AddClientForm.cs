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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AutoPartsStore
{
    public partial class AddClientForm : Form
    {
        NpgsqlConnection con;
        public AddClientForm(NpgsqlConnection con)
        {
            InitializeComponent();
            this.con = con;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                NpgsqlCommand command = new NpgsqlCommand("INSERT INTO client (name, tel, email) VALUES (:name, :tel, :email)", con);
                command.Parameters.AddWithValue("name", name.Text);
                command.Parameters.AddWithValue("tel", telephone.Text);
                command.Parameters.AddWithValue("email", email.Text);
                command.ExecuteNonQuery();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddClientForm_Load(object sender, EventArgs e)
        {

        }
    }
}
