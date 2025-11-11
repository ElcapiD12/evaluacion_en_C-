namespace SistemaCartasAutorizacion
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.btnIngresarUsuario = new System.Windows.Forms.Button();
            this.btnIngresarAdmin = new System.Windows.Forms.Button();
            this.btnVerEstadisticas = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.panelBienvenida = new System.Windows.Forms.Panel();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.panelBienvenida.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblTitulo.Location = new System.Drawing.Point(100, 30);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(448, 29);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Sistema de Cartas de Autorización";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(180, 70);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(280, 18);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Gestión Eficiente de Solicitudes";
            // 
            // panelBienvenida
            // 
            this.panelBienvenida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.panelBienvenida.Controls.Add(this.lblDescripcion);
            this.panelBienvenida.Location = new System.Drawing.Point(50, 120);
            this.panelBienvenida.Name = "panelBienvenida";
            this.panelBienvenida.Size = new System.Drawing.Size(550, 100);
            this.panelBienvenida.TabIndex = 2;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblDescripcion.Location = new System.Drawing.Point(20, 15);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(510, 70);
            this.lblDescripcion.TabIndex = 0;
            this.lblDescripcion.Text = "Bienvenido al Sistema de Gestión de Cartas de Autorización.\r\n\r\nSeleccione su tipo de usuario para comenzar:";
            this.lblDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnIngresarUsuario
            // 
            this.btnIngresarUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnIngresarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresarUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresarUsuario.ForeColor = System.Drawing.Color.White;
            this.btnIngresarUsuario.Location = new System.Drawing.Point(100, 250);
            this.btnIngresarUsuario.Name = "btnIngresarUsuario";
            this.btnIngresarUsuario.Size = new System.Drawing.Size(200, 50);
            this.btnIngresarUsuario.TabIndex = 3;
            this.btnIngresarUsuario.Text = "👤 Ingresar como Usuario";
            this.btnIngresarUsuario.UseVisualStyleBackColor = false;
            this.btnIngresarUsuario.Click += new System.EventHandler(this.btnIngresarUsuario_Click);
            // 
            // btnIngresarAdmin
            // 
            this.btnIngresarAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnIngresarAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresarAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresarAdmin.ForeColor = System.Drawing.Color.White;
            this.btnIngresarAdmin.Location = new System.Drawing.Point(350, 250);
            this.btnIngresarAdmin.Name = "btnIngresarAdmin";
            this.btnIngresarAdmin.Size = new System.Drawing.Size(200, 50);
            this.btnIngresarAdmin.TabIndex = 4;
            this.btnIngresarAdmin.Text = "🔑 Panel Administrador";
            this.btnIngresarAdmin.UseVisualStyleBackColor = false;
            this.btnIngresarAdmin.Click += new System.EventHandler(this.btnIngresarAdmin_Click);
            // 
            // btnVerEstadisticas
            // 
            this.btnVerEstadisticas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnVerEstadisticas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerEstadisticas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerEstadisticas.ForeColor = System.Drawing.Color.White;
            this.btnVerEstadisticas.Location = new System.Drawing.Point(100, 330);
            this.btnVerEstadisticas.Name = "btnVerEstadisticas";
            this.btnVerEstadisticas.Size = new System.Drawing.Size(200, 45);
            this.btnVerEstadisticas.TabIndex = 5;
            this.btnVerEstadisticas.Text = "📊 Ver Estadísticas";
            this.btnVerEstadisticas.UseVisualStyleBackColor = false;
            this.btnVerEstadisticas.Click += new System.EventHandler(this.btnVerEstadisticas_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Location = new System.Drawing.Point(350, 330);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(200, 45);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "❌ Salir del Sistema";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(650, 420);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnVerEstadisticas);
            this.Controls.Add(this.btnIngresarAdmin);
            this.Controls.Add(this.btnIngresarUsuario);
            this.Controls.Add(this.panelBienvenida);
            this.Controls.Add(this.lblSubtitulo);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Cartas de Autorización - Inicio";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelBienvenida.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Button btnIngresarUsuario;
        private System.Windows.Forms.Button btnIngresarAdmin;
        private System.Windows.Forms.Button btnVerEstadisticas;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel panelBienvenida;
        private System.Windows.Forms.Label lblDescripcion;
    }
}