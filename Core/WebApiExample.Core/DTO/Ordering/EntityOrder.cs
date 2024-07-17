using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiExample.Core.DTO.Ordering;

public class EntityOrder<T> where T : struct
{
    public T OrderBy { get; set; }
    public OrderByDirection Direction { get; set; } = OrderByDirection.Asc;

    public EntityOrder()
    {

    }

    public EntityOrder(T orderBy, OrderByDirection direction)
    {
        OrderBy = orderBy;
        Direction = direction;
    }
}
