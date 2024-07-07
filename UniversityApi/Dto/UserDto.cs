namespace UniversityApi.Dto
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }
        public int RoleId { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public int UserRoleId { get; set; }



    }
}
