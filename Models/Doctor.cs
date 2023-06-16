using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kidney.Models
{
    public class Doctor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DoctorId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Gendar gender { get; set; }
        public string Position { get; set; }

        [ForeignKey(nameof(dialysisunit))]
        public int dialysisunitId { get; set; }
        [JsonIgnore]
        public virtual DialysisUnit dialysisunit { get; set; }
        [JsonIgnore]
        public virtual ICollection<PatientDoctor> patientDoctors { get; set; }

    }
}
