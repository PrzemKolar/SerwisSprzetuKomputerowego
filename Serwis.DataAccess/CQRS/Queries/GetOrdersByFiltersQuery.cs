using Microsoft.EntityFrameworkCore;
using Serwis.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serwis.DataAccess.CQRS.Queries
{
    public class GetOrdersByFiltersQuery : QueryBase<List<DataAccess.Entities.Order>>
    {
        public string LastName { get; set; }
        public string Device { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public int Quantity { get; set; }

        public async override Task<List<Order>> Execute(ServiceStorageContext context)
        {
            IQueryable<Order> orders = context.Orders;

            if (LastName != null)
                orders = orders.Where(x => x.Client.LastName == LastName);

            if (Device != null)
                orders = orders.Where(x => x.DeviceName == Device);

            if (DateStart != default)
                orders = orders.Where(x => x.OrderDate.Date >= DateStart.Date);

            if (DateEnd != default)
                orders = orders.Where(x => x.OrderDate.Date <= DateEnd.Date);

            if (Quantity != default)
                orders = orders.Take(Quantity);

            return await orders.ToListAsync();
        }
    }
}
