namespace PrototypePattern;

class Program
{
    interface IAnimal
    {
        void SetName(string name);
        string GetName();
        IAnimal Clone();
    }

    class Sheep : IAnimal
    {
        private string _name = string.Empty;

        public Sheep() {}

        public Sheep(Sheep sheepDonor) => _name = sheepDonor._name;

        public void SetName(string name) => _name = name;

        public string GetName() => _name;

        public IAnimal Clone() => new Sheep(this); 
    }


    static void Main(string[] args)
    {
        Console.WriteLine("Prototype Pattern");
        Console.WriteLine();

        IAnimal sheepOriginal = new Sheep();
        sheepOriginal.SetName("Овечка Долли");        

        IAnimal sheepCloned = sheepOriginal.Clone();

        Console.WriteLine("Первая копия: {0}", sheepOriginal.GetName());
        Console.WriteLine("Вторая копия: {0}", sheepCloned.GetName());
    }
}
