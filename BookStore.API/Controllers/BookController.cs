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
}