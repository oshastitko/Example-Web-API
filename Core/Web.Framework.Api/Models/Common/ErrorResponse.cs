using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Framework.Api.Models.Common;

public class ErrorResponse
{
    /// <summary>
    /// The error object
    /// </summary>
    [JsonProperty(PropertyName = "error")]
    public Error Error { get; set; }


    public ErrorResponse(string? code = null, string? errorMessage = null)
    {
        Error = new Error() { Message = errorMessage, Code = code };
    }
}

public abstract class ErrorCodeAbstract
{
    /// <summary>
    /// One of a server-defined set of error codes.
    /// </summary>
    /// <example>BadArgument</example>
    [JsonProperty(PropertyName = "code")]
    public string? Code { get; set; }
}

public abstract class ErrorCodeDetailAbstract : ErrorCodeAbstract
{
    /// <summary>
    /// A human-readable representation of the error
    /// </summary>
    /// <example>Field should be in ABC format</example>
    [JsonProperty(PropertyName = "message")]
    public string? Message { get; set; }

    /// <summary>
    /// The target of the error.
    /// </summary>
    /// <example>FieldName</example>
    [JsonProperty(PropertyName = "target")]
    public string? Target { get; set; }
}


public class Error : ErrorCodeDetailAbstract
{
    /// <summary>
    /// An array of details about specific errors that led to this reported error.
    /// </summary>
    [JsonProperty(PropertyName = "details")]
    public List<ErrorDetail> Details { get; set; } = new();

    /// <summary>
    /// An object containing more specific information than the current object about the error.
    /// </summary>
    [JsonProperty(PropertyName = "innererror")]
    public InnerError? InnerError { get; set; }
}

public class ErrorDetail : ErrorCodeDetailAbstract
{
}

public class InnerError : ErrorCodeAbstract
{
    /// <summary>
    /// An object containing more specific information than the current object about the error.
    /// </summary>
    [JsonProperty(PropertyName = "innererror")]
    public InnerError NestedInnerError { get; set; }
}