using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookshelfMVC.Application.Interfaces;
using BookshelfMVC.Application.ViewModels.Book;
using BookshelfMVC.Domain.Interfaces;
using BookshelfMVC.Domain.Model;
using System;
using System.Linq;

namespace BookshelfMVC.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepo;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepo, IMapper mapper)
        {
            _bookRepo = bookRepo;
            _mapper = mapper;
        }

        public int AddBook(NewBookVm book)
        {
            var newBook = _mapper.Map<Book>(book);
            return _bookRepo.AddBook(newBook);
        }

        public void DeleteBook(int bookId)
        {
            _bookRepo.DeleteBook(bookId);
        }

        public ListBookForListVm GetAllBooksForList(int pageSize, int pageNumber, string searchString)
        {
            var books = _bookRepo.GetAllBooks().Where(p => p.Name.StartsWith(searchString))
                  .ProjectTo<BookForListVm>(_mapper.ConfigurationProvider).ToList();
            var booksToShow = books.Skip(pageSize * (pageNumber - 1)).Take(pageSize);
            var bookList = new ListBookForListVm()
            {
                PageSize = pageSize,
                CurrentPage = pageNumber,
                SearchString = searchString,
                Books = books,
                Count = books.Count
            };
           
            return bookList;
        }

        public BookDetailsVm GetBookDetails(int bookId)
        {
            var book = _bookRepo.GetBook(bookId);
            var bookVm =  _mapper.Map<BookDetailsVm>(book);
            return bookVm;
           
        }

        public NewBookVm GetBookForEdit(int id)
        {
            var book = _bookRepo.GetBook(id);
            return _mapper.Map<NewBookVm>(book);
        }

        public void UpdateBook(NewBookVm model)
        {
            var book = _mapper.Map<Book>(model);
            _bookRepo.UpdateBook(book);
        }
    }
}
