using AutoMapper;
using BookshelfMVC.Application.Mapper;

namespace BookshelfMVC.Application.ViewModels.Publisher
{
    public class PublisherForListVm : IMapFrom<BookshelfMVC.Domain.Model.Publisher>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NIP { get; set; }

        
        public void Mapping(Profile profile)
            => profile.CreateMap<BookshelfMVC.Domain.Model.Publisher, PublisherForListVm>();
               
    }
}
