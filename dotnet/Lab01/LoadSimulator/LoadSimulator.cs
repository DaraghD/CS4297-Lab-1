using System;
using System.Threading.Tasks;
using System.Net.Http;
class LoadSimulator
{
    static async Task Main(string[] args)
    {
        using var client = new HttpClient();
        var tasks = new Task[50];
        for (int i = 0; i < 50; i++)
        {
            tasks[i] = Task.Run(async () =>
            {
                try
                {
                    var response = await client.GetStringAsync("http://localhost:5280/hello");
                    Console.WriteLine(response);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            });
        }
        await Task.WhenAll(tasks);
    }
}