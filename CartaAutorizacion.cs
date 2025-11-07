using System;
using System.Security.Cryptography;

namespace SistemaCartasAutorizacion.Models
{
    /// <summary>
    /// Clase que representa una carta de autorizaciónjjjj
    /// Implementa encapsulación y propiedades
    /// </summary>
    public class CartaAutorizacion
    {
        // Variables privadas (encapsulación)
        private int id;
        private string solicitante;
        private string motivo;
        private DateTime fechaSolicitud;
        private string estado; // "Pendiente", "Aprobada", "Rechazada"
        private string comentarioAdmin;
        private string tipoAutorizacion;

        // Propiedades públicas
        /// <summary>
        /// ID único de la carta
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Nombre de quien solicita la autorización
        /// </summary>
        public string Solicitante
        {
            get { return solicitante; }
            set { solicitante = value; }
        }

        /// <summary>
        /// Motivo de la solicitud
        /// </summary>
        public string Motivo
        {
            get { return motivo; }
            set { motivo = value; }
        }

        /// <summary>
        /// Fecha en que se realizó la solicitud
        /// </summary>
        public DateTime FechaSolicitud
        {
            get { return fechaSolicitud; }
            set { fechaSolicitud = value; }
        }

        /// <summary>
        /// Estado actual de la carta (Pendiente/Aprobada/Rechazada)
        /// </summary>
        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        /// <summary>
        /// Comentario del administrador sobre la decisión
        /// </summary>
        public string ComentarioAdmin
        {
            get { return comentarioAdmin; }
            set { comentarioAdmin = value; }
        }

        /// <summary>
        /// Tipo de autorización solicitada
        /// </summary>
        public string TipoAutorizacion
        {
            get { return tipoAutorizacion; }
            set { tipoAutorizacion = value; }
        }

        // Constructor sin parámetros
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public CartaAutorizacion()
        {
            this.id = 0;
            this.solicitante = "";
            this.motivo = "";
            this.fechaSolicitud = DateTime.Now;
            this.estado = "Pendiente";
            this.comentarioAdmin = "";
            this.tipoAutorizacion = "";
        }

        // Constructor con parámetros (sobrecarga)
        /// <summary>
        /// Constructor para crear una nueva carta con datos iniciales
        /// </summary>
        /// <param name="id">ID de la carta</param>
        /// <param name="solicitante">Nombre del solicitante</param>
        /// <param name="motivo">Motivo de la solicitud</param>
        /// <param name="tipoAutorizacion">Tipo de autorización</param>
        public CartaAutorizacion(int id, string solicitante, string motivo, string tipoAutorizacion)
        {
            this.id = id;
            this.solicitante = solicitante;
            this.motivo = motivo;
            this.tipoAutorizacion = tipoAutorizacion;
            this.fechaSolicitud = DateTime.Now;
            this.estado = "Pendiente";
            this.comentarioAdmin = "";
        }

        // Métodos públicos
        /// <summary>
        /// Aprueba la carta de autorización
        /// </summary>
        /// <param name="comentario">Comentario del admin</param>
        public void Aprobar(string comentario)
        {
            this.estado = "Aprobada";
            this.comentarioAdmin = comentario;
        }

        /// <summary>
        /// Rechaza la carta de autorización
        /// </summary>
        /// <param name="comentario">Motivo del rechazo</param>
        public void Rechazar(string comentario)
        {
            this.estado = "Rechazada";
            this.comentarioAdmin = comentario;
        }

        /// <summary>
        /// Verifica si la carta está pendiente de revisión
        /// </summary>
        /// <returns>True si está pendiente</returns>
        public bool EstaPendiente()
        {
            return estado == "Pendiente";
        }

        /// <summary>
        /// Obtiene un resumen de la carta en formato texto
        /// </summary>
        /// <returns>String con el resumen</returns>
        public string ObtenerResumen()
        {
            return $"ID: {id}\n" +
                   $"Solicitante: {solicitante}\n" +
                   $"Tipo: {tipoAutorizacion}\n" +
                   $"Estado: {estado}\n" +
                   $"Fecha: {fechaSolicitud.ToShortDateString()}";
        }

        /// <summary>
        /// Valida que los datos de la carta sean correctos
        /// </summary>
        /// <returns>True si los datos son válidos</returns>
        public bool ValidarDatos()
        {
            return !string.IsNullOrEmpty(solicitante) &&
                   !string.IsNullOrEmpty(motivo) &&
                   !string.IsNullOrEmpty(tipoAutorizacion);
        }
    }
}
