using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitTestingApi.Core.Interface;
using UnitTestingApi.DataAccess;
using UnitTestingApi.Models;

namespace UnitTestingApi.Core.Repository
{
    public class Employee : IEmployee
    {
        private readonly EmployeeDbContext _context;
        public Employee(EmployeeDbContext _context)
        {
            this._context = _context;
        }
        public List<EmployeeModel> GetEmployee()
        {
            try
            {
                var result = _context.employeeModel.ToList();
                return result;
            }
            catch (Exception ex) { throw ex; }
        }
        public EmployeeModel AddEmployee(EmployeeModel employeeModel)
        {
            try
            {
                _context.employeeModel.AddAsync(employeeModel);
                _context.SaveChangesAsync();
                return employeeModel;
            }
            catch (Exception ex) { throw ex; }
        }
        public EmployeeModel UpdateEmployee(EmployeeModel employeeModel)
        {
            try
            {
                var result = _context.employeeModel.FirstOrDefault(x => x.Id == employeeModel.Id);
                if (result != null)
                {
                    result.Name = employeeModel.Name;
                    result.Age = employeeModel.Age;
                    _context.SaveChangesAsync();
                    return result;
                }
                return null;
            }
            catch (Exception ex) { throw ex; }
        }
        public bool DeleteEmployee(int employeeId)
        {
            try
            {
                var result =_context.employeeModel.FirstOrDefault(x => x.Id == employeeId);
                if (result != null)
                {
                    _context.employeeModel.Remove(result);
                    _context.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
