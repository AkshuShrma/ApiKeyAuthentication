using MediatR;
using PostgreSQL.Models;

namespace PostgreSQL.Commands
{
    public class CreateStudentCommand:IRequest<Student>
    {
        public string name { get; set; }
        public string email { get; set; }
        public string student_address { get; set; }
        public CreateStudentCommand(string Name, string Email, string student_Address)
        {
            name = Name;
            email = Email;
            student_address = student_Address;
        }
    }
}
