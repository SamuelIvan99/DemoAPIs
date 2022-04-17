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

    public static async Task<BookReply> gRPCGetById(int id, string url = "https://localhost:7254")
    {
        using var channel = GrpcChannel.ForAddress(url);
        var client = new CrudBook.CrudBookClient(channel);
        var reply = client.GetById(new BookRequest { Id = id, Title = "" });
        return reply;
    }
}
