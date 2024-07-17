using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiExample.Core.DTO.Ordering;

public enum VendorOrderBy
{
    Name,
    DateAdded,
    RegisteredDevicesCount,
    RevokedDevicesCount
}
