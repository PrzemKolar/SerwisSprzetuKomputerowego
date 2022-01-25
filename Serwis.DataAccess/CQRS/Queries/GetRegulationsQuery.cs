using Microsoft.EntityFrameworkCore;
using Serwis.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serwis.DataAccess.CQRS.Queries
{
    public class GetRegulationsQuery : QueryBase<List<Regulation>>
    {
        public override async Task<List<Regulation>> Execute(ServiceStorageContext context)
        {
            var regulations = await context.Regulations.ToListAsync();
            return regulations;
        }
    }
}
