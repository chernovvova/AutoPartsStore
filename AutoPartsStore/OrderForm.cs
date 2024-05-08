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
    public partial class OrderForm : Form
    {
        NpgsqlConnection con;
        int id;
        int client_id;
        int product_id;
        int product_price;
        DataTable clientsDataTable;
        DataSet clientsDataSet;
        DataTable orderInfoDataTable;
        DataSet orderInfoDataSet;
        public OrderForm(NpgsqlConnection con)
        {
            InitializeComponent();
            this.con = con;
            clientsDataTable = new DataTable();
            clientsDataSet = new DataSet();
            orderInfoDataTable = new DataTable();
            orderInfoDataSet = new DataSet();
            UpdateOrders();
            UpdateProducts();
        }

        public void UpdateOrders()
        {
            string sql = "SELECT * FROM orderr";
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, con);
            clientsDataSet.Reset();
            dataAdapter.Fill(clientsDataSet);
            clientsDataTable = clientsDataSet.Tables[0];
            orderGridView.DataSource = clientsDataTable;
            orderGridView.Columns[0].HeaderText = "Номер заказа";
            orderGridView.Columns[1].HeaderText = "Имя клиента";
            orderGridView.Columns[2].HeaderText = "Адрес доставки";
            orderGridView.Columns[3].HeaderText = "Общая стоимость";
            orderGridView.Columns[4].HeaderText = "Дата заказа";
            orderGridView.Columns[5].HeaderText = "Статус заказа";

            List<Client> clients = new List<Client>();
            string request = "SELECT id, name FROM client";

            NpgsqlCommand command = new NpgsqlCommand(request, con);

            using (NpgsqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"].ToString());
                    string name = reader["name"].ToString();

                    Client client = new Client(id, name);
                    clients.Add(client);
                }
            }

            clientsComboBox.DataSource = clients;
            clientsComboBox.DisplayMember = "name";
            clientsComboBox.ValueMember = "id";
        }

        public void UpdateProducts()
        {
            string sql = "SELECT * FROM order_info";
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, con);
            orderInfoDataSet.Reset();
            dataAdapter.Fill(orderInfoDataSet);

            orderInfoDataTable = orderInfoDataSet.Tables[0];
            productGridView.DataSource = orderInfoDataTable;
            productGridView.Columns[0].HeaderText = "Номер заказа";
            productGridView.Columns[1].HeaderText = "Название товара";
            productGridView.Columns[2].HeaderText = "Количество";
            productGridView.Columns[3].HeaderText = "Цена";
            productGridView.Columns[4].HeaderText = "Статус оплаты";
            productGridView.Columns[5].HeaderText = "Статус доставки";

            List<Product> products = new List<Product>();

            string request = "SELECT id, name, price FROM product";
            NpgsqlCommand command = new NpgsqlCommand(request, con);
            using (NpgsqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"].ToString());
                    string name = reader["name"].ToString();
                    int price = Convert.ToInt32(reader["price"].ToString());

                    Product product = new Product(id, name, price);
                    products.Add(product);
                }
            }

            productComboBox.DataSource = products;
            productComboBox.DisplayMember = "name";
            productComboBox.ValueMember = "id";
        }


        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = string.Format("INSERT INTO orderr (client_id, order_address, total_price, order_date, order_status) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')", client_id, addressTextBox.Text, 0, DateTime.Now, "не выполнен");
                NpgsqlCommand command = new NpgsqlCommand(sql, con);
                command.ExecuteNonQuery();
                UpdateOrders();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRows = orderGridView.SelectedRows;

            if(selectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = selectedRows[0];
                try
                {
                    int id = Convert.ToInt32(selectedRow.Cells["id"].Value);
                    string sql = string.Format("DELETE FROM order_info WHERE order_id = '{0}'" , id);
                    NpgsqlCommand command = new NpgsqlCommand(sql, con);
                    command.ExecuteNonQuery();

                    sql = string.Format("DELETE FROM orderr WHERE id = '{0}'", id);
                    command = new NpgsqlCommand(sql, con);
                    command.ExecuteNonQuery();
                    UpdateOrders();
                    UpdateProducts();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public class Client
        {
            public int id { get; set; }
            public string name { get; set; }

            public Client(int id, string name)
            {
                this.id = id;
                this.name = name;
            }
        }
        public class Product
        {
            public int id { get; set; }
            public string name { get; set; }
            public int price { get; set; }


            public Product(int id, string name, int price)
            {
                this.id = id;
                this.name = name;
                this.price = price;
            }
        }


        private void addProductButton_Click(object sender, EventArgs e)
        {
            try
            {
                int count = Convert.ToInt32(countProductTextBox.Text);

                string sql = string.Format("INSERT INTO order_info (order_id, product_id, count, price, payment_status, delivery_status) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')",
                    id, product_id, count, product_price * count, "Не оплачено", "Не доставлено");
                NpgsqlCommand command = new NpgsqlCommand(sql, con);
                command.ExecuteNonQuery();
                UpdateProducts();
                UpdateOrders();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void orderGridView_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRow = orderGridView.SelectedRows;
            if (selectedRow.Count > 0)
            {
                DataGridViewRow dataGridViewRow = selectedRow[0];
                id = Convert.ToInt32(dataGridViewRow.Cells["id"].Value);
            }

        }

        private void countProductTextBox_TextChanged(object sender, EventArgs e)
        {
            int count = 0;
            if (int.TryParse(countProductTextBox.Text, out count))
            {
                sumTextBox.Text = Convert.ToString(count * product_price);
            }
            else
            {
                sumTextBox.Text = "";
            }
        }

        private void productComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            product_id = ((Product)productComboBox.SelectedItem).id;
            product_price = ((Product)productComboBox.SelectedItem).price;
        }
        private void clientsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            client_id = ((Client)clientsComboBox.SelectedItem).id;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void OrderForm_Load(object sender, EventArgs e)
        {

        }

    }
}
