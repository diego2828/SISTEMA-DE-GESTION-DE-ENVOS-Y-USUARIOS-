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
    public class RepositorioRol : IRepositorioRol
    {
        private LogisticaContexto Contexto;

        public RepositorioRol(LogisticaContexto context)
        {
            Contexto = context;
        }

        public void Add(Rol item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Rol> FindAll()
        {
            throw new NotImplementedException();
        }

        public Rol FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Rol ObtenerPorId(int id)
        {
            return Contexto.Roles.FirstOrDefault(r => r.Id == id);
        }

        public List<Rol> ObtenerTodos()
        {
            return Contexto.Roles.ToList();
        }

        public void Update(Rol item)
        {
            throw new NotImplementedException();
        }
    }
}
