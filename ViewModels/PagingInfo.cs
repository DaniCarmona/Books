using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.ViewModels
{
    public class PagingInfo
    {
        public const int NUMBER_OF_PAGES_TO_SHOW_BEFORE_AND_AFTER=5;
        public int TotalItems { get; set; }
        public int PageSize { get; set; } = 10;
        public int CurrentPage { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalItems / PageSize);


    }
}
