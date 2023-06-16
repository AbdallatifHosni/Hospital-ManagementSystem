using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kidney.Models
{
    public class Report
    {
        public int ReportId { get; set; }
        public string Status { get; set; }
        public string ReportName { get; set; }
        public string ReportDescription { get; set; }
        public string ReportType { get; set; }

        [ForeignKey(nameof(Doctor))]
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }

        [ForeignKey(nameof(patient))]
        public int PatientId { get; set; }
        [JsonIgnore]
        public virtual Patient patient { get; set; }
        [JsonIgnore]
        public virtual ICollection<Drug> Drugs { get; set; }
        [JsonIgnore]
        public virtual ICollection<ReportFiles> ReportFiles { get; set; }



    }
}
