using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Framework.Api.Core;

public static class ErrorResponseList
{
    static ErrorResponseList()
    {
        Values.Add(ErrorResponseKeys.VENDOR_EXISTS, "Vendor with such name already exists");
        Values.Add(ErrorResponseKeys.VENDOR_NOT_FOUND, "Vendor is not found");
        Values.Add(ErrorResponseKeys.DEVICE_NOT_FOUND, "Device is not found");
        Values.Add(ErrorResponseKeys.INVALID_MODEL, "Model state is not valid");
        Values.Add(ErrorResponseKeys.RECORD_NOT_FOUND, "Record not found");
        Values.Add(ErrorResponseKeys.INVALID_DATA, "Some passed data is invalid");
    }

    public static Dictionary<string, string> Values { get; set; } = [];
}

public static class ErrorResponseKeys
{
    public const string VENDOR_EXISTS = "VENDOR_EXISTS";
    public const string VENDOR_NOT_FOUND = "VENDOR_NOT_FOUND";
    public const string DEVICE_NOT_FOUND = "DEVICE_NOT_FOUND";
    public const string INVALID_MODEL = "INVALID_MODEL";
    public const string RECORD_NOT_FOUND = "RECORD_NOT_FOUND";
    public const string INVALID_DATA = "INVALID_DATA";
}
