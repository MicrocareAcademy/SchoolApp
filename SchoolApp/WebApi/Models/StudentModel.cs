namespace SchoolApp.WebApi.Models
{
    public class StudentModel
    {
        public string student_name { get; set; }
        public int class_id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public List<int> subject { get; set; }
    }
}
