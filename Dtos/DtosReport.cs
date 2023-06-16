using Kidney.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kidney.Dtos
{
    public class DtosReport
    {
        public int ReportId { get; set; }
        
        public string Status { get; set; }
        public string ReportName { get; set; }
        public string ReportDescription { get; set; }
        public string ReportType { get; set; }

        public int DoctorId { get; set; }
        public int PatientId { get; set; }
    }
}
