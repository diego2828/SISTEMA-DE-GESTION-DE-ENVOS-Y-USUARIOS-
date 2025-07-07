using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Compartido.DTOs.Envio;
using Compartido.DTOs.Usuario;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.ValueObject;

namespace Compartido.Mappers
{
    public class EnvioMapper
    {
       
        public static List<ListadoEnvioDTO> ListadoEnvioDTOFromListadoEnvios(List<Envio> envios)
        {
            List<ListadoEnvioDTO> listadoEnviosDTOs = new List<ListadoEnvioDTO>();

            listadoEnviosDTOs = envios.Select(envio => new ListadoEnvioDTO()
            {
                Id = envio.Id,
                NumeroTracking = envio.NumeroTracking,
                Finalizado = envio.EstadoFinalizado,

            }).ToList();


            return listadoEnviosDTOs;

        }


        public static void EnvioFromFinalizarEnvioDTO(Envio envio, EnvioFinalizarDTO dto)
        {
            envio.Id = dto.Id;
            envio.fechaFinalizacion = dto.FechaFinalizacion;
            envio.EstadoFinalizado = true;
       
        }

        public static DetalleEnvioDTO ToDetalleEnvioDTO(Envio envio)
        {
            if (envio == null) return null;
            return new DetalleEnvioDTO
            {
                NumeroTracking = envio.NumeroTracking,
                PesoPaquete = envio.PesoPaquete,
                EstadoFinalizado = envio.EstadoFinalizado,
                FechaFinalizacion = envio.fechaFinalizacion,
                Empleado = envio.Empleado?.Nombre + " " + envio.Empleado?.Apellido,
                Cliente = envio.Cliente?.Nombre + " " + envio.Cliente?.Apellido,
                Comentarios = envio.Comentarios?
            .Select(c => new ComentarioTrackingDTO
            {
                Mensaje = c.Mensaje,
                EmpleadoEmail = c.Empleado?.Email?.Valor
            }).ToList() ?? new List<ComentarioTrackingDTO>()
            };
        }


        public static Comentario ComentarioFromComentarioDTO (ComentarioDTO comentarioDTO, Usuario empleado)
        {
            if(comentarioDTO == null)
            {

                throw new ArgumentException("Los datos no son correctos");
            }

            if (empleado == null || !(empleado.Email.Valor.Equals( comentarioDTO.EmpleadoEmail))   )
            {
                throw new ArgumentException("El empleado no es válido");
            }
                

            return new Comentario(comentarioDTO.Mensaje, empleado);
        }

        
        public static List<DatoEnvioDTO> DatoEnvioDTOFromListadoEnvios(List<Envio> envios)
        {

            return envios.Select(e=>new DatoEnvioDTO()
            {
                NumeroTracking=e.NumeroTracking,
                Finalizado=e.EstadoFinalizado,
                fechaInicio=e.fechaInicio

            }).ToList();
   
        }

        public static EnvioClienteConComentariosDTO ToEnvioClienteConComentariosDTO(Envio envio)
        {
            return new EnvioClienteConComentariosDTO
            {
                Id = envio.Id,
                NumeroTracking = envio.NumeroTracking,
                Finalizado = envio.EstadoFinalizado,
                FechaFinalizacion = envio.fechaFinalizacion,
                Comentarios = envio.Comentarios.Select(c => new ComentarioTrackingDTO
                {
                    Mensaje = c.Mensaje,
                    EmpleadoEmail = c.Empleado.Email.Valor
                }).ToList()
            };
        }



    }
}
