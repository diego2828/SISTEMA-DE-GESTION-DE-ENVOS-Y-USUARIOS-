using LogicaAplicacion.InterfacesCasosUso.Envios;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.Envios
{
    public class BuscarEnviosPorComentario : IBuscarEnviosPorComentario
    {
        private readonly IRepositorioEnvio RepoEnvio;

        public BuscarEnviosPorComentario(IRepositorioEnvio repoEnvio)
        {
            RepoEnvio = repoEnvio;
        }

        public IEnumerable<Envio> Ejecutar(string emailCliente, string palabra)
        {
            return RepoEnvio.BuscarEnviosPorComentario(emailCliente, palabra);
        }
    }
}
