using Beginners_CRUD_EvtApi.Interfaces;
using Beginners_CRUD_EvtApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Beginners_CRUD_EvtApi.Services
{
    public class SuperHeroServices : ISuperHeroServices
    {
        private readonly ISuperHeroRepository _superHeroRepository;
        public SuperHeroServices(ISuperHeroRepository superHeroRepository)
        {
            _superHeroRepository = superHeroRepository;
        }
        public Task<ActionResult<List<SuperHeroModel>>> AddHero(SuperHeroModel hero)
        {
            return _superHeroRepository.AddHero(hero);
        }

        public Task<ActionResult<List<SuperHeroModel>>> DeleteHero(string id)
        {
            return _superHeroRepository.DeleteHero(id);
        }

        public Task<ActionResult<List<SuperHeroModel>>> GetAllHeroes()
        {
            var heroes = _superHeroRepository.GetAllHeroes();
            return heroes;
        }

        public Task<ActionResult<SuperHeroModel>> GetHeroById(string id)
        {
            return _superHeroRepository.GetHeroById(id);
        }

        public Task<ActionResult<List<SuperHeroModel>>> UpdateHero(SuperHeroModel request)
        {
            return _superHeroRepository.UpdateHero(request);
        }
    }
}
