int result = await GetUrlContentLengthAsync();
Console.WriteLine(result);

async Task<int> GetUrlContentLengthAsync()
{
    var client = new HttpClient();
    Task<string> getStringTask = client.GetStringAsync("https://learn.microsoft.com/dotnet");

    DoIndependentWork();

    string contents = await getStringTask;

    return contents.Length;
}

void DoIndependentWork()
{
    Console.WriteLine("Working");
}