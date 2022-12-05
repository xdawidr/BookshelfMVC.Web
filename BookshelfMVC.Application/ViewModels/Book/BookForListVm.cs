using AutoMapper;
using BookshelfMVC.Application.Mapper;

namespace BookshelfMVC.Application.ViewModels.Book
{
    public class BookForListVm : IMapFrom<BookshelfMVC.Domain.Model.Book>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
            => profile.CreateMap<BookshelfMVC.Domain.Model.Book, BookForListVm>();
        
    }
}
