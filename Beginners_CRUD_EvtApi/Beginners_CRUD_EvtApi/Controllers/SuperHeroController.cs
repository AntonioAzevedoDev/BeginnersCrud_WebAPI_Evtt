using Beginners_CRUD_EvtApi.Interfaces;
using Beginners_CRUD_EvtApi.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Beginners_CRUD_EvtApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
       
        private readonly ISuperHeroServices _superHeroServices;
        public SuperHeroController(ISuperHeroServices superHeroServices)
        {
            _superHeroServices = superHeroServices;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHeroModel>>> Get()
        {
            var token = HttpContext.GetTokenAsync("acess_token").Result;
            var heroes = await _superHeroServices.GetAllHeroes();
            return Ok(heroes.Value);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHeroModel>> Get(string id)
        {
            var hero = _superHeroServices.GetHeroById(id);
            if (hero == null)
                return BadRequest("Hero not found.");
            return Ok(hero.Result.Value);
        }
        [HttpPost]
        public async Task<ActionResult<List<SuperHeroModel>>> AddHero(SuperHeroModel hero)
        {
            var request = await _superHeroServices.AddHero(hero);
            return Ok(request.Value);
        }
        [HttpPut]
        public async Task<ActionResult<List<SuperHeroModel>>> UpdateHero(SuperHeroModel request)
        {
            var dbHero = await _superHeroServices.UpdateHero(request);
            if (dbHero == null)
                return BadRequest("Hero not found.");
           
            return Ok(dbHero.Value);
        }

        [HttpDelete]
        public async Task<ActionResult<List<SuperHeroModel>>> DeleteHero(string id)
        {
            var request = await _superHeroServices.DeleteHero(id);
            if (request == null)
                return BadRequest("Hero not found.");
            return Ok(request.Value);
        }
    }
}
