using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gosinfoproj.Models
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAsync(Guid? id, string name);
        Task<Employee> GetByIdAsync(Guid id);
        Task<Guid> CreateAsync(Employee employee);
        Task<Guid> UpdateAsync(Employee employee);
        Task<Guid> DeleteAsync(Guid id);
    }
}
