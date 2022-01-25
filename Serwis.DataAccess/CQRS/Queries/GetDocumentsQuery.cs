using Microsoft.EntityFrameworkCore;
using Serwis.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serwis.DataAccess.CQRS.Queries
{
    public class GetDocumentsQuery : QueryBase<List<Document>>
    {
        public override async Task<List<Document>> Execute(ServiceStorageContext context)
        {
            var documents = await context.Documents.ToListAsync();
            return documents;
        }
    }
}
