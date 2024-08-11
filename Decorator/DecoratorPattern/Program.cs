namespace DecoratorPattern;

interface IProcessor
{
    void Process();
}

class Transmitter : IProcessor
{
    private string _data = string.Empty;

    public Transmitter(string data) => _data = data;
    
    public void Process() => Console.WriteLine($"Данные {_data} переданы по каналу связи");
}

abstract class Shell : IProcessor
{
    protected IProcessor processor;

    public Shell(IProcessor processor) => this.processor = processor;

    public virtual void Process() => processor.Process();
}

class HammingCoder : Shell
{
    public HammingCoder(IProcessor pr) : base(pr) {}

    public override void Process()
    {
        Console.WriteLine("Наложен помехоустойчивый код Хамминга->");
        processor.Process();
    }
}

class Encryptor : Shell
{
    public Encryptor(IProcessor processor) : base(processor){}

    public override void Process()
    {
        Console.WriteLine("Шифрование данных->");
        processor.Process();
    }
}

class Program
{    
    static void Main(string[] args)
    {
        Console.WriteLine("Decorator Pattern");

        IProcessor transmitter = new Transmitter("12345");
        transmitter.Process();
        Console.WriteLine();

        Shell hammingCoder = new HammingCoder(transmitter);
        hammingCoder.Process();
        Console.WriteLine();

        Shell encoder = new Encryptor(hammingCoder);
        encoder.Process();
        Console.WriteLine();
    }
}
