using AutoMapper;
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
        private readonly IMapper mapper;

        public GetDocumentsHandler(IRepository<DataAccess.Entities.Document> documentRepository, IMapper mapper)
        {
            this.documentRepository = documentRepository;
            this.mapper = mapper;
        }

        public async Task<GetDocumentsResponse> Handle(GetDocumentsRequest request, CancellationToken cancellationToken)
        {
            var documents = await documentRepository.GetAll();
            var mappedDocuments = this.mapper.Map<List<Domain.Models.Document>>(documents);

            var response = new GetDocumentsResponse()
            {
                Data = mappedDocuments
            };

            return response;
        }
    }
}
