using APIProject.Models;

namespace APIProject.Repository
{
    public class Repository<T> where T : Entity
    {
        public IList<T> _container;
        public Repository()
        {
            _container = new List<T>();
        }
        public async Task<bool> CreateAsync(T entity)
        {
            return await Task.Run(() =>
            {
                bool result = false;
                if (!_container.Contains(entity))
                {
                    _container.Add(entity);
                    result = true;
                }

                return result;
            });
        }

        public async Task<T?> GetAsync(int id)
        {
            return await Task.Run(() =>
            {
                return _container.Where(e => e.Id == id).FirstOrDefault();
            });
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            return await Task.Run(async () =>
            {
                bool result = false;
                T? oldEntity = await GetAsync(entity.Id);

                if (oldEntity is not null && !_container.Contains(entity))
                {
                    _container.Remove(oldEntity);
                    _container.Add(entity);
                    result = true;
                }

                return result;
            });
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await Task.Run(async () =>
            {
                T? entity = await GetAsync(id);

                if (entity is null)
                    return false;

                return _container.Remove(entity);
            });
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await Task.Run(() =>
            {
                return new List<T>(_container.OrderBy(t => t.Id));
            });
        }
    }
}
