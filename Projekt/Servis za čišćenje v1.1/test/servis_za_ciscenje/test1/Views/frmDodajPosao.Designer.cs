namespace servis_za_ciscenje.Views
{
    partial class frmDodajPosao
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxDate = new System.Windows.Forms.TextBox();
            this.tbxVrijeme = new System.Windows.Forms.TextBox();
            this.tbxAdresa = new System.Windows.Forms.TextBox();
            this.tbxKvadratura = new System.Windows.Forms.TextBox();
            this.tbxCijena = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbTip = new System.Windows.Forms.ComboBox();
            this.cmbKlijent = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnOdabirUsluga = new System.Windows.Forms.Button();
            this.btnOdabirRadnika = new System.Windows.Forms.Button();
            this.btnOdabirVozila = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbTrajanje = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbZakazi = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Datum";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(222, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Vrijeme";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(417, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Adresa";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(544, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Veličina prostora";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(315, 336);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ukupna cijena";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(356, 216);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Klijent";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(355, 243);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Tip posla";
            // 
            // tbxDate
            // 
            this.tbxDate.Location = new System.Drawing.Point(68, 12);
            this.tbxDate.Name = "tbxDate";
            this.tbxDate.ReadOnly = true;
            this.tbxDate.Size = new System.Drawing.Size(100, 20);
            this.tbxDate.TabIndex = 7;
            // 
            // tbxVrijeme
            // 
            this.tbxVrijeme.Location = new System.Drawing.Point(276, 11);
            this.tbxVrijeme.Name = "tbxVrijeme";
            this.tbxVrijeme.ReadOnly = true;
            this.tbxVrijeme.Size = new System.Drawing.Size(100, 20);
            this.tbxVrijeme.TabIndex = 8;
            // 
            // tbxAdresa
            // 
            this.tbxAdresa.Location = new System.Drawing.Point(482, 12);
            this.tbxAdresa.Name = "tbxAdresa";
            this.tbxAdresa.ReadOnly = true;
            this.tbxAdresa.Size = new System.Drawing.Size(203, 20);
            this.tbxAdresa.TabIndex = 9;
            // 
            // tbxKvadratura
            // 
            this.tbxKvadratura.Location = new System.Drawing.Point(648, 128);
            this.tbxKvadratura.Name = "tbxKvadratura";
            this.tbxKvadratura.Size = new System.Drawing.Size(55, 20);
            this.tbxKvadratura.TabIndex = 10;
            this.tbxKvadratura.TextChanged += new System.EventHandler(this.tbxKvadratura_TextChanged);
            // 
            // tbxCijena
            // 
            this.tbxCijena.Location = new System.Drawing.Point(419, 333);
            this.tbxCijena.Name = "tbxCijena";
            this.tbxCijena.ReadOnly = true;
            this.tbxCijena.Size = new System.Drawing.Size(55, 20);
            this.tbxCijena.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(716, 131);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "m2";
            // 
            // cmbTip
            // 
            this.cmbTip.FormattingEnabled = true;
            this.cmbTip.Location = new System.Drawing.Point(420, 240);
            this.cmbTip.Name = "cmbTip";
            this.cmbTip.Size = new System.Drawing.Size(121, 21);
            this.cmbTip.TabIndex = 15;
            this.cmbTip.SelectedIndexChanged += new System.EventHandler(this.cmbTip_SelectedIndexChanged);
            // 
            // cmbKlijent
            // 
            this.cmbKlijent.FormattingEnabled = true;
            this.cmbKlijent.Location = new System.Drawing.Point(420, 213);
            this.cmbKlijent.Name = "cmbKlijent";
            this.cmbKlijent.Size = new System.Drawing.Size(121, 21);
            this.cmbKlijent.TabIndex = 16;
            this.cmbKlijent.SelectedIndexChanged += new System.EventHandler(this.cmbKlijent_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(79, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Usluga";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(345, 374);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 52);
            this.button1.TabIndex = 19;
            this.button1.Text = "Dodaj posao";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(487, 336);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Kn";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(564, 54);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "Vozilo";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(302, 54);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 13);
            this.label12.TabIndex = 21;
            this.label12.Text = "Radnik";
            // 
            // btnOdabirUsluga
            // 
            this.btnOdabirUsluga.Location = new System.Drawing.Point(56, 85);
            this.btnOdabirUsluga.Name = "btnOdabirUsluga";
            this.btnOdabirUsluga.Size = new System.Drawing.Size(100, 23);
            this.btnOdabirUsluga.TabIndex = 25;
            this.btnOdabirUsluga.Text = "Odabir usluga";
            this.btnOdabirUsluga.UseVisualStyleBackColor = true;
            this.btnOdabirUsluga.Click += new System.EventHandler(this.btnOdabirUsluga_Click);
            // 
            // btnOdabirRadnika
            // 
            this.btnOdabirRadnika.Location = new System.Drawing.Point(276, 85);
            this.btnOdabirRadnika.Name = "btnOdabirRadnika";
            this.btnOdabirRadnika.Size = new System.Drawing.Size(100, 23);
            this.btnOdabirRadnika.TabIndex = 26;
            this.btnOdabirRadnika.Text = "Odabir Radnika";
            this.btnOdabirRadnika.UseVisualStyleBackColor = true;
            this.btnOdabirRadnika.Click += new System.EventHandler(this.btnOdabirRadnika_Click);
            // 
            // btnOdabirVozila
            // 
            this.btnOdabirVozila.Location = new System.Drawing.Point(529, 85);
            this.btnOdabirVozila.Name = "btnOdabirVozila";
            this.btnOdabirVozila.Size = new System.Drawing.Size(100, 23);
            this.btnOdabirVozila.TabIndex = 27;
            this.btnOdabirVozila.Text = "Odabir vozila";
            this.btnOdabirVozila.UseVisualStyleBackColor = true;
            this.btnOdabirVozila.Click += new System.EventHandler(this.btnOdabirVozila_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(390, 131);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(115, 13);
            this.label13.TabIndex = 28;
            this.label13.Text = "Trajanje posla u satima";
            // 
            // cmbTrajanje
            // 
            this.cmbTrajanje.FormattingEnabled = true;
            this.cmbTrajanje.Location = new System.Drawing.Point(420, 161);
            this.cmbTrajanje.Name = "cmbTrajanje";
            this.cmbTrajanje.Size = new System.Drawing.Size(42, 21);
            this.cmbTrajanje.TabIndex = 29;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(591, 213);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(162, 13);
            this.label14.TabIndex = 30;
            this.label14.Text = "Zakažite termin unaprijed svakih:";
            // 
            // cmbZakazi
            // 
            this.cmbZakazi.FormattingEnabled = true;
            this.cmbZakazi.Location = new System.Drawing.Point(648, 236);
            this.cmbZakazi.Name = "cmbZakazi";
            this.cmbZakazi.Size = new System.Drawing.Size(50, 21);
            this.cmbZakazi.TabIndex = 31;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(27, 152);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 201);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalji o uslugama";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(247, 176);
            this.dataGridView1.TabIndex = 0;
            // 
            // frmDodajPosao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 438);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbZakazi);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cmbTrajanje);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnOdabirVozila);
            this.Controls.Add(this.btnOdabirRadnika);
            this.Controls.Add(this.btnOdabirUsluga);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbKlijent);
            this.Controls.Add(this.cmbTip);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbxCijena);
            this.Controls.Add(this.tbxKvadratura);
            this.Controls.Add(this.tbxAdresa);
            this.Controls.Add(this.tbxVrijeme);
            this.Controls.Add(this.tbxDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmDodajPosao";
            this.Text = "Dodaj posao";
            this.Load += new System.EventHandler(this.frmDodajPosao_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbxDate;
        private System.Windows.Forms.TextBox tbxVrijeme;
        private System.Windows.Forms.TextBox tbxAdresa;
        private System.Windows.Forms.TextBox tbxKvadratura;
        private System.Windows.Forms.TextBox tbxCijena;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbTip;
        private System.Windows.Forms.ComboBox cmbKlijent;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnOdabirUsluga;
        private System.Windows.Forms.Button btnOdabirRadnika;
        private System.Windows.Forms.Button btnOdabirVozila;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbTrajanje;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbZakazi;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}