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
            ((System.ComponentModel.ISupportInitialize)orderInfoGridView).BeginInit();
            SuspendLayout();
            // 
            // orderInfoGridView
            // 
            orderInfoGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            orderInfoGridView.Location = new Point(0, 27);
            orderInfoGridView.Name = "orderInfoGridView";
            orderInfoGridView.Size = new Size(585, 303);
            orderInfoGridView.TabIndex = 0;
            orderInfoGridView.CellContentClick += dataGridView1_CellContentClick;
            // 
            // menuStrip1
            // 
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1189, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // OrderInfoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1189, 623);
            Controls.Add(orderInfoGridView);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "OrderInfoForm";
            Text = "OrderInfoForm";
            ((System.ComponentModel.ISupportInitialize)orderInfoGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView orderInfoGridView;
        private MenuStrip menuStrip1;
    }
}