using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kidney.Data;
using Kidney.Dtos;
using Kidney.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KidneyUnit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DialysisUnitsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DialysisUnitsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/DialysisUnits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DialysisUnit>>> GetDialysisUnits()
        {
            return await _context.DialysisUnits.ToListAsync();
        }

        // GET: api/DialysisUnits/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<DialysisUnit>> GetDialysisUnit(int id)
        {
            var dialysisUnit = await _context.DialysisUnits.FindAsync(id);

            if (dialysisUnit == null)
            {
                return NotFound();
            }

            return dialysisUnit;
        }

        // PUT: api/DialysisUnits/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDialysisUnit(int id, DtosDialysisUnit model)
        {
            if (id!= model.DialysisUnitId)
            {
                return BadRequest();
            }

            var item = new DialysisUnit() 
            {
                DialysisUnitId=id,
                Name=model.Name,
                capacity=model.capacity,
                HospitalId=model.HospitalId,
            };
            _context.DialysisUnits.Update(item);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DialysisUnitExists(id))
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

        // POST: api/DialysisUnits
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DialysisUnit>> PostDialysisUnit(DtosDialysisUnit dtos)
        {
            var item = new DialysisUnit()
            {
                DialysisUnitId = dtos.DialysisUnitId,
                Name = dtos.Name,
                capacity=dtos.capacity,
                HospitalId = dtos.HospitalId,

            };
            _context.DialysisUnits.Add(item);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DialysisUnitExists(item.DialysisUnitId))
                {
                    return Conflict();
                }
            }

            return CreatedAtAction("GetDialysisUnit", new { id = item.DialysisUnitId }, item);
        }

        // DELETE: api/DialysisUnits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDialysisUnit(int id)
        {
            var dialysisUnit = await _context.DialysisUnits.FindAsync(id);
            if (dialysisUnit == null)
            {
                return NotFound();
            }

            _context.DialysisUnits.Remove(dialysisUnit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DialysisUnitExists(int id)
        {
            return _context.DialysisUnits.Any(e => e.DialysisUnitId == id);
        }
    }
}
