using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiUsuarios.Models;
using ApiUsuarios.Data;

namespace ApiUsuarios.Controllers
{
    [ApiController]
    [Route("api/personagens")]
    public class PersonagensController : ControllerBase
    {
        private readonly AppDBContext _context;

        public PersonagensController(AppDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Personagem>>> Get()
        {
            return Ok(await _context.Personagens.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Personagem>> GetById(int id)
        {
            var personagem = await _context.Personagens.FindAsync(id);

            if (personagem == null)
                return NotFound();

            return Ok(personagem);
        }

        [HttpPost]
        public async Task<ActionResult<Personagem>> Create(Personagem personagem)
        {
            _context.Personagens.Add(personagem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = personagem.Id }, personagem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Personagem personagem)
        {
            if (id != personagem.Id)
                return BadRequest();

            _context.Entry(personagem).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var personagem = await _context.Personagens.FindAsync(id);

            if (personagem == null)
                return NotFound();

            _context.Personagens.Remove(personagem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}