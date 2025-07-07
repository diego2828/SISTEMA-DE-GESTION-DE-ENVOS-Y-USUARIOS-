using Compartido.DTOs.Usuario;
using Compartido.ExcepcionesGenericas;
using LogicaAplicacion.InterfacesCasosUso.Usuarios;
using LogicaNegocio.ExcepcionesEntidades;
using LogicaNegocio.ValueObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using WebApi.Token;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    

    public class UsuarioController : ControllerBase
    {

        public ILoginUsuario CULogin { get; set; }
        public IModificarUsuario CUModificarUsuario { get; set; }



        public UsuarioController(ILoginUsuario cuLogin, IModificarUsuario cUModificarUsuario)
        {
            CULogin = cuLogin;
            CUModificarUsuario = cUModificarUsuario;
        }
        [HttpPost("Login")]
        public IActionResult Login(LoginUsuarioDTO usuarioLogindto)
        {
            try
            {
                if (usuarioLogindto == null)
                {
                    return BadRequest("Datos incorrectos");
                }

                UsuarioLogueadoDTO usuLogueado = CULogin.Login(usuarioLogindto);
                if (usuLogueado != null)
                {
                    usuLogueado.Token = ManejadorToken.CrearToken(usuLogueado);
                    return Ok(usuLogueado);
                }
                else
                {
                    return NotFound("Credenciales incorrectas");
                }


            }
            catch (UsuarioException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error");
            }

        }



        // PUT api/<UsuarioController>/
        [HttpPut("CambiarContrasenia")]
        [Authorize(Roles = "CLIENTE")]
        public IActionResult Put([FromBody] CambioContraseniaDTO cambioContraseniaDTO)
        {
            //Update
            try
            {
                if (cambioContraseniaDTO == null)
                {
                    return BadRequest("Datos incorrectos");
                }

                CUModificarUsuario.Ejecutar(cambioContraseniaDTO, cambioContraseniaDTO.Email);
                return Ok("Contrasenia cambiada correctamente");
            }
            catch (ConflictException ex)
            {
                return Conflict(ex.Message);
            }
            catch (UsuarioException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno");
            }

        }
















    }
}
