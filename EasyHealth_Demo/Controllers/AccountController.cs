using Microsoft.AspNetCore.Mvc;
using EasyHealth_Demo.Repository;
using EasyHealth_Demo.Models;

namespace EasyHealth_Demo.Controllers
{
    public class AccountController : Controller
    {
        //create instance of IClient Repos
        private readonly IClientRepository _clientRepository;
        public AccountController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public IActionResult Login()
        {
            return View();
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
        public IActionResult RegisterUserClient(RegisterModel register)
        {
            string registerResult;
            bool emailVerifyResult;
            string phoneNoExt = Request.Form["testSelect"];
            _clientRepository.Register(register, out registerResult, out emailVerifyResult,phoneNoExt);

            if (emailVerifyResult == true)
            {
                ModelState.AddModelError(nameof(register.Email), registerResult);
                return View("ClientCreateAccount",register);
            }
            else
            {
                return Redirect("Login");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LoginUserClient(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                if (_clientRepository.CheckLogin(login))
                {
                    HttpContext.Session.SetString("Email", login.EmailEntered);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(nameof(login.EmailEntered), "Email not found or matched");
                    return View(login);
                }
            }
            return View("Login", login);


        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Email");
            return Redirect("Login");
        }
    }
}
