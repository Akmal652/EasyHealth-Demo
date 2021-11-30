using EasyHealth_Demo.Models;
using Microsoft.EntityFrameworkCore;
using EasyHealth_Demo.DBContexts;
using BC = BCrypt.Net.BCrypt;
using System.Web.Mvc;

namespace EasyHealth_Demo.Repository
{
    public class ClientRepository : IClientRepository
    {
        // create a object for productContext
        private readonly ClientContext _dbContext;

        private readonly Client _client;

        public ClientRepository(ClientContext dbContext, Client client)
        {
            _dbContext = dbContext;
            _client = client;

        }

        public Client GetClient(string email)
        {
            var selectedClient = _dbContext.Clients.FirstOrDefault(c => c.Email == email);

            return selectedClient;
        }

        public bool CheckLogin(LoginModel model,out string checkLoginMessage)
        {
            // get account from database
            Client userFound = GetClient(model.EmailEntered);

            // check account found and verify password
            if (userFound != null && BC.Verify(model.PasswordEntered, userFound.PasswordHash))
            {
                checkLoginMessage="";
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

        public void Register(RegisterModel register,out string message,out bool verifyResult, string phoneCountryExt)
        {
            verifyResult = VerifyClient(register);

            if (verifyResult == true)
            {
                message = "Email exists, please register again using different email.";
                return;
            }
            else
            {
                _client.FirstName = register.FirstName;
                _client.LastName = register.LastName;
                _client.PhoneNumber = phoneCountryExt+register.PhoneNumber;
                _client.Email = register.Email;
                _client.PasswordHash = BC.HashPassword(register.Password);
                _dbContext.Add(_client);
                _dbContext.SaveChanges();
                message = "Register succesful, please login using email and password registered.";
            }
        }

        public bool VerifyClient(RegisterModel register)
        {
            string emailCheck = register.Email;

            bool emailFound = _dbContext.Clients.Any(c => c.Email == emailCheck);

            if (emailFound == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
