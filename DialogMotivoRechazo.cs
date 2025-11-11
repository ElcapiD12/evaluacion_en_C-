using System;
using System.Windows.Forms;

namespace SistemaCartasAutorizacion.Forms
{
    /// <summary>
    /// Diálogo personalizado para solicitar el motivo de rechazo de una carta
    /// Reemplaza la funcionalidad de InputBox sin necesidad de Microsoft.VisualBasic
    /// </summary>
    public class DialogMotivoRechazo : Form
    {
        #region Controles Privados

        private Label lblInstruccion;
        private TextBox txtMotivo;
        private Button btnAceptar;
        private Button btnCancelar;

        #endregion

        #region Propiedades Públicas

        /// <summary>
        /// Obtiene el motivo ingresado por el usuario
        /// </summary>
        public string MotivoRechazo { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor del diálogo de motivo de rechazo
        /// </summary>
        public DialogMotivoRechazo()
        {
            InicializarComponentes();
        }

        #endregion

        #region Métodos de Inicialización

        /// <summary>
        /// Inicializa todos los componentes visuales del diálogo
        /// </summary>
        private void InicializarComponentes()
        {
            // Configuración del formulario
            this.Text = "Motivo de Rechazo";
            this.Size = new System.Drawing.Size(450, 250);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Label de instrucción
            lblInstruccion = new Label
            {
                Text = "Por favor, ingrese el motivo por el cual se rechaza esta carta de autorización:",
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(400, 40),
                Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular)
            };

            // TextBox para el motivo
            txtMotivo = new TextBox
            {
                Location = new System.Drawing.Point(20, 70),
                Size = new System.Drawing.Size(400, 80),
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                Font = new System.Drawing.Font("Microsoft Sans Serif", 9F)
            };

            // Botón Aceptar
            btnAceptar = new Button
            {
                Text = "Aceptar",
                Location = new System.Drawing.Point(220, 170),
                Size = new System.Drawing.Size(90, 30),
                DialogResult = DialogResult.OK,
                BackColor = System.Drawing.Color.FromArgb(52, 152, 219),
                ForeColor = System.Drawing.Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnAceptar.Click += BtnAceptar_Click;

            // Botón Cancelar
            btnCancelar = new Button
            {
                Text = "Cancelar",
                Location = new System.Drawing.Point(320, 170),
                Size = new System.Drawing.Size(90, 30),
                DialogResult = DialogResult.Cancel,
                BackColor = System.Drawing.Color.FromArgb(189, 195, 199),
                ForeColor = System.Drawing.Color.White,
                FlatStyle = FlatStyle.Flat
            };

            // Agregar controles al formulario
            this.Controls.Add(lblInstruccion);
            this.Controls.Add(txtMotivo);
            this.Controls.Add(btnAceptar);
            this.Controls.Add(btnCancelar);

            // Establecer botones de diálogo
            this.AcceptButton = btnAceptar;
            this.CancelButton = btnCancelar;
        }

        #endregion

        #region Eventos

        /// <summary>
        /// Evento del botón Aceptar - Valida que se haya ingresado un motivo
        /// </summary>
        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            MotivoRechazo = txtMotivo.Text.Trim();

            if (string.IsNullOrWhiteSpace(MotivoRechazo))
            {
                MessageBox.Show("Debe ingresar un motivo para el rechazo.",
                              "Campo Requerido",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                txtMotivo.Focus();
            }
        }

        #endregion

        #region Método Estático de Uso

        /// <summary>
        /// Muestra el diálogo y retorna el motivo ingresado
        /// </summary>
        /// <returns>Motivo ingresado o null si se cancela</returns>
        public static string MostrarDialogo()
        {
            using (var dialogo = new DialogMotivoRechazo())
            {
                if (dialogo.ShowDialog() == DialogResult.OK)
                {
                    return dialogo.MotivoRechazo;
                }
                return null;
            }
        }

        #endregion
    }
}