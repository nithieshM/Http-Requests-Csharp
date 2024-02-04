namespace HttpRequestPractice;
using System.Net.Http.Headers;

class Program
{
    public static async Task Main(string[] args)
    {
        using HttpClient client = new();
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
        client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
    
        await ProcessRepositoriesAsync(client);
    }
    static async Task ProcessRepositoriesAsync(HttpClient client)
    {
        var json = await client.GetStringAsync("https://api.github.com/orgs/dotnet/repos");
        
        Console.Write(json);
    }
}