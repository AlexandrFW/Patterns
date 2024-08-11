using System.Runtime.CompilerServices;

namespace BuilderPattern;

class Program
{
    class Phone
    {
        string data;

        public Phone() => data = string.Empty;

        public string AboutPhone() => data;

        public void AppendData(string str) => data += str;
    }

    interface IDeveloper
    {
        void CreateDisplay();
        void CreateBox();
        void SystemInstall();
        Phone GetPhone();
    }

    class AndroidDeveloper : IDeveloper
    {
        private Phone phone;

        public AndroidDeveloper() => phone = new Phone();

        public void CreateBox() => phone.AppendData("Произведён корпус Sumsung");

        public void CreateDisplay() => phone.AppendData("Произведён дисплей Sumsung");

        public void SystemInstall() => phone.AppendData("Установлена операционная система Android");

        public Phone GetPhone() => phone;        
    }

    class IPhoneDeveloper : IDeveloper
    {
        private Phone phone;

        public IPhoneDeveloper() => phone = new Phone();

        public void CreateBox() => phone.AppendData("Произведён корпус IPhone");

        public void CreateDisplay() => phone.AppendData("Произведён дисплей IPhone");

        public void SystemInstall() => phone.AppendData("Установлена операционная система IOS");

        public Phone GetPhone() => phone;        
    }

    class Director
    {
        private IDeveloper _developer;

        public Director(IDeveloper developer) => _developer = developer;

        public void SetDeveloper(IDeveloper developer) => _developer = developer;

        public Phone MountPhoneOnly()
        {
            _developer.CreateBox();
            _developer.CreateDisplay();

            return _developer.GetPhone();
        }

        public Phone MountPhoneCompleted()
        {
            _developer.CreateBox();
            _developer.CreateDisplay();
            _developer.SystemInstall();

            return _developer.GetPhone();
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Builder Pattern");
        Console.WriteLine();

        IDeveloper androidDeveloper = new AndroidDeveloper();

        Director director = new Director(androidDeveloper);

        Phone sumsung = director.MountPhoneCompleted();

        Console.WriteLine(sumsung.AboutPhone());
        Console.WriteLine();

        IDeveloper iphoneDeveloper = new IPhoneDeveloper();

        director.SetDeveloper(iphoneDeveloper);

        Phone iphone = director.MountPhoneOnly();
        
        Console.WriteLine(iphone.AboutPhone());
        Console.WriteLine();



    }
}
