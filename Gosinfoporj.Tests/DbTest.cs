using Gosinfoproj.Models;
using Gosinfoproj.Repositories;
using Gosinfoproj.Repositories.Configuration;
using Gosinfoproj.Services;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace Gosinfoporj.Tests
{
    public class DbTest
    {
        private readonly Guid Id = new Guid("83fe0506-03d0-44e6-a997-23f8cf41a985");

        [Fact]
        public void Test()
        {
            var options = new DbContextOptionsBuilder<PgDbContext>()
               .UseInMemoryDatabase(databaseName: "Integration_Test_database")
               .Options;

            // Adding predefined instances
            using (var context = new PgDbContext(options))
            {
                context.Employees.Add(new Employee() { Id = Id, Name = "Name", Info = "Info" });
                context.SaveChanges();
            }

            using (var context = new PgDbContext(options))
            {
                var employeeRepo = new EmployeeRepository(context);
                var employeeService = new EmployeeService(employeeRepo);

                // checking predefined instance by Get single method
                var employee = employeeService.GetByIdAsync(Id).Result;
                Assert.NotNull(employee);

                // creating new employee
                var newEmployee = new Employee() { Name = "New", Info = "New" };
                var creationResult = employeeService.CreateAsync(newEmployee).Result;

                // checking get all method
                var getAllResult = employeeService.GetAsync(null, null).Result;
                Assert.Equal(2, getAllResult.Count);

                // checking update
                employee.Info = "Updated";
                employeeService.UpdateAsync(employee);
                var updatedEntity = employeeService.GetByIdAsync(Id).Result;
                Assert.Equal("Updated", updatedEntity.Info);
            }

            using (var context = new PgDbContext(options))
            {
                var employeeRepo = new EmployeeRepository(context);
                var employeeService = new EmployeeService(employeeRepo);

                // checking get all method
                var getAllResult = employeeService.GetAsync(null, null).Result;
                Assert.Equal(2, getAllResult.Count);

                // checking update
                var employee = employeeService.GetByIdAsync(Id).Result;
                employee.Info = "Updated";
                employeeService.UpdateAsync(employee);
                var updatedEntity = employeeService.GetByIdAsync(Id).Result;
                Assert.Equal("Updated", updatedEntity.Info);

            }


                // checking removal
                using (var context = new PgDbContext(options))
            {
                var employeeRepo = new EmployeeRepository(context);
                var employeeService = new EmployeeService(employeeRepo);

                var dr = employeeService.DeleteAsync(Id).Result;
                var deleteResult = employeeService.GetAsync(null, null).Result;
                Assert.Single(deleteResult);
            }
        }
    }
}
