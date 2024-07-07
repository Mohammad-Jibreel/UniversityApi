using System.Text.Json.Serialization;

namespace UniversityApi.Models
{
    public class UserQualification
    {
  
            public int Id { get; set; }
            public string Degree { get; set; }
            public string Institution { get; set; }
            public DateTime GraduationDate { get; set; }
            public int UserProfileId { get; set; }
        [JsonIgnore] // Prevents reference loop

        public UserProfile UserProfile { get; set; }
   

        //public University University { get; set; }
    }

}
