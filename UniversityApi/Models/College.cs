using System.Text.Json.Serialization;

namespace UniversityApi.Models
{
    public class College
    {
        public int CollegeId { get; set; } 
        public int UniversityId { get; set; }  
        public string Name { get; set; }
        public string Description { get; set; }

        [JsonIgnore]

        public University University { get; set; }
        [JsonIgnore]

        public ICollection<Major> Majors { get; set; }
    }

}
