using System.Diagnostics;
using System.Runtime.ConstrainedExecution;
using Vijay.Practice.CSharpAdvanced;

class Program
{
    static async Task Main(string[] args)
    {
        //Asynchronomous
        Console.WriteLine("Asynchronomous Result");
        HttpClient client = new HttpClient();

        HttpResponseMessage httpResponseMessage = await client.GetAsync("https://timeapi.io/api/Time/current/zone?timeZone=Europe/Amsterdam");
        string content = await httpResponseMessage.Content.ReadAsStringAsync();

        Console.WriteLine(content);

        //LINQ
        Console.WriteLine("LINQ Result");
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

        var enumNumbers = numbers.Where(k => k % 2 == 0);

        foreach (int number in enumNumbers)
        {
            Console.WriteLine(number);
        }

        //Generic List
        Console.WriteLine("Generic List Result");
        GenericList<int> genericList = new GenericList<int>();
        genericList.Add(10);
        genericList.Add(20);

        Console.WriteLine(genericList.Get(0));
        Console.WriteLine(genericList.Get(1));

        //Expressions
        Console.WriteLine("Expressions Result");
        string s = "Hello";
        Console.WriteLine(s.ReverseMe());

        //Delegates and Events
        Console.WriteLine("Delegates and Events Result");
        MyEventClass obj = new MyEventClass();
        obj.MyEvent += () => Console.WriteLine("Event Raised");
        obj.RaiseEvent();

        //Nullable Value Types
        Console.WriteLine("Nullable Value Result");
        int? nullableInt = null;
        Console.WriteLine(nullableInt.HasValue);
        nullableInt = 10;
        Console.WriteLine(nullableInt.HasValue);

        //Pattern Matching
        Console.WriteLine("Pattern Matching Result");
        object obj1 = "Hello";

        if (obj1 is string str && str.Length > 0)
        {
            Console.WriteLine($"This is a string {str} and the length is {str.Length}");
        }

        //Indexers and Properties
        Console.WriteLine("Indexers and Properties Result");
        MyCollection myCollection = new MyCollection();

        myCollection[0] = 10;
        myCollection[1] = 20;

        Console.WriteLine(myCollection[0]);
        Console.WriteLine(myCollection[1]);

        //Asynchronomous Streams
        Console.WriteLine("Asynchronomous Streams Result");
        await foreach (var item in GetDataAsync())
        {
            Console.WriteLine(item);
        }

        //Attributes and Reflection
        Console.WriteLine("Attributes and Reflection Result");
        Type type = typeof(MyAttributeTestClass);

        MyCustomAttribute myCustomAttribute = (MyCustomAttribute)Attribute.GetCustomAttribute(type, typeof(MyCustomAttribute))!;
        if (myCustomAttribute != null)
        {
            Console.WriteLine($"Description for MyClass: {myCustomAttribute.Description}");
        }
    }

    //Asynchronomous Streams
    static async IAsyncEnumerable<int> GetDataAsync()
    {
        for(int i = 0; i < 5; i++)
        {
            await Task.Delay(100);
            yield return i;
        }
    }
}

//Generic List
public class GenericList<T>
{
    private T[] t = new T[5];
    private int count = 0;

    public void Add(T item)
    {
        t[count++] = item;
    }

    public T Get(int index)
    {
        return t[index];
    }
}

//Extensions
public static class StringExtensions
{
    public static string ReverseMe(this string s)
    {
        char[] chars = s.ToCharArray();
        Array.Reverse(chars);

        return new string(chars);
    }
}

//Delegates and Events
public delegate void MyEventHandler();

public class MyEventClass
{
    public event MyEventHandler? MyEvent;

    public void RaiseEvent()
    {
        MyEvent?.Invoke();
    }
}

//Indexers and Properties
class MyCollection
{
    private int[] array = new int[5];

    public int this[int index]
    {
        get { return array[index];}
        set { array[index] = value; }
    }

    public int Count { get { return array.Length; } }
}