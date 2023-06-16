using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KidneyUnit;
using Kidney.Data;
using Kidney.Models;
using Kidney.Dtos;

namespace KidneyUnit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NursesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public NursesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Nurses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nurse>>> GetNurses()
        {
            return await _context.Nurses.ToListAsync();
        }

        // GET: api/Nurses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Nurse>> GetNurse(int id)
        {
            var nurse = await _context.Nurses.FindAsync(id);

            if (nurse == null)
            {
                return NotFound();
            }

            return nurse;
        }

        // PUT: api/Nurses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNurse(int id, DtosNurse nurse)
        {
            if (id != nurse.NurseId|| id==null)
            {
                return BadRequest();
            }
            var model = new Nurse() 
            {
                NurseId = nurse.NurseId,
                Name= nurse.Name,
                gender=nurse.gender,
                dialysisUnitId=nurse.dialysisUnitId,
            
            };
            _context.Nurses.Update(model);



            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NurseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(model);
        }

        // POST: api/Nurses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Nurse>> PostNurse(DtosNurse nurse)
        {
            var model = new Nurse()
            {
                NurseId = nurse.NurseId,
                Name = nurse.Name,
                gender = nurse.gender,
                dialysisUnitId = nurse.dialysisUnitId,

            };
            _context.Nurses.Add(model);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NurseExists(nurse.NurseId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetNurse", new { id = nurse.NurseId }, nurse);
        }

        // DELETE: api/Nurses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNurse(int id)
        {
            var nurse = await _context.Nurses.FindAsync(id);
            if (nurse == null)
            {
                return NotFound();
            }

            _context.Nurses.Remove(nurse);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NurseExists(int id)
        {
            return _context.Nurses.Any(e => e.NurseId == id);
        }
    }
}
