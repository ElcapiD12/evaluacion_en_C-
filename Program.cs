using System;
using System.Windows.Forms;

namespace SistemaCartasAutorizacion
{
    /// <summary>
    /// Clase principal del programa
    /// Punto de entrada de la aplicación
    /// </summary>
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Habilitar estilos visuales de Windows
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                // Iniciar la aplicación con el formulario principal (Form1)
                Application.Run(new Form1());
            }
            catch (Exception ex)
            {
                // Capturar errores no manejados en el nivel más alto
                MessageBox.Show(
                    $"Error crítico en la aplicación:\n\n{ex.Message}\n\nLa aplicación se cerrará.",
                    "Error Fatal",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}