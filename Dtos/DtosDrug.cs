using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Kidney.Dtos
{
    public class DtosDrug
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Code { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public byte Dosage { get; set; }
        public string Description { get; set; }
        public int DoctorId { get; set; }
    }
}
