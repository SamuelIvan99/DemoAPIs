using APIProject.Models;
using APIProject.Repository.Interfaces;

namespace APIProject.Repository;

public class BookRepository : Repository<Book>, IBookRepository
{
    public BookRepository() : base() { }

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
