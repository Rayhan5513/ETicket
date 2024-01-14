using ETicket.Data;
using ETicket.Models;
using Microsoft.AspNetCore.Mvc;
using Optivem.Framework.Core.Domain;
using System.Diagnostics;

namespace ETicket.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext applicationDbContext;

        public HomeController(ILogger<HomeController> logger,
            ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            this.applicationDbContext = applicationDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
            
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult SignUp()
        {
            var model = new User();
            return View(model);
        }

        [HttpPost]
        public IActionResult SignUp(User model)
        {
            if(model == null)
            {
                throw new ArgumentNullException("model");
            }            
            if(ModelState.IsValid) {
                var user = applicationDbContext.Users.FirstOrDefault(x => x.Email == model.Email);
                if (user !=null)
                {
                    ModelState.AddModelError("Email", "An user already exist with this user please login");
                    return View("SignUp", model);
                }
              var res=  applicationDbContext.Users.Add(model);
                if(res!=null)applicationDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }

        public IActionResult SignIn()
        {
            return View(new LoginModel());
        }

        [HttpPost]
        public IActionResult SignIn(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = applicationDbContext.Users.FirstOrDefault(x => x.Email == model.Email);
                if (user != null && user.Password == model.Password)
                {
                    return RedirectToAction("Index");
                }
                else if(user != null) 
                {
                    ModelState.AddModelError("Password", "Password is not correct");
                    return View("SignIn", model);
                }
                else
                {
                    ModelState.AddModelError("Email", "User doesn't exist with this email");
                    return View("SignIn", model);
                }
            }
            return View(new LoginModel());
        }
    }
}
