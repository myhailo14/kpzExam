using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Build.Framework;
using Newtonsoft.Json;

namespace exam_back.Models
{
    public class MedicalHistory
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public DateTime VisitTime { get; set; }


        [ForeignKey("Patient")]
        public Guid PatientId { get; set; }

        [JsonIgnore]
        public Patient Patient { get; set; }
    }
}
