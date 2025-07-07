

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc.Rendering;

using MVC.Models.UsuariosVM;
using MVC.Models.EnviosVM;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using NuGet.Common;



namespace MVC.Controllers
{
    public class EnvioController : Controller
    {
        public string urlBase = "https://localhost:7259/";

        private HttpClient _httpClient;

        public EnvioController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri(configuration.GetValue<string>("urlBase"));

        }

        public IActionResult Consultar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Consultar(string tracking)
        {
            if (string.IsNullOrWhiteSpace(tracking))
            {
                ModelState.AddModelError("", "Debe ingresar un número de tracking.");
                return View();
            }

            var response = await _httpClient.GetAsync($"Envio/consultar/{tracking}");

            if (response.IsSuccessStatusCode)
            {
                var detalle = await response.Content.ReadFromJsonAsync<EnvioTrackingViewModel>();
                return View("Detalle", detalle);
            }
            else
            {

                var error = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError("", "No se encontró el envío o hubo un error.");
                return View();
            }
        }

        [HttpGet]
        public IActionResult Buscar()
        {
            return View(); // dirijo a vista para solicitar datos
        }

        [HttpGet]
        public async Task<IActionResult> MisEnvios()
        {
            // Obtener el token JWT de la sesión
            var token = HttpContext.Session.GetString("Token");
            if (string.IsNullOrEmpty(token))
            {
                // Redireccionar al login si no hay token
                return RedirectToAction("Login", "Usuario");
            }

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            try
            {
                var response = await _httpClient.GetAsync("Envio/mis-envios");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var envios = JsonConvert.DeserializeObject<List<EnvioConComentariosVM>>(json);
                    return View(envios);
                }
                else
                {
                    ViewBag.Error = "No se pudieron obtener los envíos.";
                    return View(new List<EnvioConComentariosVM>());
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Ocurrió un error al intentar obtener los envíos.";
                return View(new List<EnvioConComentariosVM>());
            }
        }

        [HttpPost]
        public IActionResult Buscar(string fechaInicio, string fechaFin, bool estado)
        {
            IEnumerable<ListadoEnvioViewModel> enviosFiltrados = new List<ListadoEnvioViewModel>();

            try
            {
                if (!string.IsNullOrEmpty(fechaInicio) && !string.IsNullOrEmpty(fechaFin))
                {
                    var token = HttpContext.Session.GetString("Token");
                    HttpClient cliente = new HttpClient();
                    cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    var url = $"{urlBase}api/Envio/porFechas/{fechaInicio}/{fechaFin}/{estado}";
                    var respuesta = cliente.GetAsync(url).Result;

                    if (respuesta.IsSuccessStatusCode)
                    {
                        var datos = respuesta.Content.ReadAsStringAsync().Result;
                        enviosFiltrados = JsonConvert.DeserializeObject<List<ListadoEnvioViewModel>>(datos);
                    }
                    else
                    {
                        ViewBag.Mensaje = $"Error: {respuesta.StatusCode}";
                    }
                }
                else
                {
                    ViewBag.Mensaje = "Datos incorrectos";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Error";
            }
            return View(enviosFiltrados);
        }

        [HttpGet]
        public IActionResult BuscarPorComentario()
        {
            return View(new List<BuscarEnvioVM>());
        }

        [HttpPost]
        public async Task<IActionResult> BuscarPorComentario(string palabra)
        {
            var token = HttpContext.Session.GetString("Token");
            if (string.IsNullOrEmpty(token))
                return RedirectToAction("Login", "Usuario");

            if (string.IsNullOrWhiteSpace(palabra))
            {
                ViewBag.Error = "Debe ingresar una palabra para buscar.";
                return View(new List<BuscarEnvioVM>());
            }

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync($"Envio/mis-envios/buscar-por-comentario?palabra={palabra}");
            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = "No se pudo obtener la información.";
                return View(new List<BuscarEnvioVM>());
            }

            var enviosVM = await response.Content.ReadFromJsonAsync<List<BuscarEnvioVM>>();

            if (enviosVM == null || !enviosVM.Any())
            {
                ViewBag.Mensaje = "No se encontraron envíos que coincidan con la búsqueda.";
            }
            return View(enviosVM);
        }
























        ////GET: EnvioController
        //public ActionResult Index()
        //{
        //    var correo = HttpContext.Session.GetString("correo");
        //    var rol = HttpContext.Session.GetString("rol");




        //    if (!string.IsNullOrEmpty(rol) && rol == "ADMINISTRADOR" || rol == "EMPLEADO")
        //    {

        //    }

        //    return View();

        //}


        // GET: EnvioController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: EnvioController/Create
        //public IActionResult Create()
        //{
        //    var correo = HttpContext.Session.GetString("correo");
        //    var rol = HttpContext.Session.GetString("rol");

        //    if (!string.IsNullOrEmpty(rol) && (rol == "ADMINISTRADOR" || rol == "EMPLEADO"))
        //    {


        //    return View();
        //    }

        //    return RedirectToAction("Login", "Usuario");

        //}

        //// POST: EnvioController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(EnvioViewModel vm)
        //{
        //    var rol = HttpContext.Session.GetString("rol");

        //    if (string.IsNullOrEmpty(rol) || !(rol.ToUpper() == "ADMINISTRADOR" || rol.ToUpper() == "EMPLEADO"))
        //    {
        //        return RedirectToAction("Login", "Usuario");
        //    }

        //    try
        //    {



        //        if (!ModelState.IsValid)
        //        {
        //            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
        //            ViewBag.Errores = string.Join(" | ", errors);
        //            return View(vm);
        //        }








        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch (Exception ex)
        //    {


        //        return View(vm);
        //    }
        //}

        //// GET: EnvioController/CreateUrgente
        //public IActionResult CreateUrgente()
        //{
        //    var rol = HttpContext.Session.GetString("rol");

        //    if (string.IsNullOrEmpty(rol) ||
        //        !(rol.ToUpper() == "ADMINISTRADOR" || rol.ToUpper() == "EMPLEADO"))
        //    {
        //        return RedirectToAction("Login", "Usuario");
        //    }



        //    return View();
        //}

        //// POST: EnvioController/CreateUrgente
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult CreateUrgente(EnvioUrgenteViewModel vm)
        //{
        //    var rol = HttpContext.Session.GetString("rol");

        //    if (string.IsNullOrEmpty(rol) ||
        //        !(rol.ToUpper() == "ADMINISTRADOR" || rol.ToUpper() == "EMPLEADO"))
        //    {
        //        return RedirectToAction("Login", "Usuario");
        //    }

        //    try
        //    {


        //        if (!ModelState.IsValid)
        //            return View(vm);









        //        return RedirectToAction("Index");
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.Mensaje = "Error al guardar el envío urgente: " + ex.Message;

        //        return View(vm);
        //    }
        //}


        //// GET: EnvioController/Edit

        //public ActionResult Edit(int id)
        //{
        //    var rol = HttpContext.Session.GetString("rol");

        //    if (string.IsNullOrEmpty(rol) ||
        //        !(rol.ToUpper() == "ADMINISTRADOR" || rol.ToUpper() == "EMPLEADO"))
        //    {
        //        return RedirectToAction("Login", "Usuario");
        //    }

        //    ListadoEnvioFinalizarViewModel envio = new ListadoEnvioFinalizarViewModel();
        //    {
        //        envio.Id = id;
        //    }

        //    return View(envio); // Muestra un campo para ingresar la fecha
        //}

        //// POST: EnvioController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]

        //public ActionResult Edit(ListadoEnvioFinalizarViewModel envio)
        //{
        //    var rol = HttpContext.Session.GetString("rol");

        //    if (string.IsNullOrEmpty(rol) ||
        //        !(rol.ToUpper() == "ADMINISTRADOR" || rol.ToUpper() == "EMPLEADO"))
        //    {
        //        return RedirectToAction("Login", "Usuario");
        //    }

        //    try
        //    {



        //        return RedirectToAction(nameof(Index));
        //    }

        //    catch (Exception ex)
        //    {
        //        ViewBag.Mensaje = "Error";
        //    }

        //    return View(envio);

        //}


        //// GET: EnvioController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: EnvioController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}


        //public IActionResult AgregarComentario(int idEnvio)
        //{


        //    var rol = HttpContext.Session.GetString("rol");

        //    if (string.IsNullOrEmpty(rol) ||
        //        !(rol.ToUpper() == "ADMINISTRADOR" || rol.ToUpper() == "EMPLEADO"))
        //    {
        //        return RedirectToAction("Login", "Usuario");
        //    }

        //    string correo = HttpContext.Session.GetString("correo");
        //    ComentarioViewModel comentarioVM = new ComentarioViewModel();
        //    try
        //    {

        //        if (idEnvio > 0)
        //        {
        //            comentarioVM.EnvioId = idEnvio;
        //            comentarioVM.EmpleadoEmail = correo;

        //        }
        //        else
        //        {
        //            ViewBag.Mensaje = "Id envio incorrecto";
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.Mensaje = "Error en datos";

        //    }


        //    return View(comentarioVM);
        //}

        //[HttpPost]
        //public IActionResult AgregarComentario(ComentarioViewModel comentarioVM)
        //{
        //    var rol = HttpContext.Session.GetString("rol");

        //    if (string.IsNullOrEmpty(rol) ||
        //        !(rol.ToUpper() == "ADMINISTRADOR" || rol.ToUpper() == "EMPLEADO"))
        //    {
        //        return RedirectToAction("Login", "Usuario");
        //    }

        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {



        //            return RedirectToAction(nameof(Index));

        //        }
        //        else
        //        {
        //            ViewBag.Mensaje = "Datos incorrectos";
        //        }

        //    }

        //    catch (Exception ex)
        //    {
        //        ViewBag.Mensaje = "Error";
        //    }
        //    return RedirectToAction("Index", "Envio");
        //}
    }
}


