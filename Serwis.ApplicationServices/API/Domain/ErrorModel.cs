﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serwis.ApplicationServices.API.Domain
{
    public class ErrorModel
    {
        public ErrorModel(string error)
        {
            this.Error = error;
        }

        public string Error { get; private set; }
    }
}
