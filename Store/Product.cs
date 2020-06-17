using System;

namespace Store
{
    public class Product : IComparable
    {
        public string Name { get; }
        public int Price { get; }
        public Product(string name, int price)
        {
            Name = name;
            Price = price;
        }
        public override string ToString() => $"Name: {Name}\tPrice: {Price}";
        public int CompareTo(object obj)
        {
            var p = (Product)obj;
            if (p.Name == this.Name && p.Price == this.Price)
                return 0;
            else if (this.Price > p.Price)
                return 1;
            else if (this.Price < p.Price)
                return -1;
            else
            {
                if (this.Name.CompareTo(p.Name) > 0)
                    return 1;
                else 
                    return -1;
            }
        }
        public override bool Equals(object obj)
        {
            var value = (Product)obj; 
            return value.CompareTo(this) == 0;
        }
    }
}
