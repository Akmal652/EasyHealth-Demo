using Microsoft.AspNetCore.Mvc;
using EasyHealth_Demo.Repository;

namespace EasyHealth_Demo.Controllers
{
    public class RegisterController : Controller
    {
        //create instance of IClient Repos
        private readonly IClientRepository _clientRepository;
        public RegisterController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
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

        [HttpPost]

        public IActionResult RegisterUserClient()
        {

        }
    }
}
