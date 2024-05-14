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
            label1 = new Label();
            SuspendLayout();
            // 
            // clientButton
            // 
            clientButton.Location = new Point(136, 352);
            clientButton.Name = "clientButton";
            clientButton.Size = new Size(124, 73);
            clientButton.TabIndex = 0;
            clientButton.Text = "Клиенты";
            clientButton.UseVisualStyleBackColor = true;
            clientButton.Click += clientButton_Click;
            // 
            // productButton
            // 
            productButton.Location = new Point(276, 352);
            productButton.Name = "productButton";
            productButton.Size = new Size(124, 73);
            productButton.TabIndex = 1;
            productButton.Text = "Товары";
            productButton.UseVisualStyleBackColor = true;
            productButton.Click += productButton_Click;
            // 
            // storageButton
            // 
            storageButton.Location = new Point(421, 352);
            storageButton.Name = "storageButton";
            storageButton.Size = new Size(124, 73);
            storageButton.TabIndex = 2;
            storageButton.Text = "Склад";
            storageButton.UseVisualStyleBackColor = true;
            storageButton.Click += storageButton_Click;
            // 
            // orderButton
            // 
            orderButton.Location = new Point(571, 352);
            orderButton.Name = "orderButton";
            orderButton.Size = new Size(124, 73);
            orderButton.TabIndex = 3;
            orderButton.Text = "Заказы";
            orderButton.UseVisualStyleBackColor = true;
            orderButton.Click += orderButton_Click;
            // 
            // orderInfoButton
            // 
            orderInfoButton.Location = new Point(718, 352);
            orderInfoButton.Name = "orderInfoButton";
            orderInfoButton.Size = new Size(124, 73);
            orderInfoButton.TabIndex = 4;
            orderInfoButton.Text = "Информация о заказах";
            orderInfoButton.UseVisualStyleBackColor = true;
            orderInfoButton.Click += orderInfoButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 35F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(223, 159);
            label1.Name = "label1";
            label1.Size = new Size(535, 62);
            label1.TabIndex = 5;
            label1.Text = "Магазин автозапчастей";
            label1.Click += label1_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(948, 644);
            ControlBox = false;
            Controls.Add(label1);
            Controls.Add(orderInfoButton);
            Controls.Add(orderButton);
            Controls.Add(storageButton);
            Controls.Add(productButton);
            Controls.Add(clientButton);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button clientButton;
        private Button productButton;
        private Button storageButton;
        private Button orderButton;
        private Button orderInfoButton;
        private Label label1;
    }
}
