using System.Text.Json.Serialization;

namespace UniversityApi.Models
{

    public class UserRole
    {

        public int UserRoleId { get; set; }
        public string RoleName { get; set; }

        [JsonIgnore]

        public ICollection<User> Users { get; set; }
    }



}
