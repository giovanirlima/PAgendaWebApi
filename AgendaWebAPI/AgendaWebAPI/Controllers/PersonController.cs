using AgendaWebAPI.Data;
using AgendaWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly AgendaContext _context;

        public PersonController(AgendaContext agendaContext)
        {
            _context = agendaContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPerson()
        {
            return await _context.People.Include(people => people.Address).AsNoTracking().ToListAsync();
        }
        [HttpGet("id")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var person = await _context.People.Include(people => people.Address).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }
        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            _context.People.Add(person);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPerson", new {id = person.Id}, person);
        }
        [HttpPut("id")]
        public async Task<IActionResult> PutPerson(int id, Person person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }

            _context.Entry(person).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
                {
                    return NotFound();
                }                
            }

            return NoContent();
        }
        [HttpDelete("id")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var person = await _context.People.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            _context.People.Remove(person);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool PersonExists(int id)
        {
            return _context.People.Any(p => p.Id == id);
        }

    }
}
