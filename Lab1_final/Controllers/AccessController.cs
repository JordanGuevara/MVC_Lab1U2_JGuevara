using System.Linq;
using System.Web.Mvc;
using Lab1_final.Filters; // Filtro de sesión
using Lab1_final.Models; // Modelo EF
using Lab1_final.Models.TableViewModel; // ViewModel para la tabla

namespace Lab1_final.Controllers
{
    public class AccessController : Controller
    {
        // Muestra el formulario de login
        public ActionResult Index()
        {
            // Si ya hay sesión activa, redirige a la página Welcome
            if (Session["user"] != null)
            {
                return RedirectToAction("Welcome");
            }

            return View();
        }

        // Procesa los datos del formulario de login
        [HttpPost]
        public ActionResult Login(string user, string password)
        {
            using (AccessEntityFramework db = new AccessEntityFramework())
            {
                var userExist = db.usuario.FirstOrDefault(u => u.user == user && u.password == password);
                if (userExist != null)
                {
                    Session["user"] = userExist.user;
                    return RedirectToAction("Welcome");
                }
                else
                {
                    ViewBag.Error = "Usuario o contraseña incorrectos.";
                    return View("Index");
                }
            }
        }

        // Vista protegida por sesión
        [VerifySession]
        public ActionResult Welcome()
        {
            ViewBag.User = Session["user"].ToString();
            return View();
        }

        // Cierra la sesión y regresa al login
        public ActionResult Logout()
        {
            Session.Clear(); // Limpia la sesión activa
            return RedirectToAction("Index"); // Regresa al login
        }

        // Lista de usuarios usando ViewModel
        [VerifySession]
        public ActionResult UserList()
        {
            using (AccessEntityFramework db = new AccessEntityFramework())
            {
                var usuarios = db.usuario.Select(u => new UserTableViewModel
                {
                    User = u.user,
                    Password = u.password
                }).ToList();

                return View(usuarios);
            }
        }
    }
}
