namespace BridgePattern;

class Program
{
    interface IDataReader
    {
        void Read();
    }

    class DatabaseReader : IDataReader
    {
        public void Read() => Console.Write("Данные из базы данных - ");        
    }

    class FileReader : IDataReader
    {
        public void Read() => Console.Write("Данные из файла - ");        
    }

    abstract class Sender
    {
        protected IDataReader _reader;
        public Sender(IDataReader reader) => _reader = reader;

        public void SetDataReader(IDataReader reader) => _reader = reader;

        public abstract void Send();
    }

    class EmailSender : Sender
    {
        public EmailSender(IDataReader reader) : base(reader){}
        public override void Send()
        {
            _reader.Read();
            Console.WriteLine("Отправлено при помощи Email");
        }
    }

    class TelegrambotSender : Sender
    {
        public TelegrambotSender(IDataReader reader) : base(reader){}
        public override void Send()
        {
            _reader.Read();
            Console.WriteLine("Отправлено при помощи Telegram");
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Bridge Pattern");
        Console.WriteLine();

        Sender sender = new EmailSender(new DatabaseReader());
        sender.Send();

        sender.SetDataReader(new FileReader());
        sender.Send();

        sender = new TelegrambotSender(new DatabaseReader());
        sender.Send();
    }
}
