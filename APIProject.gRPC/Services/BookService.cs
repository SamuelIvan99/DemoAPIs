using APIProject.gRPC.Repository;
using Grpc.Core;

namespace APIProject.gRPC.Services
{
    public class BookService : CrudBook.CrudBookBase
    {
        private readonly ILogger<BookService> _logger;
        private IBookRepository _bookRepository;
        public BookService(ILogger<BookService> logger, IBookRepository bookRepository)
        {
            _logger = logger;
            _bookRepository = bookRepository;
        }

        public override async Task<Book> GetById(Book request, ServerCallContext context)
        {
            var result = await _bookRepository.GetAsync(request.Iban);
            if (result is null)
                return new Book { Iban = "", Title = "", Author = "", PagesNo = 0 };
            else
                return result;
        }

        public override async Task<Book> GetByTitle(Book request, ServerCallContext context)
        {
            var result = await _bookRepository.GetByTitleAsync(request.Title);
            if (result is null)
                return new Book { Iban = "", Title = "", Author = "", PagesNo = 0 };
            else
                return result;
        }

        public override async Task<Reply> Create(Book request, ServerCallContext context)
        {
            var result = await _bookRepository.CreateAsync(request);
            if (result)
                return new Reply { Message = "Book created successfully." };
            else
                return new Reply { Message = "Failed to create a Book entity." };
        }
    }
}