using APIProject.Models;
using APIProject.Repository.Interfaces;

namespace APIProject.Repository;

public class BookRepository : Repository<Book>, IBookRepository
{
    public BookRepository() : base()
    {
        _container.Add(new Book { Id = 1, IBAN = Guid.NewGuid().ToString(), Title = "Book1", Author = "Author1", PagesNo = 100 });
        _container.Add(new Book { Id = 2, IBAN = Guid.NewGuid().ToString(), Title = "Book2", Author = "Author2", PagesNo = 200 });
        _container.Add(new Book { Id = 3, IBAN = Guid.NewGuid().ToString(), Title = "Book3", Author = "Author3", PagesNo = 300 });
        _container.Add(new Book { Id = 4, IBAN = Guid.NewGuid().ToString(), Title = "Book4", Author = "Author4", PagesNo = 400 });
        _container.Add(new Book { Id = 5, IBAN = Guid.NewGuid().ToString(), Title = "Book5", Author = "Author5", PagesNo = 500 });
    }

    public async Task<Book?> GetByAuthorAsync(string author)
    {
        return await Task.Run(() =>
        {
            return _container.Where(e => e.Author.Equals(author)).FirstOrDefault();
        });
    }

    public async Task<Book?> GetByTitleAsync(string title)
    {
        return await Task.Run(() =>
        {
            return _container.Where(e => e.Title.Equals(title)).FirstOrDefault();
        });
    }
}
