namespace CommandPattern;

interface ICommand
{
    void Positive();
    void Negative();
}

class Conveyor
{
    public void On() => Console.WriteLine("Конвейер запущен");
    public void Off() => Console.WriteLine("Конвейер остановлен");
    public void SpeedIncreace() => Console.WriteLine("Увеличена скорость конвейера");
    public void SpeedDecreace() => Console.WriteLine("Уменьшена скорость конвейера");
}

class ConveyorworkCommand : ICommand
{
    private Conveyor _conveyor;

    public ConveyorworkCommand(Conveyor conveyor) => _conveyor = conveyor;

    public void Positive() => _conveyor.On();
    public void Negative() => _conveyor.Off();
}

class ConveyorAjustCommand : ICommand
{
    private Conveyor _conveyor;

    public ConveyorAjustCommand(Conveyor conveyor) => _conveyor = conveyor;

    public void Positive() => _conveyor.SpeedIncreace();
    public void Negative() => _conveyor.SpeedDecreace();
}

class Multipult
{
    private List<ICommand> commnds;
    private Stack<ICommand> history;

    public Multipult()
    {
        commnds = new List<ICommand>() { null, null };
        history = new Stack<ICommand>();
    }

    public void SetCommand(int button, ICommand command) => commnds[button] = command;
    public void PressOn(int button)
    {
        commnds[button].Positive();
        history.Push(commnds[button]);
    }

    public void PressCancel()
    {
        if (history.Count > 0)
            history.Pop().Negative();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Command Pattern");

        Conveyor conveyor = new Conveyor();
        Multipult multipult = new Multipult();
        multipult.SetCommand(0, new ConveyorworkCommand(conveyor));
        multipult.SetCommand(1, new ConveyorAjustCommand(conveyor));

        multipult.PressOn(0);
        multipult.PressOn(1);
        multipult.PressCancel();
        multipult.PressCancel();
    }
}
