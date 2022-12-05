using AutoMapper;
using BookshelfMVC.Application.Mapper;

namespace BookshelfMVC.Application.ViewModels.Book
{
    public class BookDetailsVm : IMapFrom<BookshelfMVC.Domain.Model.Book>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int PrintLength { get; set; }
        public string Language { get; set; }
        public int YearOfPublish { get; set; }

        public void Mapping(Profile profile)
           => profile.CreateMap<BookshelfMVC.Domain.Model.Book, BookDetailsVm>();
    }
}
