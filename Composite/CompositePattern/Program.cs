using System.ComponentModel;

namespace CompositePattern;

class Program
{
    abstract class Item
    {
        protected string itemName = string.Empty;
        protected string ownerName = string.Empty;

        public Item(string name) => itemName = name;

        public void SetOwner(string o) => ownerName = o;
 
        public virtual void Add(Item subItem) {}
        public virtual void Remove(Item subItem) {}
        public abstract void Display();
    }

    class ClickableItem : Item
    {
        public ClickableItem(string Name) : base(Name) {}

        public override void Add(Item subItem)
        {
            throw new Exception();
        }

        public override void Remove(Item subItem)
        {
            throw new Exception();
        }

        public override void Display()
        {
            Console.WriteLine(itemName);
        }
    }

    class DropDownItem : Item
    {
        private List<Item> _children = [];

        public DropDownItem(string name) : base(name)
        {
            _children = new List<Item>();
        }

        public override void Add(Item subItem)
        {
            subItem.SetOwner(itemName);
            _children.Add(subItem);
        }

        public override void Remove(Item subItem) => _children.Remove(subItem);

        public override void Display()
        {
            foreach(Item item in _children)
            {
                if (!string.IsNullOrEmpty(ownerName))
                    Console.Write(ownerName + itemName);

                item.Display();
            }
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Composite Pattern");
        Console.WriteLine();

        Item file = new DropDownItem("Файл->");

        Item create = new DropDownItem("Создать->");
        Item open = new DropDownItem("Открыть->");
        Item exit = new ClickableItem("Выход");

        file.Add(create);
        file.Add(open);
        file.Add(exit);

        Item project = new ClickableItem("Проект...");
        Item repository = new ClickableItem("Репозиторий...");

        create.Add(project);
        create.Add(repository);

        Item solution = new ClickableItem("Решение...");
        Item folder = new ClickableItem("Папка...");

        open.Add(solution);
        open.Add(folder);

        file.Display();
        Console.WriteLine();

        file.Remove(create);
        file.Display();
        Console.WriteLine();
    }
}