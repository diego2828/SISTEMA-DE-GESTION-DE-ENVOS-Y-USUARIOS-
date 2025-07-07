using Compartido.DTOs.Envio;
using Compartido.Mappers;
using LogicaAplicacion.InterfacesCasosUso.Envios;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.Envios
{
    public class ListarEnviosPorCliente : IListarEnviosPorCliente
    {
        private readonly IRepositorioEnvio RepoEnvio;

        public ListarEnviosPorCliente(IRepositorioEnvio repoEnvio)
        {
            RepoEnvio = repoEnvio;
        }

        public IEnumerable<EnvioClienteConComentariosDTO> Ejecutar(string emailCliente)
        {
            var envios = RepoEnvio.EnviosPorCliente(emailCliente);

            return envios.Select(EnvioMapper.ToEnvioClienteConComentariosDTO);
        }
    }
}
