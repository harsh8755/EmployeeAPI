using DatabaseProject.DatabaseContext;
using DatabaseProject.Interfaces;
using DatabaseProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.Repositories
{
    public class EmployeeRepository :IEmployeeRepository
    {
        private readonly SqlServerContext _SqlServerContext;

        public EmployeeRepository(SqlServerContext sqlServerContext)
        {
            _SqlServerContext = sqlServerContext;
        }

        public List<Employee> GetEmployees()
        {
            var lstEmployee = _SqlServerContext.employee.ToList();
            return lstEmployee;
        }
        public Employee GetEmployeeById(int id)
        {
            var employee = _SqlServerContext.employee.FirstOrDefault(x=>x.EmployeeId == id);
            return employee;
        }
        public Employee AddEmployee(Employee employee)
        {
            _SqlServerContext.employee.Add(employee);
            _SqlServerContext.SaveChanges();
            return employee;
        }

        public Employee DeleteEmployee(int id)
        {
            var deleteEmployee = _SqlServerContext.employee.Find(id);
            if (deleteEmployee != null)
            {
            _SqlServerContext.employee.Remove(deleteEmployee);
            _SqlServerContext.SaveChanges();
            }
            return deleteEmployee;
        }
        public Employee UpdateEmployee(int Id,Employee updatedEmployee)
        {
            var existingEmployee = _SqlServerContext.employee.FirstOrDefault(x => x.EmployeeId == Id);
            if (existingEmployee != null)
            {
                // Update properties
                existingEmployee.EmployeeName = updatedEmployee.EmployeeName;
                existingEmployee.City = updatedEmployee.City;
                existingEmployee.Salary = updatedEmployee.Salary;

                _SqlServerContext.SaveChanges();
            }
            return existingEmployee;
        }

    }

}

