using System;

namespace Store
{
    public class Program
    {
        public static void Main()
        {
            var gs = new GroceryStore();
            gs.Add(new Product("Масло", 60));
            gs.Add(new Product("Молоко", 40));
            gs.Add(new Product("Хлеб", 100));
            gs.Add(new Product("Сок", 80));
            gs.Add(new Product("Насвай", 5));
            gs.Add(new Product("Майонез", 30));
            gs.Add(new Product("Кетчуп", 35));

            Console.WriteLine("Для помощи введите команду help");
            while (true)
            {
                Console.Write(">>");
                var command = Console.ReadLine();
                if (command == "" || command == null) break;
                switch (command)
                {
                    case "add": Command.Add(gs); break;
                    case "remove": Command.Remove(gs); break;
                    case "find": Command.Find(gs); break;
                    case "show": Command.Show(gs); break;
                    case "help": Command.Help(); break;
                    case "orderby": Command.OrderBy(gs); break;
                    case "profit": Command.Profit(gs); break;
                    case "tocell": Command.ToCell(gs); break;
                    case "ssp": Command.ShowSoldProducts(gs); break;
                    default: Console.WriteLine("Неверный формат команды, введите команду help для ознакомления"); break;
                }
            }
        }
    }
}
