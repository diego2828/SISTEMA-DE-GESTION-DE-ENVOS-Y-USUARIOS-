using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioAuditoria : IRepositorioAuditoria
    {
        private  LogisticaContexto _contexto;

        public RepositorioAuditoria(LogisticaContexto contexto)
        {
            _contexto = contexto;
        }

        public void Add(Auditoria item)
        {
            _contexto.Auditoria.Add(item);
            _contexto.SaveChanges();
        }


       public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Auditoria> FindAll()
        {
            throw new NotImplementedException();
        }

        public Auditoria FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Auditoria item)
        {
            throw new NotImplementedException();
        }
        
    }
}
