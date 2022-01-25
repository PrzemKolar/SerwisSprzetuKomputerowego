using AutoMapper;
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
        private readonly IMapper mapper;

        public GetRegulationsHandler(IRepository<DataAccess.Entities.Regulation> regulationRepository, IMapper mapper)
        {
            this.regulationRepository = regulationRepository;
            this.mapper = mapper;
        }

        public async Task<GetRegulationsResponse> Handle(GetRegulationsRequest request, CancellationToken cancellationToken)
        {
            var regulations = await regulationRepository.GetAll();
            var mappedRegulations = this.mapper.Map<List<Domain.Models.Regulation>>(regulations);

            var response = new GetRegulationsResponse() { Data = mappedRegulations };
            return response;
        }
    }
}
