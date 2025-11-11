namespace SistemaCartasAutorizacion.Forms
{
    partial class FormUsuario
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.txtTipo = new System.Windows.Forms.TextBox();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.lblMisCartas = new System.Windows.Forms.Label();
            this.dgvMisCartas = new System.Windows.Forms.DataGridView();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnVerAdmin = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMisCartas)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(50, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(329, 24);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Nueva Carta de Autorización";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(50, 80);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(128, 13);
            this.lblTipo.TabIndex = 1;
            this.lblTipo.Text = "Tipo de Autorización:";
            // 
            // txtTipo
            // 
            this.txtTipo.Location = new System.Drawing.Point(220, 78);
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.Size = new System.Drawing.Size(400, 20);
            this.txtTipo.TabIndex = 2;
            // 
            // lblMotivo
            // 
            this.lblMotivo.AutoSize = true;
            this.lblMotivo.Location = new System.Drawing.Point(50, 120);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(143, 13);
            this.lblMotivo.TabIndex = 3;
            this.lblMotivo.Text = "Motivo de la Solicitud:";
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(220, 118);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMotivo.Size = new System.Drawing.Size(400, 80);
            this.txtMotivo.TabIndex = 4;
            // 
            // btnEnviar
            // 
            this.btnEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviar.Location = new System.Drawing.Point(320, 220);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(150, 35);
            this.btnEnviar.TabIndex = 5;
            this.btnEnviar.Text = "Enviar Carta";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // lblMisCartas
            // 
            this.lblMisCartas.AutoSize = true;
            this.lblMisCartas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMisCartas.Location = new System.Drawing.Point(50, 280);
            this.lblMisCartas.Name = "lblMisCartas";
            this.lblMisCartas.Size = new System.Drawing.Size(173, 18);
            this.lblMisCartas.TabIndex = 6;
            this.lblMisCartas.Text = "Mis Cartas Enviadas:";
            // 
            // dgvMisCartas
            // 
            this.dgvMisCartas.AllowUserToAddRows = false;
            this.dgvMisCartas.AllowUserToDeleteRows = false;
            this.dgvMisCartas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMisCartas.Location = new System.Drawing.Point(50, 310);
            this.dgvMisCartas.Name = "dgvMisCartas";
            this.dgvMisCartas.ReadOnly = true;
            this.dgvMisCartas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMisCartas.Size = new System.Drawing.Size(700, 200);
            this.dgvMisCartas.TabIndex = 7;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(50, 520);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(130, 30);
            this.btnActualizar.TabIndex = 8;
            this.btnActualizar.Text = "Actualizar Lista";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnVerAdmin
            // 
            this.btnVerAdmin.Location = new System.Drawing.Point(200, 520);
            this.btnVerAdmin.Name = "btnVerAdmin";
            this.btnVerAdmin.Size = new System.Drawing.Size(130, 30);
            this.btnVerAdmin.TabIndex = 9;
            this.btnVerAdmin.Text = "Ver Vista Admin";
            this.btnVerAdmin.UseVisualStyleBackColor = true;
            this.btnVerAdmin.Click += new System.EventHandler(this.btnVerAdmin_Click);
            // 
            // FormUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.btnVerAdmin);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.dgvMisCartas);
            this.Controls.Add(this.lblMisCartas);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.txtMotivo);
            this.Controls.Add(this.lblMotivo);
            this.Controls.Add(this.txtTipo);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.lblTitulo);
            this.Name = "FormUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vista Usuario";
            this.Load += new System.EventHandler(this.FormUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMisCartas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.TextBox txtTipo;
        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Label lblMisCartas;
        private System.Windows.Forms.DataGridView dgvMisCartas;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnVerAdmin;
    }
}