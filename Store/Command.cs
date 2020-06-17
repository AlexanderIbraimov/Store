using System;

namespace Store
{
    public static class Command
    {
        public static void Add(GroceryStore gs)
        {
            Console.WriteLine("Введите название продукта:\t");
            var name = Console.ReadLine();
            Console.WriteLine("Введите цену продукта:\t");
            var price = Console.ReadLine();
            gs.Add(new Product(name, int.Parse(price)));
        }
        public static void Remove(GroceryStore gs)
        {
            Console.WriteLine("Введите название продукта: ");
            var name = Console.ReadLine();
            gs.Remove(name);
        }
        public static void Find(GroceryStore gs)
        {
            try
            {
                Console.WriteLine("Введите имя и/или цену товара");
                var nameOrPrice = Console.ReadLine();
                var s = nameOrPrice.Split(' ');
                if (s.Length == 2)
                {
                    var name = s[0];
                    var price = int.Parse(s[1]);
                    var list = gs.Find(p => p.Equals(new Product(name, price)));
                    foreach (var item in list)
                    {
                        Console.WriteLine(item);
                    }
                }
                else
                {
                    int num = 0;
                    if (int.TryParse(s[0], out num))
                    {
                        var list = gs.FindByPrice(int.Parse(s[0]));
                        foreach (var item in list)
                            Console.WriteLine(item);
                    }
                    else
                    {
                        var product = gs.FindByName(s[0]);
                        Console.WriteLine(product);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Такого продукта нет!");
            }
        }
        public static void Show(GroceryStore gs)
        {
            foreach (var product in gs.Products)
                Console.WriteLine(product);
        }       
        public static void OrderBy(GroceryStore gs)
        {
            Console.WriteLine("Сортировать по цене - введите price");
            Console.WriteLine("Сортировать по имени - введите name");
            Console.Write(">>");
            var command = Console.ReadLine();
            switch (command)
            {
                case "price": gs.OrderByPrice(); break;
                case "name": gs.OrderByName(); break;
                default: Console.WriteLine("Неверный формат команды"); break;
            }
        }
        public static void Profit(GroceryStore gs) 
        {
            Console.WriteLine($"Прибыль равна: {gs.Profit}");
        }
        public static void ToCell(GroceryStore gs)
        {
            Console.WriteLine("Введите название продукта:\t");
            var name = Console.ReadLine();
            var product = gs.FindByName(name);
            if (product!=null)
                gs.ToSellProduct(product);
            else 
                Console.WriteLine("Такого продукта нет!");
        }
        public static void ShowSoldProducts(GroceryStore gs) 
        {
            foreach (var item in gs.SoldProducts)
                Console.WriteLine(item);
        }
        public static void Help()
        {
            Console.WriteLine("add - добавить новый продукт");
            Console.WriteLine("remove - удалить существующий продукт");
            Console.WriteLine("find - найти продукт из имеющегося списка");
            Console.WriteLine("show - список всех имеющихся продуктов");
            Console.WriteLine("orderby - сортировка по названию или цене");
            Console.WriteLine("profit - показывает прибыль с продажи");
            Console.WriteLine("ssp - показывает проданные продукты");
            Console.WriteLine("tocell - продажа продукта");
            Console.WriteLine("help - описание команд");
        }
    }
}
