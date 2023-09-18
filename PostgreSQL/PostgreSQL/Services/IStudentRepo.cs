using PostgreSQL.Models;

namespace PostgreSQL.Services
{
    public interface IStudentRepo
    {
        public Task<List<Student>> GetStudentListAsync();
        public Task<Student> GetStudentByIdAsync(string Id);
        public Task<Student> AddStudentAsync(Student studentDetails);
        public Task<int> UpdateStudentAsync(Student studentDetails);
        public Task<int> DeleteStudentAsync(string Id);
    }
}
