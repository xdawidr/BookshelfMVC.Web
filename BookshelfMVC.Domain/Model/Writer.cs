using System.Collections.Generic;

namespace BookshelfMVC.Domain.Model
{
    public class Writer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }

    }
}
