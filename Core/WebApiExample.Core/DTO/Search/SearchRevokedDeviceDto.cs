using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiExample.Core.DTO.Ordering;

namespace WebApiExample.Core.DTO.Search;

public class SearchRevokedDeviceDto : SearchDeviceBaseDto<RevokedDeviceOrderBy>
{
    public DateTime? RevokedAfter { get; set; }
    public DateTime? RevokedBefore { get; set; }
}
