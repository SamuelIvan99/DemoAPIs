namespace APIProject.gRPC.Repository;

public class BookRepository : IBookRepository
{
    public IList<Book> _container;
    public BookRepository()
    {
        _container = new List<Book>()
        {
            new Book { Iban = Guid.NewGuid().ToString(), Title = "Book1", Author = "Author1", PagesNo = 100 },
            new Book { Iban = Guid.NewGuid().ToString(), Title = "Book2", Author = "Author2", PagesNo = 200 },
            new Book { Iban = Guid.NewGuid().ToString(), Title = "Book3", Author = "Author3", PagesNo = 300 },
            new Book { Iban = Guid.NewGuid().ToString(), Title = "Book4", Author = "Author4", PagesNo = 400 },
            new Book { Iban = Guid.NewGuid().ToString(), Title = "Book5", Author = "Author5", PagesNo = 500 }
        };
    }
    public async Task<bool> CreateAsync(Book entity)
    {
        return await Task.Run(() =>
        {
            bool result = false;
            if (_container.Where(b => entity.Iban.Equals(b.Iban)).Count() < 1)
            {
                _container.Add(entity);
                result = true;
            }

            return result;
        });
    }

    public async Task<Book?> GetAsync(string id)
    {
        return await Task.Run(() =>
        {
            return _container.Where(e => e.Iban.Equals(id)).FirstOrDefault();
        });
    }

    public async Task<IList<Book>> GetAllAsync()
    {
        return await Task.Run(() =>
        {
            return new List<Book>(_container.OrderBy(t => t.Title));
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
