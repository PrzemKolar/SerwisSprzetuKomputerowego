using Microsoft.EntityFrameworkCore;
using Serwis.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serwis.DataAccess.CQRS.Queries
{
    public class GetDelayedOrdersQuery : QueryBase<List<DataAccess.Entities.Order>>
    {
        DateTime delayedTime = DateTime.Now.Date;

        public async override Task<List<Order>> Execute(ServiceStorageContext context)
        {
            delayedTime.AddDays(-10);
            return await context.Orders.Where(x => x.OrderDate.Date <= delayedTime).ToListAsync();
        }
    }
}
