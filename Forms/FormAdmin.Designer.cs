namespace SistemaCartasAutorizacion.Forms
{
    partial class FormAdmin
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
            this.lblTituloAdmin = new System.Windows.Forms.Label();
            this.grpEstadisticas = new System.Windows.Forms.GroupBox();
            this.lblEstadisticas = new System.Windows.Forms.Label();
            this.btnMostrarTodas = new System.Windows.Forms.Button();
            this.btnMostrarPendientes = new System.Windows.Forms.Button();
            this.lblListaCartas = new System.Windows.Forms.Label();
            this.dgvCartas = new System.Windows.Forms.DataGridView();
            this.lblDetalles = new System.Windows.Forms.Label();
            this.txtDetalles = new System.Windows.Forms.TextBox();
            this.btnAprobar = new System.Windows.Forms.Button();
            this.btnRechazar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.grpEstadisticas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCartas)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTituloAdmin
            // 
            this.lblTituloAdmin.AutoSize = true;
            this.lblTituloAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloAdmin.Location = new System.Drawing.Point(50, 20);
            this.lblTituloAdmin.Name = "lblTituloAdmin";
            this.lblTituloAdmin.Size = new System.Drawing.Size(260, 24);
            this.lblTituloAdmin.TabIndex = 0;
            this.lblTituloAdmin.Text = "Panel de Administración";
            // 
            // grpEstadisticas
            // 
            this.grpEstadisticas.Controls.Add(this.lblEstadisticas);
            this.grpEstadisticas.Location = new System.Drawing.Point(50, 60);
            this.grpEstadisticas.Name = "grpEstadisticas";
            this.grpEstadisticas.Size = new System.Drawing.Size(300, 120);
            this.grpEstadisticas.TabIndex = 1;
            this.grpEstadisticas.TabStop = false;
            this.grpEstadisticas.Text = "Estadísticas del Sistema";
            // 
            // lblEstadisticas
            // 
            this.lblEstadisticas.AutoSize = true;
            this.lblEstadisticas.Location = new System.Drawing.Point(10, 25);
            this.lblEstadisticas.Name = "lblEstadisticas";
            this.lblEstadisticas.Size = new System.Drawing.Size(155, 13);
            this.lblEstadisticas.TabIndex = 0;
            this.lblEstadisticas.Text = "Cargando estadísticas...";
            // 
            // btnMostrarTodas
            // 
            this.btnMostrarTodas.Location = new System.Drawing.Point(400, 80);
            this.btnMostrarTodas.Name = "btnMostrarTodas";
            this.btnMostrarTodas.Size = new System.Drawing.Size(150, 35);
            this.btnMostrarTodas.TabIndex = 2;
            this.btnMostrarTodas.Text = "Mostrar Todas";
            this.btnMostrarTodas.UseVisualStyleBackColor = true;
            this.btnMostrarTodas.Click += new System.EventHandler(this.btnMostrarTodas_Click);
            // 
            // btnMostrarPendientes
            // 
            this.btnMostrarPendientes.Location = new System.Drawing.Point(570, 80);
            this.btnMostrarPendientes.Name = "btnMostrarPendientes";
            this.btnMostrarPendientes.Size = new System.Drawing.Size(150, 35);
            this.btnMostrarPendientes.TabIndex = 3;
            this.btnMostrarPendientes.Text = "Solo Pendientes";
            this.btnMostrarPendientes.UseVisualStyleBackColor = true;
            this.btnMostrarPendientes.Click += new System.EventHandler(this.btnMostrarPendientes_Click);
            // 
            // lblListaCartas
            // 
            this.lblListaCartas.AutoSize = true;
            this.lblListaCartas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListaCartas.Location = new System.Drawing.Point(50, 200);
            this.lblListaCartas.Name = "lblListaCartas";
            this.lblListaCartas.Size = new System.Drawing.Size(132, 18);
            this.lblListaCartas.TabIndex = 4;
            this.lblListaCartas.Text = "Lista de Cartas:";
            // 
            // dgvCartas
            // 
            this.dgvCartas.AllowUserToAddRows = false;
            this.dgvCartas.AllowUserToDeleteRows = false;
            this.dgvCartas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCartas.Location = new System.Drawing.Point(50, 230);
            this.dgvCartas.Name = "dgvCartas";
            this.dgvCartas.ReadOnly = true;
            this.dgvCartas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCartas.Size = new System.Drawing.Size(800, 250);
            this.dgvCartas.TabIndex = 5;
            this.dgvCartas.SelectionChanged += new System.EventHandler(this.dgvCartas_SelectionChanged);
            // 
            // lblDetalles
            // 
            this.lblDetalles.AutoSize = true;
            this.lblDetalles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalles.Location = new System.Drawing.Point(50, 500);
            this.lblDetalles.Name = "lblDetalles";
            this.lblDetalles.Size = new System.Drawing.Size(280, 17);
            this.lblDetalles.TabIndex = 6;
            this.lblDetalles.Text = "Detalles de la Carta Seleccionada:";
            // 
            // txtDetalles
            // 
            this.txtDetalles.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDetalles.Location = new System.Drawing.Point(50, 525);
            this.txtDetalles.Multiline = true;
            this.txtDetalles.Name = "txtDetalles";
            this.txtDetalles.ReadOnly = true;
            this.txtDetalles.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDetalles.Size = new System.Drawing.Size(500, 100);
            this.txtDetalles.TabIndex = 7;
            // 
            // btnAprobar
            // 
            this.btnAprobar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnAprobar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAprobar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAprobar.ForeColor = System.Drawing.Color.White;
            this.btnAprobar.Location = new System.Drawing.Point(570, 525);
            this.btnAprobar.Name = "btnAprobar";
            this.btnAprobar.Size = new System.Drawing.Size(130, 40);
            this.btnAprobar.TabIndex = 8;
            this.btnAprobar.Text = "✓ Aprobar";
            this.btnAprobar.UseVisualStyleBackColor = false;
            this.btnAprobar.Click += new System.EventHandler(this.btnAprobar_Click);
            // 
            // btnRechazar
            // 
            this.btnRechazar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnRechazar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRechazar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRechazar.ForeColor = System.Drawing.Color.White;
            this.btnRechazar.Location = new System.Drawing.Point(720, 525);
            this.btnRechazar.Name = "btnRechazar";
            this.btnRechazar.Size = new System.Drawing.Size(130, 40);
            this.btnRechazar.TabIndex = 9;
            this.btnRechazar.Text = "✗ Rechazar";
            this.btnRechazar.UseVisualStyleBackColor = false;
            this.btnRechazar.Click += new System.EventHandler(this.btnRechazar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Location = new System.Drawing.Point(720, 80);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(130, 35);
            this.btnActualizar.TabIndex = 10;
            this.btnActualizar.Text = "🔄 Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 650);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnRechazar);
            this.Controls.Add(this.btnAprobar);
            this.Controls.Add(this.txtDetalles);
            this.Controls.Add(this.lblDetalles);
            this.Controls.Add(this.dgvCartas);
            this.Controls.Add(this.lblListaCartas);
            this.Controls.Add(this.btnMostrarPendientes);
            this.Controls.Add(this.btnMostrarTodas);
            this.Controls.Add(this.grpEstadisticas);
            this.Controls.Add(this.lblTituloAdmin);
            this.Name = "FormAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Cartas - Administrador";
            this.Load += new System.EventHandler(this.FormAdmin_Load);
            this.grpEstadisticas.ResumeLayout(false);
            this.grpEstadisticas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCartas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTituloAdmin;
        private System.Windows.Forms.GroupBox grpEstadisticas;
        private System.Windows.Forms.Label lblEstadisticas;
        private System.Windows.Forms.Button btnMostrarTodas;
        private System.Windows.Forms.Button btnMostrarPendientes;
        private System.Windows.Forms.Label lblListaCartas;
        private System.Windows.Forms.DataGridView dgvCartas;
        private System.Windows.Forms.Label lblDetalles;
        private System.Windows.Forms.TextBox txtDetalles;
        private System.Windows.Forms.Button btnAprobar;
        private System.Windows.Forms.Button btnRechazar;
        private System.Windows.Forms.Button btnActualizar;
    }
}