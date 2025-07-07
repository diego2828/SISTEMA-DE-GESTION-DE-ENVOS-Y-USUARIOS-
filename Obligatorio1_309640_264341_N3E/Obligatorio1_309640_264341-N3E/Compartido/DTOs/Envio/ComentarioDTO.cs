using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Envio
{
    public class ComentarioDTO
    {
        
        public string Mensaje { get; set; }
       
        public string EmpleadoEmail { get; set; }

        public int EnvioId { get; set; }

    }
}
