using BookshelfMVC.Application.ViewModels.Book;

namespace BookshelfMVC.Application.Interfaces
{
    public interface IBookService
    {
        ListBookForListVm GetAllBooksForList(int pageSize, int pageNumber, string searchString);
        int AddBook(NewBookVm book);
        BookDetailsVm GetBookDetails(int bookId);
        void DeleteBook(int bookId);
        NewBookVm GetBookForEdit(int id);
        void UpdateBook(NewBookVm model);
    }
}
