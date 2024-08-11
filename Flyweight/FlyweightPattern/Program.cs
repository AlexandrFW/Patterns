using System.Collections;

namespace FlyweightPattern;

struct Shared
{
    private string company;
    private string position;

    public Shared(string company, string position)
    {
        this.company = company;
        this.position = position;
    }

    public string Company { get => company; }
    public string Position { get => position; }
}

struct Unique
{
    private string name;
    private string passport;

    public Unique(string name, string passport)
    {
        this.name = name;
        this.passport = passport;
    }

    public string Name { get => name; }
    public string Passport { get => passport; }
}

class Flyweight
{
    private Shared shared;

    public Flyweight(Shared shared) => this.shared = shared;

    public void Process(Unique unique)
    {
        Console.WriteLine("Отображаем новые данные: общее: - {0}-{1} и уникальные: {2}-{3}", shared.Company, shared.Position, unique.Name, unique.Passport);
    }

    public string GetData() => string.Format("{0}-{1}", shared.Company, shared.Position);
}

class FlyweightFactory
{
    private Hashtable flyweights;

    private string GetKey(Shared shared) => string.Format("{0}_{1}", shared.Company, shared.Position);

    public FlyweightFactory(List<Shared> shareds)
    {
        flyweights = new Hashtable();
        foreach(Shared shared in shareds)
        {
            flyweights.Add(GetKey(shared), new Flyweight(shared));
        }
    }

    public Flyweight GetFlyweight(Shared shared)
    {
        string key = GetKey(shared);
        if (!flyweights.Contains(key))
        {
            Console.WriteLine("Фабрика легковесов: Общий объект по ключу {0} не найден. Создаём новый!", key);
           
            Flyweight flyweight = new Flyweight(shared);

            flyweights.Add(key, flyweight);

            return flyweight;
        }

        Console.WriteLine("Фабрика легковесов: Извлекаем запись по имеющемуся ключу {0}!", key);
       
        return (Flyweight)flyweights[key]!;
    }

    public void ListFlyweights()
    {
        Console.WriteLine("Фабрика легковесов: Всего записей: {0}", flyweights.Count);
        foreach(Flyweight pair in flyweights.Values)
        {
            Console.WriteLine(pair.GetData());
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Flyweight Pattern");

        FlyweightFactory flyweightFactory = new FlyweightFactory(new List<Shared>
        {
            new Shared("Microsoft", "Управляющий"),
            new Shared("Google", "Android-разработчик"),
            new Shared("Google", "Web-разработчик"),
            new Shared("Apple", "IPhone-разработчик")
        });

        flyweightFactory.ListFlyweights();

        AddSpecialistDatabase(flyweightFactory, 
         "Google",
         "Web-разработчик",
         "Борис",
         "АИ-1234567");

          AddSpecialistDatabase(flyweightFactory, 
         "Apple",
         "Управляющий",
         "Александр",
         "DE-0099988");

         flyweightFactory.ListFlyweights();
    }

    static void AddSpecialistDatabase(FlyweightFactory ff, string company, string position, string name, string passport)
    {
        Console.WriteLine();
        Flyweight flyweight = ff.GetFlyweight(new Shared(company, position));
        flyweight.Process(new Unique(name, passport));
        Console.WriteLine();
    }
}
