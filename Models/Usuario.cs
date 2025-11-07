using System;

namespace SistemaCartasAutorizacion.Models
{
    /// <summary>
    /// Clase que representa un usuario del sistema
    /// Aplica encapsulación con propiedades privadas
    /// </summary>
    public class Usuario
    {
        // Variables privadas (encapsulación)
        private string nombre;
        private string email;
        private bool esAdmin;

        // Propiedades públicas con get/set
        /// <summary>
        /// Nombre completo del usuario
        /// </summary>
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        /// <summary>
        /// Email del usuario para notificaciones
        /// </summary>
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        /// <summary>
        /// Indica si el usuario tiene permisos de administrador
        /// </summary>
        public bool EsAdmin
        {
            get { return esAdmin; }
            set { esAdmin = value; }
        }

        // Constructor sin parámetros
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Usuario()
        {
            this.nombre = "";
            this.email = "";
            this.esAdmin = false;
        }

        // Constructor con parámetros (sobrecarga)
        /// <summary>
        /// Constructor con parámetros para inicializar el usuario
        /// </summary>
        /// <param name="nombre">Nombre del usuario</param>
        /// <param name="email">Email del usuario</param>
        /// <param name="esAdmin">Si es administrador</param>
        public Usuario(string nombre, string email, bool esAdmin)
        {
            this.nombre = nombre;
            this.email = email;
            this.esAdmin = esAdmin;
        }

        // Constructor con solo nombre y email (sobrecarga)
        /// <summary>
        /// Constructor que crea un usuario normal (no admin)
        /// </summary>
        /// <param name="nombre">Nombre del usuario</param>
        /// <param name="email">Email del usuario</param>
        public Usuario(string nombre, string email)
        {
            this.nombre = nombre;
            this.email = email;
            this.esAdmin = false; // Por defecto no es admin
        }

        // Métodos públicos
        /// <summary>
        /// Obtiene la información completa del usuario
        /// </summary>
        /// <returns>String con los datos del usuario</returns>
        public string ObtenerInformacion()
        {
            string tipoUsuario = esAdmin ? "Administrador" : "Usuario";
            return $"Nombre: {nombre}\nEmail: {email}\nTipo: {tipoUsuario}";
        }

        /// <summary>
        /// Valida si el email tiene formato correcto
        /// </summary>
        /// <returns>True si el email es válido</returns>
        public bool ValidarEmail()
        {
            return !string.IsNullOrEmpty(email) && email.Contains("@");
        }
    }
}