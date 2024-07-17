using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiExample.Core.DTO.Search;

public abstract class SearchDeviceBaseDto<TOrderedEnum> : SearchWithOrderingBaseDto<TOrderedEnum> where TOrderedEnum : struct, Enum
{
    public string? SearchByKeyword { get; set; }
    public DateTime? AddedAfter { get; set; }
    public DateTime? ModifiedAfter { get; set; }
    public bool IsLive { get; set; } = true;
    public bool? DeviceChanges { get; set; }
    public bool? IsVendorLinked { get; set; }
    public bool? IsVirtualAddress { get; set; }
    public string? MailingAddress { get; set; }
    public string? Phone { get; set; }
    public int? VendorId { get; set; }

}
