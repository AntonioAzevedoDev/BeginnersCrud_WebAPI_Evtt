using Beginners_CRUD_EvtApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Beginners_CRUD_EvtApi.Interfaces
{
    public interface ISuperHeroRepository 
    {
        Task<ActionResult<List<SuperHeroModel>>> GetAllHeroes();
        Task<ActionResult<SuperHeroModel>> GetHeroById(string id);
        Task<ActionResult<List<SuperHeroModel>>> AddHero(SuperHeroModel hero);
        Task<ActionResult<List<SuperHeroModel>>> UpdateHero(SuperHeroModel request);
        Task<ActionResult<List<SuperHeroModel>>> DeleteHero(string id);
        
    }
}
