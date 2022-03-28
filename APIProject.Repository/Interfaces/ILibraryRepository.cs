using APIProject.Models;

namespace APIProject.Repository.Interfaces;
public interface ILibraryRepository : IRepository<Library>
{
    Task<Library> GetByNameAsync(string name);
}
