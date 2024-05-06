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
    public partial class StorageForm : Form
    {
        NpgsqlConnection con;
        int id;
        DataTable dataTable;
        DataSet dataSet;

        public StorageForm(NpgsqlConnection con)
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
                string sql = "SELECT * FROM storage";
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, con);
                dataSet.Reset();
                count.Text = "";

                dataAdapter.Fill(dataSet);
                dataTable = dataSet.Tables[0];

                dataGridView1.DataSource = dataTable;
                dataGridView1.Columns[1].HeaderText = "Номер товара на складе";
                dataGridView1.Columns[1].HeaderText = "Номер товара";
                dataGridView1.Columns[2].HeaderText = "Количество";
                dataGridView1.Columns[3].HeaderText = "Дата последнего изменения";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try 
            {
                string sql = string.Format("UPDATE storage SET count = '{0}', last_update_date = '{1}' WHERE id = '{2}'", Convert.ToInt32(count.Text), DateTime.Now, id);
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
            if(selectedRows.Count > 0)
            {
                DataGridViewRow dataGridViewRow = selectedRows[0];
                id = Convert.ToInt32(dataGridViewRow.Cells[0].Value);
                int product_id = Convert.ToInt32(dataGridViewRow.Cells[1].Value);
                count.Text = Convert.ToString(dataGridViewRow.Cells[2].Value);
                try
                {
                    string request = string.Format("SELECT name, description, price FROM product WHERE id = '{0}'", product_id);
                    NpgsqlCommand command = new NpgsqlCommand(request, con);
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            product_name.Text = reader["name"].ToString();
                            product_description.Text = reader["description"].ToString();
                            product_price.Text = reader["price"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void StorageForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
