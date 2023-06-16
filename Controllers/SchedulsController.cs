using Kidney.Data;
using Kidney.Dtos;
using Kidney.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Kidney.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SchedulsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Schedules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Schedule>>> GetSchedule()
        {
            return await _context.Schedules.ToListAsync();
        }

        // GET: api/Schedule/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Schedule>> GetScheduleById(int id)
        {
            var item = await _context.Schedules.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        // PUT: api/Schedule/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutSchedule(int id, DtosSchedule model)
        {
            if (id != model.ScheduleId)
            {

                return NotFound();
            }
            var item = new Schedule()
            {
                NumberOfTimes=model.NumberOfTimes,
                DateOfTreatment=model.DateOfTreatment,
                days=model.days,
                PatientId=model.PatientId,  

            };

            _context.Schedules.Update(item);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScheduleExists(id))
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

        // POST: api/Schedules
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DtosSchedule>> PostHSchedule(DtosSchedule model)
        {
            var item = new Schedule()
            {
                NumberOfTimes = model.NumberOfTimes,
                DateOfTreatment = model.DateOfTreatment,
                days = model.days,
                PatientId = model.PatientId,

            };
            _context.Schedules.Add(item);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ScheduleExists(model.ScheduleId))
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

        // DELETE: api/Schedule/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteSchedule(int id)
        {
            var item = await _context.Schedules.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.Schedules.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ScheduleExists(int id)
        {
            return _context.Schedules.Any(e => e.ScheduleId ==  id);
        }
    }

}

