using Kidney.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kidney.Dtos
{
    public class DtosDoctor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DoctorId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }  
        public Gendar gender { get; set; }
        public string Position { get; set; } 
        public string Email { get; set; }
        public string Phone { get; set; }
        public int dialysisunitId { get; set; }


    }
}
