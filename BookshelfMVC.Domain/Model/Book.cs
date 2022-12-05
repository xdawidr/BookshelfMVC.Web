namespace BookshelfMVC.Domain.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int PrintLength { get; set; }
        public string Language { get; set; }
        public int YearOfPublish { get; set; }

        public int WriterId { get; set; }
        public virtual Writer Writer { get; set; }
        public int PublisherId { get; set; }
        public virtual Publisher Publisher { get; set; }
    }
}
