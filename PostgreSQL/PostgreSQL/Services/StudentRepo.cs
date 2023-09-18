using Microsoft.EntityFrameworkCore;
using PostgreSQL.Data;
using PostgreSQL.Models;

namespace PostgreSQL.Services
{
    public class StudentRepo : IStudentRepo
    {
        private readonly DataContext _dbContext;

        public StudentRepo(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Student> AddStudentAsync(Student studentDetails)
        {
            var result = _dbContext.Students.Add(studentDetails);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> DeleteStudentAsync(string id)
        {
            var filteredData = _dbContext.Students.Where(x => x.student_id == id).FirstOrDefault();
            _dbContext.Students.Remove(filteredData);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<Student> GetStudentByIdAsync(string Id)
        {
            return await _dbContext.Students.Where(x => x.student_id == Id).FirstOrDefaultAsync();
        }

        public async Task<List<Student>> GetStudentListAsync()
        {
            return await _dbContext.Students.ToListAsync();
        }

        public async Task<int> UpdateStudentAsync(Student studentDetails)
        {
            _dbContext.Students.Update(studentDetails);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
