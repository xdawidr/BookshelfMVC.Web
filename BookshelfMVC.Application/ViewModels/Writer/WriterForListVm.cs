using AutoMapper;
using BookshelfMVC.Application.Mapper;
using BookshelfMVC.Application.ViewModels.Publisher;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookshelfMVC.Application.ViewModels.Writer
{
    public class WriterForListVm : IMapFrom<BookshelfMVC.Domain.Model.Writer>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
            => profile.CreateMap<BookshelfMVC.Domain.Model.Writer, WriterForListVm>();
    }
}
