using Beginners_CRUD_EvtApi.Models;

namespace Beginners_CRUD_EvtApi.Interfaces
{
    public interface IJwtTokenManager
    {
        string Authenticate(string userName, string password);
        bool CreateNewUser(UserCredential user);
    }
}
