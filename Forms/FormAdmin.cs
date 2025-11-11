using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SistemaCartasAutorizacion.Models;
using SistemaCartasAutorizacion.Business;

namespace SistemaCartasAutorizacion.Forms
{
    /// <summary>
    /// Formulario de administración para gestionar cartas de autorización
    /// Permite aprobar, rechazar y visualizar todas las solicitudes del sistema
    /// </summary>
    public partial class FormAdmin : Form
    {
        #region Variables Privadas

        /// <summary>
        /// Gestor de cartas compartido con otros formularios
        /// </summary>
        private GestorCartas gestor;

        /// <summary>
        /// Lista completa de todas las cartas en el sistema
        /// </summary>
        private List<CartaAutorizacion> cartasActuales;

        /// <summary>
        /// Carta actualmente seleccionada en el DataGridView
        /// </summary>
        private CartaAutorizacion cartaSeleccionada;

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor que recibe el gestor de cartas compartido
        /// </summary>
        /// <param name="gestorCartas">Instancia del gestor de cartas</param>
        public FormAdmin(GestorCartas gestorCartas)
        {
            InitializeComponent();
            this.gestor = gestorCartas ?? throw new ArgumentNullException("El gestor de cartas no puede ser nulo");
            this.cartasActuales = new List<CartaAutorizacion>();
        }

        /// <summary>
        /// Constructor por defecto - crea un nuevo gestor
        /// Solo para diseño, en producción siempre usar el constructor con parámetros
        /// </summary>
        public FormAdmin()
        {
            InitializeComponent();
            this.gestor = new GestorCartas();
            this.cartasActuales = new List<CartaAutorizacion>();
        }

        #endregion

        #region Eventos de Formulario

        /// <summary>
        /// Evento que se ejecuta al cargar el formulario
        /// Carga las cartas iniciales y configura el DataGridView
        /// </summary>
        private void FormAdmin_Load(object sender, EventArgs e)
        {
            try
            {
                ConfigurarDataGridView();
                CargarTodasLasCartas();
                ActualizarEstadisticas();
                DeshabilitarBotonesAccion();
            }
            catch (Exception ex)
            {
                MostrarError("Error al cargar el formulario", ex.Message);
            }
        }

        #endregion

        #region Métodos de Configuración

        /// <summary>
        /// Configura las columnas del DataGridView para mostrar las cartas
        /// Define qué información será visible y cómo se mostrará
        /// </summary>
        private void ConfigurarDataGridView()
        {
            dgvCartas.AutoGenerateColumns = false;
            dgvCartas.MultiSelect = false;

            // Configurar columnas manualmente para mayor control
            dgvCartas.Columns.Clear();

            // Columna ID
            dgvCartas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "ID",
                DataPropertyName = "Id",
                Width = 50
            });

            // Columna Solicitante
            dgvCartas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Solicitante",
                HeaderText = "Solicitante",
                DataPropertyName = "Solicitante",
                Width = 120
            });

            // Columna Tipo
            dgvCartas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Tipo",
                HeaderText = "Tipo",
                DataPropertyName = "TipoAutorizacion",
                Width = 150
            });

            // Columna Motivo
            dgvCartas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Motivo",
                HeaderText = "Motivo",
                DataPropertyName = "Motivo",
                Width = 200
            });

            // Columna Estado
            dgvCartas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Estado",
                HeaderText = "Estado",
                DataPropertyName = "Estado",
                Width = 80
            });

            // Columna Fecha
            dgvCartas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Fecha",
                HeaderText = "Fecha",
                DataPropertyName = "FechaSolicitud",
                Width = 100
            });
        }

        #endregion

        #region Métodos de Carga de Datos

        /// <summary>
        /// Carga todas las cartas de autorización desde el gestor
        /// y las muestra en el DataGridView
        /// </summary>
        private void CargarTodasLasCartas()
        {
            try
            {
                // Obtener todas las cartas del gestor
                cartasActuales = gestor.ObtenerTodasLasCartas();

                // Actualizar el DataGridView
                ActualizarDataGridView(cartasActuales);

                // Actualizar contador
                lblListaCartas.Text = $"Lista de Cartas: ({cartasActuales.Count} total)";
            }
            catch (Exception ex)
            {
                MostrarError("Error al cargar las cartas", ex.Message);
            }
        }

        /// <summary>
        /// Actualiza el DataGridView con una lista específica de cartas
        /// </summary>
        /// <param name="cartas">Lista de cartas a mostrar</param>
        private void ActualizarDataGridView(List<CartaAutorizacion> cartas)
        {
            dgvCartas.DataSource = null;
            dgvCartas.DataSource = cartas;

            // Aplicar formato condicional a las filas según el estado
            AplicarFormatoFilas();
        }

        /// <summary>
        /// Aplica colores a las filas según el estado de la carta
        /// Verde: Aprobada, Rojo: Rechazada, Amarillo: Pendiente
        /// </summary>
        private void AplicarFormatoFilas()
        {
            foreach (DataGridViewRow fila in dgvCartas.Rows)
            {
                if (fila.DataBoundItem is CartaAutorizacion carta)
                {
                    switch (carta.Estado.ToLower())
                    {
                        case "aprobada":
                            fila.DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                            break;
                        case "rechazada":
                            fila.DefaultCellStyle.BackColor = System.Drawing.Color.LightCoral;
                            break;
                        case "pendiente":
                            fila.DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                            break;
                    }
                }
            }
        }

        #endregion

        #region Métodos de Estadísticas

        /// <summary>
        /// Calcula y muestra las estadísticas del sistema
        /// Total de cartas, aprobadas, rechazadas y pendientes
        /// </summary>
        private void ActualizarEstadisticas()
        {
            try
            {
                // Obtener estadísticas del gestor
                var stats = gestor.ObtenerEstadisticas();

                // Mostrar estadísticas en el label
                lblEstadisticas.Text = $"Total: {stats["Total"]}\n" +
                                      $"✓ Aprobadas: {stats["Aprobadas"]}\n" +
                                      $"✗ Rechazadas: {stats["Rechazadas"]}\n" +
                                      $"⏳ Pendientes: {stats["Pendientes"]}";
            }
            catch (Exception ex)
            {
                lblEstadisticas.Text = "Error al calcular estadísticas";
                MostrarError("Error en estadísticas", ex.Message);
            }
        }

        #endregion

        #region Eventos de Botones

        /// <summary>
        /// Muestra todas las cartas sin filtro
        /// </summary>
        private void btnMostrarTodas_Click(object sender, EventArgs e)
        {
            try
            {
                cartasActuales = gestor.ObtenerTodasLasCartas();
                ActualizarDataGridView(cartasActuales);
                lblListaCartas.Text = $"Lista de Cartas: ({cartasActuales.Count} total)";
            }
            catch (Exception ex)
            {
                MostrarError("Error al mostrar todas las cartas", ex.Message);
            }
        }

        /// <summary>
        /// Filtra y muestra solo las cartas con estado "Pendiente"
        /// </summary>
        private void btnMostrarPendientes_Click(object sender, EventArgs e)
        {
            try
            {
                cartasActuales = gestor.ObtenerCartasPendientes();
                ActualizarDataGridView(cartasActuales);
                lblListaCartas.Text = $"Lista de Cartas: ({cartasActuales.Count} pendientes)";

                if (cartasActuales.Count == 0)
                {
                    MessageBox.Show("No hay cartas pendientes de revisión.",
                                  "Información",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MostrarError("Error al filtrar cartas pendientes", ex.Message);
            }
        }

        /// <summary>
        /// Recarga todas las cartas y actualiza la vista
        /// </summary>
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                CargarTodasLasCartas();
                ActualizarEstadisticas();
                LimpiarDetalles();
                MessageBox.Show("Datos actualizados correctamente.",
                              "Actualización",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MostrarError("Error al actualizar", ex.Message);
            }
        }

        /// <summary>
        /// Aprueba la carta seleccionada actualmente
        /// Cambia su estado a "Aprobada" y registra la fecha de aprobación
        /// </summary>
        private void btnAprobar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar que hay una carta seleccionada
                if (cartaSeleccionada == null)
                {
                    MessageBox.Show("Por favor, seleccione una carta para aprobar.",
                                  "Advertencia",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Warning);
                    return;
                }

                // Verificar que la carta está pendiente
                if (!cartaSeleccionada.Estado.Equals("Pendiente", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show($"Esta carta ya fue procesada. Estado actual: {cartaSeleccionada.Estado}",
                                  "Información",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                    return;
                }

                // Confirmar acción
                DialogResult resultado = MessageBox.Show(
                    $"¿Está seguro de aprobar la carta #{cartaSeleccionada.Id} de {cartaSeleccionada.Solicitante}?\n\n" +
                    $"Tipo: {cartaSeleccionada.TipoAutorizacion}\n" +
                    $"Motivo: {cartaSeleccionada.Motivo}",
                    "Confirmar Aprobación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Aprobar la carta usando el gestor
                    bool exitoso = gestor.AprobarCarta(cartaSeleccionada.Id, "Aprobada por el administrador");

                    if (exitoso)
                    {
                        MessageBox.Show("Carta aprobada exitosamente.",
                                      "Éxito",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Information);

                        // Actualizar vista
                        CargarTodasLasCartas();
                        ActualizarEstadisticas();
                        MostrarDetallesCarta(cartaSeleccionada);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo aprobar la carta.",
                                      "Error",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarError("Error al aprobar carta", ex.Message);
            }
        }

        /// <summary>
        /// Rechaza la carta seleccionada actualmente
        /// Solicita un motivo y cambia el estado a "Rechazada"
        /// </summary>
        private void btnRechazar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar que hay una carta seleccionada
                if (cartaSeleccionada == null)
                {
                    MessageBox.Show("Por favor, seleccione una carta para rechazar.",
                                  "Advertencia",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Warning);
                    return;
                }

                // Verificar que la carta está pendiente
                if (!cartaSeleccionada.Estado.Equals("Pendiente", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show($"Esta carta ya fue procesada. Estado actual: {cartaSeleccionada.Estado}",
                                  "Información",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                    return;
                }

                // Solicitar motivo de rechazo usando el diálogo personalizado
                string motivo = DialogMotivoRechazo.MostrarDialogo();

                if (string.IsNullOrWhiteSpace(motivo))
                {
                    // Usuario canceló la operación
                    return;
                }

                // Confirmar acción
                DialogResult resultado = MessageBox.Show(
                    $"¿Está seguro de rechazar la carta #{cartaSeleccionada.Id} de {cartaSeleccionada.Solicitante}?\n\n" +
                    $"Motivo del rechazo: {motivo}",
                    "Confirmar Rechazo",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Rechazar la carta usando el gestor
                    bool exitoso = gestor.RechazarCarta(cartaSeleccionada.Id, motivo);

                    if (exitoso)
                    {
                        MessageBox.Show("Carta rechazada exitosamente.",
                                      "Éxito",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Information);

                        // Actualizar vista
                        CargarTodasLasCartas();
                        ActualizarEstadisticas();
                        MostrarDetallesCarta(cartaSeleccionada);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo rechazar la carta.",
                                      "Error",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarError("Error al rechazar carta", ex.Message);
            }
        }

        #endregion

        #region Eventos de DataGridView

        /// <summary>
        /// Se ejecuta cuando cambia la selección en el DataGridView
        /// Muestra los detalles de la carta seleccionada
        /// </summary>
        private void dgvCartas_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvCartas.SelectedRows.Count > 0)
                {
                    cartaSeleccionada = dgvCartas.SelectedRows[0].DataBoundItem as CartaAutorizacion;

                    if (cartaSeleccionada != null)
                    {
                        MostrarDetallesCarta(cartaSeleccionada);
                        HabilitarBotonesAccion(cartaSeleccionada);
                    }
                }
                else
                {
                    LimpiarDetalles();
                    DeshabilitarBotonesAccion();
                }
            }
            catch (Exception ex)
            {
                MostrarError("Error al seleccionar carta", ex.Message);
            }
        }

        #endregion

        #region Métodos de Visualización

        /// <summary>
        /// Muestra los detalles completos de una carta en el TextBox
        /// </summary>
        /// <param name="carta">Carta a mostrar</param>
        private void MostrarDetallesCarta(CartaAutorizacion carta)
        {
            txtDetalles.Text = $"═══════════════════════════════════════════════\n" +
                              $"DETALLES DE LA CARTA #{carta.Id}\n" +
                              $"═══════════════════════════════════════════════\n\n" +
                              $"👤 Solicitante: {carta.Solicitante}\n" +
                              $"📋 Tipo de Autorización: {carta.TipoAutorizacion}\n\n" +
                              $"📄 Motivo de la Solicitud:\n{carta.Motivo}\n\n" +
                              $"📊 Estado: {carta.Estado}\n" +
                              $"📅 Fecha Solicitud: {carta.FechaSolicitud:dd/MM/yyyy HH:mm}\n";

            // Agregar comentario del administrador si existe
            if (!string.IsNullOrEmpty(carta.ComentarioAdmin))
            {
                txtDetalles.Text += $"\n💬 Comentario del Administrador:\n{carta.ComentarioAdmin}\n";
            }
        }

        /// <summary>
        /// Limpia el TextBox de detalles
        /// </summary>
        private void LimpiarDetalles()
        {
            txtDetalles.Clear();
            txtDetalles.Text = "Seleccione una carta para ver sus detalles...";
            cartaSeleccionada = null;
        }

        #endregion

        #region Métodos de Control de Botones

        /// <summary>
        /// Habilita o deshabilita los botones de acción según el estado de la carta
        /// Solo se pueden aprobar/rechazar cartas pendientes
        /// </summary>
        /// <param name="carta">Carta seleccionada</param>
        private void HabilitarBotonesAccion(CartaAutorizacion carta)
        {
            bool esPendiente = carta.Estado.Equals("Pendiente", StringComparison.OrdinalIgnoreCase);
            btnAprobar.Enabled = esPendiente;
            btnRechazar.Enabled = esPendiente;
        }

        /// <summary>
        /// Deshabilita los botones de aprobar y rechazar
        /// </summary>
        private void DeshabilitarBotonesAccion()
        {
            btnAprobar.Enabled = false;
            btnRechazar.Enabled = false;
        }

        #endregion

        #region Métodos de Utilidad

        /// <summary>
        /// Muestra un mensaje de error formateado
        /// </summary>
        /// <param name="titulo">Título del error</param>
        /// <param name="mensaje">Descripción del error</param>
        private void MostrarError(string titulo, string mensaje)
        {
            MessageBox.Show($"{mensaje}",
                          titulo,
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error);
        }

        #endregion
    }
}