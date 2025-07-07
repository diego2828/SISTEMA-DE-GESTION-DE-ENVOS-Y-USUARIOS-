using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Compartido.Mappers;
using LogicaNegocio.EntidadesNegocio;
using LogicaAccesoDatos.Repositorios;
using LogicaNegocio.InterfacesRepositorios;
using LogicaAplicacion.InterfacesCasosUso.Envios;
using Compartido.DTOs.Envio;

namespace LogicaAplicacion.ImplementacionCasosUso.Envios
{
    public class AltaEnvio: IAltaEnvio
    {
        private  IRepositorioEnvio RepoEnvio;

        public AltaEnvio(IRepositorioEnvio repositorioEnvio)
        {
            RepoEnvio = repositorioEnvio;
        }

        public void Ejecutar(Envio envio)
        {
            if (envio == null)
                throw new ArgumentNullException(nameof(envio));

    
            if (string.IsNullOrEmpty(envio.NumeroTracking))
                throw new Exception("El número de tracking no puede estar vacío.");

            RepoEnvio.Add(envio);
        }

    }
}
