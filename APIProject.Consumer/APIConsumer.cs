using Grpc.Net.Client;
using System.Text;
using System.Text.Json;

namespace APIProject.Consumer;

public static class APIConsumer
{
    private const string REST_URL = "https://localhost:7206";
    private const string GRPC_URL = "https://localhost:7254";
    public static async Task<APIProject.Consumer.Models.Book?> RESTGetById(string id)
    {
        using HttpClient client = new HttpClient();
        string endpoint = $"api/book/{id}";
        var response = await client.GetAsync($"{REST_URL}/{endpoint}");

        var content = await response.Content.ReadAsStringAsync();
        APIProject.Consumer.Models.Book? book = JsonSerializer.Deserialize<APIProject.Consumer.Models.Book>(content);
        return book;
    }

    public static async Task<string> RESTCreate(APIProject.Consumer.Models.Book book)
    {
        using HttpClient client = new HttpClient();
        string endpoint = $"api/book";

        var jsonBook = JsonSerializer.Serialize<APIProject.Consumer.Models.Book>(book);
        var content = new StringContent(jsonBook, Encoding.UTF8, "application/json");
        var response = await client.PostAsync($"{REST_URL}/{endpoint}", content);
        return await response.Content.ReadAsStringAsync();
    }

    public static async Task<APIProject.Consumer.Book> gRPCGetById(string id)
    {
        using var channel = GrpcChannel.ForAddress(GRPC_URL);
        var client = new CrudBook.CrudBookClient(channel);
        var reply = await client.GetByIdAsync(new Book { Iban = id, Title = "", Author = "", PagesNo = 0 });
        return reply;
    }

    public static async Task<string> gRPCCreate(APIProject.Consumer.Book book)
    {
        using var channel = GrpcChannel.ForAddress(GRPC_URL);
        var client = new CrudBook.CrudBookClient(channel);
        var reply = await client.CreateAsync(book);
        return reply.Message;
    }
}
