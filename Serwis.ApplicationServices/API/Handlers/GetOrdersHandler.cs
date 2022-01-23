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

        public GetOrdersHandler(IRepository<DataAccess.Entities.Order> OrderRepository)
        {
            this.orderRepository = OrderRepository;
        }

        public Task<GetOrdersResponse> Handle(GetOrdersRequest request, CancellationToken cancellationToken)
        {
            var orders = orderRepository.GetAll();

            var domainOrders = orders.Select(x => new Domain.Models.Order()
            {
                DescriptionFault = x.DescriptionFault,
                DeviceName = x.DeviceName,
                Price = x.Price
            });

            var response = new GetOrdersResponse()
            {
                Data = domainOrders.ToList()
            };

            return Task.FromResult(response);
        }
    }
}
