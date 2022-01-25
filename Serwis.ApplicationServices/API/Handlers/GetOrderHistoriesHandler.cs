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
    public class GetOrderHistoriesHandler : IRequestHandler<GetOrderHistoriesRequest, GetOrderHistoriesResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetOrderHistoriesHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<GetOrderHistoriesResponse> Handle(GetOrderHistoriesRequest request, CancellationToken cancellationToken)
        {
            var query = new GetOrderHistoriesQuery();
            var orderHistories = await this.queryExecutor.Execute(query);
            var mappedOrderHistories = this.mapper.Map<List<Domain.Models.OrderHistory>>(orderHistories);
            

            var response = new GetOrderHistoriesResponse() 
            { 
                Data = mappedOrderHistories
            };

            return response;
        }
    }
}
