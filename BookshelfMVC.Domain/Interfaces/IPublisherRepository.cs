using BookshelfMVC.Domain.Model;
using System.Linq;

namespace BookshelfMVC.Domain.Interfaces
{
    public interface IPublisherRepository
    {
        IQueryable<Publisher> GetAllActivePublishers();
        Publisher GetPublisher(int id);
        int AddPublisher(Publisher publisher);
        void UpdatePublisher(Publisher publisher);
        void DeletePublisher(int id);
    }
}
