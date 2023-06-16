using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kidney.Models
{
    public class PatientDrug
    {
        public int PatientId { get ; set ; }
        public int DrugId { get ; set ; }
        [DataType(DataType.DateTime)]
        public DateTime NTimes { get ; set ;}
        public virtual Patient patient { get; set; }
        public virtual Drug drug { get; set; }
    }
}
