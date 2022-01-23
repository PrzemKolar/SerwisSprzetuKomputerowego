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
    public class GetOrderHistoriesHandler : IRequestHandler<GetOrderHistoriesRequest, GetOrderHistoriesResponse>
    {
        private readonly IRepository<DataAccess.Entities.OrderHistory> orderHistoryRepository;

        public GetOrderHistoriesHandler(IRepository<DataAccess.Entities.OrderHistory> orderHistoryRepository)
        {
            this.orderHistoryRepository = orderHistoryRepository;
        }

        public Task<GetOrderHistoriesResponse> Handle(GetOrderHistoriesRequest request, CancellationToken cancellationToken)
        {
            var orderHistories = orderHistoryRepository.GetAll();

            var domainOrderHistories = orderHistories.Select(x => new Domain.Models.OrderHistory()
            {
                Description = x.Description,
                Title = x.Title
            });

            var response = new GetOrderHistoriesResponse() 
            { 
                Data = domainOrderHistories.ToList() 
            };

            return Task.FromResult(response);
        }
    }
}
