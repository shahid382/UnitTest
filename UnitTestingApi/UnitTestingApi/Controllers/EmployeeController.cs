using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitTestingApi.Core.Interface;
using UnitTestingApi.Models;

namespace UnitTestingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IEmployee _context;
        public EmployeeController(IEmployee _context)
        {
            this._context = _context;
        }
        [HttpGet]
        public async Task<IActionResult> GetEmployee()
        {
            try
            {
                var result =_context.GetEmployee();
                log.Info("Data is Displayed");
                return StatusCode(200,result);
            }
            catch (Exception)
            {
                log.Error("Error occur");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Retrieving Data from the Database");
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeModel employeeModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _context.AddEmployee(employeeModel);
                    log.Error("Added Successfully");
                    return StatusCode(200, result);
                }
                else
                {
                    log.Error("No Data");
                    return BadRequest("No Data");
                }
            }
            catch (Exception)
            {
                log.Error("Error occur");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Adding Data to the Database");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateEmployee(EmployeeModel employeeModel)
        {
            try
            {
                var result = _context.UpdateEmployee(employeeModel);
                log.Error("Updated Successfully");
                return StatusCode(200, result);
            }
            catch (Exception)
            {
                log.Error("Error occur");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Updating Data to the Database");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                var result = _context.DeleteEmployee(id);
                log.Error("Deleted Successfully");
                return StatusCode(200, result);
            }
            catch (Exception)
            {
                log.Error("Error occur");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Updating Data to the Database");
            }
        }
    }
}
