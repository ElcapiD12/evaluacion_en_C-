using System;
using System.Collections.Generic;
using System.Linq;
using SistemaCartasAutorizacion.Models;

namespace SistemaCartasAutorizacion.Business
{
    /// <summary>
    /// Clase que gestiona todas las operaciones con las cartas de autorización.
    /// Implementa la lógica de negocio del sistema.
    /// Aplica encapsulación y validaciones.
    /// ADAPTADA para trabajar con las clases Usuario y CartaAutorizacion del Programador 1
    /// </summary>
    public class GestorCartas
    {
        // Variable privada - Lista que almacena todas las cartas
        private List<CartaAutorizacion> cartas;

        // Variable privada - Contador para generar IDs únicos
        private int contadorId;

        /// <summary>
        /// Propiedad pública para acceder a las cartas (solo lectura)
        /// Implementa encapsulación
        /// </summary>
        public List<CartaAutorizacion> Cartas
        {
            get { return cartas; }
        }

        /// <summary>
        /// Constructor sin parámetros
        /// Inicializa la lista vacía y el contador en 1
        /// </summary>
        public GestorCartas()
        {
            cartas = new List<CartaAutorizacion>();
            contadorId = 1;
        }

        /// <summary>
        /// Constructor con parámetros (sobrecarga de constructor)
        /// Permite inicializar con cartas existentes
        /// </summary>
        /// <param name="cartasIniciales">Lista de cartas para inicializar</param>
        public GestorCartas(List<CartaAutorizacion> cartasIniciales)
        {
            cartas = cartasIniciales ?? new List<CartaAutorizacion>();
            contadorId = cartas.Count > 0 ? cartas.Max(c => c.Id) + 1 : 1;
        }

        /// <summary>
        /// Crea una nueva carta de autorización usando objeto Usuario
        /// Aplica validaciones de negocio
        /// </summary>
        /// <param name="usuario">Usuario que crea la carta</param>
        /// <param name="tipo">Tipo de autorización</param>
        /// <param name="motivo">Motivo de la solicitud</param>
        /// <returns>La carta creada o null si hay error</returns>
        public CartaAutorizacion CrearCarta(Usuario usuario, string tipo, string motivo)
        {
            // Validación 1: Usuario no puede ser nulo
            if (usuario == null)
            {
                throw new ArgumentNullException("El usuario no puede ser nulo");
            }

            // Validación 2: Tipo no puede estar vacío
            if (string.IsNullOrWhiteSpace(tipo))
            {
                throw new ArgumentException("El tipo de autorización es obligatorio");
            }

            // Validación 3: Motivo debe tener al menos 10 caracteres
            if (string.IsNullOrWhiteSpace(motivo) || motivo.Length < 10)
            {
                throw new ArgumentException("El motivo debe tener al menos 10 caracteres");
            }

            // Crear nueva carta usando el nombre del usuario
            CartaAutorizacion nuevaCarta = new CartaAutorizacion(
                contadorId++,
                usuario.Nombre,  // Usa el nombre del usuario
                motivo,
                tipo
            );

            // Agregar a la lista
            cartas.Add(nuevaCarta);

            return nuevaCarta;
        }

        /// <summary>
        /// Sobrecarga del método CrearCarta
        /// Versión simplificada que recibe solo strings
        /// </summary>
        public CartaAutorizacion CrearCarta(string nombreSolicitante, string tipo, string motivo)
        {
            // Validar nombre de solicitante
            if (string.IsNullOrWhiteSpace(nombreSolicitante))
            {
                throw new ArgumentException("El nombre del solicitante es obligatorio");
            }

            // Validación 2: Tipo no puede estar vacío
            if (string.IsNullOrWhiteSpace(tipo))
            {
                throw new ArgumentException("El tipo de autorización es obligatorio");
            }

            // Validación 3: Motivo debe tener al menos 10 caracteres
            if (string.IsNullOrWhiteSpace(motivo) || motivo.Length < 10)
            {
                throw new ArgumentException("El motivo debe tener al menos 10 caracteres");
            }

            // Crear nueva carta directamente
            CartaAutorizacion nuevaCarta = new CartaAutorizacion(
                contadorId++,
                nombreSolicitante,
                motivo,
                tipo
            );

            // Agregar a la lista
            cartas.Add(nuevaCarta);

            return nuevaCarta;
        }

        /// <summary>
        /// Aprueba una carta de autorización
        /// </summary>
        /// <param name="idCarta">ID de la carta a aprobar</param>
        /// <param name="comentario">Comentario del administrador</param>
        /// <returns>true si se aprobó correctamente, false si no existe</returns>
        public bool AprobarCarta(int idCarta, string comentario = "Aprobada por el administrador")
        {
            CartaAutorizacion carta = BuscarCartaPorId(idCarta);

            if (carta == null)
            {
                return false;
            }

            // Verificar que esté pendiente
            if (carta.Estado != "Pendiente")
            {
                throw new InvalidOperationException("Solo se pueden aprobar cartas pendientes");
            }

            carta.Aprobar(comentario);
            return true;
        }

        /// <summary>
        /// Sobrecarga: Aprueba una carta sin comentario
        /// </summary>
        public bool AprobarCarta(int idCarta)
        {
            return AprobarCarta(idCarta, "Aprobada por el administrador");
        }

        /// <summary>
        /// Rechaza una carta de autorización
        /// </summary>
        /// <param name="idCarta">ID de la carta a rechazar</param>
        /// <param name="comentario">Motivo del rechazo</param>
        /// <returns>true si se rechazó correctamente, false si no existe</returns>
        public bool RechazarCarta(int idCarta, string comentario = "Rechazada por el administrador")
        {
            CartaAutorizacion carta = BuscarCartaPorId(idCarta);

            if (carta == null)
            {
                return false;
            }

            // Verificar que esté pendiente
            if (carta.Estado != "Pendiente")
            {
                throw new InvalidOperationException("Solo se pueden rechazar cartas pendientes");
            }

            carta.Rechazar(comentario);
            return true;
        }

        /// <summary>
        /// Sobrecarga: Rechaza una carta sin comentario
        /// </summary>
        public bool RechazarCarta(int idCarta)
        {
            return RechazarCarta(idCarta, "Rechazada por el administrador");
        }

        /// <summary>
        /// Busca una carta por su ID
        /// Método privado auxiliar
        /// </summary>
        private CartaAutorizacion BuscarCartaPorId(int id)
        {
            return cartas.FirstOrDefault(c => c.Id == id);
        }

        /// <summary>
        /// Obtiene todas las cartas del sistema
        /// </summary>
        public List<CartaAutorizacion> ObtenerTodasLasCartas()
        {
            return new List<CartaAutorizacion>(cartas);
        }

        /// <summary>
        /// Obtiene solo las cartas pendientes
        /// </summary>
        public List<CartaAutorizacion> ObtenerCartasPendientes()
        {
            return cartas.Where(c => c.Estado == "Pendiente").ToList();
        }

        /// <summary>
        /// Sobrecarga: Obtiene cartas filtradas por estado
        /// </summary>
        public List<CartaAutorizacion> ObtenerCartasPorEstado(string estado)
        {
            if (string.IsNullOrWhiteSpace(estado))
            {
                return ObtenerTodasLasCartas();
            }

            return cartas.Where(c => c.Estado.Equals(estado, StringComparison.OrdinalIgnoreCase))
                        .ToList();
        }

        /// <summary>
        /// Obtiene las cartas de un solicitante específico
        /// </summary>
        public List<CartaAutorizacion> ObtenerCartasPorSolicitante(string nombreSolicitante)
        {
            if (string.IsNullOrWhiteSpace(nombreSolicitante))
            {
                throw new ArgumentException("El nombre del solicitante es obligatorio");
            }

            return cartas.Where(c => c.Solicitante.Equals(nombreSolicitante,
                                    StringComparison.OrdinalIgnoreCase))
                        .ToList();
        }

        /// <summary>
        /// Obtiene cartas por tipo de autorización
        /// </summary>
        public List<CartaAutorizacion> ObtenerCartasPorTipo(string tipo)
        {
            if (string.IsNullOrWhiteSpace(tipo))
            {
                throw new ArgumentException("El tipo de autorización es obligatorio");
            }

            return cartas.Where(c => c.TipoAutorizacion.Equals(tipo,
                                    StringComparison.OrdinalIgnoreCase))
                        .ToList();
        }

        /// <summary>
        /// Calcula estadísticas del sistema
        /// </summary>
        public Dictionary<string, int> ObtenerEstadisticas()
        {
            Dictionary<string, int> estadisticas = new Dictionary<string, int>();

            estadisticas["Total"] = cartas.Count;
            estadisticas["Pendientes"] = cartas.Count(c => c.Estado == "Pendiente");
            estadisticas["Aprobadas"] = cartas.Count(c => c.Estado == "Aprobada");
            estadisticas["Rechazadas"] = cartas.Count(c => c.Estado == "Rechazada");

            return estadisticas;
        }

        /// <summary>
        /// Sobrecarga: Obtiene estadísticas en formato de texto
        /// </summary>
        public string ObtenerEstadisticasTexto()
        {
            var stats = ObtenerEstadisticas();
            return $"Total: {stats["Total"]} | " +
                   $"Pendientes: {stats["Pendientes"]} | " +
                   $"Aprobadas: {stats["Aprobadas"]} | " +
                   $"Rechazadas: {stats["Rechazadas"]}";
        }

        /// <summary>
        /// Valida si un solicitante puede crear más cartas
        /// Límite: 5 cartas pendientes por solicitante
        /// </summary>
        public bool PuedeCrearCarta(string nombreSolicitante)
        {
            int cartasPendientes = cartas.Count(c =>
                c.Solicitante.Equals(nombreSolicitante, StringComparison.OrdinalIgnoreCase) &&
                c.Estado == "Pendiente"
            );

            return cartasPendientes < 5;
        }

        /// <summary>
        /// Elimina una carta del sistema
        /// Solo disponible para administradores
        /// </summary>
        public bool EliminarCarta(int idCarta)
        {
            CartaAutorizacion carta = BuscarCartaPorId(idCarta);

            if (carta == null)
            {
                return false;
            }

            cartas.Remove(carta);
            return true;
        }

        /// <summary>
        /// Obtiene el conteo total de cartas
        /// </summary>
        public int ObtenerTotalCartas()
        {
            return cartas.Count;
        }

        /// <summary>
        /// Verifica si hay cartas pendientes
        /// </summary>
        public bool HayCartasPendientes()
        {
            return cartas.Any(c => c.Estado == "Pendiente");
        }

        /// <summary>
        /// Obtiene información detallada de una carta
        /// </summary>
        public string ObtenerDetallesCarta(int idCarta)
        {
            CartaAutorizacion carta = BuscarCartaPorId(idCarta);

            if (carta == null)
            {
                return "Carta no encontrada";
            }

            return carta.ObtenerResumen() +
                   $"\nMotivo: {carta.Motivo}" +
                   (!string.IsNullOrEmpty(carta.ComentarioAdmin)
                       ? $"\nComentario Admin: {carta.ComentarioAdmin}"
                       : "");
        }

        /// <summary>
        /// Valida todas las cartas del sistema
        /// Retorna lista de cartas con datos inválidos
        /// </summary>
        public List<CartaAutorizacion> ValidarTodasLasCartas()
        {
            return cartas.Where(c => !c.ValidarDatos()).ToList();
        }
    }
}