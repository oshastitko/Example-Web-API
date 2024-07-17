

using WebApiExample.Core.DTO.Ordering;

namespace WebApiExample.Core.DTO.Search;

public abstract class SearchWithOrderingBaseDto<TOrderingEnum> : SearchBaseDto
    where TOrderingEnum : struct
{
    public EntityOrder<TOrderingEnum>? Order { get; set; }
}
