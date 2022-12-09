
using Newtonsoft.Json;

namespace exam_back.DTOs
{
    public class PatientDto
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("surname")]
        public string? Surname { get; set; }

        [JsonProperty("birthday")]
        public DateTime? Birthday { get; set; }
    }
}
