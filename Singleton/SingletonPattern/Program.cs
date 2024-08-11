using System.Net.NetworkInformation;

namespace SingletonPattern;

class Program
{
    public class DatabaseHelper
    {
        private string _data = string.Empty;
        private static DatabaseHelper? _databaseConnection;

        private DatabaseHelper() => Console.WriteLine("Подключение к БД");

        public static DatabaseHelper GetConnection()
        {
            if (_databaseConnection is null)
                _databaseConnection = new DatabaseHelper();

            return _databaseConnection;    
        }

        public string SelectData() => _data;
        public void InsertData(string d)
        {
            _data = d;
            Console.WriteLine("Новые данные: {0}. Внесены в БД.", d);
        }
    }


    static void Main(string[] args)
    {
        Console.WriteLine("Singleton Pattern");
        Console.WriteLine();

        // не можем определить класс - конструктор не доступен
        //DatabaseHelper databaseHelper = new DatabaseHelper(); 
  
        DatabaseHelper.GetConnection().InsertData("123");

        Console.WriteLine("Выборка данных из БД: {0}", DatabaseHelper.GetConnection().SelectData());
    }
}
