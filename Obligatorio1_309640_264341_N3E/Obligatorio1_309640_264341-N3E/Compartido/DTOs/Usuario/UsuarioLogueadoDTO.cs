using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Usuario
{
    public class UsuarioLogueadoDTO
    {
        public string Email {  get; set; }
        public string Rol {  get; set; }

        public string Token { get; set; }
    }
}
