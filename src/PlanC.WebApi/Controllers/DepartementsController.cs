using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanC.Client.Data;
using PlanC.EntityDataModel;

namespace PlanC.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartementsController : ControllerBase
    {
        private readonly PCU001Context _context;

        public DepartementsController(PCU001Context context)
        {
            _context = context;
        }

        // GET: api/Departements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Departements>>> GetDepartements()
        {
            return await _context.Departements.ToListAsync();
        }

        // GET: api/Departements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Departements>> GetDepartements(int id)
        {
            var departements = await _context.Departements.FindAsync(id);

            if (departements == null)
            {
                return NotFound();
            }

            return departements;
        }

        // PUT: api/Departements/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartements(int id, Departements departements)
        {
            if (id != departements.Id)
            {
                return BadRequest();
            }

            _context.Entry(departements).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartementsExists(id))
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

        // POST: api/Departements
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Departements>> PostDepartements(Departements departements)
        {
            _context.Departements.Add(departements);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DepartementsExists(departements.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDepartements", new { id = departements.Id }, departements);
        }

        // DELETE: api/Departements/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Departements>> DeleteDepartements(int id)
        {
            var departements = await _context.Departements.FindAsync(id);
            if (departements == null)
            {
                return NotFound();
            }

            _context.Departements.Remove(departements);
            await _context.SaveChangesAsync();

            return departements;
        }

        private bool DepartementsExists(int id)
        {
            return _context.Departements.Any(e => e.Id == id);
        }
    }
}
