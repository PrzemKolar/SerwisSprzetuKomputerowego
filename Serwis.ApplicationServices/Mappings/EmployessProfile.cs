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
    public class EmployeesProfile : Profile
    {
        public EmployeesProfile()
        {
            this.CreateMap<Serwis.DataAccess.Entities.Employee, Employee>()
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName));

            this.CreateMap<AddEmployeeRequest, DataAccess.Entities.Employee>()
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
                .ForMember(x => x.PhoneNumer, y => y.MapFrom(z => z.PhoneNumber));

            this.CreateMap<EditEmployeeRequest, DataAccess.Entities.Employee>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
                .ForMember(x => x.PhoneNumer, y => y.MapFrom(z => z.PhoneNumber));
        }
    }
}
