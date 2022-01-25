using Microsoft.EntityFrameworkCore;
using Serwis.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serwis.DataAccess.CQRS.Queries
{
    public class GetClientsQuery : QueryBase<List<Client>>
    {
        public override async Task<List<Client>> Execute(ServiceStorageContext context)
        {
            var clients = await context.Clients.ToListAsync();
            return clients;
        }
    }
}
