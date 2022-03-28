namespace APIProject.Repository.Interfaces;
public interface IRepository<T>
{
    Task<bool> CreateAsync(T entity);

    Task<T> GetAsync(int id);

    Task<bool> UpdateAsync(T entity);

    Task<bool> DeleteAsync(int id);
}

