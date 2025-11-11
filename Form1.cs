using System;
using System.Windows.Forms;
using SistemaCartasAutorizacion.Forms;
using SistemaCartasAutorizacion.Business;
using SistemaCartasAutorizacion.Models;

namespace SistemaCartasAutorizacion
{
    /// <summary>
    /// Formulario principal de inicio del sistema
    /// Permite seleccionar el tipo de usuario (Usuario o Administrador)
    /// y gestiona la instancia compartida del gestor de cartas
    /// </summary>
    public partial class Form1 : Form
    {
        #region Variables Privadas

        /// <summary>
        /// Instancia única del gestor de cartas
        /// Se comparte entre todos los formularios para mantener consistencia
        /// </summary>
        private GestorCartas gestor;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor del formulario de inicio
        /// Inicializa los componentes y el gestor de cartas
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            InicializarGestor();
        }

        #endregion

        #region Métodos de Inicialización

        /// <summary>
        /// Inicializa el gestor de cartas y carga datos de prueba
        /// </summary>
        private void InicializarGestor()
        {
            try
            {
                // Crear nueva instancia del gestor
                gestor = new GestorCartas();

                // Cargar datos de prueba para demostración
                CargarDatosDePrueba();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al inicializar el sistema: {ex.Message}",
                    "Error de Inicialización",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Carga cartas de ejemplo para demostración del sistema
        /// Crea varios usuarios con diferentes tipos de solicitudes
        /// </summary>
        private void CargarDatosDePrueba()
        {
            try
            {
                // Carta 1 - Juan Pérez - Pendiente
                gestor.CrearCarta(
                    "Juan Pérez",
                    "Vacaciones",
                    "Solicito autorización para tomar 5 días de vacaciones del 15 al 19 de diciembre para asuntos personales."
                );

                // Carta 2 - María López - Pendiente
                gestor.CrearCarta(
                    "María López",
                    "Compra de Equipo",
                    "Requiero autorización para la compra de una laptop nueva HP modelo ProBook con las siguientes especificaciones: Intel i7, 16GB RAM, 512GB SSD."
                );

                // Carta 3 - Carlos Ruiz - Pendiente
                gestor.CrearCarta(
                    "Carlos Ruiz",
                    "Permiso Personal",
                    "Solicito permiso para ausentarme el día viernes 20 de noviembre por motivos médicos. Adjunto comprobante de cita médica."
                );

                // Carta 4 - Ana Martínez - Aprobada
                CartaAutorizacion carta4 = gestor.CrearCarta(
                    "Ana Martínez",
                    "Capacitación",
                    "Solicito autorización para asistir al curso de Excel Avanzado que se llevará a cabo del 25 al 27 de noviembre en modalidad virtual."
                );
                gestor.AprobarCarta(carta4.Id, "Aprobado. La capacitación es relevante para el puesto.");

                // Carta 5 - Luis Hernández - Rechazada
                CartaAutorizacion carta5 = gestor.CrearCarta(
                    "Luis Hernández",
                    "Viaje de Negocios",
                    "Solicito autorización para viajar a Monterrey del 1 al 3 de diciembre para reunión con cliente potencial ABC Corporation."
                );
                gestor.RechazarCarta(carta5.Id, "Rechazado. El presupuesto de viajes ya fue utilizado este mes. Reprogramar para enero.");

                // Carta 6 - Pedro Sánchez - Pendiente
                gestor.CrearCarta(
                    "Pedro Sánchez",
                    "Horas Extra",
                    "Solicito autorización para trabajar 10 horas extra durante la semana del 18 al 22 de noviembre para completar el proyecto urgente del cliente XYZ."
                );

                // Carta 7 - Laura García - Aprobada
                CartaAutorizacion carta7 = gestor.CrearCarta(
                    "Laura García",
                    "Trabajo Remoto",
                    "Solicito autorización para trabajar de forma remota durante dos semanas (del 25 de noviembre al 6 de diciembre) debido a mudanza de domicilio."
                );
                gestor.AprobarCarta(carta7.Id, "Aprobado. Mantener comunicación constante por Teams.");

                // Carta 8 - Roberto Torres - Pendiente
                gestor.CrearCarta(
                    "Roberto Torres",
                    "Ajuste de Horario",
                    "Solicito autorización para modificar mi horario de entrada de 8:00 AM a 9:00 AM durante el próximo mes debido a compromisos académicos."
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Advertencia al cargar datos de prueba: {ex.Message}",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        #endregion

        #region Eventos del Formulario

        /// <summary>
        /// Evento que se ejecuta al cargar el formulario
        /// Muestra información de bienvenida
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // Mostrar estadísticas iniciales en el título
                var stats = gestor.ObtenerEstadisticas();
                this.Text = $"Sistema de Cartas de Autorización - {stats["Total"]} cartas en el sistema";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Eventos de Botones

        /// <summary>
        /// Abre el formulario de Usuario
        /// Solicita el nombre del usuario antes de abrir
        /// </summary>
        private void btnIngresarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                // Solicitar nombre de usuario usando el diálogo separado
                using (var dialogoNombre = new DialogoNombreUsuario())
                {
                    if (dialogoNombre.ShowDialog() == DialogResult.OK)
                    {
                        string nombreUsuario = dialogoNombre.NombreUsuario;

                        if (!string.IsNullOrWhiteSpace(nombreUsuario))
                        {
                            // Crear y mostrar formulario de usuario
                            FormUsuario formUsuario = new FormUsuario(gestor, nombreUsuario);
                            formUsuario.Show();
                        }
                        else
                        {
                            MessageBox.Show("Debe ingresar un nombre de usuario.",
                                "Nombre Requerido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir vista de usuario: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Abre el formulario de Administrador
        /// No requiere autenticación (versión simplificada)
        /// </summary>
        private void btnIngresarAdmin_Click(object sender, EventArgs e)
        {
            try
            {
                // Confirmación simple (en producción sería login con contraseña)
                DialogResult resultado = MessageBox.Show(
                    "¿Desea acceder como Administrador?\n\n" +
                    "Tendrá acceso a todas las cartas del sistema y podrá aprobar o rechazar solicitudes.",
                    "Confirmar Acceso",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Crear y mostrar formulario de administrador
                    FormAdmin formAdmin = new FormAdmin(gestor);
                    formAdmin.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir panel de administración: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Muestra las estadísticas actuales del sistema
        /// </summary>
        private void btnVerEstadisticas_Click(object sender, EventArgs e)
        {
            try
            {
                var stats = gestor.ObtenerEstadisticas();
                string mensaje = "═══════════════════════════════════\n" +
                               "ESTADÍSTICAS DEL SISTEMA\n" +
                               "═══════════════════════════════════\n\n" +
                               $"📊 Total de Cartas: {stats["Total"]}\n\n" +
                               $"⏳ Pendientes: {stats["Pendientes"]}\n" +
                               $"✓ Aprobadas: {stats["Aprobadas"]}\n" +
                               $"✗ Rechazadas: {stats["Rechazadas"]}\n\n" +
                               "═══════════════════════════════════";

                MessageBox.Show(mensaje,
                    "Estadísticas del Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener estadísticas: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Cierra la aplicación
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Está seguro que desea salir del sistema?",
                "Confirmar Salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        #endregion
    }
}