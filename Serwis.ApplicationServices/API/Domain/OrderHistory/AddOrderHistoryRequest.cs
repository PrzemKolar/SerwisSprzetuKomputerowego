using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serwis.ApplicationServices.API.Domain.OrderHistory
{
    public class AddOrderHistoryRequest : RequestBase<AddOrderHistoryResponse>
    {
        public string Description { get; set; }
        public int OrderId { get; set; }
    }
}
