namespace servis_za_ciscenje.Views
{
    partial class frmSifrarnik
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
            this.tctSifarnik = new System.Windows.Forms.TabControl();
            this.tabRadnici = new System.Windows.Forms.TabPage();
            this.tabVozila = new System.Windows.Forms.TabPage();
            this.tabKlijenti = new System.Windows.Forms.TabPage();
            this.tabUsluge = new System.Windows.Forms.TabPage();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.btnIzlaz = new System.Windows.Forms.Button();
            this.btnAzuriraj = new System.Windows.Forms.Button();
            this.btnBrisi = new System.Windows.Forms.Button();
            this.dgdRadnici = new System.Windows.Forms.DataGridView();
            this.dgdVozila = new System.Windows.Forms.DataGridView();
            this.dgdKlijenti = new System.Windows.Forms.DataGridView();
            this.dgdUsluge = new System.Windows.Forms.DataGridView();
            this.tctSifarnik.SuspendLayout();
            this.tabRadnici.SuspendLayout();
            this.tabVozila.SuspendLayout();
            this.tabKlijenti.SuspendLayout();
            this.tabUsluge.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgdRadnici)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgdVozila)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgdKlijenti)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgdUsluge)).BeginInit();
            this.SuspendLayout();
            // 
            // tctSifarnik
            // 
            this.tctSifarnik.Controls.Add(this.tabRadnici);
            this.tctSifarnik.Controls.Add(this.tabVozila);
            this.tctSifarnik.Controls.Add(this.tabKlijenti);
            this.tctSifarnik.Controls.Add(this.tabUsluge);
            this.tctSifarnik.Location = new System.Drawing.Point(13, 62);
            this.tctSifarnik.Name = "tctSifarnik";
            this.tctSifarnik.SelectedIndex = 0;
            this.tctSifarnik.Size = new System.Drawing.Size(404, 227);
            this.tctSifarnik.TabIndex = 0;
            // 
            // tabRadnici
            // 
            this.tabRadnici.Controls.Add(this.dgdRadnici);
            this.tabRadnici.Location = new System.Drawing.Point(4, 22);
            this.tabRadnici.Name = "tabRadnici";
            this.tabRadnici.Padding = new System.Windows.Forms.Padding(3);
            this.tabRadnici.Size = new System.Drawing.Size(396, 201);
            this.tabRadnici.TabIndex = 0;
            this.tabRadnici.Text = "Radnici";
            this.tabRadnici.UseVisualStyleBackColor = true;
            // 
            // tabVozila
            // 
            this.tabVozila.Controls.Add(this.dgdVozila);
            this.tabVozila.Location = new System.Drawing.Point(4, 22);
            this.tabVozila.Name = "tabVozila";
            this.tabVozila.Padding = new System.Windows.Forms.Padding(3);
            this.tabVozila.Size = new System.Drawing.Size(396, 201);
            this.tabVozila.TabIndex = 1;
            this.tabVozila.Text = "Vozila";
            this.tabVozila.UseVisualStyleBackColor = true;
            // 
            // tabKlijenti
            // 
            this.tabKlijenti.Controls.Add(this.dgdKlijenti);
            this.tabKlijenti.Location = new System.Drawing.Point(4, 22);
            this.tabKlijenti.Name = "tabKlijenti";
            this.tabKlijenti.Size = new System.Drawing.Size(396, 201);
            this.tabKlijenti.TabIndex = 2;
            this.tabKlijenti.Text = "Klijenti";
            this.tabKlijenti.UseVisualStyleBackColor = true;
            // 
            // tabUsluge
            // 
            this.tabUsluge.Controls.Add(this.dgdUsluge);
            this.tabUsluge.Location = new System.Drawing.Point(4, 22);
            this.tabUsluge.Name = "tabUsluge";
            this.tabUsluge.Size = new System.Drawing.Size(396, 201);
            this.tabUsluge.TabIndex = 3;
            this.tabUsluge.Text = "Usluge";
            this.tabUsluge.UseVisualStyleBackColor = true;
            // 
            // btnDodaj
            // 
            this.btnDodaj.Location = new System.Drawing.Point(13, 13);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(75, 23);
            this.btnDodaj.TabIndex = 1;
            this.btnDodaj.Text = "Dodaj";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // btnIzlaz
            // 
            this.btnIzlaz.Location = new System.Drawing.Point(338, 13);
            this.btnIzlaz.Name = "btnIzlaz";
            this.btnIzlaz.Size = new System.Drawing.Size(75, 23);
            this.btnIzlaz.TabIndex = 2;
            this.btnIzlaz.Text = "Izlaz";
            this.btnIzlaz.UseVisualStyleBackColor = true;
            this.btnIzlaz.Click += new System.EventHandler(this.btnIzlaz_Click);
            // 
            // btnAzuriraj
            // 
            this.btnAzuriraj.Location = new System.Drawing.Point(223, 13);
            this.btnAzuriraj.Name = "btnAzuriraj";
            this.btnAzuriraj.Size = new System.Drawing.Size(75, 23);
            this.btnAzuriraj.TabIndex = 3;
            this.btnAzuriraj.Text = "Ažuriraj";
            this.btnAzuriraj.UseVisualStyleBackColor = true;
            this.btnAzuriraj.Click += new System.EventHandler(this.btnAzuriraj_Click);
            // 
            // btnBrisi
            // 
            this.btnBrisi.Location = new System.Drawing.Point(116, 13);
            this.btnBrisi.Name = "btnBrisi";
            this.btnBrisi.Size = new System.Drawing.Size(75, 23);
            this.btnBrisi.TabIndex = 4;
            this.btnBrisi.Text = "Briši";
            this.btnBrisi.UseVisualStyleBackColor = true;
            this.btnBrisi.Click += new System.EventHandler(this.btnBrisi_Click);
            // 
            // dgdRadnici
            // 
            this.dgdRadnici.AllowUserToAddRows = false;
            this.dgdRadnici.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgdRadnici.Location = new System.Drawing.Point(3, 3);
            this.dgdRadnici.Name = "dgdRadnici";
            this.dgdRadnici.ReadOnly = true;
            this.dgdRadnici.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgdRadnici.Size = new System.Drawing.Size(387, 195);
            this.dgdRadnici.TabIndex = 0;
            // 
            // dgdVozila
            // 
            this.dgdVozila.AllowUserToAddRows = false;
            this.dgdVozila.AllowUserToResizeColumns = false;
            this.dgdVozila.AllowUserToResizeRows = false;
            this.dgdVozila.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgdVozila.Location = new System.Drawing.Point(5, 3);
            this.dgdVozila.Name = "dgdVozila";
            this.dgdVozila.ReadOnly = true;
            this.dgdVozila.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgdVozila.Size = new System.Drawing.Size(387, 195);
            this.dgdVozila.TabIndex = 1;
            // 
            // dgdKlijenti
            // 
            this.dgdKlijenti.AllowUserToAddRows = false;
            this.dgdKlijenti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgdKlijenti.Location = new System.Drawing.Point(5, 3);
            this.dgdKlijenti.Name = "dgdKlijenti";
            this.dgdKlijenti.ReadOnly = true;
            this.dgdKlijenti.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgdKlijenti.Size = new System.Drawing.Size(387, 195);
            this.dgdKlijenti.TabIndex = 1;
            // 
            // dgdUsluge
            // 
            this.dgdUsluge.AllowUserToAddRows = false;
            this.dgdUsluge.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgdUsluge.Location = new System.Drawing.Point(5, 3);
            this.dgdUsluge.Name = "dgdUsluge";
            this.dgdUsluge.ReadOnly = true;
            this.dgdUsluge.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgdUsluge.Size = new System.Drawing.Size(387, 195);
            this.dgdUsluge.TabIndex = 1;
            // 
            // frmSifrarnik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 301);
            this.Controls.Add(this.btnBrisi);
            this.Controls.Add(this.btnAzuriraj);
            this.Controls.Add(this.btnIzlaz);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.tctSifarnik);
            this.Name = "frmSifrarnik";
            this.Text = "Šifrarnik";
            this.Load += new System.EventHandler(this.frmSifrarnik_Load);
            this.tctSifarnik.ResumeLayout(false);
            this.tabRadnici.ResumeLayout(false);
            this.tabVozila.ResumeLayout(false);
            this.tabKlijenti.ResumeLayout(false);
            this.tabUsluge.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgdRadnici)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgdVozila)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgdKlijenti)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgdUsluge)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tctSifarnik;
        private System.Windows.Forms.TabPage tabRadnici;
        private System.Windows.Forms.TabPage tabVozila;
        private System.Windows.Forms.TabPage tabKlijenti;
        private System.Windows.Forms.TabPage tabUsluge;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Button btnIzlaz;
        private System.Windows.Forms.Button btnAzuriraj;
        private System.Windows.Forms.Button btnBrisi;
        private System.Windows.Forms.DataGridView dgdRadnici;
        private System.Windows.Forms.DataGridView dgdVozila;
        private System.Windows.Forms.DataGridView dgdKlijenti;
        private System.Windows.Forms.DataGridView dgdUsluge;
    }
}