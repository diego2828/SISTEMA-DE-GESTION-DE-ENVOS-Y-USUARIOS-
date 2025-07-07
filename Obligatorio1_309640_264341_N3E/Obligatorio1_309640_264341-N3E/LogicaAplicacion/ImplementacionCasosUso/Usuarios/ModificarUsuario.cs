using Compartido.DTOs.Usuario;
using Compartido.Mappers;
using LogicaAccesoDatos.Repositorios;
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
    public class ModificarUsuario : IModificarUsuario
    {
        private IRepositorioUsuario RepoUsuario { get; set; }
        private IRepositorioAuditoria RepoAuditoria { get; set; }
        public ModificarUsuario(IRepositorioUsuario repoUsuario, IRepositorioAuditoria repoAuditoria)
        {
            RepoUsuario = repoUsuario;
            RepoAuditoria = repoAuditoria;
        }
        public void Ejecutar(CambioContraseniaDTO cambioContraseniaDTO, string correoAuditoria)
        {
            var usuarioExistente = RepoUsuario.FindByEmail(cambioContraseniaDTO.Email);
            if (usuarioExistente == null)
                throw new UsuarioException("El usuario no existe.");
            if (cambioContraseniaDTO.PassActual == usuarioExistente.Contrasenia.Valor)
            {
                UsuarioMapper.UsuarioFromUsuarioModificarDTO(usuarioExistente, cambioContraseniaDTO);
                RepoUsuario.Update(usuarioExistente);

            }
            else
            {
                throw new UsuarioException("Contarsenia actual invalida");
            }

            var correo = RepoUsuario.FindAll().FirstOrDefault(u => u.Email.Valor == correoAuditoria);

            if (correo == null) throw new Exception("No se pudo identificar al auditor que creó el usuario.");

            //Luego de hecho el usuario se genera una auditoria enlazando al usuario que hizo la accion
            Auditoria auditoria = new Auditoria(correo);
            RepoAuditoria.Add(auditoria);
        }


    }
}
