using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Envio
{
    public class EnvioClienteConComentariosDTO
    {
        public int Id { get; set; }
        public string NumeroTracking { get; set; }
        public bool Finalizado { get; set; }
        public DateTime? FechaFinalizacion { get; set; }

        public List<ComentarioTrackingDTO> Comentarios { get; set; }
    }
}
