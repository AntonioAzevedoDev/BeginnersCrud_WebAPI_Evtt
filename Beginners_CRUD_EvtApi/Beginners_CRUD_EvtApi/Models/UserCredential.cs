using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Beginners_CRUD_EvtApi.Models
{
    public class UserCredential
    {
        public UserCredential(string userName, string password)
        {
            Id = Guid.NewGuid().ToString();
            UserName = userName;
            Password = password;
        }

        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
