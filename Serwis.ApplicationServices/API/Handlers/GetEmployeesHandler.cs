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
using Serwis.DataAccess.CQRS.Queries;

namespace Serwis.ApplicationServices.API.Handlers
{
    public class GetEmployeesHandler : IRequestHandler<GetEmployeesRequest, GetEmployeesResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetEmployeesHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<GetEmployeesResponse> Handle(GetEmployeesRequest request, CancellationToken cancellationToken)
        {
            var query = new GetEmployeesQuery();
            var employees = await this.queryExecutor.Execute(query);

            var mappedEmployees = this.mapper.Map<List<Employee>>(employees);

            var response = new GetEmployeesResponse()
            {
                Data = mappedEmployees
            };

            return response;
        }
    }
}
