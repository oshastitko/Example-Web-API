using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiExample.Core.DTO.Ordering;

public enum RevokedDeviceOrderBy
{
    Position,
    DeviceName,
    ModelNumber,
    EldIdentifier,
    CompanyName,
    DateAdded,
    DateRevoked,
    Status
}