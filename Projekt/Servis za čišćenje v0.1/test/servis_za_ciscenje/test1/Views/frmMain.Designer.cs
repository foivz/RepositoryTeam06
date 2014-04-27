namespace servis_za_ciscenje
{
    partial class frmMain
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
            this.btnSifrarnik = new System.Windows.Forms.Button();
            this.btnCloseMain = new System.Windows.Forms.Button();
            this.grpTermini = new System.Windows.Forms.GroupBox();
            this.calKalendar = new System.Windows.Forms.MonthCalendar();
            this.grpTermini.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSifrarnik
            // 
            this.btnSifrarnik.Location = new System.Drawing.Point(18, 12);
            this.btnSifrarnik.Name = "btnSifrarnik";
            this.btnSifrarnik.Size = new System.Drawing.Size(125, 59);
            this.btnSifrarnik.TabIndex = 1;
            this.btnSifrarnik.Text = "Šifrarnik";
            this.btnSifrarnik.UseVisualStyleBackColor = true;
            this.btnSifrarnik.Click += new System.EventHandler(this.btnSifrarnik_Click);
            // 
            // btnCloseMain
            // 
            this.btnCloseMain.Location = new System.Drawing.Point(484, 12);
            this.btnCloseMain.Name = "btnCloseMain";
            this.btnCloseMain.Size = new System.Drawing.Size(125, 59);
            this.btnCloseMain.TabIndex = 4;
            this.btnCloseMain.Text = "Izlaz";
            this.btnCloseMain.UseVisualStyleBackColor = true;
            this.btnCloseMain.Click += new System.EventHandler(this.btnCloseMain_Click);
            // 
            // grpTermini
            // 
            this.grpTermini.Controls.Add(this.calKalendar);
            this.grpTermini.Location = new System.Drawing.Point(12, 95);
            this.grpTermini.Name = "grpTermini";
            this.grpTermini.Size = new System.Drawing.Size(631, 330);
            this.grpTermini.TabIndex = 5;
            this.grpTermini.TabStop = false;
            this.grpTermini.Text = "Popis termina";
            // 
            // calKalendar
            // 
            this.calKalendar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.calKalendar.CalendarDimensions = new System.Drawing.Size(3, 2);
            this.calKalendar.Location = new System.Drawing.Point(6, 25);
            this.calKalendar.Name = "calKalendar";
            this.calKalendar.TabIndex = 0;
            this.calKalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 437);
            this.Controls.Add(this.grpTermini);
            this.Controls.Add(this.btnCloseMain);
            this.Controls.Add(this.btnSifrarnik);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.Text = "Servis za čišćenje";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.grpTermini.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSifrarnik;
        private System.Windows.Forms.Button btnCloseMain;
        private System.Windows.Forms.GroupBox grpTermini;
        private System.Windows.Forms.MonthCalendar calKalendar;
    }
}

