using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiExample.Core.DTO;

namespace Web.Framework.Api.FluentValidation;

public class VendorCreateValidation : AbstractValidator<VendorCreateDto>
{
    public VendorCreateValidation()
    {
        RuleFor(vendor => vendor.Name)
            .NotEmpty().WithMessage("Name is required");

    }
}
