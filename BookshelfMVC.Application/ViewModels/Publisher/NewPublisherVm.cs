using AutoMapper;
using BookshelfMVC.Application.Mapper;
using FluentValidation;

namespace BookshelfMVC.Application.ViewModels.Publisher
{
    public class NewPublisherVm : IMapFrom<BookshelfMVC.Domain.Model.Publisher>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NIP { get; set; }

        public void Mapping(Profile profile)
           => profile.CreateMap<NewPublisherVm, BookshelfMVC.Domain.Model.Publisher>().ReverseMap();

        public class NewPublisherValidation : AbstractValidator<NewPublisherVm>
        {
            public NewPublisherValidation()
            {
                RuleFor(x => x.Id).NotNull();
                RuleFor(x => x.Name).NotEmpty().MaximumLength(255);
                RuleFor(x => x.NIP).NotEmpty().Length(10);
            }
        }
    }
}
