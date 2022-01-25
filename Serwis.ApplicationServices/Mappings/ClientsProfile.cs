using AutoMapper;
using Serwis.ApplicationServices.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serwis.ApplicationServices.Mappings
{
    class ClientsProfile : Profile
    {
        public ClientsProfile()
        {
            this.CreateMap<DataAccess.Entities.Client, Client>()
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstNaem))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName));
        }
    }
}
