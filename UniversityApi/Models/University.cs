using System.Text.Json.Serialization;

namespace UniversityApi.Models
{
    public class University
    {
        public int UniversityId { get; set; }  
        public string Name { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        [JsonIgnore]
        public ICollection<College> Colleges { get; set; }
        [JsonIgnore]

        public ICollection<UserQualification> UserQualifications { get; set; }
    }

}
