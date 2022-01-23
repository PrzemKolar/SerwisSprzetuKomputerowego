using MediatR;
using Serwis.ApplicationServices.API.Domain;
using Serwis.ApplicationServices.API.Domain.Models;
using Serwis.DataAccess;
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
        private readonly IRepository<DataAccess.Entities.Regulation> regulationRepository;

        public GetRegulationsHandler(IRepository<DataAccess.Entities.Regulation> regulationRepository)
        {
            this.regulationRepository = regulationRepository;
        }

        public Task<GetRegulationsResponse> Handle(GetRegulationsRequest request, CancellationToken cancellationToken)
        {
            var regulations = regulationRepository.GetAll();
            var domainRegulations = regulations.Select(x => new Domain.Models.Regulation()
            {
                Text = x.Text
            });

            var response = new GetRegulationsResponse() { Data = domainRegulations.ToList() };
            return Task.FromResult(response);
        }
    }
}
