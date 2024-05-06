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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace AutoPartsStore
{
    public partial class ProductForm : Form
    {
        NpgsqlConnection con;
        int id;
        DataTable dataTable;
        DataSet dataSet;
        public ProductForm(NpgsqlConnection con)
        {
            InitializeComponent();
            this.con = con;
            this.dataTable = new DataTable();
            this.dataSet = new DataSet();
            Update();
        }

        public void Update()
        {
            try
            {
                string sql = "SELECT * FROM product";
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, con);
                dataSet.Reset();
                name.Text = "";
                description.Text = "";
                price.Text = "";

                dataAdapter.Fill(dataSet);
                dataTable = dataSet.Tables[0];

                dataGridView1.DataSource = dataTable;
                dataGridView1.Columns[0].HeaderText = "Номер";
                dataGridView1.Columns[1].HeaderText = "Название товара";
                dataGridView1.Columns[2].HeaderText = "Описание";
                dataGridView1.Columns[3].HeaderText = "Цена";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddProductForm addProductForm = new AddProductForm(con);
            addProductForm.ShowDialog();
            Update();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = string.Format("UPDATE product SET name = '{0}', description = '{1}', price = '{2}' WHERE id = '{3}'", name.Text, description.Text, Convert.ToInt32(price.Text), id);
                NpgsqlCommand command = new NpgsqlCommand(sql, con);
                command.ExecuteNonQuery();
                Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRows = dataGridView1.SelectedRows;
            if (selectedRows.Count > 0)
            {
                DataGridViewRow dataGridViewRow = selectedRows[0];
                id = Convert.ToInt32(dataGridViewRow.Cells[0].Value);
                name.Text = Convert.ToString(dataGridViewRow.Cells[1].Value);
                description.Text = Convert.ToString(dataGridViewRow.Cells[2].Value);
                price.Text = Convert.ToString(dataGridViewRow.Cells[3].Value);
            }
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Вы точно хотите удалить?";
            string caption = "Подтверждение операции";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                int id = (int)dataGridView1.CurrentRow.Cells["id"].Value;
                try
                {
                    NpgsqlCommand command = new NpgsqlCommand("DELETE FROM product WHERE id = :id", con);
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
        private void ProductForm_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
