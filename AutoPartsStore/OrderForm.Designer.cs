namespace AutoPartsStore
{
    partial class OrderForm
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
            orderGridView = new DataGridView();
            productGridView = new DataGridView();
            menuStrip1 = new MenuStrip();
            addToolStripMenuItem = new ToolStripMenuItem();
            updateToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            clientsComboBox = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            productComboBox = new ComboBox();
            addProductButton = new Button();
            countProductTextBox = new TextBox();
            sumTextBox = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            addressTextBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)orderGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)productGridView).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // orderGridView
            // 
            orderGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            orderGridView.Location = new Point(0, 87);
            orderGridView.Name = "orderGridView";
            orderGridView.Size = new Size(493, 190);
            orderGridView.TabIndex = 0;
            orderGridView.CellContentClick += orderGridView_CellContentClick;
            orderGridView.SelectionChanged += orderGridView_SelectionChanged;
            // 
            // productGridView
            // 
            productGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            productGridView.Location = new Point(688, 87);
            productGridView.Name = "productGridView";
            productGridView.Size = new Size(492, 190);
            productGridView.TabIndex = 1;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { addToolStripMenuItem, updateToolStripMenuItem, deleteToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1180, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // addToolStripMenuItem
            // 
            addToolStripMenuItem.Name = "addToolStripMenuItem";
            addToolStripMenuItem.Size = new Size(71, 20);
            addToolStripMenuItem.Text = "Добавить";
            addToolStripMenuItem.Click += addToolStripMenuItem_Click;
            // 
            // updateToolStripMenuItem
            // 
            updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            updateToolStripMenuItem.Size = new Size(73, 20);
            updateToolStripMenuItem.Text = "Обновить";
            updateToolStripMenuItem.Click += updateToolStripMenuItem_Click;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(63, 20);
            deleteToolStripMenuItem.Text = "Удалить";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // clientsComboBox
            // 
            clientsComboBox.FormattingEnabled = true;
            clientsComboBox.Location = new Point(12, 320);
            clientsComboBox.Name = "clientsComboBox";
            clientsComboBox.Size = new Size(144, 23);
            clientsComboBox.TabIndex = 3;
            clientsComboBox.SelectedIndexChanged += clientsComboBox_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 302);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 4;
            label1.Text = "Клиент";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(688, 302);
            label2.Name = "label2";
            label2.Size = new Size(48, 15);
            label2.TabIndex = 6;
            label2.Text = "Товары";
            // 
            // productComboBox
            // 
            productComboBox.FormattingEnabled = true;
            productComboBox.Location = new Point(688, 320);
            productComboBox.Name = "productComboBox";
            productComboBox.Size = new Size(121, 23);
            productComboBox.TabIndex = 5;
            productComboBox.SelectedIndexChanged += productComboBox_SelectedIndexChanged;
            // 
            // addProductButton
            // 
            addProductButton.Location = new Point(688, 360);
            addProductButton.Name = "addProductButton";
            addProductButton.Size = new Size(172, 29);
            addProductButton.TabIndex = 7;
            addProductButton.Text = "Добавить товар";
            addProductButton.UseVisualStyleBackColor = true;
            addProductButton.Click += addProductButton_Click;
            // 
            // countProductTextBox
            // 
            countProductTextBox.Location = new Point(854, 320);
            countProductTextBox.Name = "countProductTextBox";
            countProductTextBox.Size = new Size(122, 23);
            countProductTextBox.TabIndex = 8;
            countProductTextBox.TextChanged += countProductTextBox_TextChanged;
            // 
            // sumTextBox
            // 
            sumTextBox.Location = new Point(1009, 320);
            sumTextBox.Name = "sumTextBox";
            sumTextBox.ReadOnly = true;
            sumTextBox.Size = new Size(122, 23);
            sumTextBox.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(854, 302);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 10;
            label3.Text = "Количество";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1009, 302);
            label4.Name = "label4";
            label4.Size = new Size(45, 15);
            label4.TabIndex = 11;
            label4.Text = "Сумма";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(191, 302);
            label5.Name = "label5";
            label5.Size = new Size(40, 15);
            label5.TabIndex = 12;
            label5.Text = "Адрес";
            // 
            // addressTextBox
            // 
            addressTextBox.Location = new Point(191, 320);
            addressTextBox.Name = "addressTextBox";
            addressTextBox.Size = new Size(135, 23);
            addressTextBox.TabIndex = 13;
            // 
            // OrderForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1180, 558);
            Controls.Add(addressTextBox);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(sumTextBox);
            Controls.Add(countProductTextBox);
            Controls.Add(addProductButton);
            Controls.Add(label2);
            Controls.Add(productComboBox);
            Controls.Add(label1);
            Controls.Add(clientsComboBox);
            Controls.Add(productGridView);
            Controls.Add(orderGridView);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "OrderForm";
            Text = "OrderForm";
            Load += OrderForm_Load;
            ((System.ComponentModel.ISupportInitialize)orderGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)productGridView).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView orderGridView;
        private DataGridView productGridView;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem addToolStripMenuItem;
        private ToolStripMenuItem updateToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ComboBox clientsComboBox;
        private Label label1;
        private Label label2;
        private ComboBox productComboBox;
        private Button addProductButton;
        private TextBox countProductTextBox;
        private TextBox sumTextBox;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox addressTextBox;
    }
}