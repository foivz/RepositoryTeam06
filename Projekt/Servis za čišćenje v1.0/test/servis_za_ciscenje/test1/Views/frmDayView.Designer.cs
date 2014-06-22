namespace servis_za_ciscenje.Views
{
    partial class frmDayView
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
            this.btnDodaj = new System.Windows.Forms.Button();
            this.btnIzlaz = new System.Windows.Forms.Button();
            this.btnIzbrisi = new System.Windows.Forms.Button();
            this.btnUredi = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tbxDatum = new System.Windows.Forms.TextBox();
            this.cmb0 = new System.Windows.Forms.ComboBox();
            this.cmb1 = new System.Windows.Forms.ComboBox();
            this.cmb2 = new System.Windows.Forms.ComboBox();
            this.cmb3 = new System.Windows.Forms.ComboBox();
            this.cmb8 = new System.Windows.Forms.ComboBox();
            this.cmb7 = new System.Windows.Forms.ComboBox();
            this.cmb6 = new System.Windows.Forms.ComboBox();
            this.cmb5 = new System.Windows.Forms.ComboBox();
            this.cmb4 = new System.Windows.Forms.ComboBox();
            this.cmb11 = new System.Windows.Forms.ComboBox();
            this.cmb10 = new System.Windows.Forms.ComboBox();
            this.cmb9 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDodaj
            // 
            this.btnDodaj.Location = new System.Drawing.Point(26, 54);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(75, 23);
            this.btnDodaj.TabIndex = 0;
            this.btnDodaj.Text = "Dodaj";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // btnIzlaz
            // 
            this.btnIzlaz.Location = new System.Drawing.Point(402, 53);
            this.btnIzlaz.Name = "btnIzlaz";
            this.btnIzlaz.Size = new System.Drawing.Size(75, 23);
            this.btnIzlaz.TabIndex = 2;
            this.btnIzlaz.Text = "Izlaz";
            this.btnIzlaz.UseVisualStyleBackColor = true;
            this.btnIzlaz.Click += new System.EventHandler(this.btnIzlaz_Click);
            // 
            // btnIzbrisi
            // 
            this.btnIzbrisi.Location = new System.Drawing.Point(287, 54);
            this.btnIzbrisi.Name = "btnIzbrisi";
            this.btnIzbrisi.Size = new System.Drawing.Size(75, 23);
            this.btnIzbrisi.TabIndex = 3;
            this.btnIzbrisi.Text = "Izbriši";
            this.btnIzbrisi.UseVisualStyleBackColor = true;
            this.btnIzbrisi.Click += new System.EventHandler(this.btnIzbrisi_Click);
            // 
            // btnUredi
            // 
            this.btnUredi.Location = new System.Drawing.Point(156, 53);
            this.btnUredi.Name = "btnUredi";
            this.btnUredi.Size = new System.Drawing.Size(75, 23);
            this.btnUredi.TabIndex = 4;
            this.btnUredi.Text = "Uredi";
            this.btnUredi.UseVisualStyleBackColor = true;
            this.btnUredi.Click += new System.EventHandler(this.btnUredi_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 91);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(655, 359);
            this.dataGridView1.TabIndex = 5;
            // 
            // tbxDatum
            // 
            this.tbxDatum.Location = new System.Drawing.Point(201, 12);
            this.tbxDatum.Name = "tbxDatum";
            this.tbxDatum.ReadOnly = true;
            this.tbxDatum.Size = new System.Drawing.Size(103, 20);
            this.tbxDatum.TabIndex = 6;
            // 
            // cmb0
            // 
            this.cmb0.FormattingEnabled = true;
            this.cmb0.Location = new System.Drawing.Point(659, 117);
            this.cmb0.Name = "cmb0";
            this.cmb0.Size = new System.Drawing.Size(335, 21);
            this.cmb0.TabIndex = 8;
            this.cmb0.SelectedIndexChanged += new System.EventHandler(this.cmb0_SelectedIndexChanged);
            // 
            // cmb1
            // 
            this.cmb1.FormattingEnabled = true;
            this.cmb1.Location = new System.Drawing.Point(659, 144);
            this.cmb1.Name = "cmb1";
            this.cmb1.Size = new System.Drawing.Size(335, 21);
            this.cmb1.TabIndex = 9;
            this.cmb1.SelectedIndexChanged += new System.EventHandler(this.cmb1_SelectedIndexChanged);
            // 
            // cmb2
            // 
            this.cmb2.FormattingEnabled = true;
            this.cmb2.Location = new System.Drawing.Point(659, 171);
            this.cmb2.Name = "cmb2";
            this.cmb2.Size = new System.Drawing.Size(335, 21);
            this.cmb2.TabIndex = 10;
            this.cmb2.SelectedIndexChanged += new System.EventHandler(this.cmb2_SelectedIndexChanged);
            // 
            // cmb3
            // 
            this.cmb3.FormattingEnabled = true;
            this.cmb3.Location = new System.Drawing.Point(659, 198);
            this.cmb3.Name = "cmb3";
            this.cmb3.Size = new System.Drawing.Size(335, 21);
            this.cmb3.TabIndex = 11;
            this.cmb3.SelectedIndexChanged += new System.EventHandler(this.cmb3_SelectedIndexChanged);
            // 
            // cmb8
            // 
            this.cmb8.FormattingEnabled = true;
            this.cmb8.Location = new System.Drawing.Point(659, 333);
            this.cmb8.Name = "cmb8";
            this.cmb8.Size = new System.Drawing.Size(335, 21);
            this.cmb8.TabIndex = 16;
            this.cmb8.SelectedIndexChanged += new System.EventHandler(this.cmb8_SelectedIndexChanged);
            // 
            // cmb7
            // 
            this.cmb7.FormattingEnabled = true;
            this.cmb7.Location = new System.Drawing.Point(659, 306);
            this.cmb7.Name = "cmb7";
            this.cmb7.Size = new System.Drawing.Size(335, 21);
            this.cmb7.TabIndex = 15;
            this.cmb7.SelectedIndexChanged += new System.EventHandler(this.cmb7_SelectedIndexChanged);
            // 
            // cmb6
            // 
            this.cmb6.FormattingEnabled = true;
            this.cmb6.Location = new System.Drawing.Point(659, 279);
            this.cmb6.Name = "cmb6";
            this.cmb6.Size = new System.Drawing.Size(335, 21);
            this.cmb6.TabIndex = 14;
            this.cmb6.SelectedIndexChanged += new System.EventHandler(this.cmb6_SelectedIndexChanged);
            // 
            // cmb5
            // 
            this.cmb5.FormattingEnabled = true;
            this.cmb5.Location = new System.Drawing.Point(659, 252);
            this.cmb5.Name = "cmb5";
            this.cmb5.Size = new System.Drawing.Size(335, 21);
            this.cmb5.TabIndex = 13;
            this.cmb5.SelectedIndexChanged += new System.EventHandler(this.cmb5_SelectedIndexChanged);
            // 
            // cmb4
            // 
            this.cmb4.FormattingEnabled = true;
            this.cmb4.Location = new System.Drawing.Point(659, 225);
            this.cmb4.Name = "cmb4";
            this.cmb4.Size = new System.Drawing.Size(335, 21);
            this.cmb4.TabIndex = 12;
            this.cmb4.SelectedIndexChanged += new System.EventHandler(this.cmb4_SelectedIndexChanged);
            // 
            // cmb11
            // 
            this.cmb11.FormattingEnabled = true;
            this.cmb11.Location = new System.Drawing.Point(659, 414);
            this.cmb11.Name = "cmb11";
            this.cmb11.Size = new System.Drawing.Size(335, 21);
            this.cmb11.TabIndex = 19;
            this.cmb11.SelectedIndexChanged += new System.EventHandler(this.cmb11_SelectedIndexChanged);
            // 
            // cmb10
            // 
            this.cmb10.FormattingEnabled = true;
            this.cmb10.Location = new System.Drawing.Point(659, 387);
            this.cmb10.Name = "cmb10";
            this.cmb10.Size = new System.Drawing.Size(335, 21);
            this.cmb10.TabIndex = 18;
            this.cmb10.SelectedIndexChanged += new System.EventHandler(this.cmb10_SelectedIndexChanged);
            // 
            // cmb9
            // 
            this.cmb9.FormattingEnabled = true;
            this.cmb9.Location = new System.Drawing.Point(659, 360);
            this.cmb9.Name = "cmb9";
            this.cmb9.Size = new System.Drawing.Size(335, 21);
            this.cmb9.TabIndex = 17;
            this.cmb9.SelectedIndexChanged += new System.EventHandler(this.cmb9_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(544, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 55);
            this.button1.TabIndex = 20;
            this.button1.Text = "Napravi račun";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmDayView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 470);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmb11);
            this.Controls.Add(this.cmb10);
            this.Controls.Add(this.cmb9);
            this.Controls.Add(this.cmb8);
            this.Controls.Add(this.cmb7);
            this.Controls.Add(this.cmb6);
            this.Controls.Add(this.cmb5);
            this.Controls.Add(this.cmb4);
            this.Controls.Add(this.cmb3);
            this.Controls.Add(this.cmb2);
            this.Controls.Add(this.cmb1);
            this.Controls.Add(this.cmb0);
            this.Controls.Add(this.tbxDatum);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnUredi);
            this.Controls.Add(this.btnIzbrisi);
            this.Controls.Add(this.btnIzlaz);
            this.Controls.Add(this.btnDodaj);
            this.Name = "frmDayView";
            this.Text = "Pregled po danu";
            this.Load += new System.EventHandler(this.frmDayView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Button btnIzlaz;
        private System.Windows.Forms.Button btnIzbrisi;
        private System.Windows.Forms.Button btnUredi;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox tbxDatum;
        private System.Windows.Forms.ComboBox cmb0;
        private System.Windows.Forms.ComboBox cmb1;
        private System.Windows.Forms.ComboBox cmb2;
        private System.Windows.Forms.ComboBox cmb3;
        private System.Windows.Forms.ComboBox cmb8;
        private System.Windows.Forms.ComboBox cmb7;
        private System.Windows.Forms.ComboBox cmb6;
        private System.Windows.Forms.ComboBox cmb5;
        private System.Windows.Forms.ComboBox cmb4;
        private System.Windows.Forms.ComboBox cmb11;
        private System.Windows.Forms.ComboBox cmb10;
        private System.Windows.Forms.ComboBox cmb9;
        private System.Windows.Forms.Button button1;
    }
}