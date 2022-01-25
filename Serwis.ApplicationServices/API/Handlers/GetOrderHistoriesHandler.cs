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
    public class GetOrderHistoriesHandler : IRequestHandler<GetOrderHistoriesRequest, GetOrderHistoriesResponse>
    {
        private readonly IRepository<DataAccess.Entities.OrderHistory> orderHistoryRepository;
        private readonly IMapper mapper;

        public GetOrderHistoriesHandler(IRepository<DataAccess.Entities.OrderHistory> orderHistoryRepository, IMapper mapper)
        {
            this.orderHistoryRepository = orderHistoryRepository;
            this.mapper = mapper;
        }

        public async Task<GetOrderHistoriesResponse> Handle(GetOrderHistoriesRequest request, CancellationToken cancellationToken)
        {
            var orderHistories = await orderHistoryRepository.GetAll();
            var mappedOrderHistories = this.mapper.Map<List<Domain.Models.OrderHistory>>(orderHistories);
            

            var response = new GetOrderHistoriesResponse() 
            { 
                Data = mappedOrderHistories
            };

            return response;
        }
    }
}
