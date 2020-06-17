using System;
using System.Collections.Generic;
using System.Linq;

namespace Store
{
    public class GroceryStore
    {
        public double Profit { get; set; }
        public List<Product> Products { get; set; }
        public List<Product> SoldProducts { get; set; }
        public GroceryStore()
        {
            Products = new List<Product>();
            SoldProducts = new List<Product>();
        }
        public void Add(Product product) => Products.Add(product);
        public void Remove(Product product) => Products.Remove(product);
        public void Remove(string name) => Products = Products.Where(x => x.Name != name).ToList();
        public void Remove(int price) => Products = Products.Where(x => x.Price != price).ToList();
        public void OrderBy<TKey>(Func<Product, TKey> predicate) => Products = Products.OrderBy(x => predicate(x)).ToList();
        public void OrderByName() => OrderBy(x => x.Name);
        public void OrderByPrice() => OrderBy(x => x.Price);
        public List<Product> Find(Func<Product, bool> predicate)
        {
            var result = new List<Product>();
            foreach (var p in Products)
                if (predicate(p))
                    result.Add(p);
            return result;
        }
        public Product FindByName(string name)
        {
            var p = this.Find(x => x.Name == name);
            if (p.Count == 0)
                return null;
            else
                return p[0];
        }
        public List<Product> FindByPrice(int price) => this.Find(x => x.Price == price);
        public void ToSellProduct(Product product)
        {
            Profit += 0.1 * product.Price;//Прибыль считается, как 10% от цены.
            SoldProducts.Add(product);
            this.Remove(product);
        }
    }
}
