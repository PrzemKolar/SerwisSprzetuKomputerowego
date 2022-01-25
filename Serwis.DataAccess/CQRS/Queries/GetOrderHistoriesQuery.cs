using Microsoft.EntityFrameworkCore;
using Serwis.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serwis.DataAccess.CQRS.Queries
{
    public class GetOrderHistoriesQuery : QueryBase<List<OrderHistory>>
    {
        public override async Task<List<OrderHistory>> Execute(ServiceStorageContext context)
        {
            var orderDocuments = await context.OrderHistories.ToListAsync();
            return orderDocuments;
        }
    }
}
