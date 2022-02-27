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
    public class GetRepairedOrdersHandler : IRequestHandler<GetRepairedOrdersRequest, GetRepairedOrdersResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetRepairedOrdersHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetRepairedOrdersResponse> Handle(GetRepairedOrdersRequest request, CancellationToken cancellationToken)
        {
            var query = new GetRepairedOrdersQuery() { statusEnum = DataAccess.Entities.Order.StatusEnum.Repaired };
            var ordersFromDb = await this.queryExecutor.Execute(query);

            return new GetRepairedOrdersResponse() { Data = this.mapper.Map<List<Domain.Models.Order>>(ordersFromDb).ToList()};
        }
    }
}
