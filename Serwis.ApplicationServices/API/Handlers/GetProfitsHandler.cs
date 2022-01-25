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
    public class GetProfitsHandler : IRequestHandler<GetProfitsRequest, GetProfitsResponse>
    {
        private readonly IRepository<Profit> profitrepository;
        private readonly IMapper mapper;

        public GetProfitsHandler(IRepository<DataAccess.Entities.Profit> profitRepository, IMapper mapper)
        {
            this.profitrepository = profitRepository;
            this.mapper = mapper;
        }

        public async Task<GetProfitsResponse> Handle(GetProfitsRequest request, CancellationToken cancellationToken)
        {
            var profits = await profitrepository.GetAll();
            var mappedProfits = this.mapper.Map<List<Domain.Models.Profit>>(profits);

            var response = new GetProfitsResponse() { Data = mappedProfits };

            return response;
        }
    }
}
