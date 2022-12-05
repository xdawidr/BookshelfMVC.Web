using AutoMapper;
using BookshelfMVC.Application.Mapper;
using FluentValidation;

namespace BookshelfMVC.Application.ViewModels.Book
{
    public class NewBookVm : IMapFrom<BookshelfMVC.Domain.Model.Book>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
            => profile.CreateMap<NewBookVm, BookshelfMVC.Domain.Model.Book>().ReverseMap();

        public class NewBookValidation : AbstractValidator<NewBookVm>
        {
            public NewBookValidation()
            {
                RuleFor(x => x.Id).NotNull();
                RuleFor(x => x.Name).NotEmpty().MaximumLength(255);
            }
        }
    }
}
