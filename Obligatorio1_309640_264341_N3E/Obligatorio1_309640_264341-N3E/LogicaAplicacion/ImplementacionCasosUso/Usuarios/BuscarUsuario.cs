using Compartido.DTOs.Usuario;
using Compartido.Mappers;
using LogicaAplicacion.InterfacesCasosUso.Usuarios;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.Usuarios
{
    public class BuscarUsuario : IBuscarUsuario
    {
        private IRepositorioUsuario RepoUsuario { get; set; }
        public BuscarUsuario(IRepositorioUsuario repoUsuario)
        {
            RepoUsuario = repoUsuario;
        }

        public ListadoUsuarioEliminarDTO Ejecutar(int id)
        {
            ListadoUsuarioEliminarDTO usuarioEliminarDTO = null;

            Usuario usuarioBuscado = RepoUsuario.FindById(id);
            if (usuarioBuscado != null)
            {
                usuarioEliminarDTO = UsuarioMapper.ListadoUsuarioEliminarDTOFromUsuario(usuarioBuscado);
            }
            else
            {
                throw new UsuarioException("No se encontro un usuario con ese id.");
            }

            return usuarioEliminarDTO;             
        }


    }
}
