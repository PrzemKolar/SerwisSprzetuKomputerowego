using AutoMapper;
using Serwis.ApplicationServices.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serwis.ApplicationServices.Mappings
{
    class OrderHistoriesProfile : Profile
    {
        public OrderHistoriesProfile()
        {
            this.CreateMap<DataAccess.Entities.OrderHistory, OrderHistory>()
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.Title, y => y.MapFrom(z => z.Title));
        }
    }
}