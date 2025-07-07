using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.ValueObject;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Agencia: IEquatable<Agencia>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int DireccionPostal { get; set; }
        public Ubicacion Ubicacion { get; set; }

        private Agencia() { 
        
        }
        public Agencia(string nombre, int direccionPostal, Ubicacion ubicacion)
        {
            Nombre = nombre;
            DireccionPostal = direccionPostal;
            Ubicacion = ubicacion;

            Validar();
        }

        public void Validar()
        {
            ValidarNombre();
            ValidarDireccionPostal();
            ValidarUbicacion();
        }

        private void ValidarNombre()
        {
            if (string.IsNullOrEmpty(Nombre)) throw new Exception("El nombre de la agencia no puede estar vacío.");
        }

        private void ValidarDireccionPostal()
        {
            if (DireccionPostal <= 0) throw new Exception("La dirección postal debe ser un número positivo.");
        }

        private void ValidarUbicacion()
        {
            if (Ubicacion == null) throw new Exception( "La ubicación no puede ser nula.");
        }

        public bool Equals(Agencia? other)
        {
            return Nombre == other.Nombre;
        }
    }
}
