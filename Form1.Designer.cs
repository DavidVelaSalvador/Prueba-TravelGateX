
namespace Prueba_TrAvelGateX
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.CmbHoteles = new System.Windows.Forms.ComboBox();
            this.LblHoteles = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CmbHoteles
            // 
            this.CmbHoteles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbHoteles.FormattingEnabled = true;
            this.CmbHoteles.Location = new System.Drawing.Point(80, 25);
            this.CmbHoteles.Name = "CmbHoteles";
            this.CmbHoteles.Size = new System.Drawing.Size(215, 21);
            this.CmbHoteles.TabIndex = 0;
            // 
            // LblHoteles
            // 
            this.LblHoteles.AutoSize = true;
            this.LblHoteles.Location = new System.Drawing.Point(32, 29);
            this.LblHoteles.Name = "LblHoteles";
            this.LblHoteles.Size = new System.Drawing.Size(46, 13);
            this.LblHoteles.TabIndex = 1;
            this.LblHoteles.Text = "Hoteles:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LblHoteles);
            this.Controls.Add(this.CmbHoteles);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CmbHoteles;
        private System.Windows.Forms.Label LblHoteles;
    }
}

