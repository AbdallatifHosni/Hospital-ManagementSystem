namespace Kidney.Models
{
    public class PatientNurse
    {
        public int PatientId { get; set; }
        public int NurseId { get; set;}
        public virtual Patient patient { get; set; }
        public virtual Nurse nurse { get; set; }
    }
}
