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
    public class ObtenerEnvioPorTracking : IObtenerEnvioPorTracking
    {
        private  IRepositorioEnvio RepoEnvio;

        public ObtenerEnvioPorTracking(IRepositorioEnvio repoEnvio)
        {
            RepoEnvio = repoEnvio;
        }

        public DetalleEnvioDTO Ejecutar(string tracking)
        {
            var envio = RepoEnvio.FindByTracking(tracking);

            return EnvioMapper.ToDetalleEnvioDTO(envio);
        }
    }
}
