using Microsoft.EntityFrameworkCore;
using Serwis.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Serwis.DataAccess.Entities.Order;

namespace Serwis.DataAccess.CQRS.Queries
{
    public class GetResignedOrdersQuery : QueryBase<List<DataAccess.Entities.Order>>
    {
        public StatusEnum statusEnum { get; set; }
        public async override Task<List<Order>> Execute(ServiceStorageContext context)
        {
            return await context.Orders.Where(x => x.RepairStatus == statusEnum).ToListAsync();
        }
    }
}
