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
        DataTable dataTable;
        DataSet dataSet;
        public OrderInfoForm(NpgsqlConnection con)
        {
            InitializeComponent();
            this.con = con;
            dataTable = new DataTable();
            dataSet = new DataSet();
            Update();
        }

        public void Update()
        {
            string sql = "SELECT * FROM order_info";
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(sql, con);
            dataSet.Reset();
            dataAdapter.Fill(dataSet);
            dataTable = dataSet.Tables[0];
            orderInfoGridView.DataSource = dataTable;
            orderInfoGridView.Columns[0].HeaderText = "Номер заказа";
            orderInfoGridView.Columns[1].HeaderText = "Номер продукта";
            orderInfoGridView.Columns[2].HeaderText = "Количество товара";
            orderInfoGridView.Columns[3].HeaderText = "Цена";
            orderInfoGridView.Columns[4].HeaderText = "Статус оплаты";
            orderInfoGridView.Columns[5].HeaderText = "Статус заказа";

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
    }
}
