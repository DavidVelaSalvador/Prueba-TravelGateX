
namespace Prueba_TrAvelGateX
{
    partial class Frm_Principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Principal));
            this.Cmb_Hotels = new System.Windows.Forms.ComboBox();
            this.Lbl_Hotels = new System.Windows.Forms.Label();
            this.Panel_Filtros = new System.Windows.Forms.Panel();
            this.Lbl_RoomType = new System.Windows.Forms.Label();
            this.Cmb_RoomType = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Lista = new System.Windows.Forms.ListView();
            this.Col_Hotel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Col_Hab_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Col_tipo_hab = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Col_Precio = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Col_Ciudad = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Col_Regimenes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Tab_Principal = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Tb_Code = new System.Windows.Forms.TextBox();
            this.Panel_Filtros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.Tab_Principal.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Cmb_Hotels
            // 
            this.Cmb_Hotels.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Cmb_Hotels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_Hotels.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_Hotels.ForeColor = System.Drawing.Color.SteelBlue;
            this.Cmb_Hotels.FormattingEnabled = true;
            this.Cmb_Hotels.Location = new System.Drawing.Point(135, 29);
            this.Cmb_Hotels.Name = "Cmb_Hotels";
            this.Cmb_Hotels.Size = new System.Drawing.Size(552, 28);
            this.Cmb_Hotels.TabIndex = 0;
            this.Cmb_Hotels.SelectedIndexChanged += new System.EventHandler(this.Cmb_Hotels_SelectedIndexChanged);
            // 
            // Lbl_Hotels
            // 
            this.Lbl_Hotels.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Hotels.ForeColor = System.Drawing.Color.White;
            this.Lbl_Hotels.Location = new System.Drawing.Point(66, 17);
            this.Lbl_Hotels.Name = "Lbl_Hotels";
            this.Lbl_Hotels.Size = new System.Drawing.Size(63, 43);
            this.Lbl_Hotels.TabIndex = 1;
            this.Lbl_Hotels.Text = "Select Hotel:";
            this.Lbl_Hotels.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // Panel_Filtros
            // 
            this.Panel_Filtros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_Filtros.BackColor = System.Drawing.Color.SteelBlue;
            this.Panel_Filtros.Controls.Add(this.pictureBox2);
            this.Panel_Filtros.Controls.Add(this.pictureBox1);
            this.Panel_Filtros.Controls.Add(this.Lbl_RoomType);
            this.Panel_Filtros.Controls.Add(this.Cmb_RoomType);
            this.Panel_Filtros.Controls.Add(this.Lbl_Hotels);
            this.Panel_Filtros.Controls.Add(this.Cmb_Hotels);
            this.Panel_Filtros.Location = new System.Drawing.Point(0, 0);
            this.Panel_Filtros.Name = "Panel_Filtros";
            this.Panel_Filtros.Size = new System.Drawing.Size(699, 127);
            this.Panel_Filtros.TabIndex = 3;
            // 
            // Lbl_RoomType
            // 
            this.Lbl_RoomType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_RoomType.ForeColor = System.Drawing.Color.White;
            this.Lbl_RoomType.Location = new System.Drawing.Point(66, 66);
            this.Lbl_RoomType.Name = "Lbl_RoomType";
            this.Lbl_RoomType.Size = new System.Drawing.Size(107, 48);
            this.Lbl_RoomType.TabIndex = 3;
            this.Lbl_RoomType.Text = "Select Room Type:";
            this.Lbl_RoomType.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // Cmb_RoomType
            // 
            this.Cmb_RoomType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Cmb_RoomType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_RoomType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmb_RoomType.ForeColor = System.Drawing.Color.SteelBlue;
            this.Cmb_RoomType.FormattingEnabled = true;
            this.Cmb_RoomType.Location = new System.Drawing.Point(179, 83);
            this.Cmb_RoomType.Name = "Cmb_RoomType";
            this.Cmb_RoomType.Size = new System.Drawing.Size(508, 28);
            this.Cmb_RoomType.TabIndex = 2;
            this.Cmb_RoomType.SelectedIndexChanged += new System.EventHandler(this.Cmb_RoomType_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(12, 66);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(48, 48);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // Lista
            // 
            this.Lista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lista.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Col_Hotel,
            this.Col_Ciudad,
            this.Col_Hab_Name,
            this.Col_tipo_hab,
            this.Col_Regimenes,
            this.Col_Precio});
            this.Lista.FullRowSelect = true;
            this.Lista.GridLines = true;
            this.Lista.HideSelection = false;
            this.Lista.Location = new System.Drawing.Point(2, 2);
            this.Lista.MultiSelect = false;
            this.Lista.Name = "Lista";
            this.Lista.Size = new System.Drawing.Size(668, 382);
            this.Lista.TabIndex = 4;
            this.Lista.UseCompatibleStateImageBehavior = false;
            this.Lista.View = System.Windows.Forms.View.Details;
            // 
            // Col_Hotel
            // 
            this.Col_Hotel.Text = "Hotel";
            this.Col_Hotel.Width = 116;
            // 
            // Col_Hab_Name
            // 
            this.Col_Hab_Name.Text = "Name";
            this.Col_Hab_Name.Width = 98;
            // 
            // Col_tipo_hab
            // 
            this.Col_tipo_hab.Text = "Room type";
            this.Col_tipo_hab.Width = 117;
            // 
            // Col_Precio
            // 
            this.Col_Precio.Text = "Price";
            this.Col_Precio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Col_Precio.Width = 74;
            // 
            // Col_Ciudad
            // 
            this.Col_Ciudad.Text = "City";
            this.Col_Ciudad.Width = 126;
            // 
            // Col_Regimenes
            // 
            this.Col_Regimenes.Text = "Meal Plan";
            this.Col_Regimenes.Width = 109;
            // 
            // Tab_Principal
            // 
            this.Tab_Principal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tab_Principal.Controls.Add(this.tabPage1);
            this.Tab_Principal.Controls.Add(this.tabPage2);
            this.Tab_Principal.Location = new System.Drawing.Point(9, 134);
            this.Tab_Principal.Name = "Tab_Principal";
            this.Tab_Principal.SelectedIndex = 0;
            this.Tab_Principal.Size = new System.Drawing.Size(678, 410);
            this.Tab_Principal.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Lista);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(670, 384);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Detail View";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.Tb_Code);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(670, 384);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Data View";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Tb_Code
            // 
            this.Tb_Code.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tb_Code.Location = new System.Drawing.Point(3, 3);
            this.Tb_Code.Multiline = true;
            this.Tb_Code.Name = "Tb_Code";
            this.Tb_Code.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Tb_Code.Size = new System.Drawing.Size(664, 378);
            this.Tb_Code.TabIndex = 0;
            // 
            // Frm_Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 558);
            this.Controls.Add(this.Tab_Principal);
            this.Controls.Add(this.Panel_Filtros);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Frm_Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TravelGateX";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Panel_Filtros.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.Tab_Principal.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox Cmb_Hotels;
        private System.Windows.Forms.Label Lbl_Hotels;
        private System.Windows.Forms.Panel Panel_Filtros;
        private System.Windows.Forms.Label Lbl_RoomType;
        private System.Windows.Forms.ComboBox Cmb_RoomType;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListView Lista;
        private System.Windows.Forms.ColumnHeader Col_Hotel;
        private System.Windows.Forms.ColumnHeader Col_Hab_Name;
        private System.Windows.Forms.ColumnHeader Col_tipo_hab;
        private System.Windows.Forms.ColumnHeader Col_Precio;
        private System.Windows.Forms.ColumnHeader Col_Ciudad;
        private System.Windows.Forms.ColumnHeader Col_Regimenes;
        private System.Windows.Forms.TabControl Tab_Principal;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox Tb_Code;
    }
}

