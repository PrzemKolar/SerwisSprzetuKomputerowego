using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serwis.ApplicationServices.API.Domain
{
    public abstract class RequestBase<TResponse> : IRequest<TResponse>
    {
        public string Name { get; set; }
    }
}
