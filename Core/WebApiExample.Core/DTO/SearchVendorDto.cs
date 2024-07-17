using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiExample.Core.DTO.Ordering;
using WebApiExample.Core.DTO.Search;

namespace WebApiExample.Core.DTO
{
    public class SearchVendorDto : SearchWithOrderingBaseDto<VendorOrderBy>
    {
    }
}
