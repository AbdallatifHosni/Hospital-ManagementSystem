using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kidney.Models
{
    public class Patient
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PatientId { get; set; }
        public string Name { get; set; }
        public Gendar gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        [ForeignKey(nameof(dialysisUnit))]
        public int dialysisUnitId { get; set; }
        [JsonIgnore]
        public virtual DialysisUnit dialysisUnit { get; set;}
        [JsonIgnore]
        public virtual ICollection<PatientDrug> patientDrugs { get; set; }
        [JsonIgnore]
        public virtual ICollection<PatientNurse> patientNurses { get; set; }
        [JsonIgnore]
        public virtual ICollection<PatientDoctor> patientDoctors { get; set; }
        public Patient()
        {
            patientDrugs = new HashSet<PatientDrug>();
            patientNurses = new HashSet<PatientNurse>();
            patientDoctors = new HashSet<PatientDoctor>();
        }
    }
}
