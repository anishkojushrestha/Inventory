using Inventory_Project.Models;
using Inventory_WebApi.Data;
using Inventory_WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventory_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly Inventory_WebApiContext _context;
        public UnitController(Inventory_WebApiContext _context)
        {
            this._context = _context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Unit>>> GetUnit()
        {
            return await _context.units.ToListAsync();
        }


        [HttpPost]
        public async Task<ActionResult<Unit>> Create(Unit unit)

        {
            await _context.units.AddAsync(unit);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetUnit", new { id = unit.Id }, unit);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Unit>> GetUnit(int id)
        {
            var data = await _context.units.FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
            {
                return NotFound();
            }

            return data;

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Put(int id, Unit unit)
        {
            if (id != unit.Id)
            {
                return BadRequest();
            }

            _context.Entry(unit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnitExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(int id)
        {
            if (_context.units == null)
            {
                return NotFound();
            }
            var data = await _context.units.FirstOrDefaultAsync(x => x.Id == id);

            _context.units.Remove(data);
            await _context.SaveChangesAsync();
            return NoContent(); ;
        }
        private bool UnitExists(int id)
        {
            return (_context.units?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
 }
