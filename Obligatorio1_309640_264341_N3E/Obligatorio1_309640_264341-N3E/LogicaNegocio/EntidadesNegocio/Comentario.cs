using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Comentario
    {
        public int Id { get; set; }
        public string Mensaje { get; set; }
        public DateTime Fecha { get; set; }
        public Usuario Empleado { get; set; }


        private Comentario() { }

        public Comentario(string mensaje, Usuario empleado)
        {
            Mensaje = mensaje;
            Empleado = empleado;
            Fecha = DateTime.Now;

            Validar();
        }

        public void Validar()
        {
            ValidarMensaje();
            ValidarEmpleado();
        }

        private void ValidarMensaje()
        {
            if (string.IsNullOrEmpty(Mensaje)) throw new Exception("El mensaje no puede estar vacío.");
        }

        private void ValidarEmpleado()
        {
            if (Empleado == null) throw new Exception("El empleado no puede ser nulo.");
        }




    }
}
