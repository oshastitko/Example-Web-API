using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiExample.Core.DTO;

public class VendorDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime DateAdded { get; set; }
    public int RegisteredDevicesCount { get; set; } = 0;
    public int RevokedDevicesCount { get; set; } = 0;
}

public abstract class VendorActionDto
{
    public string Name { get; set; }
}

public class VendorCreateDto : VendorActionDto
{
}

public class VendorUpdateDto : VendorActionDto
{
    public int Id { get; set; }
}
