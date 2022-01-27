using AutoMapper;
using Serwis.ApplicationServices.API.Domain;
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
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
                .ForMember(x => x.PhoneNumber, y => y.MapFrom(z => z.PhoneNumer));

            this.CreateMap<AddClientRequest, DataAccess.Entities.Client>()
                .ForMember(x => x.FirstNaem, y => y.MapFrom(z => z.FirstName))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
                .ForMember(x => x.PhoneNumer, y => y.MapFrom(z => z.PhoneNumber))
                .ForMember(x => x.Street, y => y.MapFrom(z => z.Street))
                .ForMember(x => x.HouseNumber, y => y.MapFrom(z => z.HouseNumber))
                .ForMember(x => x.ApartmentNumber, y => y.MapFrom(z => z.ApartmentNumber))
                .ForMember(x => x.PostCode, y => y.MapFrom(z => z.PostCode))
                .ForMember(x => x.Discount, y => y.MapFrom(z => z.Discount));
        }
    }
}
