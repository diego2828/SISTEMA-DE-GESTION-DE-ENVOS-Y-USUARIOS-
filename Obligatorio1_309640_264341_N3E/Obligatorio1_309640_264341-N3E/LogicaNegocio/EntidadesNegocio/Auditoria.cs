using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.EntidadesNegocio
{
    public class Auditoria
    {
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime FechaHora { get; set; }
        private Auditoria()
        {     
        }

        public Auditoria(Usuario usuario)
        {
            Usuario = usuario;
            FechaHora = DateTime.Now;
            Validar();
        }

        public void Validar()
        {
            ValidarUsuario();
        }

        private void ValidarUsuario()
        {
            if (Usuario == null) throw new Exception ("El usuario no puede ser nulo.");
        }
    }
}
