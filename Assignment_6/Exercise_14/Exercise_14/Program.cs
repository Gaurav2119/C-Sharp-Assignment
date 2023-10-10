using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_14
{
    class Product : IEquatable<Product>
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public Product(int id, double price)
        {
            Id = id;
            Price = price;
        }
        public bool Equals(Product other)
        {
            if (other == null)
                return false;
            return (this.Id.Equals(other.Id));
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
    
    class Inventory
    {
        private IDictionary<Product, int> products;
        public double totalValue;
        public Inventory()
        {
            products = new Dictionary<Product, int>();
            totalValue = 0;
        }
        public void AddProduct(Product product, int quantity)
        {
            if (products.ContainsKey(product))
                products[product] += quantity;
            else
                products[product] = quantity;
            totalValue += product.Price * quantity;
        }

        public void RemoveProduct(Product product, int quantity)
        {
            if (products.ContainsKey(product))
            {
                if (products[product] >= quantity)
                {
                    products[product] -= quantity;
                    totalValue -= product.Price * quantity;
                }
                if (products[product] == 0)
                    products.Remove(product);
            }
        }

        public void UpdateProductQuantity(Product product, int quantity)
        {
            if (products.ContainsKey(product))
            {
                totalValue -= product.Price * products[product];
                products[product] = quantity;
                totalValue += product.Price * quantity;
            }
        }
        public void OnPriceChanged(object sender, EventArgs e)
        {
            Product product = (Product)sender;
            int quantity = products[product];
            totalValue -= product.Price * quantity;
            totalValue += product.Price * quantity;
        }
        public void OnDefectiveProductRemoved(object sender, EventArgs e)
        {
            Product product = (Product)sender;
            int quantity = products[product];
            totalValue -= product.Price * quantity;
            products.Remove(product);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Product p1 = new Product (1, 10.0);
            Product p2 = new Product(2, 20.0);
            Product p3 = new Product(3, 30.0);

            Inventory inventory = new Inventory();
            
            inventory.AddProduct(p1, 5);
            inventory.AddProduct(p2, 10);
            inventory.AddProduct(p3, 15);

            inventory.UpdateProductQuantity(p1, 7);

            inventory.RemoveProduct(p2, 5);

            p2.Price = 25.0;
        }
    }
}
