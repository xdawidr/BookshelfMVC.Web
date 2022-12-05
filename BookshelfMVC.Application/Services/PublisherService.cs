using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookshelfMVC.Application.Interfaces;
using BookshelfMVC.Application.ViewModels.Publisher;
using BookshelfMVC.Domain.Interfaces;
using BookshelfMVC.Domain.Model;
using System.Collections.Generic;
using System.Linq;


namespace BookshelfMVC.Application.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository _publisherRepo;
        private readonly IMapper _mapper;

        public PublisherService(IPublisherRepository publisherRepo, IMapper mapper)
        {
            _publisherRepo = publisherRepo;
            _mapper = mapper;
        }

        public int AddPublisher(NewPublisherVm publisher)
        {
            var newPublisher = _mapper.Map<Publisher>(publisher);
            return _publisherRepo.AddPublisher(newPublisher);
            
        }

        public void DeletePublisher(int id)
        {
            _publisherRepo.DeletePublisher(id);
        }

        public ListPublisherForListVm GetAllPublishersForList(int pageSize, int pageNumber, string searchString)
        {
            var publishers = _publisherRepo.GetAllActivePublishers().Where(p => p.Name.StartsWith(searchString))
                .ProjectTo<PublisherForListVm>(_mapper.ConfigurationProvider).ToList();
            var publishersToShow = publishers.Skip(pageSize * (pageNumber - 1)).Take(pageSize);
            var publisherList = new ListPublisherForListVm()
            {
                PageSize = pageSize,
                CurrentNumber = pageNumber,
                SearchString = searchString,
                Publishers = publishers,
                Count = publishers.Count
            };
          
            return publisherList;
        }

        public PublisherDetailsVm GetPublisherDetails(int publisherId)
        {
            var publisher = _publisherRepo.GetPublisher(publisherId);
            return _mapper.Map<PublisherDetailsVm>(publisher);
        }

        public NewPublisherVm GetPublisherForEdit(int id)
        {
            var publisher = _publisherRepo.GetPublisher(id);
            return _mapper.Map<NewPublisherVm>(publisher);
        }

        public void UpdatePublisher(NewPublisherVm model)
        {
            var publisher = _mapper.Map<Publisher>(model);
            _publisherRepo.UpdatePublisher(publisher);
        }
    }
}
