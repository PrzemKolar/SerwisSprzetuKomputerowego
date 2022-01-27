using Serwis.DataAccess.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serwis.DataAccess
{
    public class QueryExecutor : IQueryExecutor
    {
        private readonly ServiceStorageContext context;

        public QueryExecutor(ServiceStorageContext context)
        {
            this.context = context;
        }

        public Task<TResult> Execute<TResult>(QueryBase<TResult> query)
        {
            return query.Execute(this.context);
        }
    }
}
