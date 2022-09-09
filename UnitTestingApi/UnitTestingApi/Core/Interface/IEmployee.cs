using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitTestingApi.Models;

namespace UnitTestingApi.Core.Interface
{
    public interface IEmployee
    {
        List<EmployeeModel> GetEmployee();
        EmployeeModel AddEmployee(EmployeeModel employeeModel);
        EmployeeModel UpdateEmployee(EmployeeModel employeeModel);
        bool DeleteEmployee(int employeeId);
    }
}
