using System.Text.Json.Serialization;

namespace UniversityApi.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }
        public int RoleId { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }

        public int UserRoleId { get; set; }
        [JsonIgnore]
        public UserRole UserRole { get; set; }
        [JsonIgnore]

        public UserProfile UserProfile { get; set; }
        [JsonIgnore] // Prevents JSON cycle
        public ICollection<Payment> Payments { get; set; }

        // Navigation property

        //public ICollection<UserQualification> UserQualifications { get; set; }
    }

}
