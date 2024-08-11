namespace MediatorPattern;

interface IMediator
{
    void Notify(Employee employee, string msg);
}

abstract class Employee
{
    protected IMediator mediator;

    public Employee(IMediator med) => mediator = med;
    
    public void SetMediator(IMediator med) => mediator = med;
}

class Designer : Employee
{
    private bool _isWorking;
    public Designer(IMediator med = null) : base(med) { }

    public void ExecuteWork()
    {
        Console.WriteLine("<- Дизайнер в работе");
        mediator.Notify(this, "Дизайнер проектирует...");
    }

    public void SetWork(bool state)
    {
        _isWorking = state;
        if (state)
            Console.WriteLine("Дизайнер освобождён от работы");
        else
            Console.WriteLine("<-Дизайнер  занят");
    }
}

class Director : Employee
{
    private string text;

    public Director(IMediator med = null) : base(med) { }

    public void GiveCommand(string txt)
    {
        text = txt;
        if (string.IsNullOrEmpty(txt))
            Console.WriteLine("-> Директор знает, что дизайнер уже работает");
        else
            Console.WriteLine("-> Директор дал команду: " + text);

        mediator.Notify(this, text);
    }
}

class Controller : IMediator
{
    private Designer _designer;
    private Director _director;

    public Controller(Designer designer, Director director)
    {
        _designer = designer;
        _director = director;
        _designer.SetMediator(this);
        _director.SetMediator(this);
    }

    public void Notify(Employee emp, string msg)
    {
        if (emp is Director dir)
        {
            if (string.IsNullOrEmpty(msg))
                _designer.SetWork(false);
            else
                _designer.SetWork(true);

            if (emp is Designer des)
            {
                if (msg == "дизайнер проектирует...")
                    _director.GiveCommand("");
            }
        }

    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Mediator Pattern");

        Designer designer = new Designer();
        Director director = new Director();

        Controller controller = new Controller(designer, director);

        director.GiveCommand("Проектировать");

        Console.WriteLine();

        designer.ExecuteWork();        
    }
}
