﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serwis.ApplicationServices.API.Domain.Order
{
    public class GetOrdersForEmployeeRequest : RequestBase<GetOrdersForEmployeeResponse>
    {
        public int IdEmployee { get; set; }
    }
}
