using APIProject.Consumer;
string responseREST = await APIConsumer.ConsumeREST(url: "https://localhost:7206/api/book");
Console.WriteLine(responseREST);
