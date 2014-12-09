namespace WindowsFormsApplication1
{
    partial class Relatorio
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btBuscar = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.destino = new System.Windows.Forms.TextBox();
            this.awb = new System.Windows.Forms.TextBox();
            this.origem = new System.Windows.Forms.TextBox();
            this.tb_item_reportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbRFixDataSet = new WindowsFormsApplication1.dbRFixDataSet();
            this.tb_itemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tb_itemTableAdapter = new WindowsFormsApplication1.dbRFixDataSetTableAdapters.tb_itemTableAdapter();
            this.tb_item_reportTableAdapter = new WindowsFormsApplication1.dbRFixDataSetTableAdapters.tb_item_reportTableAdapter();
            this.dtAtualizacao = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.tb_item_reportBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbRFixDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_itemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.tb_item_reportBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "WindowsFormsApplication1.ReportItem.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 108);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(774, 412);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // btBuscar
            // 
            this.btBuscar.Location = new System.Drawing.Point(464, 28);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(80, 21);
            this.btBuscar.TabIndex = 1;
            this.btBuscar.Text = "Buscar";
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(464, 70);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(80, 21);
            this.btCancel.TabIndex = 2;
            this.btCancel.Text = "Limpar";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // destino
            // 
            this.destino.Location = new System.Drawing.Point(19, 71);
            this.destino.Name = "destino";
            this.destino.Size = new System.Drawing.Size(212, 20);
            this.destino.TabIndex = 4;
            // 
            // awb
            // 
            this.awb.Location = new System.Drawing.Point(237, 28);
            this.awb.Name = "awb";
            this.awb.Size = new System.Drawing.Size(221, 20);
            this.awb.TabIndex = 5;
            // 
            // origem
            // 
            this.origem.Location = new System.Drawing.Point(237, 71);
            this.origem.Name = "origem";
            this.origem.Size = new System.Drawing.Size(221, 20);
            this.origem.TabIndex = 6;
            // 
            // tb_item_reportBindingSource
            // 
            this.tb_item_reportBindingSource.DataMember = "tb_item_report";
            this.tb_item_reportBindingSource.DataSource = this.dbRFixDataSet;
            // 
            // dbRFixDataSet
            // 
            this.dbRFixDataSet.DataSetName = "dbRFixDataSet";
            this.dbRFixDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tb_itemBindingSource
            // 
            this.tb_itemBindingSource.DataMember = "tb_item";
            this.tb_itemBindingSource.DataSource = this.dbRFixDataSet;
            // 
            // tb_itemTableAdapter
            // 
            this.tb_itemTableAdapter.ClearBeforeFill = true;
            // 
            // tb_item_reportTableAdapter
            // 
            this.tb_item_reportTableAdapter.ClearBeforeFill = true;
            // 
            // dtAtualizacao
            // 
            this.dtAtualizacao.Location = new System.Drawing.Point(19, 28);
            this.dtAtualizacao.Name = "dtAtualizacao";
            this.dtAtualizacao.Size = new System.Drawing.Size(212, 20);
            this.dtAtualizacao.TabIndex = 7;
            // 
            // Relatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 532);
            this.Controls.Add(this.dtAtualizacao);
            this.Controls.Add(this.origem);
            this.Controls.Add(this.awb);
            this.Controls.Add(this.destino);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btBuscar);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Relatorio";
            this.Text = "Relatorio";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tb_item_reportBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbRFixDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_itemBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.TextBox destino;
        private System.Windows.Forms.TextBox awb;
        private System.Windows.Forms.TextBox origem;
        private System.Windows.Forms.BindingSource tb_itemBindingSource;
        private dbRFixDataSet dbRFixDataSet;
        private dbRFixDataSetTableAdapters.tb_itemTableAdapter tb_itemTableAdapter;
        private System.Windows.Forms.BindingSource tb_item_reportBindingSource;
        private dbRFixDataSetTableAdapters.tb_item_reportTableAdapter tb_item_reportTableAdapter;
        private System.Windows.Forms.TextBox dtAtualizacao;
    }
}

