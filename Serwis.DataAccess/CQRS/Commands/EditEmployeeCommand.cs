using Serwis.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serwis.DataAccess.CQRS.Commands
{
    public class EditEmployeeCommand : CommandBase<Employee, Employee>
    {
        public override async Task<Employee> Exexute(ServiceStorageContext context)
        {
            var employee = context.Employees.Find(Parameter.Id);
            employee.FirstName = Parameter.FirstName;
            employee.LastName = Parameter.LastName;
            employee.PhoneNumer = Parameter.PhoneNumer;
            await context.SaveChangesAsync();
            return employee;
        }
    }
}
