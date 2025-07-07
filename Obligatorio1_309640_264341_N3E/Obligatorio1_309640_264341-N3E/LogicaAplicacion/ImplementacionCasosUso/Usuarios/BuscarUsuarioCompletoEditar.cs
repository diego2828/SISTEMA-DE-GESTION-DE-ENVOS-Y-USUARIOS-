using Compartido.DTOs.Usuario;
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
    public class BuscarUsuarioCompletoEditar : IBuscarUsuarioCompeltoEditar
    {
        private IRepositorioUsuario RepoUsuario { get; set; }

        public BuscarUsuarioCompletoEditar(IRepositorioUsuario repoUsuario)
        {
            RepoUsuario = repoUsuario;
        }

        public UsuarioModificarDTO Ejecutar(int id)
        {
            Usuario usuarioBuscado = RepoUsuario.FindById(id);

            if (usuarioBuscado == null)
                throw new UsuarioException("No se encontró un usuario con ese ID.");

            return new UsuarioModificarDTO
            {
                Id = usuarioBuscado.Id,
                Nombre = usuarioBuscado.Nombre,
                Apellido = usuarioBuscado.Apellido,
                Email = usuarioBuscado.Email.Valor,
                Contrasenia = usuarioBuscado.Contrasenia.Valor
               
            };
        }
    }
}
