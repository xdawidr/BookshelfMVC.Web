using BookshelfMVC.Domain.Interfaces;
using BookshelfMVC.Domain.Model;
using System.Linq;

namespace BookshelfMVC.Infrastructure.Repositories
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly Context _context;
        public PublisherRepository(Context context)
        {
            _context = context;
        }

        public int AddPublisher(Publisher publisher)
        {
            _context.Publishers.Add(publisher);
            _context.SaveChanges();
            return publisher.Id;
        }

        public void DeletePublisher(int id)
        {
            var publisher = _context.Publishers.Find(id);
            if (publisher != null)
            {
                _context.Publishers.Remove(publisher);
                _context.SaveChanges();
            }
        }

        public IQueryable<Publisher> GetAllActivePublishers()
        {
            return _context.Publishers.Where(p => p.IsActive);
        }

        public Publisher GetPublisher(int id)
        {
            return _context.Publishers.FirstOrDefault(p => p.Id == p.Id);
        }

        public void UpdatePublisher(Publisher publisher)
        {
            _context.Attach(publisher);
            _context.Entry(publisher).Property("Name").IsModified = true;
            _context.Entry(publisher).Property("NIP").IsModified = true;
            _context.SaveChanges();
        }
    }
}
