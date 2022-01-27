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
    public class ClientsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ClientsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllClients([FromQuery] GetClientsRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }


        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddClient([FromBody] AddClientRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}
