namespace AutoPartsStore
{
    partial class StorageForm
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
            dataGridView1 = new DataGridView();
            menuStrip1 = new MenuStrip();
            updateToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            product_name = new TextBox();
            product_price = new TextBox();
            product_description = new RichTextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            count = new TextBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 27);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(481, 258);
            dataGridView1.TabIndex = 0;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { updateToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1010, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // updateToolStripMenuItem
            // 
            updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            updateToolStripMenuItem.Size = new Size(73, 20);
            updateToolStripMenuItem.Text = "Обновить";
            updateToolStripMenuItem.Click += updateToolStripMenuItem_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(661, 24);
            label1.Name = "label1";
            label1.Size = new Size(208, 25);
            label1.TabIndex = 2;
            label1.Text = "Информация о товаре";
            label1.Click += label1_Click;
            // 
            // product_name
            // 
            product_name.Location = new Point(661, 85);
            product_name.Name = "product_name";
            product_name.Size = new Size(156, 23);
            product_name.TabIndex = 3;
            // 
            // product_price
            // 
            product_price.Location = new Point(661, 270);
            product_price.Name = "product_price";
            product_price.Size = new Size(156, 23);
            product_price.TabIndex = 4;
            // 
            // product_description
            // 
            product_description.Location = new Point(661, 136);
            product_description.Name = "product_description";
            product_description.Size = new Size(156, 96);
            product_description.TabIndex = 5;
            product_description.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(661, 67);
            label2.Name = "label2";
            label2.Size = new Size(99, 15);
            label2.TabIndex = 6;
            label2.Text = "Название товара";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(661, 118);
            label3.Name = "label3";
            label3.Size = new Size(102, 15);
            label3.TabIndex = 7;
            label3.Text = "Описание товара";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(661, 252);
            label4.Name = "label4";
            label4.Size = new Size(86, 15);
            label4.TabIndex = 8;
            label4.Text = "Цена за штуку";
            // 
            // count
            // 
            count.Location = new Point(12, 329);
            count.Name = "count";
            count.Size = new Size(153, 23);
            count.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 311);
            label5.Name = "label5";
            label5.Size = new Size(112, 15);
            label5.TabIndex = 12;
            label5.Text = "Количество товара";
            // 
            // StorageForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1010, 509);
            Controls.Add(label5);
            Controls.Add(count);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(product_description);
            Controls.Add(product_price);
            Controls.Add(product_name);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "StorageForm";
            Text = "StorageForm";
            Load += StorageForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem updateToolStripMenuItem;
        private Label label1;
        private TextBox product_name;
        private TextBox product_price;
        private RichTextBox product_description;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox count;
        private Label label5;
    }
}