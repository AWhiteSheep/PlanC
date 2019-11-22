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
    public class ProgrammesController : ControllerBase
    {
        private readonly PCU001Context _context;

        public ProgrammesController(PCU001Context context)
        {
            _context = context;
        }

        // GET: api/Programmes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Programmes>>> GetProgrammes()
        {
            return await _context.Programmes.ToListAsync();
        }

        // GET: api/Departements/100/Programmes/AA
        [Route("~/api/departements/{departementId}/programmes/{programmeId}")]
        [HttpGet]
        public async Task<ActionResult<Programmes>> GetProgrammes(int departementId, string programmeId)
        {
            var programmes = await _context.Programmes.FindAsync(departementId, programmeId);

            if (programmes == null)
            {
                return NotFound();
            }

            return programmes;
        }

        // PUT: api/Programmes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        [Route("~/api/departements/{departementId}/programmes/{programmeId}")]
        public async Task<IActionResult> PutProgrammes(int departementId, string programmeId, Programmes programmes)
        {
            if (!(programmeId == programmes.Id && departementId == programmes.DepartementId))
            {
                var badRequest = BadRequest(new { "" });
                return BadRequest();
            }

            _context.Entry(programmes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgrammesExists(id))
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

        // POST: api/Programmes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Programmes>> PostProgrammes(Programmes programmes)
        {
            _context.Programmes.Add(programmes);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProgrammesExists(programmes.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProgrammes", new { id = programmes.Id }, programmes);
        }

        // DELETE: api/Programmes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Programmes>> DeleteProgrammes(string id)
        {
            var programmes = await _context.Programmes.FindAsync(id);
            if (programmes == null)
            {
                return NotFound();
            }

            _context.Programmes.Remove(programmes);
            await _context.SaveChangesAsync();

            return programmes;
        }

        private bool ProgrammesExists(string id)
        {
            return _context.Programmes.Any(e => e.Id == id);
        }
    }
}
