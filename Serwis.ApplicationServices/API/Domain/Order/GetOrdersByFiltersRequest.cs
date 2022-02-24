using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serwis.ApplicationServices.API.Domain.Order
{
    public class GetOrdersByFiltersRequest : RequestBase<GetOrdersByFiltersResponse>
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string Device { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public int Quantity { get; set; }
    }
}
