using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiExample.Core.DTO.RegisteredDevices;

public class RegisteredDeviceDto(string initSyncId) : BaseDeviceDto(initSyncId)
{
    public string DeviceName { get; set; }
    public string ModelNumber { get; set; }
    public string SoftwareVersion { get; set; }
    public string EldIdentifier { get; set; }
    public string CompanyName { get; set; }
    public string Email { get; set; }
    public string Website { get; set; }
    public string? DataTransferOptions { get; set; }
}
