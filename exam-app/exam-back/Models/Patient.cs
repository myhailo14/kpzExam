using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace exam_back.Models
{
    public class Patient
    {
        
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        public DateTime? Birthday { get; set; }

        [JsonIgnore]
        public List<MedicalHistory> History { get; set; }

    }
}
