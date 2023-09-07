using System.Text;
using Newtonsoft.Json;

if (args.Length > 0)
{
    HttpClient client = new HttpClient();

    client.DefaultRequestHeaders.Add("authorization", "Bearer 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");

    var content = new StringContent(
        "{\"model\": \"text-davinci-001\", \"prompt\": \""+ args[0] +"\",\"temperature\": 1,\"max_tokens\": 100}",
        Encoding.UTF8,
        "application/json"
    );

    HttpResponseMessage response = await client.PostAsync("https://api.openai.com/v1/completions", content);

    string responseString = await response.Content.ReadAsStringAsync();

    try
    {
        var dyData = JsonConvert.DeserializeObject<dynamic>(responseString);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"---> API Response is: {dyData.choices[0].text}");
        Console.ResetColor();
    }
    catch (Exception e)
    {
        Console.WriteLine($"---> Could not deserialize the JSON: {e.Message}");
    }
    
}
else
{
    Console.WriteLine("---> You need to provide some input");
}
