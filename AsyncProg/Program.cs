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

async Task<int> GetTaskOfResultAsync()
{
    int hours = 0;
    await Task.Delay(0);

    return hours;
}

Task<int> returnedTaskTResult = GetTaskOfResultAsync();
int intResult = await returnedTaskTResult;
Console.WriteLine(intResult);
// int intResult = await GetTaskOfResultAsync();

async Task GetTaskAsync()
{
    await Task.Delay(0);
}

Task returnedTask = GetTaskAsync();
await returnedTask;
// await GetTaskAsync();

static async Task DisplayCurrentInfoAsync()
{
    await WaitAndApologizeAsync();

    Console.WriteLine($"Today is {DateTime.Now:D}");
    Console.WriteLine($"The current time is {DateTime.Now.TimeOfDay:t}");
    Console.WriteLine("The current temperature is 76 degrees.");
}

static async Task WaitAndApologizeAsync()
{
    Console.WriteLine("First for the delay...\n");

    await Task.Delay(2000);

    Console.WriteLine("Sorry for the delay...\n");
}

Task currentTask = DisplayCurrentInfoAsync();
Console.WriteLine("Yield control to caller...\n");
await currentTask;

Console.ReadLine();