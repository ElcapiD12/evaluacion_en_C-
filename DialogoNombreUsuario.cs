using System;
using System.Windows.Forms;

namespace SistemaCartasAutorizacion.Forms
{
    public partial class DialogoNombreUsuario : Form
    {
        public string NombreUsuario { get; private set; }

        public DialogoNombreUsuario()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Por favor ingrese su nombre antes de continuar.",
                    "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            NombreUsuario = txtNombre.Text.Trim();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
