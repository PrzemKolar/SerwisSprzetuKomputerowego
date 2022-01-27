using AutoMapper;
using MediatR;
using Serwis.ApplicationServices.API.Domain;
using Serwis.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Serwis.DataAccess.CQRS.Queries;
using Serwis.ApplicationServices.API.Domain.Models;

namespace Serwis.ApplicationServices.API.Handlers
{
    class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdRequest, GetEmployeeByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetEmployeeByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<GetEmployeeByIdResponse> Handle(GetEmployeeByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetEmployeeQuery()
            {
                Id = request.EmployeeId
            };
            var employee = await queryExecutor.Execute(query);
            var mappedEmployee = mapper.Map<Employee>(employee);
            return new GetEmployeeByIdResponse() { Data = mappedEmployee };
        }
    }
}
