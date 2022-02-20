using AutoMapper;
using MediatR;
using Serwis.ApplicationServices.API.Domain.Models;
using Serwis.ApplicationServices.API.Domain.Order;
using Serwis.DataAccess;
using Serwis.DataAccess.CQRS;
using Serwis.DataAccess.CQRS.Commands;
using Serwis.DataAccess.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Serwis.ApplicationServices.API.Handlers
{
    public class AddOrderHandler : IRequestHandler<AddOrderRequest, AddOrderResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public AddOrderHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<AddOrderResponse> Handle(AddOrderRequest request, CancellationToken cancellationToken)
        {
            var query = new GetClientQuery() { Id = request.ClientId };
            var clientFromDb = await this.queryExecutor.Execute(query);

            var order = mapper.Map<DataAccess.Entities.Order>(request);
            order.Client = clientFromDb;

            var command = new AddOrderCommand() { Parameter = order };
            var orderFromDb = await this.commandExecutor.Execute(command);
            return new AddOrderResponse() { Data = this.mapper.Map<Order>(orderFromDb) };
        }
    }
}
