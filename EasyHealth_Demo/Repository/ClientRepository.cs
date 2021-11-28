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

        public ClientRepository(ClientContext dbContext)
        {
            _dbContext = dbContext;

        }

        public Client GetClient(string email)
        {
            var selectedClient = _dbContext.Clients.FirstOrDefault(c => c.Email == email);

            return selectedClient;
        }

        public bool CheckLogin(LoginModel model)
        {
            var userAccount = GetClient(model.EmailEntered);

            if (userAccount == null && !BC.Verify(model.PasswordEntered, userAccount.PasswordHash))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Register(bool verifyResult, RegisterModel register, Client client)
        {
            verifyResult = VerifyClient(register);

            if (verifyResult == true)
            {
                return;
            }
            else
            {
                client.FirstName = register.FirstName;
                client.LastName = register.LastName;
                client.PhoneNumber = register.PhoneNumber;
                client.Email = register.Email;
                client.PasswordHash = BC.HashPassword(register.Password);
                _dbContext.Add(client);
                _dbContext.SaveChanges();
            }
        }

        public bool VerifyClient(RegisterModel register)
        {
            string emailCheck = register.Email;

            var emailFound = _dbContext.Clients.Any(c => c.Email == emailCheck);

            if (emailFound == true)
            {
                return true;
            }
            return false;
        }
    }
}
