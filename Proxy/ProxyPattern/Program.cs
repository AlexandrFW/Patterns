namespace ProxyPattern;

interface ISite
{
    string GetPage(int num);
}

class Site : ISite
{
    public string GetPage(int num) => string.Format("Это страница номер {0}", num);
}

class SiteProxy : ISite
{
    private ISite _site;
    private Dictionary<int, string> cache;

    public SiteProxy(ISite site)
    {
        _site = site;
        cache = new Dictionary<int, string>();
    }

    public string GetPage(int num)
    {
        string page;
        if(cache.ContainsKey(num))
        {
            page = cache[num];
            page = string.Format(" из кэша: {0}", page);
        }
        else
        {
            page = _site.GetPage(num);
            cache.Add(num, page);
        }

        return page;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Proxy Pattern");

        ISite mySite = new SiteProxy(new Site());

        Console.WriteLine(mySite.GetPage(1));
        Console.WriteLine(mySite.GetPage(2));
        Console.WriteLine(mySite.GetPage(3));

        Console.WriteLine(mySite.GetPage(2));
    }
}
