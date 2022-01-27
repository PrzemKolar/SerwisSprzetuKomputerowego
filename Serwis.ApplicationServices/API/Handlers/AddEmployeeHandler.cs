using AutoMapper;
using MediatR;
using Serwis.ApplicationServices.API.Domain;
using Serwis.DataAccess.CQRS;
using Serwis.DataAccess.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Serwis.ApplicationServices.API.Handlers
{
    public class AddEmployeeHandler : IRequestHandler<AddEmployeeRequest, AddEmployeeResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public AddEmployeeHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<AddEmployeeResponse> Handle(AddEmployeeRequest request, CancellationToken cancellationToken)
        {
            var employee = this.mapper.Map<DataAccess.Entities.Employee>(request);
            var command = new AddEmployeeCommand() { Parameter = employee };
            var employeeFromDb = await this.commandExecutor.Execute(command);
            return new AddEmployeeResponse()
            {
                Data = this.mapper.Map<Domain.Models.Employee>(employeeFromDb)
            };
        }
    }
}
