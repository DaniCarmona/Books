using Books.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.ViewModels
{
	public class BookListViewModel
	{
		public IEnumerable<Book> Books { get; set; }
        public PagingInfo PagingInfo { get; set; }

		public string TitleSearched { get; set; }
	}
}
