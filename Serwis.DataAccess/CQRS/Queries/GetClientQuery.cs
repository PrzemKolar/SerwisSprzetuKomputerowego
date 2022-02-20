using Serwis.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serwis.DataAccess.CQRS.Queries
{
    public class GetClientQuery : QueryBase<Client>
    {
        public int Id { get; set; }

        public async override Task<Client> Execute(ServiceStorageContext context)
        {
            return await context.Clients.FindAsync(Id);
        }
    }
}
