using Web.Framework.Api.Models.Common;

namespace Web.Framework.Api.Core;

public static class ErrorResponseHelpers
{
    public static ErrorResponse InvalidDataErrorResponse(List<ErrorDetail> details)
    {
        ErrorResponse errorResponse = new ErrorResponse(code: ErrorResponseKeys.INVALID_DATA, errorMessage: ErrorResponseList.Values[ErrorResponseKeys.INVALID_DATA]);
        errorResponse.Error.Details = details;
        return errorResponse;
    }

    public static ErrorResponse InvalidDataErrorResponse(ErrorDetail detail)
    {
        return InvalidDataErrorResponse(new List<ErrorDetail> { detail });
    }

    public static ErrorResponse InvalidModelErrorResponse(List<ErrorDetail> details)
    {
        ErrorResponse errorResponse = new ErrorResponse(code: ErrorResponseKeys.INVALID_MODEL, errorMessage: ErrorResponseList.Values[ErrorResponseKeys.INVALID_MODEL]);
        errorResponse.Error.Details = details;
        return errorResponse;
    }

    public static ErrorResponse RecordNotFoundErrorResponse(ErrorDetail detail)
    {
        ErrorResponse errorResponse = new ErrorResponse(code: ErrorResponseKeys.RECORD_NOT_FOUND, errorMessage: ErrorResponseList.Values[ErrorResponseKeys.RECORD_NOT_FOUND]);
        errorResponse.Error.Details = new List<ErrorDetail> { detail };
        return errorResponse;
    }
}