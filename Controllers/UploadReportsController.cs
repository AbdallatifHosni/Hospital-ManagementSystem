using Kidney.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kidney.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadReportsController : ControllerBase

    {
            private readonly string _uploadsDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", "ReportsImages");

        public UploadReportsController( ) 
                {}

            [HttpPost("upload")]
            public async Task<IActionResult> UploadFile(IFormFile file)
            {
                if (file == null || file.Length == 0)
                {
                    return BadRequest("Please select a file to upload.");
                }

                // Create the uploads directory if it doesn't exist
                Directory.CreateDirectory(_uploadsDirectory);

                // Generate a unique file name to prevent overwriting existing files
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            //Name = fileName;
               var obj = new ReportFiles { Name= fileName };

                // Combine the uploads directory path with the unique file name
                string filePath = Path.Combine(_uploadsDirectory, fileName);

                // Save the file to disk
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // Return the URL of the uploaded file
                string fileUrl = Url.Content(Path.Combine("~/Uploads/ReportsImages", fileName));
                return Ok(new { url = fileUrl });
            }
            //private readonly string _uploadsDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", "ReportsImages");

            [HttpGet("{fileName}")]
            public IActionResult GetFile(string fileName)
            {
                // Combine the uploads directory path with the requested file name
                string filePath = Path.Combine(_uploadsDirectory, fileName);

                // Check if the file exists
                if (!System.IO.File.Exists(filePath))
                {
                    return NotFound();
                }

                // Read the file contents and return as a file result
                var fileContents = System.IO.File.ReadAllBytes(filePath);
                return File(fileContents, "application/octet-stream", fileName);
            }

       }
}
