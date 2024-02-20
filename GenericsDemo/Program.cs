
/*
 
 Understanding why generics are a great option
 */

using GenericsDemo;
using System.Diagnostics;

List<int> numbers = [1, 2, 3, 4];
List<string> strings = ["Tobi", "Luna"];
List<object> objects = [1, "FV", DateTime.Now, 3.6];

void TypeChecker<T>(T value)
{
    Console.WriteLine($"Type: {typeof(T)}");
    Console.WriteLine($"\tValue: {value}");
}




/*  Diagnostics uncomment to test it

// Int diagnostic time elapse
Stopwatch watch = new Stopwatch();
watch.Start();
for (int i = 0; i < 1_000_000; i++)
{
    numbers.Add(i);
}
watch.Stop();
Console.WriteLine($"Time elapsed in List<int>: {watch.ElapsedMilliseconds}");

// Object diagnostic time elapse
watch = new Stopwatch();
watch.Start();
for (int i = 0; i < 1_000_000; i++)
{
    objects.Add(i);
}
watch.Stop();
Console.WriteLine($"Time elapsed in List<object>: {watch.ElapsedMilliseconds}");

*/

// Working with generics



TypeChecker(1);
TypeChecker("Luna");
TypeChecker(new Animal("Fifi", 8));
Console.WriteLine();

foreach (var x in objects)
{
    TypeChecker(x);
}

BetterList<string> stringList = new();
stringList.AddToList("Malaquias");

BetterList<Animal> animalList = new();
animalList.AddToList(new Animal("Lucas", 13));


MathOperations<int> intMath = new();
Console.WriteLine($"Result int Add: {intMath.Add(23,7)}");

MathOperations<double> doubleMath = new();
Console.WriteLine($"Result double Add: {doubleMath.Add(10.6, 2.8)}");


record Animal(string Name, int Age);

