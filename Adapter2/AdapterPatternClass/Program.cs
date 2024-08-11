namespace AdapterPatternClass;

class Program
{
    interface IScales
    {
        double GetWeight();
        
        void Adjust();
    }

    class RussianScales : IScales
    {
        double _currentWeight;

        public RussianScales(double currentWeight) => _currentWeight = currentWeight;

        public void Adjust() => Console.WriteLine("Регулировка российских весов");

        public double GetWeight() => _currentWeight;
    }

     class BritishScales : IScales
    {
        double _currentWeight;

        public BritishScales(double currentWeight) => _currentWeight = currentWeight;

        public void Adjust() => Console.Write("Регулировка британских весов");

        public double GetWeight() => _currentWeight;
    }

    class BritishScalesAdapter : BritishScales, IScales
    {
        public BritishScalesAdapter(double currentWeight) : base(currentWeight){}

        double IScales.GetWeight()
        {
            return base.GetWeight() * 0.453;
        }

        void IScales.Adjust()
        {
            base.Adjust();
            Console.WriteLine(" в методе регулировке Ajust() адаптера");
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Adapter Pattern (by Class realization)");
        Console.WriteLine();

        IScales russianScales = new RussianScales(55.0);
        IScales britishScales = new BritishScalesAdapter(55.0);

        Console.WriteLine(russianScales.GetWeight());
        Console.WriteLine(britishScales.GetWeight());

        russianScales.Adjust();
        britishScales.Adjust();
    }
}
