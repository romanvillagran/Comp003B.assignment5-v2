using Comp003B.assignment5_v2.Models;

namespace Comp003B.assignment5_v2.Data
{
    public class LibraryData
    {
        public static List<Book> Books = new List<Book>
        {
            new Book { Id = 1, Title = "The Fellowship of the Ring", Author = "John Ronald Reuel Tolkien", YearPublished = 1954, IsAvailable = true },
            new Book { Id = 2, Title = "The Hobbit", Author = "John Ronald Rreuel Tolkien", YearPublished = 1937, IsAvailable = false },
            new Book { Id = 3, Title = "Berserk", Author = "Kentaro Miura", YearPublished = 1989, IsAvailable = true }
        };
    }
}
