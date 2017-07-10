namespace Practica_Final
{
    partial class insertaingrediente
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
            this.lvingrediente = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.tbcantingrediente = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.tbcantingrediente);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.lvingrediente);
            // 
            // lvingrediente
            // 
            this.lvingrediente.Location = new System.Drawing.Point(31, 23);
            this.lvingrediente.Name = "lvingrediente";
            this.lvingrediente.Size = new System.Drawing.Size(688, 489);
            this.lvingrediente.TabIndex = 0;
            this.lvingrediente.UseCompatibleStateImageBehavior = false;
            this.lvingrediente.View = System.Windows.Forms.View.List;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(793, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "CANTIDAD DE INGREDIENTE";
            // 
            // tbcantingrediente
            // 
            this.tbcantingrediente.Location = new System.Drawing.Point(771, 181);
            this.tbcantingrediente.Name = "tbcantingrediente";
            this.tbcantingrediente.Size = new System.Drawing.Size(261, 22);
            this.tbcantingrediente.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(805, 261);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(195, 90);
            this.button2.TabIndex = 5;
            this.button2.Text = "AÑADIR INGREDIENTES";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // insertaingrediente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1295, 821);
            this.Name = "insertaingrediente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "INSERTAR INGREDIENTE EN RECETA";
            this.Load += new System.EventHandler(this.insertaingrediente_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvingrediente;
        private System.Windows.Forms.TextBox tbcantingrediente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
    }
}