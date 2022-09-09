using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;
using UnitTestingApi.Controllers;
using UnitTestingApi.Core.Interface;
using UnitTestingApi.Models;

namespace EmployeeTest
{
    [TestClass]
    public class EmployeeControllerTest
    {
        private Mock<IEmployee> _employeeRepoMock;
        private Fixture _fixture;
        private EmployeeController _controller;
        public EmployeeControllerTest()
        {
            _fixture = new Fixture();
            _employeeRepoMock = new Mock<IEmployee>();
        }
        [TestMethod]
        public async Task GetEmployeeReturnOk()
        {
            var employeeList = _fixture.CreateMany<EmployeeModel>(3).ToList();
            _employeeRepoMock.Setup(repo => repo.GetEmployee()).Returns(employeeList);
            _controller = new EmployeeController(_employeeRepoMock.Object);
            var result = await _controller.GetEmployee();
            var obj = result as ObjectResult;
            Assert.AreEqual(200, obj.StatusCode);
        }
        [TestMethod]
        public async Task GetEmployeeThrowException()
        {
            _employeeRepoMock.Setup(repo => repo.GetEmployee()).Throws(new Exception());
            _controller = new EmployeeController(_employeeRepoMock.Object);
            var result = await _controller.GetEmployee();
            var obj = result as ObjectResult;
            Assert.AreEqual(500, obj.StatusCode);
        }
        [TestMethod]
        public async Task AddEmployeeReturnOk()
        {
            var employee = _fixture.Create<EmployeeModel>();
            _employeeRepoMock.Setup(repo => repo.AddEmployee(It.IsAny<EmployeeModel>())).Returns(employee);
            _controller = new EmployeeController(_employeeRepoMock.Object);
            var result = await _controller.AddEmployee(employee);
            var obj = result as ObjectResult;
            Assert.AreEqual(200, obj.StatusCode);
        }
        [TestMethod]
        public async Task UpdateEmployeeReturnOk()
        {
            var employee = _fixture.Create<EmployeeModel>();
            _employeeRepoMock.Setup(repo => repo.UpdateEmployee(It.IsAny<EmployeeModel>())).Returns(employee);
            _controller = new EmployeeController(_employeeRepoMock.Object);
            var result = await _controller.UpdateEmployee(employee );
            var obj = result as ObjectResult;
            Assert.AreEqual(200, obj.StatusCode);
        }
        [TestMethod]
        public async Task DeleteEmployeeReturnOk()
        {
            _employeeRepoMock.Setup(repo => repo.DeleteEmployee(It.IsAny<int>()));
            _controller = new EmployeeController(_employeeRepoMock.Object);
            var result = await _controller.DeleteEmployee(It.IsAny<int>());
            var obj = result as ObjectResult;
            Assert.AreEqual(200, obj.StatusCode);
        }
    }
}
