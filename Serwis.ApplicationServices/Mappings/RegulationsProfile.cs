using AutoMapper;
using Serwis.ApplicationServices.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serwis.ApplicationServices.Mappings
{
    class RegulationsProfile : Profile
    {
        public RegulationsProfile()
        {
            this.CreateMap<DataAccess.Entities.Regulation, Regulation>()
                .ForMember(x => x.Text, y => y.MapFrom(z => z.Text));
        }
    }
}
