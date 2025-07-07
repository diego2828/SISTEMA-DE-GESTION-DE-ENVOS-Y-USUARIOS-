using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Compartido.DTOs.Usuario;
using LogicaNegocio.EntidadesNegocio;


namespace LogicaAplicacion.InterfacesCasosUso.Usuarios
{
    public interface IAltaUsuario
    {

        public void Ejecutar(UsuarioDTO usuarioDTO, string correoAuditoria);
        List<Rol> ObtenerRoles();
    }
}
