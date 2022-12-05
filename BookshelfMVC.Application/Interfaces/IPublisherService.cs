using BookshelfMVC.Application.ViewModels.Publisher;

namespace BookshelfMVC.Application.Interfaces
{
    public interface IPublisherService
    {
        ListPublisherForListVm GetAllPublishersForList(int pageSize, int pageNumber, string searchString);
        int AddPublisher(NewPublisherVm publisher);
        PublisherDetailsVm GetPublisherDetails(int publisherId);
        void DeletePublisher(int id);
        NewPublisherVm GetPublisherForEdit(int id);
        void UpdatePublisher(NewPublisherVm model);

    }
}
