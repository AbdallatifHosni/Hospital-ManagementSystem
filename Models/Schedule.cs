using Kidney.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kidney.Models
{
    public class Schedule
    {
        public int ScheduleId { get; set; }
        public int NumberOfTimes { get; set; }
        public DateTime DateOfTreatment { get; set; }   
        public Days days { get; set; }

        [ForeignKey(nameof(patient))]
        public int PatientId { get; set; }
        public virtual Patient patient { get; set;}
    }
}
