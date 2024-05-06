namespace AutoPartsStore
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            clientButton = new Button();
            productButton = new Button();
            storageButton = new Button();
            orderButton = new Button();
            orderInfoButton = new Button();
            SuspendLayout();
            // 
            // clientButton
            // 
            clientButton.Location = new Point(87, 247);
            clientButton.Name = "clientButton";
            clientButton.Size = new Size(124, 73);
            clientButton.TabIndex = 0;
            clientButton.Text = "Клиенты";
            clientButton.UseVisualStyleBackColor = true;
            clientButton.Click += clientButton_Click;
            // 
            // productButton
            // 
            productButton.Location = new Point(232, 247);
            productButton.Name = "productButton";
            productButton.Size = new Size(124, 73);
            productButton.TabIndex = 1;
            productButton.Text = "Товары";
            productButton.UseVisualStyleBackColor = true;
            productButton.Click += productButton_Click;
            // 
            // storageButton
            // 
            storageButton.Location = new Point(382, 247);
            storageButton.Name = "storageButton";
            storageButton.Size = new Size(124, 73);
            storageButton.TabIndex = 2;
            storageButton.Text = "Склад";
            storageButton.UseVisualStyleBackColor = true;
            storageButton.Click += storageButton_Click;
            // 
            // orderButton
            // 
            orderButton.Location = new Point(535, 247);
            orderButton.Name = "orderButton";
            orderButton.Size = new Size(124, 73);
            orderButton.TabIndex = 3;
            orderButton.Text = "Заказы";
            orderButton.UseVisualStyleBackColor = true;
            orderButton.Click += orderButton_Click;
            // 
            // orderInfoButton
            // 
            orderInfoButton.Location = new Point(700, 247);
            orderInfoButton.Name = "orderInfoButton";
            orderInfoButton.Size = new Size(124, 73);
            orderInfoButton.TabIndex = 4;
            orderInfoButton.Text = "Информация о заказах";
            orderInfoButton.UseVisualStyleBackColor = true;
            orderInfoButton.Click += orderInfoButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1005, 644);
            Controls.Add(orderInfoButton);
            Controls.Add(orderButton);
            Controls.Add(storageButton);
            Controls.Add(productButton);
            Controls.Add(clientButton);
            Name = "MainForm";
            Text = "Main";
            Load += MainForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button clientButton;
        private Button productButton;
        private Button storageButton;
        private Button orderButton;
        private Button orderInfoButton;
    }
}
