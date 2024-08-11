namespace FactoryPattern;

class Program
{
    interface IProduction 
    {
        void Release();
    }

    interface IWorkShop
    {
        IProduction Create();
    }

    class Car : IProduction
    {
        public void Release() => Console.WriteLine("Выпущен новый легковой автомобиль");
    }

    class Truck : IProduction
    {
        public void Release() => Console.WriteLine("Выпущен новый грузовой автомобиль");
    }

    class CarWorkShop : IWorkShop
    {
        public IProduction Create() => new Car();
    }

    class TruckWorkShop : IWorkShop
    {
        public IProduction Create() => new Truck();
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        IWorkShop workShop = new CarWorkShop();

        IProduction car = workShop.Create();

        workShop = new TruckWorkShop();

        IProduction truck = workShop.Create();

        car.Release();
        truck.Release();
    }
}
