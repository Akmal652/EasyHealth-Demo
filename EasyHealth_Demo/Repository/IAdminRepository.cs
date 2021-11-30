using EasyHealth_Demo.Models;

namespace EasyHealth_Demo.Repository
{
    public interface IAdminRepository
    {
        Admin GetAdmin(string adminEmail);

        void RegisterAdmin(RegisterAdminModel register, out string message, out bool verifyResult);

        bool CheckAdminLogin(LoginModel model, out string checkLoginMessage);

        bool VerifyAdmin(RegisterAdminModel register);
    }
}
