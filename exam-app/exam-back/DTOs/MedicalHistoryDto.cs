using Newtonsoft.Json;

namespace exam_back.DTOs
{
    public class MedicalHistoryDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("visitTime")]
        public string VisitTime { get; set; }

        [JsonProperty("patientId")]
        public string PatientId { get; set; }
    }
}
