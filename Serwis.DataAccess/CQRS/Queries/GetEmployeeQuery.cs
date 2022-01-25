using Microsoft.EntityFrameworkCore;
using Serwis.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Serwis.DataAccess.CQRS.Queries
{
    public class GetEmployeeQuery : QueryBase<Employee>
    {
        public int Id { get; set; }

        public override async Task<Employee> Execute(ServiceStorageContext context)
        {
            var employee = await context.Employees.FirstOrDefaultAsync(x => x.Id == this.Id);
            return employee;
        }
    }
}
