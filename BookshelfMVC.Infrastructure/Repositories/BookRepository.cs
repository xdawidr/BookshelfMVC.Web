using BookshelfMVC.Domain.Interfaces;
using BookshelfMVC.Domain.Model;
using System.Linq;

namespace BookshelfMVC.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly Context _context;

        public BookRepository(Context context)
        {
            _context = context;
        }

        public void DeleteBook(int bookId)
        {
            var book = _context.Books.Find(bookId);
            if (book != null)
                _context.Books.Remove(book);
                _context.SaveChanges();
        }

        public int AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return book.Id;
        }


        public Book GetBook(int id)
        {
            return _context.Books.FirstOrDefault(b =>  b.Id == b.Id);
        }

        public IQueryable<Book> GetAllBooks()
        {
            return _context.Books;
           
        }

        public void UpdateBook(Book book)
        {
            _context.Attach(book);
            _context.Entry(book).Property("Name").IsModified = true;
            _context.SaveChanges();
        }
    }
}
