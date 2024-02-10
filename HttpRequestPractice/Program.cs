using System.Text.Json;

namespace HttpRequestPractice;

using System.Net.Http.Headers;

class Program
{
    static async Task ProcessRepositoriesAsync(HttpClient client)
    {
        await using Stream stream = await client.GetStreamAsync(
            "https://www.thecocktaildb.com/api/json/v1/1/search.php?s=margarita");

        var reposiotries = await JsonSerializer.DeserializeAsync<List<Repository>>(stream);


        foreach (var repo in reposiotries ?? Enumerable.Empty<Repository>())
            Console.Write(repo.strDrinks);
    }

    static async Task Main(string[] args)
    {
        using HttpClient client = new();

        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        client.DefaultRequestHeaders.Add("User-Agent", "Cocktail-Retriever-dog");

        await ProcessRepositoriesAsync(client);
    }
}