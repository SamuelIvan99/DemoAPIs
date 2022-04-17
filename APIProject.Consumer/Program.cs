using APIProject.Consumer;

Console.WriteLine("Hello World!");

//string responseREST = await APIConsumer.ConsumeREST(url: "api/book");
//Console.WriteLine(responseREST);

var book = await APIConsumer.gRPCGetById(id: 1);
Console.WriteLine($"Id: {book.Id}, IBAN: {book.Iban}, Title: {book.Title}, Author: {book.Author}, Pages: {book.PagesNo}");
