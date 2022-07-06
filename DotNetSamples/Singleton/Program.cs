
var singleton1 = Singleton.Singleton.MyInstance;
var singleton2 = Singleton.Singleton.MyInstance;


singleton1.Amount = 1;

Console.WriteLine(singleton1.Amount);
Console.WriteLine(singleton2.Amount);

Console.ReadLine();