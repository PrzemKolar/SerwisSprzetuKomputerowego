using AutoMapper;
using Serwis.ApplicationServices.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serwis.ApplicationServices.Mappings
{
    class ProfitsProfile : Profile
    {
        public ProfitsProfile()
        {
            this.CreateMap<DataAccess.Entities.Profit, Profit>()
                .ForMember(x => x.Amount, y => y.MapFrom(z => z.Amount));
        }
    }
}