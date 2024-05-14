namespace AutoPartsStore
{
    partial class AddClientForm
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
            name = new TextBox();
            telephone = new TextBox();
            email = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            addButton = new Button();
            clearButton = new Button();
            label4 = new Label();
            SuspendLayout();
            // 
            // name
            // 
            name.Location = new Point(308, 149);
            name.Name = "name";
            name.Size = new Size(160, 23);
            name.TabIndex = 0;
            // 
            // telephone
            // 
            telephone.Location = new Point(308, 206);
            telephone.Name = "telephone";
            telephone.Size = new Size(160, 23);
            telephone.TabIndex = 1;
            // 
            // email
            // 
            email.Location = new Point(308, 264);
            email.Name = "email";
            email.Size = new Size(160, 23);
            email.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(308, 131);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 3;
            label1.Text = "Имя";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(308, 188);
            label2.Name = "label2";
            label2.Size = new Size(101, 15);
            label2.TabIndex = 4;
            label2.Text = "Номер телефона";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(308, 246);
            label3.Name = "label3";
            label3.Size = new Size(41, 15);
            label3.TabIndex = 5;
            label3.Text = "Почта";
            // 
            // addButton
            // 
            addButton.Location = new Point(264, 320);
            addButton.Name = "addButton";
            addButton.Size = new Size(75, 23);
            addButton.TabIndex = 6;
            addButton.Text = "Добавить";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // clearButton
            // 
            clearButton.Location = new Point(436, 320);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(75, 23);
            clearButton.TabIndex = 7;
            clearButton.Text = "Отмена";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += clearButton_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(298, 82);
            label4.Name = "label4";
            label4.Size = new Size(170, 25);
            label4.TabIndex = 8;
            label4.Text = "Добавить клиента";
            // 
            // AddClientForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(clearButton);
            Controls.Add(addButton);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(email);
            Controls.Add(telephone);
            Controls.Add(name);
            Name = "AddClientForm";
            Text = "AddClientForm";
            Load += AddClientForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox name;
        private TextBox telephone;
        private TextBox email;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button addButton;
        private Button clearButton;
        private Label label4;
    }
}