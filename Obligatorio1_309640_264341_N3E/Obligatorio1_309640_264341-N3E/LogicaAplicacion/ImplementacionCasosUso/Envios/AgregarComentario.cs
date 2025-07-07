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
    public class AgregarComentario : IAgregarComentario
    {

        public IRepositorioEnvio RepoEnvio { get; set; }

        public IRepositorioUsuario RepoUsuario { get; set; }

        public AgregarComentario (IRepositorioEnvio repoEnvio, IRepositorioUsuario repoUsuario)
        {
            RepoEnvio = repoEnvio;
            RepoUsuario = repoUsuario;
        }



        public void Ejecutar(ComentarioDTO comentarioDTO)
        {
            Envio envio = RepoEnvio.FindById(comentarioDTO.EnvioId);

            Usuario empleado = RepoUsuario.FindByEmail(comentarioDTO.EmpleadoEmail);

            
                
            Comentario comentario = EnvioMapper.ComentarioFromComentarioDTO(comentarioDTO, empleado);

            if (envio != null) {
                List<Comentario> comentariosEnvios = envio.Comentarios.ToList();
                comentariosEnvios.Add(comentario);
                envio.Comentarios = comentariosEnvios;
                RepoEnvio.Update(envio);
            }
            else
            {
                throw new EnvioException("No existe envio con ese id");
               
            }



            
        }
    }
}
