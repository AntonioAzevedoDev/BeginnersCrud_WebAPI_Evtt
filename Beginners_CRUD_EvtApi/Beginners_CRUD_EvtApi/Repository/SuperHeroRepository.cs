using Beginners_CRUD_EvtApi.Configuration;
using Beginners_CRUD_EvtApi.Interfaces;
using Beginners_CRUD_EvtApi.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Beginners_CRUD_EvtApi.Repository
{
    public class SuperHeroRepository : ISuperHeroRepository
    {
        private readonly IMongoCollection<SuperHeroModel> _superHeroCollection;
        private readonly IMongoCollection<UserCredential> _userCollection;
        public SuperHeroRepository(IDatabaseConfig databaseConfig)
        {
            var client = new MongoClient(databaseConfig.ConnectionString);
            var database = client.GetDatabase(databaseConfig.DatabaseName);
            _superHeroCollection = database.GetCollection<SuperHeroModel>("superheroes");
            _userCollection = database.GetCollection<UserCredential>("users");
        }
        
        public async Task<ActionResult<List<SuperHeroModel>>> AddHero(SuperHeroModel hero)
        {
            await _superHeroCollection.InsertOneAsync(hero);
            return await _superHeroCollection.Find(h => true).ToListAsync();
        }

        public async Task<ActionResult<List<SuperHeroModel>>> DeleteHero(string id)
        {
            var hero = _superHeroCollection.Find(h => h.Id == id).FirstOrDefault();
            if (hero == null)
                return null;
            _superHeroCollection.DeleteOne(h => h.Id == id);
            return await _superHeroCollection.Find(h => true).ToListAsync();
        }

        public async Task<ActionResult<List<SuperHeroModel>>> GetAllHeroes()
        {
            var heroes = await _superHeroCollection.Find(h => true).ToListAsync();
            return heroes;
        }

        public async Task<ActionResult<SuperHeroModel>> GetHeroById(string id)
        {
            var hero = _superHeroCollection.Find(h => h.Id == id).FirstOrDefault();
            if (hero == null)
                return null;
            return hero;
        }

        public async Task<ActionResult<List<SuperHeroModel>>> UpdateHero(SuperHeroModel request)
        {
            var dbHero = _superHeroCollection.Find(h => h.Id == request.Id).FirstOrDefault();
            if (dbHero == null)
                return null;

            dbHero.Name = request.Name;
            dbHero.FirstName = request.FirstName;
            dbHero.LastName = request.LastName;
            dbHero.Place = request.Place;

            await _superHeroCollection.ReplaceOneAsync(h => h.Id == dbHero.Id, dbHero);
            return await _superHeroCollection.Find(h => true).ToListAsync();
        }
    }
}
