
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
            this.Cmb_Hotels = new System.Windows.Forms.ComboBox();
            this.Lbl_Hotels = new System.Windows.Forms.Label();
            this.Panel_Filtros = new System.Windows.Forms.Panel();
            this.Lbl_RoomType = new System.Windows.Forms.Label();
            this.Cmb_RoomType = new System.Windows.Forms.ComboBox();
            this.Panel_Filtros.SuspendLayout();
            this.SuspendLayout();
            // 
            // Cmb_Hotels
            // 
            this.Cmb_Hotels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_Hotels.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Hotels.ForeColor = System.Drawing.Color.SteelBlue;
            this.Cmb_Hotels.FormattingEnabled = true;
            this.Cmb_Hotels.Location = new System.Drawing.Point(38, 34);
            this.Cmb_Hotels.Name = "Cmb_Hotels";
            this.Cmb_Hotels.Size = new System.Drawing.Size(283, 24);
            this.Cmb_Hotels.TabIndex = 0;
            this.Cmb_Hotels.SelectedIndexChanged += new System.EventHandler(this.Cmb_Hotels_SelectedIndexChanged);
            // 
            // Lbl_Hotels
            // 
            this.Lbl_Hotels.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Hotels.ForeColor = System.Drawing.Color.White;
            this.Lbl_Hotels.Location = new System.Drawing.Point(35, 7);
            this.Lbl_Hotels.Name = "Lbl_Hotels";
            this.Lbl_Hotels.Size = new System.Drawing.Size(286, 24);
            this.Lbl_Hotels.TabIndex = 1;
            this.Lbl_Hotels.Text = "Select Hotel:";
            this.Lbl_Hotels.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // Panel_Filtros
            // 
            this.Panel_Filtros.BackColor = System.Drawing.Color.SteelBlue;
            this.Panel_Filtros.Controls.Add(this.Lbl_RoomType);
            this.Panel_Filtros.Controls.Add(this.Cmb_RoomType);
            this.Panel_Filtros.Controls.Add(this.Lbl_Hotels);
            this.Panel_Filtros.Controls.Add(this.Cmb_Hotels);
            this.Panel_Filtros.Location = new System.Drawing.Point(2, 2);
            this.Panel_Filtros.Name = "Panel_Filtros";
            this.Panel_Filtros.Size = new System.Drawing.Size(799, 76);
            this.Panel_Filtros.TabIndex = 3;
            // 
            // Lbl_RoomType
            // 
            this.Lbl_RoomType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_RoomType.ForeColor = System.Drawing.Color.White;
            this.Lbl_RoomType.Location = new System.Drawing.Point(324, 7);
            this.Lbl_RoomType.Name = "Lbl_RoomType";
            this.Lbl_RoomType.Size = new System.Drawing.Size(286, 24);
            this.Lbl_RoomType.TabIndex = 3;
            this.Lbl_RoomType.Text = "Select Room Type:";
            this.Lbl_RoomType.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // Cmb_RoomType
            // 
            this.Cmb_RoomType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_RoomType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_RoomType.ForeColor = System.Drawing.Color.SteelBlue;
            this.Cmb_RoomType.FormattingEnabled = true;
            this.Cmb_RoomType.Location = new System.Drawing.Point(327, 34);
            this.Cmb_RoomType.Name = "Cmb_RoomType";
            this.Cmb_RoomType.Size = new System.Drawing.Size(283, 24);
            this.Cmb_RoomType.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 450);
            this.Controls.Add(this.Panel_Filtros);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Panel_Filtros.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox Cmb_Hotels;
        private System.Windows.Forms.Label Lbl_Hotels;
        private System.Windows.Forms.Panel Panel_Filtros;
        private System.Windows.Forms.Label Lbl_RoomType;
        private System.Windows.Forms.ComboBox Cmb_RoomType;
    }
}

