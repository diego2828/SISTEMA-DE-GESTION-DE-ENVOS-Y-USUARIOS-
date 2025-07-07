using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Rol : IEquatable<Rol>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public Rol() { }

        public Rol(string nombre)
        {
            Nombre = nombre;
            Validar();
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Nombre))
                throw new Exception("El nombre del rol no puede estar vacío.");
        }

        public bool Equals(Rol? other)
        {
            return other != null && Nombre == other.Nombre;
        }

        //Para que se muestre el nombre del rol
        public override string ToString()
        {
            return Nombre;
        }
    }
}
