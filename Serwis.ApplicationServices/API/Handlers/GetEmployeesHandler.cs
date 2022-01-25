using AutoMapper;
using MediatR;
using Serwis.ApplicationServices.API.Domain;
using Serwis.ApplicationServices.API.Domain.Models;
using Serwis.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Serwis.ApplicationServices.API.Handlers
{
    public class GetEmployeesHandler : IRequestHandler<GetEmployeesRequest, GetEmployeesResponse>
    {
        private readonly IRepository<DataAccess.Entities.Employee> employeeRepository;
        private readonly IMapper mapper;

        public GetEmployeesHandler(IRepository<DataAccess.Entities.Employee> employeeRepository, IMapper mapper)
        {
            this.employeeRepository = employeeRepository;
            this.mapper = mapper;
        }

        public async Task<GetEmployeesResponse> Handle(GetEmployeesRequest request, CancellationToken cancellationToken)
        {
            var employees = await this.employeeRepository.GetAll();
            var mappedEmployees = this.mapper.Map<List<Employee>>(employees);

            //var domainEmployees = employees.Select(x => new Domain.Models.Employee()
            //{
            //    FirstName = x.FirstName,
            //    LastName = x.LastName
            //});

            var response = new GetEmployeesResponse()
            {
                Data = mappedEmployees
            };

            return response;
        }
    }
}
