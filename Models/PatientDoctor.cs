namespace Kidney.Models
{
    public class PatientDoctor
    {
        public int PatientId { get; set;}
        public int DoctorID { get; set;}
        public virtual Patient Patient { get; set;}
        public virtual Doctor Doctor { get; set; }


    }
}
