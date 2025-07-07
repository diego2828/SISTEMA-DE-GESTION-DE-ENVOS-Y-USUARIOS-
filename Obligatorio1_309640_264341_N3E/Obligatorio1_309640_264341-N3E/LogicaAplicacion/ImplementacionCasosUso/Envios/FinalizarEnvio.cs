using Compartido.DTOs.Envio;
using Compartido.DTOs.Usuario;
using Compartido.Mappers;
using LogicaAplicacion.InterfacesCasosUso.Envios;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ImplementacionCasosUso.Envios
{
    public class FinalizarEnvio: IFinalizarEnvio 
    {

        private IRepositorioEnvio RepoEnvio { get; set; }
        public FinalizarEnvio(IRepositorioEnvio repoEnvio)
        {
            RepoEnvio = repoEnvio;
        }

        public void Ejecutar(EnvioFinalizarDTO envioDTO)
        {
            var envio = RepoEnvio.FindById(envioDTO.Id);
            if (envio == null)
                throw new UsuarioException("El envio no existe.");

            EnvioMapper.EnvioFromFinalizarEnvioDTO(envio, envioDTO);
            RepoEnvio.Update(envio);
        }




    }
}
