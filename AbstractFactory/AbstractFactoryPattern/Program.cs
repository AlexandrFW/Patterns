namespace AbstractFactoryPattern;

class Program
{
    interface IEngine
    {
        void ReleaseEngine();
    }

    class JapaniseEngine : IEngine
    {
        public void ReleaseEngine() => Console.WriteLine("японский двигатель");
    }

    class RussianEngine : IEngine
    {
        public void ReleaseEngine() => Console.WriteLine("российский двигатель");
    }

    interface ICar
    {
        void ReleaseCar(IEngine engine);
    }

    class JapaniseCar : ICar
    {
        public void ReleaseCar(IEngine engine)
        {
            Console.Write("Собрали японский автомобиль: ");
            engine.ReleaseEngine();
        }
    }

     class RussianCar : ICar
    {
        public void ReleaseCar(IEngine engine)
        {
            Console.Write("Собрали российский автомобиль: ");
            engine.ReleaseEngine();
        }
    }

    interface  IFactory
    {
        IEngine CreateEngine();

        ICar CreateCar();
    }

    class JapaniseFactory : IFactory
    {
        public ICar CreateCar() => new JapaniseCar();

        public IEngine CreateEngine() => new JapaniseEngine();
    }

     class RussianFactory : IFactory
    {
        public ICar CreateCar() => new RussianCar();

        public IEngine CreateEngine() => new RussianEngine();
    }


    static void Main(string[] args)
    {
        Console.WriteLine("Abstract Factory Pattern");

        IFactory jFactory = new JapaniseFactory();
        IEngine jEngine = jFactory.CreateEngine();
        ICar jCar = jFactory.CreateCar();
        jCar.ReleaseCar(jEngine);

        IFactory rFactory = new RussianFactory();
        IEngine rEngine = rFactory.CreateEngine();
        ICar rCar = rFactory.CreateCar();
        rCar.ReleaseCar(rEngine);
    }
}
