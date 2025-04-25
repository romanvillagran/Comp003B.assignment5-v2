using Comp003B.assignment5_v2.Data;
using Comp003B.assignment5_v2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Comp003B.assignment5_v2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class LibraryController : Controller
    {

        [HttpGet]
        public ActionResult<List<Book>> GetAllBooks()
        {

            return Ok(LibraryData.Books);
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int id)
        {
            var book = LibraryData.Books.Find(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }


            return Ok(book);
        }

        [HttpPost]
        public ActionResult<Book> AddBook(Book newBook)
        {
            if (newBook == null || string.IsNullOrEmpty(newBook.Title))
            {
                return BadRequest("Book needs a title!");
            }

            newBook.Id = LibraryData.Books.Max(b => b.Id) + 1;

            LibraryData.Books.Add(newBook);

            return CreatedAtAction(nameof(GetBook), new { id = newBook.Id }, newBook);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, Book updatedBook)
        {

            if (id != updatedBook.Id)
            {
                return BadRequest("ID mismatch!");
            }


            var existingBook = LibraryData.Books.Find(b => b.Id == id);


            if (existingBook == null)
            {
                return NotFound();
            }


            existingBook.Title = updatedBook.Title;
            existingBook.Author = updatedBook.Author;
            existingBook.YearPublished = updatedBook.YearPublished;
            existingBook.IsAvailable = updatedBook.IsAvailable;


            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = LibraryData.Books.Find(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            LibraryData.Books.Remove(book);

            return NoContent();
        }

    }
}
