using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Compartido.Mappers;
using LogicaNegocio.EntidadesNegocio;
using LogicaAccesoDatos.Repositorios;
using LogicaNegocio.InterfacesRepositorios;
using LogicaAplicacion.InterfacesCasosUso.Agencias;
using Compartido.DTOs.Agencias;
using Compartido.DTOs.Usuario;

namespace LogicaAplicacion.ImplementacionCasosUso.Agencias
{
    public class AltaAgencia:IAltaAgencia 
    {
        private IRepositorioAgencia RepoAgencia { get; set; }

        public AltaAgencia(IRepositorioAgencia repoAgencia)
        {
            RepoAgencia = repoAgencia;
        }

        public void Ejecutar(AgenciaDTO agenciaDto)
        {

            //Validar el dato entrada 
            if (agenciaDto == null)
            {
                throw new ArgumentNullException("Datos incorrectos");
            }
            //Convertir carreraDTO a tipo Carrera
           // Agencia agencia = AgenciaMapper.AgenciaFromUsuarioDTO(agenciaDto);

                  
            //Llamar al metodo Add del repositorio de carrera y le paso por parametros la carrera
            //RepoAgencia.Add(agencia);

        }



    }

    
}
