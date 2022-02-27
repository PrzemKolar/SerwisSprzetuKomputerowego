using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serwis.ApplicationServices.API.Domain.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Serwis.Controllers
{
    public class ReportsController : ApiControllerBase
    {
        public ReportsController(IMediator mediator) : base(mediator)
        {

        }

        [HttpGet]
        [Route("Repaired")]
        public Task<IActionResult> GetRepairedOrders([FromQuery] GetRepairedOrdersRequest request)
        {
            return HandleRequest<GetRepairedOrdersRequest, GetRepairedOrdersResponse>(request);
        }

        [HttpGet]
        [Route("Resigned")]
        public Task<IActionResult> GetResignedOrders([FromQuery] GetResignedOrdersRequest request)
        {
            return HandleRequest<GetResignedOrdersRequest, GetResignedOrdersResponse>(request);
        }
        
        [HttpGet]
        [Route("Delayed")]
        public Task<IActionResult> GetDelayedOrders([FromQuery] GetDelayedOrdersRequest request)
        {
            return HandleRequest<GetDelayedOrdersRequest, GetDelayedOrdersResponse>(request);
        }


    }
}
