using MediatR;

namespace PostgreSQL.Commands
{
    public class DeleteStudentCommand : IRequest<int>
    {
        public string student_id { get; set; }
    }
}
