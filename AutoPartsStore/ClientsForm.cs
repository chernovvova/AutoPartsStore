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
    public partial class ClientsForm : Form
    {
        NpgsqlConnection con;
        int id;
        DataTable dt;
        DataSet ds;
        public ClientsForm(NpgsqlConnection con)
        {
            this.con = con;
            dt = new DataTable();
            ds = new DataSet();
            InitializeComponent();
            Update();
        }

        public void Update()
        {
            try 
            {
                String sql = "SELECT * FROM client";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, con);
                ds.Reset();
                name.Text = "";
                telephone.Text = "";
                email.Text = "";
                da.Fill(ds);
                dt = ds.Tables[0];
                clientsGridView.DataSource = dt;
                clientsGridView.Columns[0].HeaderText = "Номер";
                clientsGridView.Columns[1].HeaderText = "Имя";
                clientsGridView.Columns[2].HeaderText = "Телефон";
                clientsGridView.Columns[3].HeaderText = "Почта";
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddClientForm addClientForm = new AddClientForm(con);
            addClientForm.ShowDialog();
            Update();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = string.Format("UPDATE client SET name = '{0}', tel = '{1}', email = '{2}' WHERE id = '{3}'", name.Text, telephone.Text, email.Text, id);
                NpgsqlCommand command = new NpgsqlCommand(sql, con); 
                command.ExecuteNonQuery();
                Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Вы точно хотите удалить?";
            string caption = "Подтверждение операции";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                int id = (int)clientsGridView.CurrentRow.Cells["id"].Value;
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("DELETE FROM client WHERE id = :id", con);
                    command.Parameters.AddWithValue("id", id);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Update();
            }
        }


        private void clientsGridView_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRows = clientsGridView.SelectedRows;
            if (selectedRows.Count > 0)
            {
                DataGridViewRow row = selectedRows[0];
                id = Convert.ToInt32(row.Cells[0].Value);
                name.Text = Convert.ToString(row.Cells[1].Value);
                telephone.Text = Convert.ToString(row.Cells[2].Value);
                email.Text = Convert.ToString(row.Cells[3].Value);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private void ClientsForm_Load(object sender, EventArgs e)
        {

        }
        private void clientsGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
