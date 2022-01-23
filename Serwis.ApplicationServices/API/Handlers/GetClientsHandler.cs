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

        public GetClientsHandler(IRepository<DataAccess.Entities.Client> clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        public Task<GetClientsResponse> Handle(GetClientsRequest request, CancellationToken cancellationToken)
        {
            var clients = this.clientRepository.GetAll();
            var domainClients = clients.Select(x => new Domain.Models.Client()
            {
                FirstName = x.FirstNaem,
                LastName = x.LastName,
                PhoneNumber = x.PhoneNumer
            });

            var response = new GetClientsResponse()
            {
                Data = domainClients.ToList()
            };

            return Task.FromResult(response);
        }
    }
}
