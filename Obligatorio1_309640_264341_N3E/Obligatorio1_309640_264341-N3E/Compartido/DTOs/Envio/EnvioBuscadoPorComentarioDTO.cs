using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Envio
{
    public class EnvioBuscadoPorComentarioDTO
    {
        public int Id { get; set; }
        public string NumeroTracking { get; set; }
        public bool Finalizado { get; set; }
        public DateTime? FechaFinalizacion { get; set; }
        public List<ComentarioDTO> Comentarios { get; set; }
    }
    public class ComentarioBuscadoPorComentarioDTO
    {
        public string Mensaje { get; set; }
        public string EmpleadoEmail { get; set; }
    }
}

