using Microsoft.AspNetCore.Mvc;

namespace EasyHealth_Demo.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult CreateAccount()
        {
            return View();
        }
    }
}
