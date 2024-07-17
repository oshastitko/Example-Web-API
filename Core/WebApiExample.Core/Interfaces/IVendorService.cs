using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiExample.Core.Interfaces;

public interface IVendorService
{
    /// <summary>
    /// Get full vendor list as dictionary "id / name"
    /// </summary>
    /// <returns></returns>
    IDictionary<int, string> GetVendors();
}
