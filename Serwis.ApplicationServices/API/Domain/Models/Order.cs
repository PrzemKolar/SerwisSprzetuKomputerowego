using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serwis.ApplicationServices.API.Domain.Models
{
    public class Order
    {
        public string DeviceName { get; set; }
        public string DescriptionFault { get; set; }
        public float Price { get; set; }
    }
}
