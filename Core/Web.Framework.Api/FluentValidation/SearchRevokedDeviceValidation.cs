using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiExample.Core.DTO.Search;

namespace Web.Framework.Api.FluentValidation;

public class SearchRevokedDeviceValidation : AbstractValidator<SearchRevokedDeviceDto>
{
    public SearchRevokedDeviceValidation()
    {
        RuleFor(search => search.VendorId)
            .GreaterThan(0).When(search => search.VendorId.HasValue).WithMessage("VendorId should be greater than 0");

        RuleFor(search => search.AddedAfter)
            .LessThan(DateTime.UtcNow).WithMessage("AddedAfter should be less than today");

        RuleFor(search => search.ModifiedAfter)
            .LessThan(DateTime.UtcNow).WithMessage("ModifiedAfter should be less than today");

    }
}
