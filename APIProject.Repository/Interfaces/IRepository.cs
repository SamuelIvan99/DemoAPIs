namespace APIProject.Repository.Interfaces;
public interface IRepository<T>
{
    Task<bool> CreateAsync(T entity);

    Task<T?> GetAsync(string id);

    Task<bool> UpdateAsync(T entity);

    Task<bool> DeleteAsync(string id);

    Task<IList<T>> GetAllAsync();
}

