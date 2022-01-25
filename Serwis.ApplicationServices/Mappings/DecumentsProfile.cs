using AutoMapper;
using Serwis.ApplicationServices.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serwis.ApplicationServices.Mappings
{
    class DecumentsProfile : Profile
    {
        public DecumentsProfile()
        {
            this.CreateMap<DataAccess.Entities.Document, Document>()
                .ForMember(x => x.Order, y => y.MapFrom(z => z.Order));
        }
    }
}