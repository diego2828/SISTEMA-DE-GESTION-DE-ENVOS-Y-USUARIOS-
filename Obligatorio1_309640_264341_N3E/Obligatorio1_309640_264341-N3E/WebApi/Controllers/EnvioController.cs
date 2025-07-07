using LogicaAplicacion.ImplementacionCasosUso.Envios;
using LogicaAplicacion.InterfacesCasosUso.Envios;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.ExcepcionesEntidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvioController : ControllerBase
    {
        private  IObtenerEnvioPorTracking CUObtenerPorTracking;
        private IFiltrarEnvio CUFiltrarEnvio;
        private IListarEnviosPorCliente CUListarEnvios;
        private IBuscarEnviosPorComentario CUBuscarEnviosPorComentario;

        public EnvioController(IObtenerEnvioPorTracking cUObtenerPorTracking, IFiltrarEnvio cUFiltrarEnvio, IListarEnviosPorCliente cUListarEnvios, IBuscarEnviosPorComentario cUBuscarEnviosPorComentario)
        {
            CUObtenerPorTracking = cUObtenerPorTracking;
            CUFiltrarEnvio = cUFiltrarEnvio;
            CUListarEnvios = cUListarEnvios;
            CUBuscarEnviosPorComentario = cUBuscarEnviosPorComentario;
        }

        /// <summary>
        /// Obtiene un detalle de envío por su número de tracking.
        /// </summary>
        /// <param name="tracking"></param>
        /// <returns></returns>
        [HttpGet("consultar/{tracking}")]
        public IActionResult GetPorTracking(string tracking)
        {
            var detalle = CUObtenerPorTracking.Ejecutar(tracking);
            if (detalle == null) return NotFound(new { mensaje = "No se encontró el envío con ese número de tracking." });

            return Ok(detalle);
        }

        [Authorize(Roles = "CLIENTE")]
        [HttpGet("mis-envios")]
        public IActionResult MisEnvios()
        {
            string emailCliente = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

            // if (string.IsNullOrEmpty(emailCliente)) return Unauthorized("No se encontró el email del usuario autenticado.");

            var enviosDTO = CUListarEnvios.Ejecutar(emailCliente);
            return Ok(enviosDTO);
        }

        // GET: api/<EnvioController>
        [HttpGet]
        public IEnumerable<string> Get()

            //findall
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<EnvioController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            //findbyid
            return "value";
        }

  
    
        [HttpGet("porFechas/{f1}/{f2}/{estado}")]
        [Authorize(Roles = "CLIENTE")]
        public IActionResult GetPorFechas(string f1, string f2, bool estado)
        {
            try
            {
                string email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;


                if (!DateTime.TryParseExact(f1, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fecha1))
                    return BadRequest("Fecha 1 inválida. Use formato yyyy-MM-dd");

                if (!DateTime.TryParseExact(f2, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fecha2))
                    return BadRequest("Fecha 2 inválida. Use formato yyyy-MM-dd");



                if (email == null )
                {
                    return BadRequest("Usuario Incorrecto");
                }
                
                if (fecha1 > fecha2)
                {
                    return BadRequest("f1 debe ser menor a f2");
                }

                return Ok(CUFiltrarEnvio.Ejecutar(email, fecha1, fecha2, estado));
            }
            catch (EnvioException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error");
            }
            }

        [Authorize(Roles = "CLIENTE")]
        [HttpGet("mis-envios/buscar-por-comentario")]
        public IActionResult BuscarPorComentario([FromQuery] string palabra)
        {
            var emailCliente = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value
                            ?? User.Claims.FirstOrDefault(c => c.Type == "email")?.Value;

            if (string.IsNullOrEmpty(emailCliente))
                return Unauthorized();

            var envios = CUBuscarEnviosPorComentario.Ejecutar(emailCliente, palabra); // Inyectá IBuscarEnviosPorComentario en el ctor
            return Ok(envios);
        }





    }
}
