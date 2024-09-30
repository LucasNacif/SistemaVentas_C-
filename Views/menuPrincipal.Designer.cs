namespace Sistema_scan_codigo_barras
{
    partial class menuPrincipal
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(menuPrincipal));
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnModificarMenu = new System.Windows.Forms.Button();
            this.btnSalirMenu = new System.Windows.Forms.Button();
            this.btnBuscarMenu = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TLbuscarMenuPrincipal = new System.Windows.Forms.ToolTip(this.components);
            this.TLagregarMenuPrincipal = new System.Windows.Forms.ToolTip(this.components);
            this.TLSalir = new System.Windows.Forms.ToolTip(this.components);
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = System.Drawing.SystemColors.Window;
            this.lblTitulo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitulo.Font = new System.Drawing.Font("Rockwell", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(201, 70);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(582, 67);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "DESPENSA NATASHA";
            // 
            // btnModificarMenu
            // 
            this.btnModificarMenu.AutoSize = true;
            this.btnModificarMenu.BackColor = System.Drawing.SystemColors.Window;
            this.btnModificarMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificarMenu.Font = new System.Drawing.Font("Dubai", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarMenu.Image = ((System.Drawing.Image)(resources.GetObject("btnModificarMenu.Image")));
            this.btnModificarMenu.Location = new System.Drawing.Point(396, 49);
            this.btnModificarMenu.Name = "btnModificarMenu";
            this.btnModificarMenu.Size = new System.Drawing.Size(193, 179);
            this.btnModificarMenu.TabIndex = 2;
            this.btnModificarMenu.Text = "AGREGAR";
            this.btnModificarMenu.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnModificarMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.TLagregarMenuPrincipal.SetToolTip(this.btnModificarMenu, "Presione este boton para\r\nagregar un nuevo producto \r\no tambien para modificar o " +
        "eliminar\r\nun producto ya existente");
            this.btnModificarMenu.UseVisualStyleBackColor = false;
            this.btnModificarMenu.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnSalirMenu
            // 
            this.btnSalirMenu.AutoSize = true;
            this.btnSalirMenu.BackColor = System.Drawing.SystemColors.Window;
            this.btnSalirMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalirMenu.Font = new System.Drawing.Font("Dubai", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalirMenu.Image = ((System.Drawing.Image)(resources.GetObject("btnSalirMenu.Image")));
            this.btnSalirMenu.Location = new System.Drawing.Point(731, 49);
            this.btnSalirMenu.Name = "btnSalirMenu";
            this.btnSalirMenu.Size = new System.Drawing.Size(193, 179);
            this.btnSalirMenu.TabIndex = 3;
            this.btnSalirMenu.Text = "SALIR";
            this.btnSalirMenu.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalirMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.TLSalir.SetToolTip(this.btnSalirMenu, "Presione este boton si desea salir del sistema");
            this.btnSalirMenu.UseVisualStyleBackColor = false;
            this.btnSalirMenu.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnBuscarMenu
            // 
            this.btnBuscarMenu.AutoSize = true;
            this.btnBuscarMenu.BackColor = System.Drawing.SystemColors.Window;
            this.btnBuscarMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarMenu.Font = new System.Drawing.Font("Dubai", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarMenu.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarMenu.Image")));
            this.btnBuscarMenu.Location = new System.Drawing.Point(65, 49);
            this.btnBuscarMenu.Name = "btnBuscarMenu";
            this.btnBuscarMenu.Size = new System.Drawing.Size(193, 179);
            this.btnBuscarMenu.TabIndex = 1;
            this.btnBuscarMenu.Text = "BUSCAR";
            this.btnBuscarMenu.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBuscarMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.TLbuscarMenuPrincipal.SetToolTip(this.btnBuscarMenu, "Presione este boton para buscar \r\nun producto mediante el lector \r\nde codigo de b" +
        "arras");
            this.btnBuscarMenu.UseVisualStyleBackColor = false;
            this.btnBuscarMenu.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BackColor = System.Drawing.Color.SkyBlue;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Location = new System.Drawing.Point(58, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1135, 608);
            this.panel2.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.AutoSize = true;
            this.panel3.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.lblTitulo);
            this.panel3.Location = new System.Drawing.Point(70, 61);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(990, 209);
            this.panel3.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnModificarMenu);
            this.panel1.Controls.Add(this.btnSalirMenu);
            this.panel1.Controls.Add(this.btnBuscarMenu);
            this.panel1.Location = new System.Drawing.Point(70, 276);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(990, 273);
            this.panel1.TabIndex = 7;
            // 
            // menuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1256, 640);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "menuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de ventas V. 1.0.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.menuPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.menuPrincipal_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnBuscarMenu;
        private System.Windows.Forms.Button btnSalirMenu;
        private System.Windows.Forms.Button btnModificarMenu;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolTip TLbuscarMenuPrincipal;
        private System.Windows.Forms.ToolTip TLagregarMenuPrincipal;
        private System.Windows.Forms.ToolTip TLSalir;
    }
}

