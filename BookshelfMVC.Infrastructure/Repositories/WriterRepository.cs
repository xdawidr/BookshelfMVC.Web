using BookshelfMVC.Domain.Interfaces;
using BookshelfMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookshelfMVC.Infrastructure.Repositories
{
    public class WriterRepository : IWriterRepository
    {
        private readonly Context _context;

        public WriterRepository(Context context)
        {
            _context = context;
        }

        public int AddWriter(Writer writer)
        {
            _context.Writers.Add(writer);
            _context.SaveChanges();
            return writer.Id;
        }

        public void DeleteWriter(int id)
        {
            var writer = _context.Writers.Find(id);
            if (writer != null)
            {
                _context.Writers.Remove(writer);
                _context.SaveChanges();
            }
            
        }

        public IQueryable<Writer> GetAllWriters()
        {
            return _context.Writers;
        }

        public Writer GetWriter(int id)
        {
           return _context.Writers.FirstOrDefault(w => w.Id == w.Id);
        }

        public void UpdateWriter(Writer writer)
        {
            _context.Writers.Attach(writer);
            _context.Entry(writer).Property("Name").IsModified = true;
            _context.SaveChanges();
        }
    }
}
