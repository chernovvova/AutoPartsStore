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
            productGridView.Columns[0].HeaderText = "Название товара";
            productGridView.Columns[0].HeaderText = "Количество";
            productGridView.Columns[0].HeaderText = "Цена";
            productGridView.Columns[0].HeaderText = "Статус оплаты";
            productGridView.Columns[0].HeaderText = "Статус доставки";

            List<Product> products = new List<Product>();

            string request = "SELECT id, name FROM product";
            NpgsqlCommand command = new NpgsqlCommand(request, con);
            using (NpgsqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["id"].ToString());
                    string name = reader["name"].ToString();

                    Product product = new Product(id, name);
                    products.Add(product);
                }
            }

            productComboBox.DataSource = products;
            productComboBox.DisplayMember = "name";
            productComboBox.ValueMember = "id";
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {

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

            public Product(int id, string name)
            {
                this.id = id;
                this.name = name;
            }   
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
