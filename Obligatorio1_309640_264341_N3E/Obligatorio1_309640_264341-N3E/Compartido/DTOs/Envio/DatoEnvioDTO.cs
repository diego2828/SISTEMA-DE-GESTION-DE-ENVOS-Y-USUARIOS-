using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Envio
{
    public class DatoEnvioDTO
    {

        public string NumeroTracking { get; set; }

        public bool Finalizado { get; set; }

        public DateTime fechaInicio { get; set; }


    }
}
