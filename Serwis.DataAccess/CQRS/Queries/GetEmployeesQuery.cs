using Microsoft.EntityFrameworkCore;
using Serwis.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serwis.DataAccess.CQRS.Queries
{
    public class GetEmployeesQuery : QueryBase<List<Employee>>
    {
        public override async Task<List<Employee>> Execute(ServiceStorageContext context)
        {
            var employees = await context.Employees.ToListAsync();
            return employees;
        }
    }
}
