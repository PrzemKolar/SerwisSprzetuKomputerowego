using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serwis.ApplicationServices.API.Domain.Order
{
    public class EditOrderRequest : RequestBase<EditOrderResponse>
    {
        public int Id { get; set; }
        public string Diagnosis { get; set; }
        public float Price { get; set; }
    }
}
