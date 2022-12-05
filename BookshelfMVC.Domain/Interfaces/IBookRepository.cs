using BookshelfMVC.Domain.Model;
using System.Linq;

namespace BookshelfMVC.Domain.Interfaces
{
    public interface IBookRepository
    {
       void DeleteBook(int bookId);
       int AddBook(Book book);
       Book GetBook(int id);
       IQueryable<Book> GetAllBooks();
       void UpdateBook(Book book);

    }
}
