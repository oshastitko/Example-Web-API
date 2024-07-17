using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiExample.Core.DTO.Search;

public abstract class SearchBaseDto
{
    public int PageIndex { get; set; } = 0;
    public int PageSize { get; set; } = 50;// int.MaxValue;
}
