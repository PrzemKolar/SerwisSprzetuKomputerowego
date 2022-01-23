using MediatR;
using Serwis.ApplicationServices.API.Domain;
using Serwis.DataAccess;
using Serwis.DataAccess.Entities;
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

        public GetEmployeesHandler(IRepository<DataAccess.Entities.Employee> employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public Task<GetEmployeesResponse> Handle(GetEmployeesRequest request, CancellationToken cancellationToken)
        {
            var employees = this.employeeRepository.GetAll();
            var domainEmployees = employees.Select(x => new Domain.Models.Employee()
            {
                FirstName = x.FirstName,
                LastName = x.LastName
            });

            var response = new GetEmployeesResponse()
            {
                Data = domainEmployees.ToList()
            };

            return Task.FromResult(response);
        }
    }
}
