using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiExample.Core.DTO.RevokedDevices;

public class RevokedDeviceHistoryItemDto
{
    public RevokedDeviceFieldNameDto FieldName { get; set; }
    public string OldValue { get; set; }
    public string NewValue { get; set; }
    public DateTime DateChanges { get; set; }
}
