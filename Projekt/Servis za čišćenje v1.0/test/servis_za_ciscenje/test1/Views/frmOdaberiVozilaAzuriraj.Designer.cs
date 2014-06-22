namespace servis_za_ciscenje.Views
{
    partial class frmOdaberiVozilaAzuriraj
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnOdabir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(2, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(349, 224);
            this.dataGridView1.TabIndex = 3;
            // 
            // btnOdabir
            // 
            this.btnOdabir.Location = new System.Drawing.Point(111, 241);
            this.btnOdabir.Name = "btnOdabir";
            this.btnOdabir.Size = new System.Drawing.Size(107, 44);
            this.btnOdabir.TabIndex = 2;
            this.btnOdabir.Text = "Odaberi vozila";
            this.btnOdabir.UseVisualStyleBackColor = true;
            this.btnOdabir.Click += new System.EventHandler(this.btnOdabir_Click);
            // 
            // frmOdaberiVozilaAzuriraj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 297);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnOdabir);
            this.Name = "frmOdaberiVozilaAzuriraj";
            this.Text = "Odaberi vozila";
            this.Load += new System.EventHandler(this.frmOdaberiVozilaAzuriraj_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnOdabir;
    }
}