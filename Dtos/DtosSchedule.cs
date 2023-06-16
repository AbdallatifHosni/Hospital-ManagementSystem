using Kidney.Models;

namespace Kidney.Dtos
{
    public class DtosSchedule
    {
        public int ScheduleId { get; set; }
        public int NumberOfTimes { get; set; }
        public DateTime DateOfTreatment { get; set; }
        public Days days { get; set; }
        public int PatientId { get; set; }
    }
}
