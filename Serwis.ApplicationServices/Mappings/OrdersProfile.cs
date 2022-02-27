using AutoMapper;
using Serwis.ApplicationServices.API.Domain.Models;
using Serwis.ApplicationServices.API.Domain.Order;
using Serwis.DataAccess.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serwis.ApplicationServices.Mappings
{
    class OrdersProfile : Profile
    {
        public OrdersProfile()
        {
            this.CreateMap<DataAccess.Entities.Order, Order>()
                .ForMember(x => x.DescriptionFault, y => y.MapFrom(z => z.DescriptionFault))
                .ForMember(x => x.DeviceName, y => y.MapFrom(z => z.DeviceName))
                .ForMember(x => x.Price, y => y.MapFrom(z => z.Price));

            this.CreateMap<AddOrderRequest, DataAccess.Entities.Order>()
                .ForMember(x => x.DeviceName, y => y.MapFrom(z => z.DeviceName))
                .ForMember(x => x.DescriptionFault, y => y.MapFrom(z => z.DescriptionFault))
                .ForMember(x => x.DeviceSN, y => y.MapFrom(z => z.DeviceSN));

            this.CreateMap<EditOrderRequest, DataAccess.Entities.Order>()
                .ForMember(x => x.Diagnosis, y => y.MapFrom(z => z.Diagnosis))
                .ForMember(x => x.Price, y => y.MapFrom(z => z.Price))
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.PayedPrice, y => y.MapFrom(z => z.PayedPrice))
                .ForMember(x => x.RepairStatus, y => y.MapFrom(z => z.OrderStatus));

            this.CreateMap<GetOrdersByFiltersRequest, GetOrdersByFiltersQuery>()
                .ForMember(x => x.Device, y => y.MapFrom(z => z.Device))
                .ForMember(x => x.DateStart, y => y.MapFrom(z => z.DateStart))
                .ForMember(x => x.DateEnd, y => y.MapFrom(z => z.DateEnd))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
                .ForMember(x => x.Quantity, y => y.MapFrom(z => z.Quantity));
        }
    }
}
