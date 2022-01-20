using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serwis.DataAccess;
using Serwis.DataAccess.Entities;

namespace Serwis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IRepository<Employee> employeeRepository;

        public EmployeeController(IRepository<Employee> employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Employee> GetAllEmployees() => this.employeeRepository.GetAll();

        [HttpGet]
        [Route("{employeeId}")]
        public Employee GetEmployeesById(int employeeId) => this.employeeRepository.GetById(employeeId);
    }
}
