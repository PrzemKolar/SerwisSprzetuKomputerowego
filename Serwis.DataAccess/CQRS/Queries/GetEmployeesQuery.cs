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
        public string FirstName { get; set; }
        public override async Task<List<Employee>> Execute(ServiceStorageContext context)
        {
            if(FirstName == null)
                return await context.Employees.ToListAsync();
            else
                return await context.Employees.Where(x => x.FirstName == FirstName).ToListAsync();
        }
    }
}
