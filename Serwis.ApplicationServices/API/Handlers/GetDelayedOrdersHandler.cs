using AutoMapper;
using MediatR;
using Serwis.ApplicationServices.API.Domain.Reports;
using Serwis.DataAccess;
using Serwis.DataAccess.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Serwis.ApplicationServices.API.Handlers
{
    public class GetDelayedOrdersHandler : IRequestHandler<GetDelayedOrdersRequest, GetDelayedOrdersResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetDelayedOrdersHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<GetDelayedOrdersResponse> Handle(GetDelayedOrdersRequest request, CancellationToken cancellationToken)
        {
            var query = new GetDelayedOrdersQuery();
            var ordersFromDb = await this.queryExecutor.Execute(query);

            return new GetDelayedOrdersResponse() { Data = this.mapper.Map<List<Domain.Models.Order>>(ordersFromDb).ToList() };
        }
    }
}
