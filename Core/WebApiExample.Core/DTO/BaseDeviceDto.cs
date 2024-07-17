using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiExample.Core.DTO;

public abstract class BaseDeviceDto
{
    protected readonly string _initSyncId;

    public BaseDeviceDto(string initSyncId)
    {
        _initSyncId = initSyncId;
    }

    public int Id { get; set; }

    public int Position { get; set; }
    public DateTime DateAdded { get; set; }
    public string FileAdded { get; set; }
    public bool HasChangesHistory { get; set; }
    public bool AddedByInitSync { get; set; } = false;
    public string? Vendor { get; set; }


    public bool? VirtualAddress { get; set; }

    public string Phone { get; set; }
    public string MailingAddress { get; set; }
    public string CityStateZip { get; set; }
}
