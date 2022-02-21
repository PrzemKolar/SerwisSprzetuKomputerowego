using Serwis.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serwis.DataAccess.CQRS.Commands
{
    public class EditOrderCommand : CommandBase<Order, Order>
    {
        public async override Task<Order> Exexute(ServiceStorageContext context)
        {
            var order = await context.Orders.FindAsync(Parameter.Id);
            order.Diagnosis = Parameter.Diagnosis;
            order.Price = Parameter.Price;

            await context.SaveChangesAsync();
            return order;
        }
    }
}
