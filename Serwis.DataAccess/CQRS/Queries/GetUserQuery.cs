using Microsoft.EntityFrameworkCore;
using Serwis.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serwis.DataAccess.CQRS.Queries
{
    public class GetUserQuery : QueryBase<User>
    {
        public string UserName { get; set; }

        public async override Task<User> Execute(ServiceStorageContext context)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Username == this.UserName);
            return user;
        }
    }
}
