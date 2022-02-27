using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serwis.ApplicationServices.API.Domain;
using Serwis.DataAccess.CQRS.Queries;

namespace Serwis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ApiControllerBase
    {
        public EmployeesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllEmployees([FromQuery] GetEmployeesRequest request)
        {
            return HandleRequest<GetEmployeesRequest, GetEmployeesResponse>(request);
        }

        [HttpGet]
        [Route("{employeeId}")]
        public Task<IActionResult> GetAllEmployeeById([FromRoute] int employeeId)
        {
            var request = new GetEmployeeByIdRequest()
            {
                EmployeeId = employeeId
            };
            return HandleRequest<GetEmployeeByIdRequest, GetEmployeeByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddEmployee([FromBody] AddEmployeeRequest request)
        {
            return this.HandleRequest<AddEmployeeRequest, AddEmployeeResponse>(request);
        }

        [HttpPut]
        [Route("")]
        public Task<IActionResult> EditEmployee([FromBody] EditEmployeeRequest request)
        {
            return this.HandleRequest<EditEmployeeRequest, EditEmployeeResponse>(request);
        }
    }
}
