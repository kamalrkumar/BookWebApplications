using BookWebAPI.Model;
using BookWebAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BooksDBContext _dbContext;

        public BooksController(BooksDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        //GET : /books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Books>>> GetBooks()
        {
            return await _dbContext.books.ToListAsync();
        }


        //GET: /books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Books>> GetBook(int id)
        {
            var book = await _dbContext.books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        //POST: /books
        [HttpPost]
        public async Task<ActionResult<Books>> PostBook(Books book)
        {
            _dbContext.books.Add(book);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetBooks", new { id = book.BookId }, book);
        }

        //PUT: /books/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Books book)
        {
            if (id != book.BookId)
            {
                return BadRequest();
            }

            _dbContext.Entry(book).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BooksExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool BooksExists(int id)
        {
            return _dbContext.books.Any(e => e.BookId == id);
        }
    }
}
