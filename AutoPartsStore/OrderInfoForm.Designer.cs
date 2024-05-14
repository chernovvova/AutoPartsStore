namespace AutoPartsStore
{
    partial class OrderInfoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            orderInfoGridView = new DataGridView();
            menuStrip1 = new MenuStrip();
            currentOrders = new DataGridView();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)orderInfoGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)currentOrders).BeginInit();
            SuspendLayout();
            // 
            // orderInfoGridView
            // 
            orderInfoGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            orderInfoGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            orderInfoGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            orderInfoGridView.Location = new Point(0, 27);
            orderInfoGridView.Name = "orderInfoGridView";
            orderInfoGridView.Size = new Size(554, 303);
            orderInfoGridView.TabIndex = 0;
            orderInfoGridView.CellContentClick += dataGridView1_CellContentClick;
            // 
            // menuStrip1
            // 
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1388, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // currentOrders
            // 
            currentOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            currentOrders.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            currentOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            currentOrders.Location = new Point(727, 27);
            currentOrders.Name = "currentOrders";
            currentOrders.RowTemplate.Height = 25;
            currentOrders.Size = new Size(661, 303);
            currentOrders.TabIndex = 2;
            currentOrders.CellContentClick += dataGridView1_CellContentClick_1;
            // 
            // button1
            // 
            button1.Location = new Point(1208, 353);
            button1.Name = "button1";
            button1.Size = new Size(168, 52);
            button1.TabIndex = 3;
            button1.Text = "Показать список неоплаченных товаров";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // OrderInfoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1388, 623);
            Controls.Add(button1);
            Controls.Add(currentOrders);
            Controls.Add(orderInfoGridView);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "OrderInfoForm";
            Text = "OrderInfoForm";
            Load += OrderInfoForm_Load;
            ((System.ComponentModel.ISupportInitialize)orderInfoGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)currentOrders).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView orderInfoGridView;
        private MenuStrip menuStrip1;
        private DataGridView currentOrders;
        private Button button1;
    }
}