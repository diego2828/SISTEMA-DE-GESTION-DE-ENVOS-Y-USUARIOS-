using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioAgencia : IRepositorioAgencia
    {
        private readonly LogisticaContexto Contexto;

        public RepositorioAgencia(LogisticaContexto context)
        {
            Contexto = context;
        }
        public void Add(Agencia item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Agencia> FindAll()
        {
            return Contexto.Agencias.ToList();
        }

        public Agencia FindById(int id)
        {
            return Contexto.Agencias.Find(id);
        }

        public void Update(Agencia item)
        {
            throw new NotImplementedException();
        }
    }
}
