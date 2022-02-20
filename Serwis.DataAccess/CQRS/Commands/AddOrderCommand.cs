using Serwis.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serwis.DataAccess.CQRS.Commands
{
    public class AddOrderCommand : CommandBase<Order, Order>
    {
        public async override Task<Order> Exexute(ServiceStorageContext context)
        {
            this.Parameter.OrderDate = DateTime.Now;

            await context.Orders.AddAsync(Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
