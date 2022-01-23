using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serwis.ApplicationServices.API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Serwis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfitsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProfitsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllProfits([FromQuery] GetProfitsRequest request)
        {
            var response = await mediator.Send(request);
            return this.Ok(response);
        }
    }
}
