using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serwis.ApplicationServices.API.Domain;
using Serwis.ApplicationServices.API.Domain.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Serwis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrdersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllOrders([FromQuery] GetOrdersRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpGet]
        [Route("ForEmployee")]
        public async Task<IActionResult> GetOrdersForEmployee([FromQuery] GetOrdersForEmployeeRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpGet]
        [Route("Filters")]
        public async Task<IActionResult> GetOrdersByFilters([FromQuery] GetOrdersByFiltersRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddOrder([FromBody] AddOrderRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> EditOrder([FromBody] EditOrderRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}
