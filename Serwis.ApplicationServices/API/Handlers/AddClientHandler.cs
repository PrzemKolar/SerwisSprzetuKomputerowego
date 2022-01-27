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
    public class AddClientHandler : IRequestHandler<AddClientRequest, AddClientResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public AddClientHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<AddClientResponse> Handle(AddClientRequest request, CancellationToken cancellationToken)
        {
            var client = this.mapper.Map<DataAccess.Entities.Client>(request);
            var command = new AddClientCommand() { Parameter = client };
            var clientFromDb = await this.commandExecutor.Execute(command);
            return new AddClientResponse() { Data = this.mapper.Map<Domain.Models.Client>(clientFromDb) };
        }
    }
}
