using Beginners_CRUD_EvtApi.Models;

namespace Beginners_CRUD_EvtApi.Interfaces
{
    public interface IUserRepository
    {
        bool Authentication(string username, string pass);
        bool CreateUser(UserCredential user);
    }
}
