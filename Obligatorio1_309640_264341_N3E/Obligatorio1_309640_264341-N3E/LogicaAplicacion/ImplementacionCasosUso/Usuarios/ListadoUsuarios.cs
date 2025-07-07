using LogicaAccesoDatos.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaAccesoDatos.Repositorios;
using Compartido.DTOs.Usuario;
using LogicaNegocio.EntidadesNegocio;
using Compartido.Mappers;
using LogicaNegocio.InterfacesRepositorios;
using LogicaAplicacion.InterfacesCasosUso.Usuarios;

namespace LogicaAplicacion.ImplementacionCasosUso.Usuarios
{
    public class ListadoUsuarios:IListadoUsuarios
    {

        private IRepositorioUsuario RepoUsuarios;

        public ListadoUsuarios(IRepositorioUsuario repositorioUsuario)
        {
            RepoUsuarios = repositorioUsuario;
        }

        public List<ListadoUsuarioDTO> Ejecutar()
        {
            List<Usuario> usuarios = RepoUsuarios.FindAll().ToList();
            return UsuarioMapper.ListadoUsuarioDTOFromListadoUsuarios(usuarios);
        }
    }
}
