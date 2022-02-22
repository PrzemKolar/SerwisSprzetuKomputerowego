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
    public class GetOrdersForEmployeeHandler : IRequestHandler<GetOrdersForEmployeeRequest, GetOrdersForEmployeeResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetOrdersForEmployeeHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetOrdersForEmployeeResponse> Handle(GetOrdersForEmployeeRequest request, CancellationToken cancellationToken)
        {
            var query = new GetOrdersForEmployeeQuery() { Id = request.IdEmployee };
            var orders = await this.queryExecutor.Execute(query);

            return new GetOrdersForEmployeeResponse() { Data = this.mapper.Map<List<Domain.Models.Order>>(orders).ToList() };
        }
    }
}
