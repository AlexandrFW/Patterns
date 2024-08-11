using System.Net.NetworkInformation;

namespace ChainOfResponsibilityPattern;

interface IWorker
{
    IWorker SetNextWorker(IWorker worker);

    string Execute(string command);
}

abstract class AbsWorker : IWorker
{
    private IWorker _nextWorker;
    public AbsWorker() => _nextWorker = null;
    
    public virtual string Execute(string command)
    {
        if (_nextWorker is not null)
           return _nextWorker.Execute(command);

        return string.Empty;   
    }

    public IWorker SetNextWorker(IWorker worker)
    {
        _nextWorker = worker;
        return worker;
    }
}

class Designer : AbsWorker
{
    public override string Execute(string command)
    {
        if (command == "спроектировать дом")
            return string.Format("Проектировщик выполнил команду: {0}", command);
        else
            return base.Execute(command);
    }
}

class Corpenter : AbsWorker
{
    public override string Execute(string command)
    {
        if (command == "класть кирпич")
            return string.Format("Плотник выполнил команду: {0}", command);
        else
            return base.Execute(command);
    }
}

class FinshingWorker : AbsWorker
{
    public override string Execute(string command)
    {
        if (command == "клеить обои")
            return string.Format("Отделочник выполнил команду: {0}", command);
        else
            return base.Execute(command);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Chain Of Responsibility Pattern");

        Designer designer = new Designer();
        Corpenter corpenter = new Corpenter();
        FinshingWorker finshingWorker = new FinshingWorker();

        designer.SetNextWorker(corpenter).SetNextWorker(finshingWorker);

        GiveCommand(designer, "спроектировать дом");
        GiveCommand(designer, "класть кирпич");
        GiveCommand(designer, "клеить обои");

        GiveCommand(designer, "провести проводку");
    }

    public static void GiveCommand(IWorker worker, string command)
    {
        string str = worker.Execute(command);
        if (string.IsNullOrEmpty(str))
            Console.WriteLine(string.Format("{0} - никто не умеет делать", command));
        else
            Console.WriteLine(str);
    }
}
