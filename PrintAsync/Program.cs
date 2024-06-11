//commited changes

using System.Diagnostics;
/***************************************************************/
async Task PrintNameAsync(string name)
{
    await Task.Delay(3000);     
    Console.WriteLine(name);
}

/* 1 */

var tomTask = PrintNameAsync("Tom");
var bobTask = PrintNameAsync("Bob");
var samTask = PrintNameAsync("Sam");

var watch = Stopwatch.StartNew();
await tomTask;
await bobTask;
await samTask;
watch.Stop();
var elapsedMs = (int)(watch.ElapsedMilliseconds) / 1000;
Console.WriteLine(elapsedMs);
Console.WriteLine();


/* 2 */

var watch2 = Stopwatch.StartNew();
await PrintNameAsync("Tom");
await PrintNameAsync("Bob");
await PrintNameAsync("Sam");
watch.Stop();
var elapsedMs2 = (int)(watch2.ElapsedMilliseconds) / 1000;
Console.WriteLine(elapsedMs2);
Console.WriteLine();

/***************************************************************/
/***************************************************************/
/***************************************************************/

await PrintAsync();  
Console.WriteLine("Некоторые действия в методе Main");

void Print()
{
    Thread.Sleep(3000);     
    Console.WriteLine("Hello METANIT.COM");
}

async Task PrintAsync()
{
    Console.WriteLine("Начало метода PrintAsync"); 
    await Task.Run(() => Print());                
    Console.WriteLine("Конец метода PrintAsync");
}

/***************************************************************/
/***************************************************************/
/***************************************************************/

Console.WriteLine();
var task1 = PrintAsync2("1");
var task2 = PrintAsync2("2");
var task3 = PrintAsync2("3");

await Task.WhenAll(task1, task2, task3);
Console.WriteLine();

async Task PrintAsync2(string message)
{
    await Task.Delay(new Random().Next(1000, 2000));
    Console.WriteLine(message);
}

/***************************************************************/
/***************************************************************/
/***************************************************************/

var task22 = PrintAsync22("1");
Console.WriteLine("2");

await task22;

async Task PrintAsync22(string message)
{
    await Task.Delay(0);
    Console.WriteLine(message);
}
Console.WriteLine();

/***************************************************************/
/***************************************************************/
/***************************************************************/

var square5 = SquareAsync(5);
var square6 = SquareAsync(6);

Console.WriteLine("Остальные действия в методе Main");

int n1 = await square5;
int n2 = await square6;
Console.WriteLine($"n1={n1}  n2={n2}");

async Task<int> SquareAsync(int n)
{
    await Task.Delay(0);
    var result = n * n;
    Console.WriteLine($"Квадрат числа {n} равен {result}");
    return result;
}