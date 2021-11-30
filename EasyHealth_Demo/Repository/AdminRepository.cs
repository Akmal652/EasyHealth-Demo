using EasyHealth_Demo.Models;
using Microsoft.EntityFrameworkCore;
using EasyHealth_Demo.DBContexts;
using BC = BCrypt.Net.BCrypt;
using System.Web.Mvc;


namespace EasyHealth_Demo.Repository
{
    public class AdminRepository : IAdminRepository
    {
        // create a object for productContext
        private readonly ClientContext _dbContext;

        private readonly Admin _admin;

        public AdminRepository(ClientContext dbContext, Admin admin)
        {
            _dbContext = dbContext;
            _admin = admin;

        }

        public Admin GetAdmin(string adminEmail)
        {
            var selectedAdmin = _dbContext.Admins.FirstOrDefault(c => c.AdminEmail == adminEmail);

            return selectedAdmin;
        }

        public bool CheckAdminLogin(LoginModel model, out string checkLoginMessage)
        {
            // get account from database
            Admin userFound = GetAdmin(model.EmailEntered);

            // check account found and verify password
            if (userFound != null && BC.Verify(model.PasswordEntered, userFound.PasswordHash))
            {
                checkLoginMessage = "";
                // authentication successful
                return true;
            }
            else if (userFound != null && !BC.Verify(model.PasswordEntered, userFound.PasswordHash))
            {
                checkLoginMessage = "Password entered is incorrect.";
                // authentication failed
                return false;
            }
            else
            {
                checkLoginMessage = null;
                // authentication failed
                return false;
            }
        }

        public bool VerifyAdmin(RegisterAdminModel register)
        {
            string emailCheck = register.AdminEmailEntered;

            bool emailFound = _dbContext.Admins.Any(c => c.AdminEmail == emailCheck);

            if (emailFound == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RegisterAdmin(RegisterAdminModel register, out string message, out bool verifyResult)
        {
            verifyResult = VerifyAdmin(register);

            if (verifyResult == true)
            {
                message = "Email exists, please register again using different email.";
                return;
            }
            else
            {
                _admin.AdminEmail = register.AdminEmailEntered;
                _admin.PasswordHash = BC.HashPassword(register.AdminPassword);
                _dbContext.Add(_admin);
                _dbContext.SaveChanges();
                message = "Register succesful, please login using email and password registered.";
            }
        }
    }
}
