using System.IO.Compression;

namespace AdapterPattern;

class Program
{
    interface IScales
    {
        double GetWeight();
    }

    class RussianScales : IScales
    {
        private double _currentWeight;

        public RussianScales(double currentWeight) => _currentWeight = currentWeight;

        public double GetWeight() => _currentWeight;
    }

      class BritishScales : IScales
    {
        private double _currentWeight;

        public BritishScales(double currentWeight) => _currentWeight = currentWeight;

        public double GetWeight() => _currentWeight;
    }

    class BritishScalesAdapter : IScales
    {
        BritishScales _britishScales;

        public BritishScalesAdapter(BritishScales britishScales) => _britishScales = britishScales;

        public double GetWeight() =>  _britishScales.GetWeight() * 0.453;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Adapter pattern");
        Console.WriteLine();

        double kg = 55.0;
        double lb = 55.0;

        IScales russianScales = new RussianScales(kg);
        IScales britishScales = new BritishScalesAdapter(new BritishScales(lb));

        Console.WriteLine("Российские килограммы: {0} кг", russianScales.GetWeight());
        Console.WriteLine("Британские фунты: {0} фунтов", britishScales.GetWeight());
    }
}
