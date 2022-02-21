using AutoMapper;
using MediatR;
using Serwis.ApplicationServices.API.Domain.Order;
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
    public class EditOrderHandler : IRequestHandler<EditOrderRequest, EditOrderResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public EditOrderHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<EditOrderResponse> Handle(EditOrderRequest request, CancellationToken cancellationToken)
        {
            var order = this.mapper.Map<DataAccess.Entities.Order>(request);
            var command = new EditOrderCommand() { Parameter = order };
            var orderFromDb = await this.commandExecutor.Execute(command);
            return new EditOrderResponse() { Data = this.mapper.Map<Domain.Models.Order>(orderFromDb) };
        }
    }
}
