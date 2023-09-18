using System.ComponentModel.DataAnnotations;

namespace PostgreSQL.Models
{
    public class Student
    {
        [Key]
        public string student_id { get; set; }=Guid.NewGuid().ToString();
        public string name { get; set; }
        public string email { get; set; }
        public string student_address { get; set; }
    }
}
