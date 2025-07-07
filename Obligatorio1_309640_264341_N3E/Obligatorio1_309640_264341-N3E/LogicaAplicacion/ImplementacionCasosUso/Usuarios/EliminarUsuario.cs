using LogicaAplicacion.InterfacesCasosUso.Usuarios;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.Usuarios
{
    public class EliminarUsuario : IEliminarUsuario
    {
        private IRepositorioUsuario RepoUsuario;
        private IRepositorioAuditoria RepoAuditoria;

        public EliminarUsuario(IRepositorioUsuario repoUsuario, IRepositorioAuditoria repoAuditoria)
        {
            RepoUsuario = repoUsuario;
            RepoAuditoria = repoAuditoria;
        }

        public void Ejecutar(int id, string correoAuditoria)
        {
            RepoUsuario.Delete(id);


            var correo = RepoUsuario.FindAll().FirstOrDefault(u => u.Email.Valor == correoAuditoria);

            if (correo == null) throw new Exception("No se pudo identificar al auditor que elimino al usuario");

            Auditoria auditoria = new Auditoria(correo);
            RepoAuditoria.Add(auditoria);
        }
    }
}
