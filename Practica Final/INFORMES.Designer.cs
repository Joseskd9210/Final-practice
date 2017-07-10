namespace Practica_Final
{
    partial class INFORMES
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
            this.recetarioDataSet1 = new Practica_Final.recetarioDataSet1();
            this.recetarioDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.asociaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.asociaTableAdapter = new Practica_Final.recetarioDataSet1TableAdapters.asociaTableAdapter();
            this.recetaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.recetaTableAdapter = new Practica_Final.recetarioDataSet1TableAdapters.recetaTableAdapter();
            this.recetaBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.ingredientesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ingredientesTableAdapter = new Practica_Final.recetarioDataSet1TableAdapters.ingredientesTableAdapter();
            this.ingredientesTableAdapter1 = new Practica_Final.recetarioDataSet1TableAdapters.ingredientesTableAdapter();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.alergenosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.alergenosTableAdapter = new Practica_Final.recetarioDataSet1TableAdapters.alergenosTableAdapter();
            this.recetarioDataSet2 = new Practica_Final.recetarioDataSet2();
            ((System.ComponentModel.ISupportInitialize)(this.recetarioDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recetarioDataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.asociaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recetaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recetaBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alergenosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recetarioDataSet2)).BeginInit();
            this.SuspendLayout();
            // 
            // recetarioDataSet1
            // 
            this.recetarioDataSet1.DataSetName = "recetarioDataSet1";
            this.recetarioDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // recetarioDataSet1BindingSource
            // 
            this.recetarioDataSet1BindingSource.DataSource = this.recetarioDataSet1;
            this.recetarioDataSet1BindingSource.Position = 0;
            // 
            // asociaBindingSource
            // 
            this.asociaBindingSource.DataMember = "asocia";
            this.asociaBindingSource.DataSource = this.recetarioDataSet1;
            // 
            // asociaTableAdapter
            // 
            this.asociaTableAdapter.ClearBeforeFill = true;
            // 
            // recetaBindingSource
            // 
            this.recetaBindingSource.DataMember = "receta";
            this.recetaBindingSource.DataSource = this.recetarioDataSet1BindingSource;
            // 
            // recetaTableAdapter
            // 
            this.recetaTableAdapter.ClearBeforeFill = true;
            // 
            // recetaBindingSource1
            // 
            this.recetaBindingSource1.DataMember = "receta";
            this.recetaBindingSource1.DataSource = this.recetarioDataSet1;
            // 
            // ingredientesBindingSource
            // 
            this.ingredientesBindingSource.DataMember = "ingredientes";
            this.ingredientesBindingSource.DataSource = this.recetarioDataSet1;
            // 
            // ingredientesTableAdapter
            // 
            this.ingredientesTableAdapter.ClearBeforeFill = true;
            // 
            // ingredientesTableAdapter1
            // 
            this.ingredientesTableAdapter1.ClearBeforeFill = true;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.recetaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Practica_Final.Report4.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(2, 1);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1379, 557);
            this.reportViewer1.TabIndex = 0;
            // 
            // alergenosBindingSource
            // 
            this.alergenosBindingSource.DataMember = "alergenos";
            this.alergenosBindingSource.DataSource = this.recetarioDataSet1;
            // 
            // alergenosTableAdapter
            // 
            this.alergenosTableAdapter.ClearBeforeFill = true;
            // 
            // recetarioDataSet2
            // 
            this.recetarioDataSet2.DataSetName = "recetarioDataSet2";
            this.recetarioDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // INFORMES
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1381, 558);
            this.Controls.Add(this.reportViewer1);
            this.Name = "INFORMES";
            this.Text = "INFORMES";
            this.Load += new System.EventHandler(this.INFORMES_Load);
            ((System.ComponentModel.ISupportInitialize)(this.recetarioDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recetarioDataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.asociaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recetaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recetaBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alergenosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recetarioDataSet2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource recetarioDataSet1BindingSource;
        private recetarioDataSet1 recetarioDataSet1;
        private System.Windows.Forms.BindingSource asociaBindingSource;
        private recetarioDataSet1TableAdapters.asociaTableAdapter asociaTableAdapter;
        private System.Windows.Forms.BindingSource recetaBindingSource;
        private recetarioDataSet1TableAdapters.recetaTableAdapter recetaTableAdapter;
        private System.Windows.Forms.BindingSource recetaBindingSource1;
        private System.Windows.Forms.BindingSource ingredientesBindingSource;
        private recetarioDataSet1TableAdapters.ingredientesTableAdapter ingredientesTableAdapter;
        private recetarioDataSet1TableAdapters.ingredientesTableAdapter ingredientesTableAdapter1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource alergenosBindingSource;
        private recetarioDataSet1TableAdapters.alergenosTableAdapter alergenosTableAdapter;
        private recetarioDataSet2 recetarioDataSet2;
    }
}