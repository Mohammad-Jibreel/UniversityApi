namespace UniversityApi.Dto
{
    public class UserQualificationDTO
    {
        public int Id { get; set; }
        public string Degree { get; set; }
        public string Institution { get; set; }
        public DateTime GraduationDate { get; set; }
        public int UserProfileId { get; set; }
    }

}
