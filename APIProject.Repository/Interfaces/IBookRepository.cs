using APIProject.Models;

namespace APIProject.Repository.Interfaces;
public interface IBookRepository : IRepository<Book>
{
    Task<Book?> GetByTitleAsync(string title);

    Task<Book?> GetByAuthorAsync(string author);
}
