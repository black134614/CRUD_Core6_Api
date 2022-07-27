using CRUD_Core6_Api.Data;
using CRUD_Core6_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Core6_Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly DataContext _context;
        public SuperHeroController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetSuperHero")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpPost("AddSuperHero")]
        public async Task<IActionResult> AddHero([FromBody] SuperHero hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();
            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpGet("FindSuperHero")]
        public async Task<IActionResult> Get(int Id)
        {
            var hero = await _context.SuperHeroes.FindAsync(Id);
            if (hero == null)
            {
                return BadRequest("Hero not found!");
            }
            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpPut("UpdateSuperHero")]
        public async Task<IActionResult> UpdateSuperHero(SuperHero request)
        {
            var hero = await _context.SuperHeroes.FindAsync(request.Id);
            if (hero == null)
            {
                return BadRequest("Hero not found!");
            }
            hero.Name = request.Name;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;

            await _context.SaveChangesAsync();
            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpDelete("DeleteSuperHero")]
        public async Task<IActionResult> DeleteSuperHero(int Id)
        {
            var hero = await _context.SuperHeroes.FindAsync(Id);
            if (hero == null)
                return BadRequest("Hero not found!");
            _context.SuperHeroes.Remove(hero);
            await _context.SaveChangesAsync();
            return Ok(await _context.SuperHeroes.ToListAsync());
        }
    }
}