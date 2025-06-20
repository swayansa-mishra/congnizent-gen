using System;
using System.Collections.Generic;

class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }

    public override string ToString()
    {
        return $"ID: {ProductId}, Name: {ProductName}, Qty: {Quantity}, Price: {Price}";
    }
}

class InventorySystem
{
    private Dictionary<int, Product> products = new Dictionary<int, Product>();

    public void AddProduct(Product p)
    {
        products[p.ProductId] = p;
    }

    public void UpdateProduct(int id, int quantity, double price)
    {
        if (products.ContainsKey(id))
        {
            products[id].Quantity = quantity;
            products[id].Price = price;
        }
    }

    public void DeleteProduct(int id)
    {
        products.Remove(id);
    }

    public void DisplayAll()
    {
        foreach (var p in products.Values)
        {
            Console.WriteLine(p);
        }
    }
}

class Program
{
    static void Main()
    {
        InventorySystem system = new InventorySystem();

        system.AddProduct(new Product { ProductId = 1, ProductName = "Laptop", Quantity = 5, Price = 1000 });
        system.AddProduct(new Product { ProductId = 2, ProductName = "Mouse", Quantity = 50, Price = 25 });

        Console.WriteLine("All Products:");
        system.DisplayAll();

        Console.WriteLine("\nUpdating product 1:");
        system.UpdateProduct(1, 10, 950);
        system.DisplayAll();

        Console.WriteLine("\nDeleting product 2:");
        system.DeleteProduct(2);
        system.DisplayAll();
    }
}

