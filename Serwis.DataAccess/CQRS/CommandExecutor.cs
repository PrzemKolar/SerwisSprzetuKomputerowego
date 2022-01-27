using Serwis.DataAccess.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serwis.DataAccess.CQRS
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly ServiceStorageContext context;

        public CommandExecutor(ServiceStorageContext context)
        {
            this.context = context;
        }

        public Task<TResult> Execute<TParameters, TResult>(CommandBase<TParameters, TResult> command)
        {
            return command.Exexute(this.context);
        }
    }
}
