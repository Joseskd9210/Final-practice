namespace Practica_Final
{
    partial class modificar
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnmodificareceta = new System.Windows.Forms.Button();
            this.lvrecetas = new System.Windows.Forms.ListView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnmodificaringrediente = new System.Windows.Forms.Button();
            this.lvingredientes = new System.Windows.Forms.ListView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnmodificavino = new System.Windows.Forms.Button();
            this.lvmodificavino = new System.Windows.Forms.ListView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnmodificarutensilios = new System.Windows.Forms.Button();
            this.lvmodificarutensilios = new System.Windows.Forms.ListView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.btnmodicaralergeno = new System.Windows.Forms.Button();
            this.lvmodicalergeno = new System.Windows.Forms.ListView();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.panel3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tabControl1);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(0, 15);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1166, 532);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnmodificareceta);
            this.tabPage1.Controls.Add(this.lvrecetas);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1158, 503);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "RECETAS";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnmodificareceta
            // 
            this.btnmodificareceta.Location = new System.Drawing.Point(876, 191);
            this.btnmodificareceta.Name = "btnmodificareceta";
            this.btnmodificareceta.Size = new System.Drawing.Size(211, 92);
            this.btnmodificareceta.TabIndex = 1;
            this.btnmodificareceta.Text = "MODIFICAR RECETA SELECCIONADA";
            this.btnmodificareceta.UseVisualStyleBackColor = true;
            this.btnmodificareceta.Click += new System.EventHandler(this.btnmodificareceta_Click);
            // 
            // lvrecetas
            // 
            this.lvrecetas.Location = new System.Drawing.Point(26, 21);
            this.lvrecetas.Name = "lvrecetas";
            this.lvrecetas.Size = new System.Drawing.Size(770, 458);
            this.lvrecetas.TabIndex = 0;
            this.lvrecetas.UseCompatibleStateImageBehavior = false;
            this.lvrecetas.View = System.Windows.Forms.View.List;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnmodificaringrediente);
            this.tabPage3.Controls.Add(this.lvingredientes);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1158, 503);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "INGREDIENTES";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnmodificaringrediente
            // 
            this.btnmodificaringrediente.Location = new System.Drawing.Point(885, 216);
            this.btnmodificaringrediente.Name = "btnmodificaringrediente";
            this.btnmodificaringrediente.Size = new System.Drawing.Size(211, 92);
            this.btnmodificaringrediente.TabIndex = 2;
            this.btnmodificaringrediente.Text = "MODIFICAR INGREDIENTE SELECCIONADO";
            this.btnmodificaringrediente.UseVisualStyleBackColor = true;
            this.btnmodificaringrediente.Click += new System.EventHandler(this.btnmodificaringrediente_Click);
            // 
            // lvingredientes
            // 
            this.lvingredientes.Location = new System.Drawing.Point(31, 22);
            this.lvingredientes.Name = "lvingredientes";
            this.lvingredientes.Size = new System.Drawing.Size(770, 458);
            this.lvingredientes.TabIndex = 1;
            this.lvingredientes.UseCompatibleStateImageBehavior = false;
            this.lvingredientes.View = System.Windows.Forms.View.List;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnmodificavino);
            this.tabPage2.Controls.Add(this.lvmodificavino);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1158, 503);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "VINOS";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnmodificavino
            // 
            this.btnmodificavino.Location = new System.Drawing.Point(901, 216);
            this.btnmodificavino.Name = "btnmodificavino";
            this.btnmodificavino.Size = new System.Drawing.Size(211, 92);
            this.btnmodificavino.TabIndex = 4;
            this.btnmodificavino.Text = "MODIFICAR VINO SELECCIONADO";
            this.btnmodificavino.UseVisualStyleBackColor = true;
            this.btnmodificavino.Click += new System.EventHandler(this.btnmodificavino_Click);
            // 
            // lvmodificavino
            // 
            this.lvmodificavino.Location = new System.Drawing.Point(47, 22);
            this.lvmodificavino.Name = "lvmodificavino";
            this.lvmodificavino.Size = new System.Drawing.Size(770, 458);
            this.lvmodificavino.TabIndex = 3;
            this.lvmodificavino.UseCompatibleStateImageBehavior = false;
            this.lvmodificavino.View = System.Windows.Forms.View.List;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btnmodificarutensilios);
            this.tabPage4.Controls.Add(this.lvmodificarutensilios);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1158, 503);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "UTENSILIOS";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnmodificarutensilios
            // 
            this.btnmodificarutensilios.Location = new System.Drawing.Point(901, 216);
            this.btnmodificarutensilios.Name = "btnmodificarutensilios";
            this.btnmodificarutensilios.Size = new System.Drawing.Size(211, 92);
            this.btnmodificarutensilios.TabIndex = 6;
            this.btnmodificarutensilios.Text = "MODIFICAR UTENSILIO SELECCIONADO";
            this.btnmodificarutensilios.UseVisualStyleBackColor = true;
            this.btnmodificarutensilios.Click += new System.EventHandler(this.btnmodificarutensilios_Click);
            // 
            // lvmodificarutensilios
            // 
            this.lvmodificarutensilios.Location = new System.Drawing.Point(47, 22);
            this.lvmodificarutensilios.Name = "lvmodificarutensilios";
            this.lvmodificarutensilios.Size = new System.Drawing.Size(770, 458);
            this.lvmodificarutensilios.TabIndex = 5;
            this.lvmodificarutensilios.UseCompatibleStateImageBehavior = false;
            this.lvmodificarutensilios.View = System.Windows.Forms.View.List;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.btnmodicaralergeno);
            this.tabPage5.Controls.Add(this.lvmodicalergeno);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1158, 503);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "ALERGENOS";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // btnmodicaralergeno
            // 
            this.btnmodicaralergeno.Location = new System.Drawing.Point(901, 216);
            this.btnmodicaralergeno.Name = "btnmodicaralergeno";
            this.btnmodicaralergeno.Size = new System.Drawing.Size(211, 92);
            this.btnmodicaralergeno.TabIndex = 8;
            this.btnmodicaralergeno.Text = "MODIFICAR ALERGENO SELECCIONADO";
            this.btnmodicaralergeno.UseVisualStyleBackColor = true;
            this.btnmodicaralergeno.Click += new System.EventHandler(this.btnmodicaralergeno_Click);
            // 
            // lvmodicalergeno
            // 
            this.lvmodicalergeno.Location = new System.Drawing.Point(47, 22);
            this.lvmodicalergeno.Name = "lvmodicalergeno";
            this.lvmodicalergeno.Size = new System.Drawing.Size(770, 458);
            this.lvmodicalergeno.TabIndex = 7;
            this.lvmodicalergeno.UseCompatibleStateImageBehavior = false;
            this.lvmodicalergeno.View = System.Windows.Forms.View.List;
            // 
            // modificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1295, 816);
            this.Name = "modificar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MODICACION DE BBDD";
            this.Load += new System.EventHandler(this.modificar_Load);
            this.panel3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button btnmodificareceta;
        public System.Windows.Forms.ListView lvrecetas;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button btnmodificaringrediente;
        public System.Windows.Forms.ListView lvingredientes;
        private System.Windows.Forms.Button btnmodificavino;
        public System.Windows.Forms.ListView lvmodificavino;
        private System.Windows.Forms.Button btnmodificarutensilios;
        public System.Windows.Forms.ListView lvmodificarutensilios;
        private System.Windows.Forms.Button btnmodicaralergeno;
        public System.Windows.Forms.ListView lvmodicalergeno;

    }
}