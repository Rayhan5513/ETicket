using Microsoft.AspNetCore.Mvc;

namespace ETicket.Controllers
{
    public class SignInController : Controller
    {
        public IActionResult SignIn()
        {
            return View();
        }

       // public IActionResult SignUp()
        //{
        //    return View();
       // }

        public IActionResult SignUp1()
        {
            return RedirectToAction("Index", "Home");
        }

    }
}
