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
    public class GetClientsHandler : IRequestHandler<GetClientsRequest, GetClientsResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetClientsHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<GetClientsResponse> Handle(GetClientsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetClientsQuery();
            var clients = await this.queryExecutor.Execute(query);
            var mappedClients = this.mapper.Map<List<Domain.Models.Client>>(clients);

            var response = new GetClientsResponse()
            {
                Data = mappedClients
            };

            return response;
        }
    }
}
