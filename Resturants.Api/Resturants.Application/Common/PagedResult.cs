using Resturants.Application.Resturants.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Application.Common;

public class PagedResult<T> where T : class
{
    public PagedResult(IEnumerable<T> items,int totalCount,int PageSize, int pageNumber)
    {
        Items = items;
        TotalItemsCount=totalCount;
        TotalPages = (int)Math.Ceiling((double)totalCount / PageSize);
        ItemsFrom = PageSize * (pageNumber - 1) + 1;
        Itemsto = ItemsFrom + PageSize - 1;

    }

    public IEnumerable<T> Items { get; set; }
    public int TotalPages { get; set; }
    public int TotalItemsCount { get; set; }
    public int ItemsFrom { get; set; }
    public int Itemsto { get; set; }

}
