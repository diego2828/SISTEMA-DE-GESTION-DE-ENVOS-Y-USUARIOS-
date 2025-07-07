using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Envio
{
    public class DetalleEnvioDTO
    {
        public string NumeroTracking { get; set; }
        public double PesoPaquete { get; set; }
        public bool EstadoFinalizado { get; set; }
        public DateTime? FechaFinalizacion { get; set; }
        public string Empleado { get; set; }
        public string Cliente { get; set; }

        public List<ComentarioTrackingDTO> Comentarios { get; set; }
    }
}
