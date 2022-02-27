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
    public class GetResignedOrdersHandler : IRequestHandler<GetResignedOrdersRequest, GetResignedOrdersResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetResignedOrdersHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<GetResignedOrdersResponse> Handle(GetResignedOrdersRequest request, CancellationToken cancellationToken)
        {
            var query = new GetResignedOrdersQuery() { statusEnum = DataAccess.Entities.Order.StatusEnum.Resigned };
            var ordersFromDb = await this.queryExecutor.Execute(query);

            return new GetResignedOrdersResponse() { Data = this.mapper.Map<List<Domain.Models.Order>>(ordersFromDb).ToList() };
        }
    }
}
