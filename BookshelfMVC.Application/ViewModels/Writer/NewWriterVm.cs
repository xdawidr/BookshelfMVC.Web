using AutoMapper;
using BookshelfMVC.Application.Mapper;
using BookshelfMVC.Application.ViewModels.Book;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookshelfMVC.Application.ViewModels.Writer
{
    public class NewWriterVm : IMapFrom<BookshelfMVC.Domain.Model.Writer>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
            => profile.CreateMap<NewWriterVm, BookshelfMVC.Domain.Model.Writer>().ReverseMap();

        public class NewWriterValidation : AbstractValidator<NewWriterVm>
        {
            public NewWriterValidation()
            {
                RuleFor(x => x.Id).NotNull();
                RuleFor(x => x.Name).NotEmpty().MaximumLength(255);
            }
        }
    }
}
