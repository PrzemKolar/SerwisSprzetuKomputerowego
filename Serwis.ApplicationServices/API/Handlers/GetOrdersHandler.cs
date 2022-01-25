using AutoMapper;
using MediatR;
using Serwis.ApplicationServices.API.Domain;
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
    public class GetOrdersHandler : IRequestHandler<GetOrdersRequest, GetOrdersResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetOrdersHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<GetOrdersResponse> Handle(GetOrdersRequest request, CancellationToken cancellationToken)
        {
            var query = new GetOrdersQuery();
            var orders = await this.queryExecutor.Execute(query);
            var mapperdOrders = this.mapper.Map<List<Domain.Models.Order>>(orders);
            

            var response = new GetOrdersResponse()
            {
                Data = mapperdOrders
            };

            return response;
        }
    }
}
