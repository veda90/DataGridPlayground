using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DataGridPlayground
{
    public class ProductManager
    {
        public ProductManager()
        {
            Products = new ObservableCollection<Product>();
            Products.Add(new Product() {Id=45, Name="Toothbrush", Price=10, Catagory="Daily Usable" });
            Products.Add(new Product() { Id = 45, Name = "Paste", Price = 23.5, Catagory = "Daily Usable" });
            Products.Add(new Product() { Id = 09, Name = "Bat", Price = 2000, Catagory = "Sports" });
            Products.Add(new Product() { Id = 10, Name = "Bedsheet", Price = 500, Catagory = "Daily Usable" });
            Products.Add(new Product() { Id = 43, Name = "Cycle", Price = 5000, Catagory = "Sports" });

        }
        public ObservableCollection<Product> Products { get; set; }

        
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Catagory { get; set; }

        public double Price { get; set; }
    }
}
