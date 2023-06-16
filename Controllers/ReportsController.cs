using Castle.Core.Resource;
using Kidney.Data;
using Kidney.Dtos;
using Kidney.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kidney.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ReportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Hospitals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Report>>> GetReport()
        {
            return await _context.Reports.ToListAsync();
        }

        // GET: api/Hospitals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Report>> GetReportById(int id)
        {
            var report = await _context.Reports.FindAsync(id);

            if (report == null)
            {
                return NotFound();
            }

            return report;
        }

        // PUT: api/Hospitals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutHospital(int id, DtosReport model)
        {
            if (id != model.ReportId)
            {

                return NotFound();
            }
            var item = new Report()
            {
                //ReportId = model.ReportId,
                ReportName = model.ReportName,
                Status = model.Status,
                ReportDescription = model.ReportDescription,
                ReportType = model.ReportType,
                DoctorId=model.DoctorId,
                PatientId=model.PatientId,


            };

            _context.Reports.Update(item);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (ReportExists(id))
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
        public async Task<ActionResult<DtosHospital>> PostReport(DtosReport model)
        {
            var item = new Report()
            {
                //ReportId = model.ReportId,
                ReportName = model.ReportName,
                Status = model.Status,
                ReportDescription = model.ReportDescription,
                ReportType = model.ReportType,
                DoctorId = model.DoctorId,
                PatientId = model.PatientId,

            };
            _context.Reports.Add(item);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ReportExists(model.ReportId))
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
        public async Task<IActionResult> DeleteReport(int id)
        {
            var report = await _context.Reports.FindAsync(id);
            if (report == null)
            {
                return NotFound();
            }

            _context.Reports.Remove(report);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        
        
    //    [HttpGet]
    //public async Task<IActionResult> GetReportFileName(string filename)
    //{
    //    var reports = _context.Reports
    //        .Include(r => r.ReportFiles)
    //        .Where(r => r.ReportFiles.Name == filename)
    //        .ToList();

    //    return Ok(reports);
    //}

    private bool ReportExists(int id)
        {
            return _context.Hospitals.Any(e => e.Id == id);
        }
    }

}
