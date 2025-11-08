using System;
using System.Windows.Forms;
using SistemaCartasAutorizacion.Forms;
using SistemaCartasAutorizacion.Business;

namespace SistemaCartasAutorizacion.Forms
{
    /// <summary>
    /// Clase principal que inicia la aplicación
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Configuración de la aplicación
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Crear instancia única del gestor de cartas
            // Esto permite compartir los datos entre formularios
            GestorCartas gestorCompartido = new GestorCartas();

            // Solicitar al usuario que seleccione su rol
            DialogResult resultado = MessageBox.Show(
                "¿Desea entrar como Administrador?\n\n" +
                "Sí = Vista Administrador\n" +
                "No = Vista Usuario",
                "Seleccionar Vista",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            // Abrir el formulario correspondiente
            if (resultado == DialogResult.Yes)
            {
                // Vista Administrador
                Application.Run(new FormAdmin(gestorCompartido));
            }
            else
            {
                // Vista Usuario
                // Solicitar nombre del usuario
                string nombreUsuario = Microsoft.VisualBasic.Interaction.InputBox(
                    "Ingrese su nombre:",
                    "Identificación de Usuario",
                    "Usuario Demo"
                );

                if (!string.IsNullOrEmpty(nombreUsuario))
                {
                    Application.Run(new FormUsuario(gestorCompartido, nombreUsuario));
                }
                else
                {
                    MessageBox.Show("Debe ingresar un nombre para continuar",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
    }
}
