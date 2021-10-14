using System;

namespace BookService.Database.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }
        public bool IsReserved { get; set; }
    }
}
