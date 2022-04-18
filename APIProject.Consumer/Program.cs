using APIProject.Consumer;

Console.WriteLine("REST API Demo");
Console.WriteLine("------------------------------------------");


//var restBook = await APIConsumer.RESTGetById(id: "1");
//Console.WriteLine($"Book - IBAN: {restBook?.IBAN}, Title: {restBook?.Title}, Author: {restBook?.Author}, Pages: {restBook?.PagesNo}");

//restBook = new APIProject.Consumer.Models.Book { IBAN = "1", Title = "Book1", Author = "Author1", PagesNo = 100 };
//var restResult = await APIConsumer.RESTCreate(restBook);
//Console.WriteLine($"Created: {restResult}");

//var restBook1 = await APIConsumer.RESTGetById(id: "1");
//Console.WriteLine($"Book - IBAN: {restBook1?.IBAN}, Title: {restBook1?.Title}, Author: {restBook1?.Author}, Pages: {restBook1?.PagesNo}");
await PerformanceTest.testRESTCreate();

Console.WriteLine("------------------------------------------");
Console.WriteLine("\n");

Console.WriteLine("gRPC API Demo");
Console.WriteLine("------------------------------------------");
//var grpcBook = await APIConsumer.gRPCGetById(id: "1");
//Console.WriteLine($"Book - IBAN: {grpcBook?.Iban}, Title: {grpcBook?.Title}, Author: {grpcBook?.Author}, Pages: {grpcBook?.PagesNo}");

//grpcBook = new Book { Iban = "1", Title = "Book1", Author = "Author1", PagesNo = 100 };
//var grpcResult = await APIConsumer.gRPCCreate(grpcBook);
//Console.WriteLine(grpcResult);

//var grpcBook1 = await APIConsumer.gRPCGetById(id: "1");
//Console.WriteLine($"Book - IBAN: {grpcBook1?.Iban}, Title: {grpcBook1?.Title}, Author: {grpcBook1?.Author}, Pages: {grpcBook1?.PagesNo}");

Console.WriteLine("------------------------------------------");
Console.WriteLine("\n");