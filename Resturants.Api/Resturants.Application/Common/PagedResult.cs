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
        Items = items ?? Enumerable.Empty<T>();
        TotalItemsCount = totalCount;

        if (PageSize <= 0 || pageNumber <= 0 || totalCount == 0)
        {
            TotalPages = 0;
            ItemsFrom = 0;
            Itemsto = 0;
            return;
        }

        TotalPages = (int)Math.Ceiling((double)totalCount / PageSize);
        ItemsFrom = PageSize * (pageNumber - 1) + 1;
        Itemsto = Math.Min(ItemsFrom + PageSize - 1, totalCount);

    }

    public IEnumerable<T> Items { get; set; }
    public int TotalPages { get; set; }
    public int TotalItemsCount { get; set; }
    public int ItemsFrom { get; set; }
    public int Itemsto { get; set; }

}
