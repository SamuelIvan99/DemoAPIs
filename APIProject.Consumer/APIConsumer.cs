namespace APIProject.Consumer;

public static class APIConsumer
{
    public static async Task<string> ConsumeREST(string url)
    {
        HttpClient client = new HttpClient();
        var response = await client.GetAsync(url);
        return await response.Content.ReadAsStringAsync();
    }
}
