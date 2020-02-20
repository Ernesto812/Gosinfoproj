using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gosinfoproj.Models
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAsync(Guid? id, string name);
        Task<Guid> CreateAsync(Employee employee);
        Task<Guid> UpdateAsync(Employee employee);
        Task<Guid> DeleteAsync(Employee employee);
    }
}
