﻿using AutoMapper;
using Serwis.ApplicationServices.API.Domain.Models;
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
        }
    }
}