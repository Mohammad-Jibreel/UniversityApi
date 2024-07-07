namespace UniversityApi.Models
{
    public class Major
    {
        public int MajorId { get; set; }  
        public int CollegeId { get; set; }  
        public string Name { get; set; }

        public College College { get; set; }
    }

}
