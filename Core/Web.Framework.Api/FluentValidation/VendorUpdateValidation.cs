using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiExample.Core.DTO;

namespace Web.Framework.Api.FluentValidation
{
    public class VendorUpdateValidation : AbstractValidator<VendorUpdateDto>
    {
        public VendorUpdateValidation()
        {
            RuleFor(vendor => vendor.Name)
                .NotEmpty().WithMessage("Name is required");

            RuleFor(vendor => vendor.Id)
                .NotEmpty().WithMessage("Id is required");

            RuleFor(vendor => vendor.Id)
                .GreaterThan(0).WithMessage("Id should be greater than 0");

        }
    }
}
