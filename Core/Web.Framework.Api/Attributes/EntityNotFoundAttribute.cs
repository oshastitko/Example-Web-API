using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Framework.Api.Core;
using Web.Framework.Api.Models.Common;
using WebApiExample.Core.Exceptions;

namespace Web.Framework.Api.Attributes;

public class EntityNotFoundAttribute(string key, string target) : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        if (context.Exception is EntityNotFoundException ex)
        {
            var errorResponse = ErrorResponseHelpers.RecordNotFoundErrorResponse(
                new ErrorDetail
                {
                    Code = key,
                    Message = ErrorResponseList.Values[key],
                    Target = target
                });

            context.Result = new ObjectResult(errorResponse) { StatusCode = 422 };
        }
    }
}
