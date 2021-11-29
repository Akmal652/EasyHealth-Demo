using EasyHealth_Demo.Models;

namespace EasyHealth_Demo.Repository
{
    public interface IClientRepository
    {
        Client GetClient(string Email);

        void Register(RegisterModel register,out string message,out bool verifyResult, string phoneCountyExt);

        bool CheckLogin(LoginModel model);

        bool VerifyClient(RegisterModel register);
    }
}
