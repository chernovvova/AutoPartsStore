using Npgsql;

namespace AutoPartsStore
{
    public partial class MainForm : Form
    {
        private NpgsqlConnection con;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            try
            {
                this.con = new NpgsqlConnection("Server=localhost; Port = 8000; UserID=postgres; Password = ; Database = AutoPartsStore");
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void clientButton_Click(object sender, EventArgs e)
        {
            ClientsForm clientsForm = new ClientsForm(con);
            clientsForm.ShowDialog();
        }

        private void productButton_Click(object sender, EventArgs e)
        {
            ProductForm productForm = new ProductForm(con);
            productForm.ShowDialog();
        }

        private void storageButton_Click(object sender, EventArgs e)
        {
            StorageForm storageForm = new StorageForm(con);
            storageForm.ShowDialog();
        }

        private void orderButton_Click(object sender, EventArgs e)
        {
            OrderForm orderForm = new OrderForm(con);
            orderForm.ShowDialog();
        }

        private void orderInfoButton_Click(object sender, EventArgs e)
        {
            OrderInfoForm orderInfoForm = new OrderInfoForm(con);
            orderInfoForm.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
