using MediatR;
using PostgreSQL.Models;

namespace PostgreSQL.Queries
{
    public class GetStudentListQuery: IRequest<List<Student>>
    {

    }
}
