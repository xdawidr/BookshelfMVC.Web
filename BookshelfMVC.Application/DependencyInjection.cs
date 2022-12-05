using BookshelfMVC.Application.Interfaces;
using BookshelfMVC.Application.Services;
using BookshelfMVC.Application.ViewModels.Publisher;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using static BookshelfMVC.Application.ViewModels.Publisher.NewPublisherVm;

namespace BookshelfMVC.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IPublisherService, PublisherService>();
            services.AddTransient<IWriterService, WriterService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<IValidator<NewPublisherVm>, NewPublisherValidation>();
            return services;
        }
    }
}
