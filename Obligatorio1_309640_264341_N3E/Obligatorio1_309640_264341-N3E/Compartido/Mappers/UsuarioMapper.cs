using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Compartido.DTOs.Usuario;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ValueObject;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Compartido.Mappers
{
    public class UsuarioMapper
    {

        public static Usuario UsuarioFromUsuarioDTO(UsuarioDTO usuarioDTO, Rol rol)
        {
            if (usuarioDTO == null)
            {
                throw new ArgumentNullException("Datos incorrectos");
            }

            return new Usuario(usuarioDTO.Nombre, usuarioDTO.Apellido, new Email(usuarioDTO.Email), new Contrasenia(usuarioDTO.Contrasenia))
            {
                Rol = rol
            };
        }

        public static List<ListadoUsuarioDTO> ListadoUsuarioDTOFromListadoUsuarios(List<Usuario> usuarios)
        {
            List<ListadoUsuarioDTO> listadoUsuariosDTOs = new List<ListadoUsuarioDTO>();

            //foreach (Usuario usuario in usuarios)
            //{

                //ListadoUsuarioDTO usuarioDTO = new ListadoUsuarioDTO()
                //{
                   // Id = usuario.Id,
                   // Nombre = usuario.Nombre
                //};

           //// listadoUsuariosDTOs.Add(usuarioDTO);
            //}

        // return listadoUsuariosDTOs;
        listadoUsuariosDTOs=usuarios.Select(usuario=>new ListadoUsuarioDTO()
        {
            Id = usuario.Id,
            Nombre = usuario.Nombre,
            Apellido = usuario.Apellido,
            Email = usuario.Email.Valor,
        }).ToList();
          

            return listadoUsuariosDTOs;

        }

        public static ListadoUsuarioEliminarDTO ListadoUsuarioEliminarDTOFromUsuario(Usuario usuario)
        {
            return new ListadoUsuarioEliminarDTO()
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre
            };
        }

        public static void UsuarioFromUsuarioModificarDTO(Usuario usuarioExistente, CambioContraseniaDTO dto)
        {
            
            usuarioExistente.Email = new Email(dto.Email);
            usuarioExistente.Contrasenia = new Contrasenia(dto.PassNueva);
        }

        public static UsuarioLogueadoDTO UsuarioLogueadoDTOFrom(Usuario usuario)
        {
            return new UsuarioLogueadoDTO()
            {
                Rol = usuario.Rol.Nombre,
                Email = usuario.Email.Valor
            };
        }



    } 
}
