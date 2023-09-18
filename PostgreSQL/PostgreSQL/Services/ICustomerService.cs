using PostgreSQL.Models;

namespace PostgreSQL.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(int id);
        Task<bool> CreateAsync(Customer model);
        Task<bool> UpdateAsync(Customer model);
        Task<bool> DeleteAsync(Customer model);
        Task<bool> CustomerExists(string name);
    }
}
