using Compartido.DTOs.Envio;
using Compartido.Mappers;
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
    public class ListadoEnviosEnProceso:IListadoEnviosEnProceso
    {
        private IRepositorioEnvio RepoEnvios;

        public ListadoEnviosEnProceso(IRepositorioEnvio repositorioEnvio)
        {
            RepoEnvios = repositorioEnvio;
        }

        public List<ListadoEnvioDTO> Ejecutar()
        {
            List<Envio> envios = RepoEnvios.EnviosEnProceso().ToList();
            return EnvioMapper.ListadoEnvioDTOFromListadoEnvios(envios);
        }




    }
}
