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
        DataTable ordersDataTable;
        DataSet ordersDataSet;
        DataTable currentOrdersDataTable;
        DataSet currentOrdersDataSet;
        public OrderInfoForm(NpgsqlConnection con)
        {
            InitializeComponent();
            this.con = con;
            ordersDataTable = new DataTable();
            ordersDataSet = new DataSet();
            currentOrdersDataSet = new DataSet();
            currentOrdersDataTable = new DataTable();
            Update();
        }

        public void Update()
        {
            string sql = "SELECT * FROM order_info";
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, con);
            ordersDataSet.Reset();
            dataAdapter.Fill(ordersDataSet);
            ordersDataTable = ordersDataSet.Tables[0];
            orderInfoGridView.DataSource = ordersDataTable;
            orderInfoGridView.Columns[0].HeaderText = "Номер заказа";
            orderInfoGridView.Columns[1].HeaderText = "Номер продукта";
            orderInfoGridView.Columns[2].HeaderText = "Количество товара";
            orderInfoGridView.Columns[3].HeaderText = "Цена";
            orderInfoGridView.Columns[4].HeaderText = "Статус оплаты";
            orderInfoGridView.Columns[5].HeaderText = "Статус заказа";

        }

        public void UpdateCurrentOrders()
        {
            string sql = "SELECT * FROM order_info WHERE delivery_status = 'Доставлено' AND payment_status = 'Не оплачено'";
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, con);
            currentOrdersDataSet.Reset();
            dataAdapter.Fill(currentOrdersDataSet);
            currentOrdersDataTable = currentOrdersDataSet.Tables[0];
            currentOrders.DataSource = currentOrdersDataTable;
            currentOrders.Columns[0].HeaderText = "Номер заказа";
            currentOrders.Columns[1].HeaderText = "Номер продукта";
            currentOrders.Columns[2].HeaderText = "Количество товара";
            currentOrders.Columns[3].HeaderText = "Цена";
            currentOrders.Columns[4].HeaderText = "Статус оплаты";
            currentOrders.Columns[5].HeaderText = "Статус заказа";
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void OrderInfoForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateCurrentOrders();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
