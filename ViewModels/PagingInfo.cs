using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.ViewModels
{
    public class PagingInfo
    {
        public int TotalItems { get; set; }
        public int PageSize { get; set; } = 10;
        public int CurrentPage { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalItems / PageSize);


    }
}
