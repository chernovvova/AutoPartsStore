namespace AutoPartsStore
{
    partial class ClientsForm
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
            clientsGridView = new DataGridView();
            menuStrip1 = new MenuStrip();
            createToolStripMenuItem = new ToolStripMenuItem();
            updateToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            telephone = new TextBox();
            email = new TextBox();
            name = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)clientsGridView).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // clientsGridView
            // 
            clientsGridView.AllowDrop = true;
            clientsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            clientsGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            clientsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            clientsGridView.Location = new Point(0, 27);
            clientsGridView.Name = "clientsGridView";
            clientsGridView.Size = new Size(677, 283);
            clientsGridView.TabIndex = 0;
            clientsGridView.CellContentClick += clientsGridView_CellContentClick;
            clientsGridView.SelectionChanged += clientsGridView_SelectionChanged;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { createToolStripMenuItem, updateToolStripMenuItem, deleteToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1078, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // createToolStripMenuItem
            // 
            createToolStripMenuItem.Name = "createToolStripMenuItem";
            createToolStripMenuItem.Size = new Size(71, 20);
            createToolStripMenuItem.Text = "Добавить";
            createToolStripMenuItem.Click += createToolStripMenuItem_Click;
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
            // telephone
            // 
            telephone.Location = new Point(794, 159);
            telephone.Name = "telephone";
            telephone.Size = new Size(198, 23);
            telephone.TabIndex = 3;
            // 
            // email
            // 
            email.Location = new Point(794, 221);
            email.Name = "email";
            email.Size = new Size(198, 23);
            email.TabIndex = 4;
            // 
            // name
            // 
            name.Location = new Point(794, 94);
            name.Name = "name";
            name.Size = new Size(198, 23);
            name.TabIndex = 5;
            name.TextChanged += textBox3_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(794, 27);
            label1.Name = "label1";
            label1.Size = new Size(217, 25);
            label1.TabIndex = 6;
            label1.Text = "Информация о клиенте";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(794, 76);
            label2.Name = "label2";
            label2.Size = new Size(78, 15);
            label2.TabIndex = 7;
            label2.Text = "Имя клиента";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(794, 141);
            label3.Name = "label3";
            label3.Size = new Size(101, 15);
            label3.TabIndex = 8;
            label3.Text = "Номер телефона";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(794, 203);
            label4.Name = "label4";
            label4.Size = new Size(41, 15);
            label4.TabIndex = 9;
            label4.Text = "Почта";
            // 
            // ClientsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1078, 598);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(name);
            Controls.Add(email);
            Controls.Add(telephone);
            Controls.Add(menuStrip1);
            Controls.Add(clientsGridView);
            MainMenuStrip = menuStrip1;
            Name = "ClientsForm";
            Text = "Clients";
            Load += ClientsForm_Load;
            ((System.ComponentModel.ISupportInitialize)clientsGridView).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem createToolStripMenuItem;
        private ToolStripMenuItem updateToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private TextBox telephone;
        private TextBox email;
        private TextBox name;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private DataGridView clientsGridView;
    }
}