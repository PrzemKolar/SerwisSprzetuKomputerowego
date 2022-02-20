using Serwis.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serwis.DataAccess.CQRS.Commands
{
    public class AddOrderHistoryCommand : CommandBase<OrderHistory, OrderHistory>
    {
        public async override Task<OrderHistory> Exexute(ServiceStorageContext context)
        {
            this.Parameter.Date = DateTime.Now;
            this.Parameter.Title = "Komentarz";

            //temporary
            var employee = await context.Employees.FindAsync(1);
            this.Parameter.Employee = employee;

            await context.OrderHistories.AddAsync(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
