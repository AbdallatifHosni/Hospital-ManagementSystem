using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Kidney.Models
{
    public class Drug
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Code { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public byte Dosage { get; set; }
        public string Description { get; set; }
        public string History { get; set; }
        public DateTime Date  { get; set; }
       
        [ForeignKey(nameof(doctor))]
        public int DoctorId { get; set; }
        public virtual Doctor doctor { get; set; }

        [ForeignKey(nameof(Report))]
        public int ReportId { get; set; }
        public virtual Report Report { get; set; }
        public virtual ICollection<PatientDrug> patientDrugs { get; set; }



    }
}
