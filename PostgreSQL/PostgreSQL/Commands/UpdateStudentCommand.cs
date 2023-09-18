using MediatR;

namespace PostgreSQL.Commands
{
    public class UpdateStudentCommand:IRequest<int>
    {
        public string student_id { get; set; } = Guid.NewGuid().ToString();
        public string name { get; set; }
        public string email { get; set; }
        public string student_address { get; set; }
        public UpdateStudentCommand(string student_Id, string Name, string Email, string student_Address)
        {
            student_id = student_Id;
            name = Name;
            email = Email;
            student_address = student_Address;
        }
    }
}
