using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Urgente: Envio
    {
        public string DireccionPostalEspecifica { get; set; }
        public DateTime TiempoSalida { get; set; }
        public DateTime TiempoLLegada { get; set; }
        public bool EntregaEficiente   { get; set; }

        public Urgente() { 
        }
        public Urgente(
            string numeroTracking,
            Usuario empleado,
            Usuario cliente,
            double pesoPaquete,
            string direccionPostalEspecifica,
            DateTime tiempoSalida,
            DateTime tiempoLlegada
        )
            : base(numeroTracking, empleado, cliente, pesoPaquete)
        {
            DireccionPostalEspecifica = direccionPostalEspecifica;
            TiempoSalida = tiempoSalida;
            TiempoLLegada = tiempoLlegada;
            EntregaEficiente = false;

            ValidarUrgente();
        }

        private void ValidarUrgente()
        {
            if (string.IsNullOrEmpty(DireccionPostalEspecifica))
                throw new Exception("La dirección postal específica no puede estar vacía.");

            if (TiempoSalida == default || TiempoLLegada == default)
                throw new Exception("Las fechas de salida y llegada deben estar definidas.");

            if (TiempoLLegada <= TiempoSalida)
                throw new Exception("La llegada debe ser posterior a la salida.");
        }

        public int CalcularEficienciaEnvio()
        {
            int ret = 0;

            return ret;
        }
    }
}
