using Microsoft.EntityFrameworkCore;
using Serwis.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serwis.DataAccess.CQRS.Queries
{
    public class GetProfitsQuery : QueryBase<List<Profit>>
    {
        public override async Task<List<Profit>> Execute(ServiceStorageContext context)
        {
            var profits = await context.Profits.ToListAsync();
            return profits;
        }
    }
}
