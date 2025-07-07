using LogicaAplicacion.InterfacesCasosUso.Agencias;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.Agencias
{
    public class ObtenerAgencias : IObtenerAgencias
    {
        private IRepositorioAgencia RepoAgencia;
        public ObtenerAgencias(IRepositorioAgencia repoAgencia)
        {
            RepoAgencia = repoAgencia;
        }

        public List<Agencia> Ejecutar()
        { 
            return RepoAgencia.FindAll().ToList();         
        }
    }
}
