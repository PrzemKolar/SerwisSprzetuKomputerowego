using AutoMapper;
using MediatR;
using Serwis.ApplicationServices.API.Domain.Order;
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
    public class GetOrdersByFiltersHandler : IRequestHandler<GetOrdersByFiltersRequest, GetOrdersByFiltersResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetOrdersByFiltersHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetOrdersByFiltersResponse> Handle(GetOrdersByFiltersRequest request, CancellationToken cancellationToken)
        {
            //find for id
            if(request.Id != default)
            {
                var queryId = new GetOrderQuery() { Id = request.Id };
                var order = await this.queryExecutor.Execute(queryId);
                List<Domain.Models.Order> list = new List<Domain.Models.Order>();
                    list.Add(this.mapper.Map<Domain.Models.Order>(order));
                return new GetOrdersByFiltersResponse() { Data = list };
            }
            
            var query = this.mapper.Map<GetOrdersByFiltersQuery>(request);
            var orders = await this.queryExecutor.Execute(query);

            return new GetOrdersByFiltersResponse() { Data = this.mapper.Map<List<Domain.Models.Order>>(orders).ToList() };
        }
    }
}
