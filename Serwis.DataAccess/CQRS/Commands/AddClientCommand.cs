using Serwis.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serwis.DataAccess.CQRS.Commands
{
    public class AddClientCommand : CommandBase<Client, Client>
    {
        public override async Task<Client> Exexute(ServiceStorageContext context)
        {
            await context.Clients.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}
