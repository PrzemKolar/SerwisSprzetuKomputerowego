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

        public GetProfitsHandler(IRepository<DataAccess.Entities.Profit> profitRepository)
        {
            this.profitrepository = profitRepository;
        }

        public Task<GetProfitsResponse> Handle(GetProfitsRequest request, CancellationToken cancellationToken)
        {
            var profits = profitrepository.GetAll();
            var domainProfits = profits.Select(x => new Domain.Models.Profit()
            {
                Amount = x.Amount
            });

            var response = new GetProfitsResponse() { Data = domainProfits.ToList() };

            return Task.FromResult(response);
        }
    }
}
