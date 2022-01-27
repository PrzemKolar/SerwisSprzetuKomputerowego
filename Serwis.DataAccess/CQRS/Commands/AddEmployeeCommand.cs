using Serwis.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serwis.DataAccess.CQRS.Commands
{
    public class AddEmployeeCommand : CommandBase<Employee, Employee>
    {
        public override async Task<Employee> Exexute(ServiceStorageContext context)
        {
            await context.Employees.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
