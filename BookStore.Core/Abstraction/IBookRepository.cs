using BookStore.Core.Models;

namespace BookStore.DataAccess.Abstracion
{
    public interface IBookRepository
    {
        public Task<List<Book>> GetBooks();
        public Task<Guid> CreateBook(Book book);
        public Task<Guid> UpdateBook(Guid id, string title, string description, decimal price);
        public Task<Guid> DeleteBook(Guid id);
    }
}