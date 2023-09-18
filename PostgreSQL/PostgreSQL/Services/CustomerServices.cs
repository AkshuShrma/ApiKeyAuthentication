using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using PostgreSQL.Data;
using PostgreSQL.Models;

namespace PostgreSQL.Services
{
    public class CustomerServices : ICustomerService
    {
        private readonly DataContext _context;

        public CustomerServices(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(Customer model)
        {
            if (model == null) return false;
            await _context.Customers.AddAsync(model);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CustomerExists(string name)
        {
            return await _context.Customers.AnyAsync(x => x.FirstName == name);
        }

        public async Task<bool> DeleteAsync(Customer model)
        {
            if (model == null) return false;
            _context.Customers.Remove(model);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            var emp = await _context.Customers.ToListAsync();
            return emp;
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            return customer;
        }

        public async Task<bool> UpdateAsync(Customer model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            _context.Customers.Update(model);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
