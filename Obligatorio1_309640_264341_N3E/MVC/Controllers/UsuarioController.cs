using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Models.UsuariosVM;

using Microsoft.AspNetCore.Mvc.Rendering;

using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Runtime.Intrinsics.Arm;
using System.Net.Http.Headers;

namespace MVC.Controllers
{
    public class UsuarioController : Controller
    {
        private string url = "";

        public UsuarioController(IConfiguration configuration)
        {
            url = configuration.GetValue<string>("urlBase") + "Usuario";
        }


        // GET: UsuarioController
        public ActionResult Index()
        {
            var correo = HttpContext.Session.GetString("correo");
            var rol = HttpContext.Session.GetString("rol");


            if (string.IsNullOrEmpty(rol) || rol != "ADMINISTRADOR")
            {
                return RedirectToAction("Login");
            }

                ViewBag.Correo = correo;
                ViewBag.Rol = rol;

                return View();
            
        }



        // GET: CarreraController/Create
        public ActionResult CambiarContrasenia()
        {

            var email = HttpContext.Session.GetString("Email");

            if (string.IsNullOrEmpty(email) )
            {
                return RedirectToAction("Login", "Usuario");
            }

            ViewBag.Email = email;

            return View();
        }




        // POST: CarreraController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CambiarContrasenia(UsuarioPassViewModel usuarioPassVM)
        {

            try
            {
                if (ModelState.IsValid)
                {


                    var token = HttpContext.Session.GetString("Token");
                    if (string.IsNullOrEmpty(token))
                    {
                        ViewBag.Mensaje = "No se encontró el token de autenticación.";
                        return View(usuarioPassVM);
                    }




                    url = url + "/CambiarContrasenia";
                    HttpClient cliente = new HttpClient();
                    cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));
                    Task<HttpResponseMessage> tarea = cliente.PutAsJsonAsync(url, usuarioPassVM);
                    tarea.Wait();
                    HttpResponseMessage respuesta = tarea.Result;
                    if (respuesta.IsSuccessStatusCode)
                    {
                        TempData["Mensaje"] = "Cambio correcto";
                        return RedirectToAction("Index", "Home");


                    }
                    else if ((int)respuesta.StatusCode == StatusCodes.Status401Unauthorized)
                    {
                        return RedirectToAction("Login", "Usuario");
                    }
                    else if ((int)respuesta.StatusCode == StatusCodes.Status403Forbidden)
                    {
                        return RedirectToAction("Index", "Curso");
                    }
                    else
                    {
                        HttpContent contenido = respuesta.Content;
                        Task<string> body = contenido.ReadAsStringAsync();
                        body.Wait();
                        ViewBag.Mensaje = body.Result;
                        return View();
                    }
                }
                else
                {
                    ViewBag.Mensaje = "Los datos no son correctos";
                    return View();
                }
            }

            catch (Exception ex)
            {

                ViewBag.Mensaje = "Error en los datos";

            }
            return View(usuarioPassVM);
        }
        











        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UsuarioLoginViewModel usuLoginVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    HttpClient client = new HttpClient();
                    Task<HttpResponseMessage> tarea = client.PostAsJsonAsync(url + "/Login", usuLoginVM);
                    tarea.Wait();
                    HttpResponseMessage respuesta = tarea.Result;
                    HttpContent contenido = respuesta.Content;
                    Task<string> body = contenido.ReadAsStringAsync();
                    body.Wait();
                    string datos = body.Result;
                    if (respuesta.IsSuccessStatusCode)
                    {

                        UsuarioLogueadoViewModel usuLogueado = JsonConvert.DeserializeObject<UsuarioLogueadoViewModel>(datos);
                        HttpContext.Session.SetString("Rol", usuLogueado.Rol);

                        HttpContext.Session.SetString("Token", usuLogueado.Token);
                        HttpContext.Session.SetString("Email", usuLogueado.Email);
                        return RedirectToAction("Index", "Home");
                        
                    }
                    else
                    {
                        ViewBag.Mensaje = datos;
                    }

                }
                else
                {
                    ViewBag.Mensaje = "Los datos no son correctos";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Error";
            }
            return View();

        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Login", "Usuario");
        }
    }
}
