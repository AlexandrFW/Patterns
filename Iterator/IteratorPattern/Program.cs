namespace IteratorPattern;

internal class DataStack
{
    private int[] _items = new int[10];
    private int _length;

    public DataStack() => _length = -1;
    public DataStack(DataStack myStack)
    {
        _items = myStack._items;
        _length = myStack._length;
    }

    public int[] Items {get => _items;}
    public int Length {get => _length;}

    public void Push(int value) => Items[++_length] = value;
    public int Pop() => Items[_length--];

    public static bool operator ==(DataStack myStack1, DataStack myStack2)
    {
        StackIterator it1 = new StackIterator(myStack1),
        it2 = new StackIterator(myStack2);

        while(it1.IsEnd() || it2.IsEnd())
        {
            if (it1.Get() != it2.Get()) break;
            it1++;
            it2++;
        }

        return !it1.IsEnd() && !it2.IsEnd();
    }

    public static bool operator !=(DataStack myStack1, DataStack myStack2)
    {
        StackIterator it1 = new StackIterator(myStack1),
        it2 = new StackIterator(myStack2);

        while(it1.IsEnd() || it2.IsEnd())
        {
            if (it1.Get() != it2.Get()) break;
            it1++;
            it2++;
        }

        return !(!it1.IsEnd() && !it2.IsEnd());
    }
}

class StackIterator
{
    private DataStack stack;
    private int index;

    public StackIterator(DataStack myStack)
    {
        stack = myStack;
        index = 0;
    }

    public static StackIterator operator ++(StackIterator s)
    {
        s.index++;
        return s;
    }

    public int Get()
    {
        if (index < stack.Length)
            return stack.Items[index];

        return 0;
    }

    public bool IsEnd() => index != stack.Length + 1;
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Iterator Pattern");

        DataStack myStack1 = new DataStack();
        for(int i = 1; i < 5; i++)
            myStack1.Push(i);

        DataStack myStack2 = new DataStack(myStack1);

        Console.WriteLine(myStack1 == myStack2);

        myStack2.Push(10);

        Console.WriteLine(myStack1 == myStack2);
    }
}