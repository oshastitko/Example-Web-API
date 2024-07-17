using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiExample.Core.DTO.Pagination;
using WebApiExample.Core.DTO.Search;

namespace Web.Framework.Api.Models.Pagination;

public class PaginationApi
{
    public int Offset { get; set; } = 0;
    public int Limit { get; set; } = 100;
    public int? Total { get; set; }
}

public class LinksApi
{
    public string? Next { get; set; }
    public string? Prev { get; set; }
}

public class PagingApi<TCollectionDto, TSearchDto> where TSearchDto : SearchBaseDto
{
    public PagingApi(IPagedList<TCollectionDto> collection, TSearchDto search)
    {
        int offset = search.PageIndex * search.PageSize;
        int limit = search.PageSize;

        int nextOffset = offset + limit;
        int prevOffset = offset - limit;


        // uncomment it if you need HATEOAS 
        //if (collection.Count == limit)
        //    Links.Next = Url.Link("", new { offset = nextOffset, limit });

        //if (prevOffset >= 0)
        //    Links.Prev = Url.Link("", new { offset = offset - limit, limit });


        Pagination = new PaginationApi { Limit = limit, Offset = offset, Total = collection.TotalCount };
        Data = collection.ToList();

    }

    public PaginationApi Pagination { get; set; }
    public LinksApi Links { get; set; } = new LinksApi();
    public List<TCollectionDto> Data { get; set; }
}
