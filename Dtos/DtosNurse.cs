using Kidney.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kidney.Dtos
{
    public class DtosNurse
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NurseId { get; set; }
        public string Name { get; set; }
        public Gendar gender { get; set; }
        public int dialysisUnitId { get; set; }

    }
}
