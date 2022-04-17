using Grpc.Net.Client;

namespace APIProject.Consumer;

public static class APIConsumer
{
    public static async Task<string> ConsumeREST(string url = "https://localhost:7206")
    {
        HttpClient client = new HttpClient();
        var response = await client.GetAsync(url);
        return await response.Content.ReadAsStringAsync();
    }

    public static async Task<Book?> gRPCGetById(string id, string url = "https://localhost:7254")
    {
        using var channel = GrpcChannel.ForAddress(url);
        var client = new CrudBook.CrudBookClient(channel);
        var reply = await client.GetByIdAsync(new Book { Iban = id, Title = "", Author = "", PagesNo = 0 });
        return reply;
    }

    public static async Task<string> gRPCCreate(Book book, string url = "https://localhost:7254")
    {
        using var channel = GrpcChannel.ForAddress(url);
        var client = new CrudBook.CrudBookClient(channel);
        var reply = await client.CreateAsync(book);
        return reply.Message;
    }
}
