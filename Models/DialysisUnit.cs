using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kidney.Models
{
    public class DialysisUnit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DialysisUnitId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string capacity { get; set;}      

       [ForeignKey(nameof(hospital))]
        public int  HospitalId { get; set; }
        [JsonIgnore]
        public virtual Hospital hospital { get; set; }

    }
}
