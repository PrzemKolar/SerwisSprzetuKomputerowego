using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serwis.ApplicationServices.API.Domain.Order
{
    public class AddOrderRequest : RequestBase<AddOrderResponse>
    {
        public string DeviceName { get; set; }
        public string DescriptionFault { get; set; }
        public string DeviceSN { get; set; }
        public int ClientId { get; set; }
    }
}
