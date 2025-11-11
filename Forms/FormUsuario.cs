using System;
using System.Windows.Forms;
using SistemaCartasAutorizacion.Models;
using SistemaCartasAutorizacion.Business;

namespace SistemaCartasAutorizacion.Forms
{
    /// <summary>
    /// Formulario de usuario para crear y visualizar cartas de autorización
    /// Permite a los usuarios enviar nuevas solicitudes y ver su historial
    /// </summary>
    public partial class FormUsuario : Form
    {
        #region Variables Privadas

        /// <summary>
        /// Gestor de cartas compartido con otros formularios
        /// </summary>
        private GestorCartas gestor;

        /// <summary>
        /// Nombre del usuario actual que está usando el sistema
        /// </summary>
        private string nombreUsuarioActual;

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto
        /// Crea un nuevo gestor y usa un usuario demo
        /// </summary>
        public FormUsuario()
        {
            InitializeComponent();
            gestor = new GestorCartas();
            nombreUsuarioActual = "Usuario Demo";
            ConfigurarDataGridView();
        }

        /// <summary>
        /// Constructor con parámetros (sobrecarga)
        /// Recibe el gestor de cartas y el nombre del usuario
        /// </summary>
        /// <param name="gestorCartas">Instancia del gestor de cartas</param>
        /// <param name="nombreUsuario">Nombre del usuario actual</param>
        public FormUsuario(GestorCartas gestorCartas, string nombreUsuario)
        {
            InitializeComponent();
            this.gestor = gestorCartas;
            this.nombreUsuarioActual = nombreUsuario;
            ConfigurarDataGridView();
        }

        #endregion

        #region Configuración del DataGridView

        /// <summary>
        /// Configura las columnas del DataGridView
        /// Define qué propiedades de CartaAutorizacion se mostrarán
        /// </summary>
        private void ConfigurarDataGridView()
        {
            dgvMisCartas.AutoGenerateColumns = false;
            dgvMisCartas.Columns.Clear();

            // Columna ID
            dgvMisCartas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "ID",
                DataPropertyName = "Id",
                Width = 50
            });

            // Columna Tipo
            dgvMisCartas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Tipo",
                DataPropertyName = "TipoAutorizacion",
                Width = 100
            });

            // Columna Motivo
            dgvMisCartas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Motivo",
                DataPropertyName = "Motivo",
                Width = 200
            });

            // Columna Estado
            dgvMisCartas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Estado",
                DataPropertyName = "Estado",
                Width = 80
            });

            // Columna Fecha
            dgvMisCartas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Fecha",
                DataPropertyName = "FechaSolicitud",
                Width = 100
            });

            // Columna Comentario Admin
            dgvMisCartas.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Comentario Admin",
                DataPropertyName = "ComentarioAdmin",
                Width = 150
            });
        }

        #endregion

        #region Eventos del Formulario

        /// <summary>
        /// Evento que se ejecuta al cargar el formulario
        /// Configura el título y carga las cartas del usuario
        /// </summary>
        private void FormUsuario_Load(object sender, EventArgs e)
        {
            this.Text = "Vista Usuario - " + nombreUsuarioActual;
            CargarMisCartas();
        }

        #endregion

        #region Métodos de Carga de Datos

        /// <summary>
        /// Carga las cartas del usuario actual desde el gestor
        /// y las muestra en el DataGridView
        /// </summary>
        private void CargarMisCartas()
        {
            try
            {
                var misCartas = gestor.ObtenerCartasPorSolicitante(nombreUsuarioActual);
                dgvMisCartas.DataSource = null;
                dgvMisCartas.DataSource = misCartas;

                // Aplicar colores según el estado
                AplicarFormatoFilas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las cartas: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Aplica colores a las filas según el estado de la carta
        /// Verde: Aprobada, Rojo: Rechazada, Amarillo: Pendiente
        /// </summary>
        private void AplicarFormatoFilas()
        {
            foreach (DataGridViewRow fila in dgvMisCartas.Rows)
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

        #region Eventos de Botones

        /// <summary>
        /// Evento del botón Enviar - Crea una nueva carta de autorización
        /// Valida los campos y envía la solicitud al gestor
        /// </summary>
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que los campos no estén vacíos
                if (!ValidarCampos())
                {
                    MessageBox.Show("Por favor complete todos los campos correctamente:\n\n" +
                                  "- Tipo de Autorización: requerido\n" +
                                  "- Motivo: debe tener al menos 10 caracteres",
                        "Error de validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                // Verificar que el usuario no tenga muchas cartas pendientes
                if (!gestor.PuedeCrearCarta(nombreUsuarioActual))
                {
                    MessageBox.Show("Ha alcanzado el límite de cartas pendientes (5 máximo).\n" +
                                  "Por favor espere a que se procesen sus solicitudes anteriores.",
                        "Límite alcanzado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                // Crear la carta con el orden correcto de parámetros
                // CrearCarta(nombreSolicitante, tipo, motivo)
                CartaAutorizacion nuevaCarta = gestor.CrearCarta(
                    nombreUsuarioActual,
                    txtTipo.Text.Trim(),      // ✅ TIPO (segundo parámetro)
                    txtMotivo.Text.Trim()     // ✅ MOTIVO (tercer parámetro)
                );

                if (nuevaCarta != null)
                {
                    MessageBox.Show($"Carta #{nuevaCarta.Id} enviada exitosamente.\n\n" +
                                  "Su solicitud está en espera de aprobación.\n" +
                                  "Podrá ver el estado actualizado en la lista de abajo.",
                        "Éxito",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // Limpiar campos y actualizar lista
                    LimpiarCampos();
                    CargarMisCartas();
                }
                else
                {
                    MessageBox.Show("Error al crear la carta. Por favor intente nuevamente.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (ArgumentException ex)
            {
                // Errores de validación del gestor
                MessageBox.Show(ex.Message,
                    "Error de validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                // Otros errores
                MessageBox.Show($"Error al enviar la carta: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento del botón Actualizar - Recarga la lista de cartas del usuario
        /// </summary>
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                CargarMisCartas();
                MessageBox.Show("Lista actualizada correctamente.",
                    "Información",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento del botón Ver Admin - Abre el formulario de administración
        /// </summary>
        private void btnVerAdmin_Click(object sender, EventArgs e)
        {
            try
            {
                // Crear y mostrar el formulario de administración
                // Pasando el mismo gestor para compartir los datos
                FormAdmin formAdmin = new FormAdmin(gestor);
                formAdmin.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el panel de administración: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Métodos de Validación

        /// <summary>
        /// Valida que los campos del formulario sean correctos
        /// </summary>
        /// <returns>True si todos los campos son válidos</returns>
        private bool ValidarCampos()
        {
            // Validar que el tipo no esté vacío
            if (string.IsNullOrWhiteSpace(txtTipo.Text))
            {
                txtTipo.Focus();
                return false;
            }

            // Validar que el motivo tenga al menos 10 caracteres
            if (string.IsNullOrWhiteSpace(txtMotivo.Text) || txtMotivo.Text.Trim().Length < 10)
            {
                txtMotivo.Focus();
                return false;
            }

            return true;
        }

        #endregion

        #region Métodos Auxiliares

        /// <summary>
        /// Limpia los campos del formulario después de enviar una carta
        /// </summary>
        private void LimpiarCampos()
        {
            txtMotivo.Clear();
            txtTipo.Clear();
            txtTipo.Focus();
        }

        #endregion
    }
}