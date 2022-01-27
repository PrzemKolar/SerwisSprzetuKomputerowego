using FluentValidation;
using Serwis.ApplicationServices.API.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serwis.ApplicationServices.API.Validators
{
    public class AddEmployeeRequestValidator : AbstractValidator<AddEmployeeRequest>
    {
        public AddEmployeeRequestValidator()
        {
            this.RuleFor(x => x.FirstName).Length(3, 30);
            this.RuleFor(x => x.LastName).Length(3, 30);
            this.RuleFor(x => x.PhoneNumber).Length(9,9);
        }
    }
}
