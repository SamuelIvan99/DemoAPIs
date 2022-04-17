using APIProject.Models;
using APIProject.Repository.Interfaces;
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

        //public override async Task<BooksReply> GetAll(EmptyRequest request, ServerCallContext context)
        //{
        //    var result = await _bookRepository.GetAllAsync();
        //    BooksReply books = new BooksReply { Books = new List<BookReply>() };
        //    return;
        //}

        public override async Task<BookReply> GetById(BookRequest request, ServerCallContext context)
        {
            Book? result = await _bookRepository.GetAsync(request.Id);
            return new BookReply
            {
                Id = result.Id,
                Iban = result.IBAN,
                Title = result.Title,
                Author = result.Author,
                PagesNo = result.PagesNo
            };
        }
    }
}