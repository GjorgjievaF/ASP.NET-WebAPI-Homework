using Class03_homework.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Class03_homework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]  //http://localhost:[port]/api/Books
        public ActionResult<List<Book>> GetAllBooks()
        {
            return Ok(StaticDb.Books);
        }



        [HttpGet("queryString")]   //http://localhost:[port]/api/queryString/1

        //http://localhost:[port]/api/queryString?index=1
        public ActionResult<string> GetBookByIndex(int? index)
        {
            try
            {
                if (index == null)
                {
                    return BadRequest("The index is required");
                }
                if (index < 0)
                {
                    return BadRequest("The index of the book can not be negative number!");
                }
                if (index >= StaticDb.Books.Count)
                {
                    return NotFound($"There is no book with index {index}");
                }

                return Ok(StaticDb.Books[index.Value]);


            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }



        //http://localhost:[port]/api/Notes/multipleQuery
        //http://localhost:[port]/api/Notes/multipleQuery?author=leo%20tolstoy
        //http://localhost:[port]/api/Notes/multipleQuery?title=war%20and%20peace
        //http://localhost:[port]/api/Notes/multipleQuery?text=war%20and%20peace&author=leo%20tolstoy
        //http://localhost:[port]/api/Notes/multipleQuery?priority=leo%20tolstoy&text=war%20and%20peace


        [HttpGet("multipleQuery")]
        public ActionResult<Book> GetBookByAuthorAndTitle(string? author, string? title)
        {
            try
            {
                if (string.IsNullOrEmpty(author) && string.IsNullOrEmpty(title))
                {
                    return BadRequest("You need to send book title or book author!");
                }
                
                if (string.IsNullOrEmpty(author))
                {
                    Book bookWithTitle = StaticDb.Books.FirstOrDefault(x => x.Title.ToLower() == title.ToLower());
                    return Ok(bookWithTitle);
                }
                if (string.IsNullOrEmpty(title))
                {
                    Book bookWithAuthor = StaticDb.Books.FirstOrDefault(x => x.Author.ToLower() == author.ToLower());
                    return Ok(bookWithAuthor);
                }

                Book bookWithAuthorAndTitle = StaticDb.Books.FirstOrDefault(x => x.Title.ToLower() == title.ToLower() && x.Author.ToLower() == author.ToLower());
                
                return Ok(bookWithAuthorAndTitle);
                
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }


        [HttpPost]
        public IActionResult AddNewBook([FromBody] Book book)
        {
            try
            {
                if (book == null)
                {
                    return BadRequest("Book cannot be null!");
                }
                if (string.IsNullOrEmpty(book.Author))
                {
                    return BadRequest("You must enter the author of the book");
                }
                if (string.IsNullOrEmpty(book.Title))
                {
                    return BadRequest("You must enter the title of the book");
                }

                StaticDb.Books.Add(book);
                return StatusCode(StatusCodes.Status201Created,"Book added to the list");

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }


        }



    }
}
