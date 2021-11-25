using Microsoft.AspNetCore.Mvc;

namespace EasyHealth_Demo.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult ClientCreateAccount()
        {
            return View();
        }

        public IActionResult HospitalCreateAccount()
        {
            return View();
        }

        public IActionResult ChooseAccount()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetAccountType()
        {
            var acctype = Request.Form["radioAccType"];
            if (acctype == "client")
            {
                return Redirect("ClientCreateAccount");
            }
            else
            {
                return Redirect("HospitalCreateAccount");
            }
        }
    }
}
