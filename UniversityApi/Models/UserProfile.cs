using System.Text.Json.Serialization;

namespace UniversityApi.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int UserId { get; set; }
        [JsonIgnore] // Prevents reference loop

        public User User { get; set; }
        [JsonIgnore] // Prevents reference loop


        public ICollection<UserQualification> UserQualifications { get; set; }
    }


}
