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
    public class GetOrdersHandler : IRequestHandler<GetOrdersRequest, GetOrdersResponse>
    {
        private readonly IRepository<DataAccess.Entities.Order> orderRepository;
        private readonly IMapper mapper;

        public GetOrdersHandler(IRepository<DataAccess.Entities.Order> OrderRepository, IMapper mapper)
        {
            this.orderRepository = OrderRepository;
            this.mapper = mapper;
        }

        public async Task<GetOrdersResponse> Handle(GetOrdersRequest request, CancellationToken cancellationToken)
        {
            var orders = await orderRepository.GetAll();
            var mapperdOrders = this.mapper.Map<List<Domain.Models.Order>>(orders);
            

            var response = new GetOrdersResponse()
            {
                Data = mapperdOrders
            };

            return response;
        }
    }
}
