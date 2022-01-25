using AutoMapper;
using MediatR;
using Serwis.ApplicationServices.API.Domain;
using Serwis.DataAccess;
using Serwis.DataAccess.CQRS.Queries;
using Serwis.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Serwis.ApplicationServices.API.Handlers
{
    public class GetProfitsHandler : IRequestHandler<GetProfitsRequest, GetProfitsResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetProfitsHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<GetProfitsResponse> Handle(GetProfitsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetProfitsQuery();
            var profits = await this.queryExecutor.Execute(query);
            var mappedProfits = this.mapper.Map<List<Domain.Models.Profit>>(profits);

            var response = new GetProfitsResponse() { Data = mappedProfits };

            return response;
        }
    }
}
