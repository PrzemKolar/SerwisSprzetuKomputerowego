using AutoMapper;
using MediatR;
using Serwis.ApplicationServices.API.Domain;
using Serwis.DataAccess;
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
        private readonly IRepository<DataAccess.Entities.Client> clientRepository;
        private readonly IMapper mapper;

        public GetClientsHandler(IRepository<DataAccess.Entities.Client> clientRepository, IMapper mapper)
        {
            this.clientRepository = clientRepository;
            this.mapper = mapper;
        }

        public async Task<GetClientsResponse> Handle(GetClientsRequest request, CancellationToken cancellationToken)
        {
            var clients = await this.clientRepository.GetAll();
            var mappedClients = this.mapper.Map<List<Domain.Models.Client>>(clients);

            var response = new GetClientsResponse()
            {
                Data = mappedClients
            };

            return response;
        }
    }
}
