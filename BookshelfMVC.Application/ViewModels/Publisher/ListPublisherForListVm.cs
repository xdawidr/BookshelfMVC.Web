using AutoMapper;
using BookshelfMVC.Application.Mapper;
using System.Collections.Generic;

namespace BookshelfMVC.Application.ViewModels.Publisher
{
    public class ListPublisherForListVm : IMapFrom<BookshelfMVC.Domain.Model.Publisher>
    {
        public List<PublisherForListVm> Publishers { get; set; }
        public int Count { get;set; }
        public int PageSize { get; set; }
        public int CurrentNumber { get; set; }
        public string SearchString { get; set; }
        

        public void Mapping(Profile profile)
            => profile.CreateMap<BookshelfMVC.Domain.Model.Publisher, ListPublisherForListVm>();
    }
}