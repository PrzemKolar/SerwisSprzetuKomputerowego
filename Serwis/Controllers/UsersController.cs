using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serwis.ApplicationServices.API.Domain;
using Serwis.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Serwis.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ApiControllerBase
    {
        HashPasswordGenerator HashPasswordGenerator = new HashPasswordGenerator();

        public UsersController(IMediator mediator) : base(mediator)
        {
            
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetUsers ([FromQuery] GetUsersRequest request)
        {
            return this.HandleRequest<GetUsersRequest, GetUsersResponse>(request);
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddUser([FromBody] AddUserRequest request)
        {
            var hashedPassword = HashPasswordGenerator.GetHashPassword(request.Password);
            request.Password = hashedPassword;
            return this.HandleRequest<AddUserRequest, AddUserResponse>(request);
        }
    }
}
