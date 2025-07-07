using Compartido.DTOs.Envio;
using Compartido.Mappers;
using LogicaAplicacion.InterfacesCasosUso.Envios;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.Envios
{
    public class FiltrarEnvio : IFiltrarEnvio
    {


        private IRepositorioEnvio RepoEnvios;

        public FiltrarEnvio(IRepositorioEnvio repositorioEnvio)
        {
            RepoEnvios = repositorioEnvio;
        }

        public List<DatoEnvioDTO> Ejecutar(string email, DateTime fecha1, DateTime fecha2, bool estado)
        {
            if (email == null)
            {
                throw new EnvioException("Error en el email");
            }
            if (fecha1==fecha2 && fecha1 > fecha2)
            {
                throw new EnvioException("Ingrese fechas de manera valida");
            }


            List<Envio> envios = RepoEnvios.FiltrarEnvios(email,fecha1, fecha2, estado);

            return EnvioMapper.DatoEnvioDTOFromListadoEnvios(envios);

        }


     






    }
}
