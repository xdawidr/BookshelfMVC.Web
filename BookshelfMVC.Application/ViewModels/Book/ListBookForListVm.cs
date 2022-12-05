using System.Collections.Generic;

namespace BookshelfMVC.Application.ViewModels.Book
{
    public class ListBookForListVm
    {
        public List<BookForListVm> Books { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
        public int Count { get; set; }
    }
}
