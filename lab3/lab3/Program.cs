using System;
using Lab3;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        string testStr = "Привіт, Світ!";
        Console.WriteLine($"Оригінал: {testStr}");
        Console.WriteLine($"Інверсія: {testStr.Invert()}");
        Console.WriteLine($"Кількість 'і': {testStr.CountChar('і')}");

        int[] numbers = { 1, 2, 2, 3, 4, 4, 4, 5 };
        Console.WriteLine($"\nКількість четвірок у масиві: {numbers.CountOccurrences(4)}");
        Console.WriteLine($"Унікальні елементи: {string.Join(", ", numbers.Unique())}");

        var myDict = new ExtendedDictionary<string, string, int>();
        myDict.Add("ID01", "Олександр", 25);
        myDict.Add("ID02", "Марія", 21);

        Console.WriteLine($"\nКількість елементів у словнику: {myDict.Count}");

        foreach (var entry in myDict)
        {
            Console.WriteLine($"Ключ: {entry.Key}, Ім'я: {entry.Value1}, Вік: {entry.Value2}");
        }

        Console.WriteLine($"\nПошук за ключем ID01: {myDict["ID01"].Value1}");
        Console.ReadKey();
    }
}