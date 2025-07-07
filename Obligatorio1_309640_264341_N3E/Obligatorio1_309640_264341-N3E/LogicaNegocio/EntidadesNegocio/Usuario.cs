using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.ValueObject;


namespace LogicaNegocio.EntidadesNegocio
{
    public class Usuario: IEquatable<Usuario>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Email Email { get; set; }
        public Contrasenia Contrasenia { get; set; }
        public Rol Rol { get; set; }



        private Usuario() { }

        public Usuario(string nombre, string apellido, Email email, Contrasenia contrasenia)
        {
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Contrasenia = contrasenia;

            Validar();
        }

        public void Validar()
        {
            ValidarNombre();
            ValidarApellido();
            ValidarEmail();
            ValidarContrasenia();
        }

        private void ValidarNombre()
        {
            if (string.IsNullOrEmpty(Nombre))
                throw new Exception("El nombre no puede estar vacío.");
        }

        private void ValidarApellido()
        {
            if (string.IsNullOrEmpty(Apellido))
                throw new Exception("El apellido no puede estar vacío.");
        }

        private void ValidarEmail()
        {
            if (Email == null || string.IsNullOrEmpty(Email.Valor))
                throw new Exception("El email no puede ser nulo o vacío.");
        }

        private void ValidarContrasenia()
        {
            if (Contrasenia == null || string.IsNullOrEmpty(Contrasenia.Valor))
                throw new Exception("La contraseña no puede ser nula o vacía.");
        }



        public bool Equals(Usuario? other)
        {
            if (other is null) return false;

            return Email.Valor.Equals(other.Email.Valor, StringComparison.OrdinalIgnoreCase);
        }
    }
}
