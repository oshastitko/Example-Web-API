using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Framework.Api.Core;
using Web.Framework.Api.Models.Common;

namespace Web.Framework.Api.Attributes;

public class ValidateApiModelStateAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            List<ErrorDetail> details = new();
            foreach (var key in context.ModelState.Keys)
            {
                foreach (var err in context.ModelState[key]!.Errors)
                {
                    details.Add(new ErrorDetail { Target = key, Message = err.ErrorMessage });
                }
            }

            ErrorResponse errorResponse = ErrorResponseHelpers.InvalidModelErrorResponse(details);

            // 422 Unprocessable Entity Explained
            context.Result = new ObjectResult(errorResponse) { StatusCode = 422 };
        }
    }
}
