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
    class EditEmployeeHandler : IRequestHandler<EditEmployeeRequest, EditEmployeeResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public EditEmployeeHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<EditEmployeeResponse> Handle(EditEmployeeRequest request, CancellationToken cancellationToken)
        {
            var employee = this.mapper.Map<DataAccess.Entities.Employee>(request);
            var command = new EditEmployeeCommand() { Parameter = employee };
            var employeeFromDb = await this.commandExecutor.Execute(command);
            return new EditEmployeeResponse() { Data = this.mapper.Map<Domain.Models.Employee>(employeeFromDb) };
        }
    }
}
