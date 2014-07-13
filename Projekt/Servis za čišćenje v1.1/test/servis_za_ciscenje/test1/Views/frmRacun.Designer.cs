namespace servis_za_ciscenje.Views
{
    partial class frmRacun
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.klijentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.servisCiscenjeDBDataSet = new servis_za_ciscenje.ServisCiscenjeDBDataSet();
            this.posaoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uslugaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.klijentTableAdapter = new servis_za_ciscenje.ServisCiscenjeDBDataSetTableAdapters.klijentTableAdapter();
            this.posaoTableAdapter = new servis_za_ciscenje.ServisCiscenjeDBDataSetTableAdapters.posaoTableAdapter();
            this.uslugaTableAdapter = new servis_za_ciscenje.ServisCiscenjeDBDataSetTableAdapters.uslugaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.klijentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.servisCiscenjeDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.posaoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uslugaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // klijentBindingSource
            // 
            this.klijentBindingSource.DataMember = "klijent";
            this.klijentBindingSource.DataSource = this.servisCiscenjeDBDataSet;
            // 
            // servisCiscenjeDBDataSet
            // 
            this.servisCiscenjeDBDataSet.DataSetName = "ServisCiscenjeDBDataSet";
            this.servisCiscenjeDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // posaoBindingSource
            // 
            this.posaoBindingSource.DataMember = "posao";
            this.posaoBindingSource.DataSource = this.servisCiscenjeDBDataSet;
            // 
            // uslugaBindingSource
            // 
            this.uslugaBindingSource.DataMember = "usluga";
            this.uslugaBindingSource.DataSource = this.servisCiscenjeDBDataSet;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetKlijent";
            reportDataSource1.Value = this.klijentBindingSource;
            reportDataSource2.Name = "DataSetPosao";
            reportDataSource2.Value = this.posaoBindingSource;
            reportDataSource3.Name = "DataSetUsluga";
            reportDataSource3.Value = this.uslugaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "servis_za_ciscenje.ReportRacun.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(590, 458);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // klijentTableAdapter
            // 
            this.klijentTableAdapter.ClearBeforeFill = true;
            // 
            // posaoTableAdapter
            // 
            this.posaoTableAdapter.ClearBeforeFill = true;
            // 
            // uslugaTableAdapter
            // 
            this.uslugaTableAdapter.ClearBeforeFill = true;
            // 
            // frmRacun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 458);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmRacun";
            this.Text = "Račun";
            this.Load += new System.EventHandler(this.frmRacun_Load);
            ((System.ComponentModel.ISupportInitialize)(this.klijentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.servisCiscenjeDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.posaoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uslugaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private ServisCiscenjeDBDataSet servisCiscenjeDBDataSet;
        private System.Windows.Forms.BindingSource klijentBindingSource;
        private ServisCiscenjeDBDataSetTableAdapters.klijentTableAdapter klijentTableAdapter;
        private System.Windows.Forms.BindingSource posaoBindingSource;
        private ServisCiscenjeDBDataSetTableAdapters.posaoTableAdapter posaoTableAdapter;
        private System.Windows.Forms.BindingSource uslugaBindingSource;
        private ServisCiscenjeDBDataSetTableAdapters.uslugaTableAdapter uslugaTableAdapter;
    }
}