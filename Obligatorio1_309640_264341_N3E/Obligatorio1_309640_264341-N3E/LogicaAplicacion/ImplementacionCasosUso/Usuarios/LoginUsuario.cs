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
    public class LoginUsuario : ILoginUsuario
    {
        private readonly IRepositorioUsuario RepoUsuario;

        public LoginUsuario(IRepositorioUsuario repoUsuario)
        {
            RepoUsuario = repoUsuario;
        }

        public ListadoUsuarioDTO Login(string email, string contrasenia)
        {
            var usuario = RepoUsuario.FindAll().FirstOrDefault(u => u.Email.Valor == email);

            if (usuario == null) throw new UsuarioException("El email no es valido.");

            if (usuario.Contrasenia.Valor != contrasenia) throw new UsuarioException("La contraseña es incorrecta.");

            return new ListadoUsuarioDTO
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Email = usuario.Email.Valor,
                Rol = usuario.Rol.Nombre
            };
        }

        public UsuarioLogueadoDTO Login(LoginUsuarioDTO loginDTO)
        {
            Usuario usuario = RepoUsuario.Login(loginDTO.Email, loginDTO.Contrasenia);
            if (usuario == null)
            {
                throw new UsuarioException("Credenciales incorrectas");

            }
            return UsuarioMapper.UsuarioLogueadoDTOFrom(usuario);
        }
    }
}
