using Beginners_CRUD_EvtApi.Configuration;
using Beginners_CRUD_EvtApi.Interfaces;
using Beginners_CRUD_EvtApi.Models;
using MongoDB.Driver;

namespace Beginners_CRUD_EvtApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<UserCredential> _userCollection;
        public UserRepository(IDatabaseConfig databaseConfig)
        {
            var client = new MongoClient(databaseConfig.ConnectionString);
            var database = client.GetDatabase(databaseConfig.DatabaseName);
            _userCollection = database.GetCollection<UserCredential>("users");
        }

        public bool Authentication(string username, string pass)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(pass))
                return false;
            var users = _userCollection.Find(u => true).ToList();
            var user = _userCollection.Find(u => u.UserName == username && u.Password == pass).FirstOrDefault();
            if (user != null)
                return true;
            return false;
        }
        public bool CreateUser(UserCredential user)
        {
            _userCollection.InsertOne(user);
            return true;
        }
    }
}
