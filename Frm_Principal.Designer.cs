
namespace Prueba_TravelGateX
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
            this.Panel_Filtros = new System.Windows.Forms.Panel();
            this.Btn_Get_Data = new System.Windows.Forms.Button();
            this.Lista = new System.Windows.Forms.ListView();
            this.Col_Hotel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Col_Ciudad = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Col_Hab_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Col_tipo_hab = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Col_Regimenes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Col_Precio = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Tab_Principal = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Tb_Code = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.Tb_Log = new System.Windows.Forms.TextBox();
            this.Panel_Filtros.SuspendLayout();
            this.Tab_Principal.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel_Filtros
            // 
            this.Panel_Filtros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_Filtros.BackColor = System.Drawing.Color.SteelBlue;
            this.Panel_Filtros.Controls.Add(this.Btn_Get_Data);
            this.Panel_Filtros.Location = new System.Drawing.Point(0, 0);
            this.Panel_Filtros.Name = "Panel_Filtros";
            this.Panel_Filtros.Size = new System.Drawing.Size(699, 127);
            this.Panel_Filtros.TabIndex = 3;
            // 
            // Btn_Get_Data
            // 
            this.Btn_Get_Data.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Get_Data.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Get_Data.ForeColor = System.Drawing.Color.White;
            this.Btn_Get_Data.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Get_Data.Image")));
            this.Btn_Get_Data.Location = new System.Drawing.Point(15, 12);
            this.Btn_Get_Data.Name = "Btn_Get_Data";
            this.Btn_Get_Data.Size = new System.Drawing.Size(148, 90);
            this.Btn_Get_Data.TabIndex = 5;
            this.Btn_Get_Data.Text = "Get Data";
            this.Btn_Get_Data.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Btn_Get_Data.UseVisualStyleBackColor = true;
            this.Btn_Get_Data.Click += new System.EventHandler(this.Btn_Get_Data_Click);
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
            this.Col_Hotel.Width = 167;
            // 
            // Col_Ciudad
            // 
            this.Col_Ciudad.Text = "City";
            this.Col_Ciudad.Width = 80;
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
            // Col_Regimenes
            // 
            this.Col_Regimenes.Text = "Meal Plan";
            this.Col_Regimenes.Width = 109;
            // 
            // Col_Precio
            // 
            this.Col_Precio.Text = "Price";
            this.Col_Precio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Col_Precio.Width = 74;
            // 
            // Tab_Principal
            // 
            this.Tab_Principal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tab_Principal.Controls.Add(this.tabPage1);
            this.Tab_Principal.Controls.Add(this.tabPage2);
            this.Tab_Principal.Controls.Add(this.tabPage3);
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
            this.Tb_Code.ReadOnly = true;
            this.Tb_Code.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Tb_Code.Size = new System.Drawing.Size(664, 378);
            this.Tb_Code.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.Tb_Log);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(670, 384);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Log";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // Tb_Log
            // 
            this.Tb_Log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tb_Log.BackColor = System.Drawing.Color.White;
            this.Tb_Log.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tb_Log.Location = new System.Drawing.Point(3, 3);
            this.Tb_Log.Multiline = true;
            this.Tb_Log.Name = "Tb_Log";
            this.Tb_Log.ReadOnly = true;
            this.Tb_Log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Tb_Log.Size = new System.Drawing.Size(664, 378);
            this.Tb_Log.TabIndex = 1;
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
            this.Tab_Principal.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel Panel_Filtros;
        private System.Windows.Forms.ColumnHeader Col_Hotel;
        private System.Windows.Forms.ColumnHeader Col_Hab_Name;
        private System.Windows.Forms.ColumnHeader Col_tipo_hab;
        private System.Windows.Forms.ColumnHeader Col_Precio;
        private System.Windows.Forms.ColumnHeader Col_Ciudad;
        private System.Windows.Forms.ColumnHeader Col_Regimenes;
        private System.Windows.Forms.TabControl Tab_Principal;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.ListView Lista;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button Btn_Get_Data;
        private System.Windows.Forms.TextBox Tb_Log;
        public System.Windows.Forms.TextBox Tb_Code;
    }
}

