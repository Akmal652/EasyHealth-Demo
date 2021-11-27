using EasyHealth_Demo.Models;

namespace EasyHealth_Demo.Repository
{
    public interface IClientRepository
    {
        Client GetClient(string Email);

        void CheckLogin(string Email,string password);

        void VerifyClient(Client client);
    }
}
