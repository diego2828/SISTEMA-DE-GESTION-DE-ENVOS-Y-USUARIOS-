using LogicaAplicacion.InterfacesCasosUso.Envios;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.Envios
{
    public class ObtenerUsuariosPorRol : IObtenerUsuariosPorRol
    {
        private  IRepositorioUsuario RepoUsuario;

        public ObtenerUsuariosPorRol(IRepositorioUsuario repoUsuario)
        {
            RepoUsuario = repoUsuario;
        }

        public List<Usuario> Ejecutar(string nombreRol)
        {
            return RepoUsuario.FindAll()
                .Where(u => u.Rol.Nombre == nombreRol)
                .ToList();
        }
    }
}
