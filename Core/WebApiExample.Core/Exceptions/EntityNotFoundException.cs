using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiExample.Core.Exceptions;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException()
    {

    }

    public string? EntityName { get; private set; }

    public EntityNotFoundException(string entityName)
    {
        EntityName = entityName;
    }
}