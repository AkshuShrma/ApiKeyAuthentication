using MediatR;
using PostgreSQL.Models;

namespace PostgreSQL.Queries
{
    public class GetStudentByIdQuery:IRequest<Student>
    {
        public string student_id { get; set; }
    }
}
