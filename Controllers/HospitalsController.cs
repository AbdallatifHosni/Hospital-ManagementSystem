using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kidney.Data;
using Kidney.Models;
using Kidney.Dtos;

namespace KidneyUnit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HospitalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Hospitals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hospital>>> GetHospitals()
        {
            return await _context.Hospitals.ToListAsync();
        }

        // GET: api/Hospitals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hospital>> GetHospital(int id)
        {
            var hospital = await _context.Hospitals.FindAsync(id);

            if (hospital == null)
            {
                return NotFound();
            }

            return hospital;
        }

        // PUT: api/Hospitals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutHospital(int id, DtosHospital model)
        {
            if (id!=model.Id)
            {

                return NotFound();
            }
            var item = new Hospital()
            {
                Id = id,
                Name = model.Name,
                Email = model.Email,
                Website = model.Website,
                Country= model.Country,
                Area = model.Area,
                City = model.City,
                Phone1 = model.Phone1,
                Phone2 = model.Phone2

            };

             _context.Hospitals.Update(item);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(item);
        }

        // POST: api/Hospitals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DtosHospital>> PostHospital(DtosHospital model)
        {
            var item = new Hospital()
            { 
                Id=model.Id,
                Name=model.Name,
                Email=model.Email,
                Website=model.Website,
                Country = model.Country,
                Area =model.Area,
                City=model.City,
                Phone1 = model.Phone1,
                Phone2=model.Phone2

            };
            _context.Hospitals.Add(item);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HospitalExists(model.Id))
                {
                    return Conflict();
                }           
                else
                {
                    throw;
                }
            }

            return Ok(model);
        }

        // DELETE: api/Hospitals/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteHospital(int id)
        {
            var hospital = await _context.Hospitals.FindAsync(id);
            if (hospital == null)
            {
                return NotFound();
            }

            _context.Hospitals.Remove(hospital);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HospitalExists(int id)
        {
            return _context.Hospitals.Any(e => e.Id == id);
        }
    }
}
