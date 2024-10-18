using BookStore.Core.Models;
using BookStore.DataAccess.Abstracion;

namespace BookStore.Application.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<List<Book>> GetAllBooks()
    {
        return await _bookRepository.GetBooks();
    }

    public async Task<Guid> CreateBook(Book book)
    {
        return await _bookRepository.CreateBook(book);
    }

    public async Task<Guid> UpdateBook(Guid id, string title, string description, decimal price)
    {
        return await _bookRepository.UpdateBook(id, title, description, price);
    }

    public async Task<Guid> DeleteBook(Guid id)
    {
        return await _bookRepository.DeleteBook(id);
    }
}