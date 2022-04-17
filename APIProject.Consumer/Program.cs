using APIProject.Consumer;

Console.WriteLine("Hello World!");

//string responseREST = await APIConsumer.ConsumeREST(url: "api/book");
//Console.WriteLine(responseREST);

var book = await APIConsumer.gRPCGetById(id: "1");
Console.WriteLine($"Book - IBAN: {book?.Iban}, Title: {book?.Title}, Author: {book?.Author}, Pages: {book?.PagesNo}");

book = new Book { Iban = "1", Title = "Book1", Author = "Author1", PagesNo = 100 };
var result = await APIConsumer.gRPCCreate(book);
Console.WriteLine(result);

var book1 = await APIConsumer.gRPCGetById(id: "1");
Console.WriteLine($"Book - IBAN: {book1?.Iban}, Title: {book1?.Title}, Author: {book1?.Author}, Pages: {book1?.PagesNo}");
