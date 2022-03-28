using APIProject.Models;
using APIProject.Repository.Interfaces;

namespace APIProject.Repository;
public class LibraryRepository : Repository<Library>, ILibraryRepository
{
    public LibraryRepository() : base() { }

    public async Task<Library?> GetByNameAsync(string name)
    {
        return await Task.Run(() =>
        {
            return _container.Where(e => e.Name.Equals(name)).FirstOrDefault();
        });
    }
}