using Gosinfoproj.Models;
using Gosinfoproj.Repositories.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gosinfoproj.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly PgDbContext _context;
        public EmployeeRepository(PgDbContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetAsync(Guid? id, string name)
        {
            IQueryable<Employee> query = _context.Employees.AsNoTracking();
            if (id.HasValue)
            {
                query = query.Where(x => x.Id == id);
            }
            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(name.ToLower()));
            }

            var employees = await query.ToListAsync();
            return employees;
        }

        public async Task<Guid> CreateAsync(Employee employee)
        {
            var result = _context.Add(employee);
            await _context.SaveChangesAsync();
            return result.Entity.Id;
        }

        public async Task<Guid> UpdateAsync(Employee employee)
        {
            var result = _context.Update(employee);
            await _context.SaveChangesAsync();
            return result.Entity.Id;
        }

        public async Task<Guid> DeleteAsync(Employee employee)
        {
            var result = _context.Remove(employee);
            await _context.SaveChangesAsync();
            return result.Entity.Id;
        }
    }
}
