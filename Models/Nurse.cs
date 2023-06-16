using System.ComponentModel.DataAnnotations.Schema;

namespace Kidney.Models
{
    public class Nurse
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NurseId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Gendar gender { get; set; }
        
        [ForeignKey(nameof(dialysisUnit))]
        public int dialysisUnitId { get; set; }
        public virtual  DialysisUnit dialysisUnit { get; set; }

        public virtual ICollection<PatientNurse> patientNurses { get; set; }

    }
}
