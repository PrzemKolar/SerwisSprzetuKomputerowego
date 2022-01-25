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
    public class GetDocumentsHandler : IRequestHandler<GetDocumentsRequest, GetDocumentsResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetDocumentsHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<GetDocumentsResponse> Handle(GetDocumentsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetDocumentsQuery();
            var documents = await this.queryExecutor.Execute(query);
            var mappedDocuments = this.mapper.Map<List<Domain.Models.Document>>(documents);

            var response = new GetDocumentsResponse()
            {
                Data = mappedDocuments
            };

            return response;
        }
    }
}
