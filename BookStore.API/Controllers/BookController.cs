using BookStore.API.Contracts;
using BookStore.Core.Models;
using BookStore.DataAccess.Abstracion;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookSerivce;

    public BookController(IBookService bookService)
    {
        _bookSerivce = bookService;
    }

    [HttpGet]
    public async Task<ActionResult<List<BookResponse>>> GetBooks()
    {
        var books = await _bookSerivce.GetAllBooks();

        var response = books.Select(b => new BookResponse(
            b.Id,
            b.Title,
            b.Description,
            b.Price));
        
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateBook([FromBody] BookRequest bookRequest)
    {
        var (book, error) = Book.Create(
            Guid.NewGuid(),
            bookRequest.Title,
            bookRequest.Description,
            bookRequest.Price);
        if (!string.IsNullOrEmpty(error))
        {
            return BadRequest(error);
        }

        await _bookSerivce.CreateBook(book);
        return Ok(book);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<Guid>> UpdateBook(Guid id, [FromBody] BookRequest bookRequest)
    {
        var bookId = await _bookSerivce.UpdateBook(
            id,
            bookRequest.Title, 
            bookRequest.Description,
            bookRequest.Price);
        return Ok(bookId);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Guid>> DeleteBook(Guid id)
    {
        return Ok(await _bookSerivce.DeleteBook(id));
    }
}