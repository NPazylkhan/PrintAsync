var tomTask = PrintNameAsync("Tom");
var bobTask = PrintNameAsync("Bob");
var samTask = PrintNameAsync("Sam");

var watch = System.Diagnostics.Stopwatch.StartNew();
await tomTask;
await bobTask;
await samTask;
watch.Stop();
var elapsedMs = (int)(watch.ElapsedMilliseconds) / 1000;
Console.WriteLine(elapsedMs);
Console.WriteLine();

var watch2 = System.Diagnostics.Stopwatch.StartNew();
await PrintNameAsync("Tom");
await PrintNameAsync("Bob");
await PrintNameAsync("Sam");
watch.Stop();
var elapsedMs2 = (int)(watch2.ElapsedMilliseconds) / 1000;
Console.WriteLine(elapsedMs2);


// определение асинхронного метода
async Task PrintNameAsync(string name)
{
    await Task.Delay(3000);     // имитация продолжительной работы
    Console.WriteLine(name);
}

Console.WriteLine();
await PrintAsync();   // вызов асинхронного метода
Console.WriteLine("Некоторые действия в методе Main");

void Print()
{
    Thread.Sleep(3000);     // имитация продолжительной работы
    Console.WriteLine("Hello METANIT.COM");
}

// определение асинхронного метода
async Task PrintAsync()
{
    Console.WriteLine("Начало метода PrintAsync"); // выполняется синхронно
    await Task.Run(() => Print());                // выполняется асинхронно
    Console.WriteLine("Конец метода PrintAsync");
}

Console.WriteLine("\n\n\n");
// определяем и запускаем задачи
var task1 = PrintAsync2("Hello C#");
var task2 = PrintAsync2("Hello World");
var task3 = PrintAsync2("Hello METANIT.COM");

// ожидаем завершения хотя бы одной задачи
await Task.WhenAll(task1, task2, task3);
Console.WriteLine();
async Task PrintAsync2(string message)
{
    await Task.Delay(new Random().Next(1000, 2000));     // имитация продолжительной операции
    Console.WriteLine(message);
}

var task22 = PrintAsync22("Hello Metanit.com"); // задача начинает выполняться
Console.WriteLine("Main Works");

await task22; // ожидаем завершения задачи

// определение асинхронного метода
async Task PrintAsync22(string message)
{
    await Task.Delay(0);
    Console.WriteLine(message);
}
Console.WriteLine();

var square5 = SquareAsync(5);
var square6 = SquareAsync(6);

Console.WriteLine("Остальные действия в методе Main");

int n1 = await square5;
int n2 = await square6;
Console.WriteLine($"n1={n1}  n2={n2}"); // n1=25  n2=36

async Task<int> SquareAsync(int n)
{
    await Task.Delay(0);
    var result = n * n;
    Console.WriteLine($"Квадрат числа {n} равен {result}");
    return result;
}