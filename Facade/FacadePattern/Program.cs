
using System.Diagnostics.CodeAnalysis;

namespace FacadePattern;

class ProviderCommunication
{
    public void Receive() => Console.WriteLine("Получение продукции от производителя");
    public void Payment() => Console.WriteLine("Оплата поставки с удержанием комиссии за продажу продукции");
}

class Site
{
    public void Placement() => Console.WriteLine("Размещение на сайте");
    public void Del() => Console.WriteLine("Удаления с сайта");
}

class Database
{
    public void Insert() => Console.WriteLine("Запись в базу данных");
    public void Del() => Console.WriteLine("Удаление из базы данных");
}

class MarketPlace
{
    private ProviderCommunication providerCommunication;
    private Site site;
    private Database database;

    public MarketPlace()
    {
        providerCommunication = new ProviderCommunication();
        site = new Site();
        database = new Database();
    }

    public void ProductRecept()
    {
        providerCommunication.Receive();
        database.Insert();
        site.Placement();
    }

    public void ProductRelease()
    {
        providerCommunication.Payment();
        site.Del();
        database.Del();
    }
}

class Program 
{
    static void Main(string[] args)
    {
        Console.WriteLine("Facade Pattern");

        MarketPlace marketPlace = new MarketPlace();
        marketPlace.ProductRecept();

        Console.WriteLine(new string('-', 20));

        marketPlace.ProductRelease();
    }
}