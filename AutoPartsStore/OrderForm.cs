using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Npgsql;

namespace AutoPartsStore
{
    public partial class OrderForm : Form
    {
        NpgsqlConnection con;
        int id = -1;
        int client_id;
        int product_id;
        int girdview_product_id;
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
            Dictionary<int, string> clientsDict = new Dictionary<int, string>();
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
            string sql = string.Format("SELECT * FROM order_info WHERE order_id = '{0}'", id);
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, con);
            orderInfoDataSet.Reset();
            dataAdapter.Fill(orderInfoDataSet);

            orderInfoDataTable = orderInfoDataSet.Tables[0];
            productGridView.DataSource = orderInfoDataTable;
            productGridView.Columns[0].HeaderText = "Номер заказа";
            productGridView.Columns[1].HeaderText = "Номер товара";
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
                string sql = string.Format("INSERT INTO orderr (client_id, order_address, total_price, order_date, order_status) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')",
                    client_id, addressTextBox.Text, 0, DateTime.Now, "Не выполнен");
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
            try
            {
                string sql = string.Format("UPDATE orderr SET order_address = '{0}' WHERE id = '{1}'", addressTextBox.Text, id);
                NpgsqlCommand command = new NpgsqlCommand(sql, con);
                command.ExecuteNonQuery();
                UpdateOrders();
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
                DataGridViewSelectedRowCollection selectedRows = orderGridView.SelectedRows;

                if (selectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = selectedRows[0];
                    try
                    {
                        int id = Convert.ToInt32(selectedRow.Cells["id"].Value);
                        if (Convert.ToString(selectedRow.Cells["order_status"].Value) == "Не выполнен")
                        {
                            string products_req = string.Format("SELECT product_id, count FROM order_info WHERE order_id = '{0}' AND delivery_status = 'Доставлено'", id);
                            NpgsqlCommand products_command = new NpgsqlCommand(products_req, con);
                            Dictionary<int, int> products = new Dictionary<int, int>();
                            using (NpgsqlDataReader reader = products_command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    products.Add(Convert.ToInt32(reader["product_id"]), Convert.ToInt32(reader["count"]));
                                }
                            }
                            foreach (KeyValuePair<int, int> entry in products)
                            {
                                string storage_req = string.Format("UPDATE storage SET count = count + '{0}', last_update_date = '{1}' WHERE product_id = '{2}'", entry.Value, DateTime.Now, entry.Key);
                                NpgsqlCommand storage_command = new NpgsqlCommand(storage_req, con);
                                storage_command.ExecuteNonQuery();
                            }
                        }
                        string sql = string.Format("DELETE FROM order_info WHERE order_id = '{0}'", id);
                        NpgsqlCommand command = new NpgsqlCommand(sql, con);
                        command.ExecuteNonQuery();

                        sql = string.Format("DELETE FROM orderr WHERE id = '{0}'", id);
                        command = new NpgsqlCommand(sql, con);
                        command.ExecuteNonQuery();
                        UpdateOrders();
                        UpdateProducts();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
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
                string delivery_status = "Не доставлено";
                string storage_req = string.Format("SELECT count FROM storage WHERE product_id = '{0}'", product_id);
                NpgsqlCommand storage_command = new NpgsqlCommand(storage_req, con);
                int count_on_storage = Convert.ToInt32(storage_command.ExecuteScalar());
                if (count_on_storage >= count)
                {
                    delivery_status = "Доставлено";
                    string storage_update_req = string.Format("UPDATE storage SET count = '{0}', last_update_date = '{1}' WHERE product_id = '{2}'", count_on_storage - count, DateTime.Now, product_id);
                    NpgsqlCommand storage_update_command = new NpgsqlCommand(storage_update_req, con);
                    storage_update_command.ExecuteNonQuery();
                }

                string sql = string.Format("INSERT INTO order_info (order_id, product_id, count, price, payment_status, delivery_status) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')",
                    id, product_id, count, product_price * count, "Не оплачено", delivery_status);
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
                UpdateProducts();
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
        private void paymentButton_Click(object sender, EventArgs e)
        {
            try
            {
                String sql = String.Format("UPDATE order_info SET payment_status = '{0}' WHERE order_id = '{1}' AND product_id = '{2}'", "Оплачено", id, girdview_product_id);
                NpgsqlCommand command = new NpgsqlCommand(sql, con);

                command.ExecuteNonQuery();
                UpdateProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void productGridView_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRow = productGridView.SelectedRows;
            if (selectedRow.Count > 0)
            {
                DataGridViewRow row = selectedRow[0];
                girdview_product_id = Convert.ToInt32(row.Cells[1].Value);
            }
        }

        private void exportToExcelButton(object sender, EventArgs e)
        {
            Excel.Application exApplication = new Excel.Application();
            exApplication.Visible = true;

            exApplication.Workbooks.Add();

            Excel.Worksheet workSheet = (Excel.Worksheet)exApplication.ActiveSheet;

            workSheet.Cells[1, 1] = "Номер заказа";
            workSheet.Cells[1, 2] = "Номер клиента";
            workSheet.Cells[1, 3] = "Имя клиента";
            workSheet.Cells[1, 4] = "Номер товара";
            workSheet.Cells[1, 5] = "Название товара";
            workSheet.Cells[1, 6] = "Количество";
            workSheet.Cells[1, 7] = "Цена";
            workSheet.Cells[1, 8] = "Статус доставки";
            workSheet.Cells[1, 9] = "Статус оплаты";

            Excel.Range header = (Excel.Range)workSheet.Range[workSheet.Cells[1, 1], workSheet.Cells[1, 9]];
            header.Cells.Font.Size = 14;
            header.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGreen);
            header.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;


            string sql = string.Format(@"SELECT order_id, client_id, client_name, product_id, product_name, count, price, payment_status, delivery_status
                                         FROM ((order_info oi JOIN orderr o ON oi.order_id = o.id) AS orders
	                                        JOIN (SELECT id, name AS client_name FROM client) AS clients ON orders.client_id = clients.id) AS orders_clients
	                                        JOIN (SELECT id, name AS product_name FROM product) AS products ON products.id = orders_clients.product_id");
            NpgsqlCommand command = new NpgsqlCommand(sql, con);
            using (NpgsqlDataReader reader = command.ExecuteReader())
            {
                int row = 1;
                while (reader.Read())
                {
                    row++;
                    workSheet.Cells[row, 1] = Convert.ToInt32(reader["order_id"]);
                    workSheet.Cells[row, 2] = Convert.ToInt32(reader["client_id"]);
                    workSheet.Cells[row, 3] = Convert.ToString(reader["client_name"]);
                    workSheet.Cells[row, 4] = Convert.ToInt32(reader["product_id"]);
                    workSheet.Cells[row, 5] = Convert.ToString(reader["product_name"]);
                    workSheet.Cells[row, 6] = Convert.ToInt32(reader["count"]);
                    workSheet.Cells[row, 7] = Convert.ToInt32(reader["price"]);
                    workSheet.Cells[row, 8] = Convert.ToString(reader["delivery_status"]);
                    workSheet.Cells[row, 9] = Convert.ToString(reader["payment_status"]);

                    Excel.Range current_row = (Excel.Range)workSheet.Range[workSheet.Cells[row, 1], workSheet.Cells[row, 9]];
                    current_row.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                }
            }

            workSheet.Columns[1].AutoFit();
            workSheet.Columns[2].AutoFit();
            workSheet.Columns[3].AutoFit();
            workSheet.Columns[4].AutoFit();
            workSheet.Columns[5].AutoFit();
            workSheet.Columns[6].AutoFit();
            workSheet.Columns[7].AutoFit();
            workSheet.Columns[8].AutoFit();
            workSheet.Columns[9].AutoFit();
        }

        private void sendOrder_Click(object sender, EventArgs e)
        {
            try
            {
                string select_sql = string.Format("SELECT delivery_status, payment_status FROM order_info WHERE order_id = '{0}'", id);
                NpgsqlCommand select_command = new NpgsqlCommand(select_sql, con);

                int count = 0;
                int count_rows = 0;

                using (NpgsqlDataReader reader = select_command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        count_rows++;
                        if (Convert.ToString(reader["delivery_status"]) == "Доставлено" && Convert.ToString(reader["payment_status"]) == "Оплачено")
                        {
                            count++;
                        }
                    }
                }

                if (count == count_rows)
                {
                    string update_sql = string.Format("UPDATE orderr SET order_status = 'Заказ отправлен клиенту' WHERE id = '{0}'", id);
                    NpgsqlCommand update_command = new NpgsqlCommand(update_sql, con);
                    update_command.ExecuteNonQuery();
                    UpdateOrders();
                }
                else
                {
                    MessageBox.Show("Ошибка. Не все товары готовы к отправке.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void OrderForm_Load(object sender, EventArgs e)
        {

        }

        private void orderGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
