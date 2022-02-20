using FluentValidation;
using Serwis.ApplicationServices.API.Domain.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serwis.ApplicationServices.API.Validators
{
    public class AddOrderRequestValidator : AbstractValidator<AddOrderRequest>
    {
        public AddOrderRequestValidator()
        {
            this.RuleFor(x => x.DeviceName).MaximumLength(100);
            this.RuleFor(x => x.DeviceSN).MaximumLength(30);
        }
    }
}
