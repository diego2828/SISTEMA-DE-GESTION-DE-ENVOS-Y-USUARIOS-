using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace LogicaNegocio.EntidadesNegocio
{
    public class Envio : IEquatable<Envio>
    {
        public int Id { get; set; }
        public string NumeroTracking { get; set; }
        public double PesoPaquete { get; set; }
        public bool EstadoFinalizado { get; set; }

        public DateTime fechaInicio { get; set; }
        public DateTime? fechaFinalizacion { get; set; }

        public Usuario Empleado { get; set; }
        public Usuario Cliente { get; set; }

        public IEnumerable<Comentario> Comentarios { get; set; } = new List<Comentario>();

        

        public Envio() { }

        public Envio(
        string numeroTracking,
        Usuario empleado,
        Usuario cliente,
        double pesoPaquete,
        bool estadoFinalizado = false,
        DateTime? fechaFinalizacion = null
    )
        {
            NumeroTracking = numeroTracking;
            Empleado = empleado;
            Cliente = cliente;
            PesoPaquete = pesoPaquete;
            EstadoFinalizado = estadoFinalizado;
            this.fechaFinalizacion = fechaFinalizacion;
            this.fechaInicio = DateTime.Now;

            Validar();
        }


        public void Validar()
        {
            ValidarNumeroTracking();
            ValidarEmpleado();
            ValidarCliente();
            ValidarPeso();
        }

        private void ValidarNumeroTracking()
        {
            if (string.IsNullOrEmpty(NumeroTracking))
                throw new Exception("El número de tracking no puede estar vacío.");
        }

        private void ValidarEmpleado()
        {
            if (Empleado == null) throw new Exception("El empleado no puede ser nulo.");
        }

        private void ValidarCliente()
        {
            if (Cliente  == null)
                throw new Exception("El cliente no puede ser nulo.");
        }

        private void ValidarPeso()
        {
            if (PesoPaquete <= 0)
                throw new Exception("El peso del paquete debe ser mayor a 0.");
        }

        public bool Equals(Envio? other)
        {
            return Id == other.Id;
        }
    }
}
