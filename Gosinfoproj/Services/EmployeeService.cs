using Gosinfoproj.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gosinfoproj.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeDataAccess; 
        public EmployeeService(IEmployeeRepository employeeDataAccess)
        {
            _employeeDataAccess = employeeDataAccess;
        }

        public async Task<Guid> CreateAsync(Employee employee)
        {
            return await _employeeDataAccess.CreateAsync(employee);
        }

        public async Task<Guid> DeleteAsync(Guid id)
        {
            var employees = await _employeeDataAccess.GetAsync(id, null);
            if (employees != null && employees.Count > 0)
            {
               return await _employeeDataAccess.DeleteAsync(employees[0]);
            }
            return id;
        }

        public async Task<List<Employee>> GetAsync(Guid? id, string name)
        {
            return await _employeeDataAccess.GetAsync(id, name);
        }

        public async Task<Employee> GetByIdAsync(Guid id)
        {
            var employees = await _employeeDataAccess.GetAsync(id, null);
            if (employees != null && employees.Count > 0)
            {
                return employees[0];
            }
            return null;
        }

        public async Task<Guid> UpdateAsync(Employee employee)
        {
            return await _employeeDataAccess.UpdateAsync(employee);
        }
    }
}
