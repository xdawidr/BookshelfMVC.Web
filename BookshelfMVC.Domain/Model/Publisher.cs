using System.Collections.Generic;

namespace BookshelfMVC.Domain.Model
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NIP { get; set; }
        public bool IsActive { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<Book> Books { get; set; }


    }
}