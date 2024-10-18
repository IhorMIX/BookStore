using BookStore.Core.Models;
using BookStore.DataAccess.Abstracion;
using BookStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataAccess.Repositories;

public class BookRepository : IBookRepository
{
    private readonly BookStoreDbContext _context;

    public BookRepository(BookStoreDbContext context)
    {
        _context = context;
    }

    public async Task<List<Book>> GetBooks()
    {
        var bookEntities = await _context.Books
            .AsNoTracking()
            .ToListAsync();

        var books = bookEntities
            .Select(i => Book.Create(i.Id, i.Title, i.Description, i.Price).book)
            .ToList();

        return books;
    }

    public async Task<Guid> CreateBook(Book book)
    {
        var bookEntity = new BookEntity
        {
            Id = book.Id,
            Title = book.Title,
            Description = book.Description,
            Price = book.Price
        };
        await _context.Books.AddAsync(bookEntity);
        await _context.SaveChangesAsync();

        return bookEntity.Id;
    }

    public async Task<Guid> UpdateBook(Guid id, string title, string description, decimal price)
    {
        await _context.Books
            .Where(i => i.Id == id)
            .ExecuteUpdateAsync(i => i
                .SetProperty(b => b.Title, b => title)
                .SetProperty(b => b.Description, b => description)
                .SetProperty(b => b.Price, b => price)
            );

        return id;
    }

    public async Task<Guid> DeleteBook(Guid id)
    {
        await _context.Books
            .Where(i => i.Id == id)
            .ExecuteDeleteAsync();
        return id;
    }
}