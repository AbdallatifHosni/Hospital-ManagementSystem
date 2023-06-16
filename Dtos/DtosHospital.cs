using System.ComponentModel.DataAnnotations.Schema;

namespace Kidney.Dtos
{
    public class DtosHospital
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public  int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string Website { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }



    }
}
