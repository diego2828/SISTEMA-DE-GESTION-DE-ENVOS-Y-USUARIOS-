using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Usuario
{
    public class CambioContraseniaDTO
    {
        public string Email { get; set; }
        public string PassActual { get; set; }
        public string PassNueva { get; set; }
     
    }
}
