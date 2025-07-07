using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Compartido.Mappers;
using LogicaNegocio.EntidadesNegocio;
using LogicaAccesoDatos.Repositorios;
using LogicaNegocio.InterfacesRepositorios;
using LogicaAplicacion.InterfacesCasosUso.Usuarios;
using Compartido.DTOs.Usuario;
using LogicaNegocio.ExcepcionesEntidades;

namespace LogicaAplicacion.ImplementacionCasosUso.Usuarios
{
    public class AltaUsuario : IAltaUsuario
    {

        private  IRepositorioUsuario RepoUsuario;
        private  IRepositorioRol RepoRol;
        private  IRepositorioAuditoria RepoAuditoria;
        public AltaUsuario(IRepositorioUsuario repoUsuario , IRepositorioRol repoRol, IRepositorioAuditoria repoAuditoria)
        {
            RepoUsuario = repoUsuario;
            RepoRol = repoRol;
            RepoAuditoria = repoAuditoria;
        }
        public void Ejecutar(UsuarioDTO usuarioDTO, string correoAuditoria)
        {
            if (usuarioDTO == null)
            {
                throw new ArgumentNullException("Datos incorrectos");
            }

            if (RepoUsuario.FindAll().Any(u => u.Email.Valor == usuarioDTO.Email))
            {
                throw new UsuarioException("Este email ya se encuentra registrado");
            }


            Rol rol = RepoRol.ObtenerPorId(usuarioDTO.RolId);

            if (rol == null)
            {
                throw new Exception("ID de Rol no válido");
            }

            Usuario usuario = UsuarioMapper.UsuarioFromUsuarioDTO(usuarioDTO, rol);

            RepoUsuario.Add(usuario);
         
            var correo = RepoUsuario.FindAll().FirstOrDefault(u => u.Email.Valor == correoAuditoria);

            if (correo == null) throw new Exception("No se pudo identificar al auditor que creó el usuario.");
                      
            //Luego de hecho el usuario se genera una auditoria enlazando al usuario que hizo la accion
            Auditoria auditoria = new Auditoria(correo);
            RepoAuditoria.Add(auditoria);
        }

        public List<Rol> ObtenerRoles()
        {
            return RepoRol.ObtenerTodos();
        }
    }
}
