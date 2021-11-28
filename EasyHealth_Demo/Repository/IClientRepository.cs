using EasyHealth_Demo.Models;

namespace EasyHealth_Demo.Repository
{
    public interface IClientRepository
    {
        Client GetClient(string Email);

        void Register(bool verifyResult,RegisterModel register,Client client);

        bool CheckLogin(LoginModel model);

        bool VerifyClient(RegisterModel register);
    }
}
