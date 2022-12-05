using BookshelfMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookshelfMVC.Domain.Interfaces
{
    public interface IWriterRepository
    {
        IQueryable<Writer> GetAllWriters();
        Writer GetWriter(int id);
        int AddWriter(Writer writer);
        void UpdateWriter(Writer writer);
        void DeleteWriter(int id);
    }
}
