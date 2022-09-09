using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitTestingApi.Models;

namespace UnitTestingApi.DataAccess
{
    public class EmployeeDbContext:DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {

        }
        public DbSet<EmployeeModel> employeeModel { get; set; }
    }
}
