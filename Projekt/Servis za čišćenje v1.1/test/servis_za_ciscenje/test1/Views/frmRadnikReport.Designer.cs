namespace servis_za_ciscenje.Views
{
    partial class frmRadnikReport
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.servisCiscenjeDBDataSetRadnik = new servis_za_ciscenje.ServisCiscenjeDBDataSetRadnik();
            this.posaoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.posaoTableAdapter = new servis_za_ciscenje.ServisCiscenjeDBDataSetRadnikTableAdapters.posaoTableAdapter();
            this.radniciBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.radniciTableAdapter = new servis_za_ciscenje.ServisCiscenjeDBDataSetRadnikTableAdapters.radniciTableAdapter();
            this.servisCiscenjeDBDataSet = new servis_za_ciscenje.ServisCiscenjeDBDataSet();
            this.klijentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.klijentTableAdapter = new servis_za_ciscenje.ServisCiscenjeDBDataSetTableAdapters.klijentTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.servisCiscenjeDBDataSetRadnik)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.posaoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radniciBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.servisCiscenjeDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.klijentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetKlijent";
            reportDataSource1.Value = this.klijentBindingSource;
            reportDataSource2.Name = "DataSetPosao";
            reportDataSource2.Value = this.posaoBindingSource;
            reportDataSource3.Name = "DataSetRadnici";
            reportDataSource3.Value = this.radniciBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "servis_za_ciscenje.ReportRadnik.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(582, 373);
            this.reportViewer1.TabIndex = 0;
            // 
            // servisCiscenjeDBDataSetRadnik
            // 
            this.servisCiscenjeDBDataSetRadnik.DataSetName = "ServisCiscenjeDBDataSetRadnik";
            this.servisCiscenjeDBDataSetRadnik.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // posaoBindingSource
            // 
            this.posaoBindingSource.DataMember = "posao";
            this.posaoBindingSource.DataSource = this.servisCiscenjeDBDataSetRadnik;
            // 
            // posaoTableAdapter
            // 
            this.posaoTableAdapter.ClearBeforeFill = true;
            // 
            // radniciBindingSource
            // 
            this.radniciBindingSource.DataMember = "radnici";
            this.radniciBindingSource.DataSource = this.servisCiscenjeDBDataSetRadnik;
            // 
            // radniciTableAdapter
            // 
            this.radniciTableAdapter.ClearBeforeFill = true;
            // 
            // servisCiscenjeDBDataSet
            // 
            this.servisCiscenjeDBDataSet.DataSetName = "ServisCiscenjeDBDataSet";
            this.servisCiscenjeDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // klijentBindingSource
            // 
            this.klijentBindingSource.DataMember = "klijent";
            this.klijentBindingSource.DataSource = this.servisCiscenjeDBDataSet;
            // 
            // klijentTableAdapter
            // 
            this.klijentTableAdapter.ClearBeforeFill = true;
            // 
            // frmRadnikReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 373);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmRadnikReport";
            this.Text = "Izvješće o radniku";
            this.Load += new System.EventHandler(this.frmRadnikReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.servisCiscenjeDBDataSetRadnik)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.posaoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radniciBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.servisCiscenjeDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.klijentBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private ServisCiscenjeDBDataSetRadnik servisCiscenjeDBDataSetRadnik;
        private System.Windows.Forms.BindingSource posaoBindingSource;
        private ServisCiscenjeDBDataSetRadnikTableAdapters.posaoTableAdapter posaoTableAdapter;
        private System.Windows.Forms.BindingSource radniciBindingSource;
        private ServisCiscenjeDBDataSetRadnikTableAdapters.radniciTableAdapter radniciTableAdapter;
        private ServisCiscenjeDBDataSet servisCiscenjeDBDataSet;
        private System.Windows.Forms.BindingSource klijentBindingSource;
        private ServisCiscenjeDBDataSetTableAdapters.klijentTableAdapter klijentTableAdapter;
    }
}