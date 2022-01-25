using AutoMapper;
using MediatR;
using Serwis.ApplicationServices.API.Domain;
using Serwis.ApplicationServices.API.Domain.Models;
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
    public class GetRegulationsHandler : IRequestHandler<GetRegulationsRequest, GetRegulationsResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetRegulationsHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<GetRegulationsResponse> Handle(GetRegulationsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetRegulationsQuery();
            var regulations = await this.queryExecutor.Execute(query);
            var mappedRegulations = this.mapper.Map<List<Domain.Models.Regulation>>(regulations);

            var response = new GetRegulationsResponse() { Data = mappedRegulations };
            return response;
        }
    }
}
