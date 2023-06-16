using Newtonsoft.Json;

namespace Kidney.Models
{
    public class ReportFiles
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual Report Reports { get; set; }
    }
}
