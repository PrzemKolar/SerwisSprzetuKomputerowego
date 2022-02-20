using AutoMapper;
using MediatR;
using Serwis.ApplicationServices.API.Domain.OrderHistory;
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
    public class AddOrderHistoryHandler : IRequestHandler<AddOrderHistoryRequest, AddOrderHistoryResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public AddOrderHistoryHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<AddOrderHistoryResponse> Handle(AddOrderHistoryRequest request, CancellationToken cancellationToken)
        {
            var query = new GetOrderQuery() { Id = request.OrderId };
            var orderFromDb = await queryExecutor.Execute(query);

            var orderHistory = mapper.Map<DataAccess.Entities.OrderHistory>(request);
            orderHistory.Order = orderFromDb;

            var command = new AddOrderHistoryCommand() { Parameter = orderHistory };
            var orderHistoryFromDb = await this.commandExecutor.Execute(command);
            return new AddOrderHistoryResponse() { Data = this.mapper.Map<Domain.Models.OrderHistory>(orderHistoryFromDb) };
        }
    }
}
