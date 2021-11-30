using Microsoft.AspNetCore.Mvc;
using EasyHealth_Demo.Repository;
using EasyHealth_Demo.Models;

namespace EasyHealth_Demo.Controllers
{
    public class AccountController : Controller
    {
        //create instance of IClient Repos
        private readonly IClientRepository _clientRepository;

        //create instance of IAdmin Repos
        private readonly IAdminRepository _adminRepository;
        public AccountController(IClientRepository clientRepository, IAdminRepository adminRepository)
        {
            _clientRepository = clientRepository;
            _adminRepository = adminRepository;
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult ClientCreateAccount()
        {
            return View();
        }

        public IActionResult AdminCreateAccount()
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
                return Redirect("AdminCreateAccount");
            }
        }

        [HttpPost]
        public IActionResult RegisterUserClient(RegisterModel register)
        {
            string registerResult;
            bool emailVerifyResult;
            string phoneNoExt = Request.Form["testSelect"];
            if (ModelState.IsValid)
            {
                _clientRepository.Register(register, out registerResult, out emailVerifyResult, phoneNoExt);

                if (emailVerifyResult == true)
                {
                    ModelState.AddModelError(nameof(register.Email), registerResult);
                    return View("ClientCreateAccount", register);
                }
                else
                {
                    return Redirect("Login");
                }
            }
            else
            {
                return View("ClientCreateAccount", register);
            }
        }

        [HttpPost]
        public IActionResult RegisterUserAdmin(RegisterAdminModel register)
        {
            string registerResult;
            bool emailVerifyResult;
            if (ModelState.IsValid)
            {
                _adminRepository.RegisterAdmin(register, out registerResult, out emailVerifyResult);

                if (emailVerifyResult == true)
                {
                    ModelState.AddModelError(nameof(register.AdminEmailEntered), registerResult);
                    return View("AdminCreateAccount", register);
                }
                else
                {
                    return Redirect("Login");
                }
            }
            else
            {
                return View("AdminCreateAccount", register);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LoginUserClient(LoginModel login)
        {
            string AuthenticateMessage;

            if (ModelState.IsValid)
            {
                if (_clientRepository.CheckLogin(login,out AuthenticateMessage))
                {
                    HttpContext.Session.SetString("Email", login.EmailEntered);
                    return RedirectToAction("Index", "Home");
                }
                else if (_clientRepository.CheckLogin(login, out AuthenticateMessage)==false && AuthenticateMessage != null)
                {
                    ModelState.AddModelError(nameof(login.PasswordEntered), AuthenticateMessage);
                    return View("Login", login);
                }
                else
                {
                    ModelState.AddModelError(nameof(login.EmailEntered), "Email not found or matched");
                    return View("Login", login);
                }
            }
            return View("Login", login);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LoginUserAdmin(LoginModel login)
        {
            string AuthenticateMessage;

            if (ModelState.IsValid)
            {
                if (_adminRepository.CheckAdminLogin(login, out AuthenticateMessage))
                {
                    HttpContext.Session.SetString("Email", login.EmailEntered);
                    return RedirectToAction("Index", "Home");
                }
                else if (_adminRepository.CheckAdminLogin(login, out AuthenticateMessage) == false && AuthenticateMessage != null)
                {
                    ModelState.AddModelError(nameof(login.PasswordEntered), AuthenticateMessage);
                    return View("Login", login);
                }
                else
                {
                    ModelState.AddModelError(nameof(login.EmailEntered), "Email not found or matched");
                    return View("Login", login);
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
