namespace Program
{
    partial class Form1
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
            dgwCustomer = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgwCustomer).BeginInit();
            SuspendLayout();
            // 
            // dgwCustomer
            // 
            dgwCustomer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgwCustomer.Location = new Point(12, 153);
            dgwCustomer.Name = "dgwCustomer";
            dgwCustomer.RowTemplate.Height = 25;
            dgwCustomer.Size = new Size(776, 150);
            dgwCustomer.TabIndex = 0;
            dgwCustomer.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgwCustomer);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgwCustomer).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgwCustomer;
    }
}