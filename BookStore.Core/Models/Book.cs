namespace BookStore.Core.Models;

public class Book
{
    private const int MAX_TITLE_LENGHT = 250;
    private Book(Guid id, string title, string description, decimal price)
    {
        Id = id;
        Title = title;
        Description = description;
        Price = price;
    }
    public Guid Id { get; }
    
    public string Title { get; } = string.Empty;
    
    public string Description { get; } = string.Empty;
    
    public decimal Price { get; }

    public static (Book book, string Error) Create(Guid id, string title, string description, decimal price)
    {
        var error = string.Empty;
        if (string.IsNullOrEmpty(title) || title.Length > MAX_TITLE_LENGHT)
        {
            error = "Title can not be more than 250 symbols";
        }
        
        var book = new Book(id, title, description, price);
        return (book, error);
    }
    
}