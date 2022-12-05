using AutoMapper;
using BookshelfMVC.Application.Mapper;
using BookshelfMVC.Application.ViewModels.Publisher;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookshelfMVC.Application.ViewModels.Writer
{
    public class ListWriterForListVm : IMapFrom<BookshelfMVC.Domain.Model.Writer>
    {
        public List<WriterForListVm> Writers { get; set; }
        public int Count { get; set; }
        public int PageSize { get; set; }
        public int CurrentNumber { get; set; }
        public string SearchString { get; set; }


        public void Mapping(Profile profile)
            => profile.CreateMap<BookshelfMVC.Domain.Model.Writer, ListWriterForListVm>();
    }
}
