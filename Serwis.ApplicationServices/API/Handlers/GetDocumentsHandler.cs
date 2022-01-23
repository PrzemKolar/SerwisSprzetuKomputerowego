using MediatR;
using Serwis.ApplicationServices.API.Domain;
using Serwis.DataAccess;
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
        private readonly IRepository<DataAccess.Entities.Document> documentRepository;

        public GetDocumentsHandler(IRepository<DataAccess.Entities.Document> documentRepository)
        {
            this.documentRepository = documentRepository;
        }

        public Task<GetDocumentsResponse> Handle(GetDocumentsRequest request, CancellationToken cancellationToken)
        {
            var documents = documentRepository.GetAll();
            var domainDocuments = documents.Select(x => new Domain.Models.Document() 
            { 
                Order = x.Order 
            });

            var response = new GetDocumentsResponse()
            {
                Data = domainDocuments.ToList()
            };

            return Task.FromResult(response);
        }
    }
}
