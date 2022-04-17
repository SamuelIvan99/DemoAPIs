namespace APIProject.gRPC.Repository;

public interface IBookRepository
{
    Task<bool> CreateAsync(Book entity);

    Task<Book?> GetAsync(string id);

    Task<Book?> GetByTitleAsync(string title);

    Task<IList<Book>> GetAllAsync();
}
