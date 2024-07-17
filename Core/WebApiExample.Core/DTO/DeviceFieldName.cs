using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiExample.Core.DTO;

public enum RegisteredDeviceFieldNameDto
{
    DeviceName,
    ModelNumber,
    SoftwareVersion,
    EldIdentifier,
    CompanyName,
    Phone,
    Email,
    Website,
    MailingAddress,
    CityStateZip,
    DataTransferOptions
}


public enum RevokedDeviceFieldNameDto
{
    DeviceName,
    ModelNumber,
    SoftwareVersion,
    EldIdentifier,
    CompanyName,
    Phone,
    Email,
    Website,
    MailingAddress,
    CityStateZip,
    DataTransferOptions,
    DateRevoked,
    Status
}
