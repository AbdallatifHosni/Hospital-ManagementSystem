using Kidney.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kidney.Dtos
{
    public class DtosPatient
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PatientId { get; set; }
        public string Name { get; set; }
        public Gendar gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int dialysisUnitId { get; set; }
    }
}
