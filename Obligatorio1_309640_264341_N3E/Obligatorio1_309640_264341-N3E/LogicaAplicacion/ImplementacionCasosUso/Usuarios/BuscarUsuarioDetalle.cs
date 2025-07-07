using Compartido.DTOs.Usuario;
using LogicaAplicacion.InterfacesCasosUso.Usuarios;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.Usuarios
{
    public class BuscarUsuarioDetalle : IBuscarUsuarioDetalle
    {
        private readonly IRepositorioUsuario RepoUsuario;

        public BuscarUsuarioDetalle(IRepositorioUsuario repoUsuario)
        {
            RepoUsuario = repoUsuario;
        }

        public UsuarioDetalleDTO Ejecutar(int id)
        {
            var usuario = RepoUsuario.FindById(id);

            if (usuario == null)
                return null;

            return new UsuarioDetalleDTO
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Email = usuario.Email.Valor,
                Contrasenia = usuario.Contrasenia.Valor,
                RolNombre = usuario.Rol.Nombre
            };
        }
    }
}
