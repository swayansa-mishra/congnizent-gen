using System;
using System.Collections.Generic;

class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string Category { get; set; }

    public override string ToString()
    {
        return $"ID: {ProductId}, Name: {ProductName}, Category: {Category}";
    }
}

class ProductSearch
{
    // Linear Search
    public static Product LinearSearch(List<Product> products, string target)
    {
        foreach (var p in products)
        {
            if (p.ProductName.Equals(target, StringComparison.OrdinalIgnoreCase))
                return p;
        }
        return null;
    }

    // Binary Search (Assumes products are sorted by ProductName)
    public static Product BinarySearch(List<Product> products, string target)
    {
        int low = 0, high = products.Count - 1;
        while (low <= high)
        {
            int mid = (low + high) / 2;
            int comp = string.Compare(products[mid].ProductName, target, true);
            if (comp == 0) return products[mid];
            else if (comp < 0) low = mid + 1;
            else high = mid - 1;
        }
        return null;
    }
}

class Program
{
    static void Main()
    {
        List<Product> products = new List<Product>
        {
            new Product { ProductId = 101, ProductName = "Keyboard", Category = "Electronics" },
            new Product { ProductId = 102, ProductName = "Mouse", Category = "Electronics" },
            new Product { ProductId = 103, ProductName = "Chair", Category = "Furniture" },
        };

        Console.WriteLine("Linear Search:");
        var found = ProductSearch.LinearSearch(products, "Mouse");
        Console.WriteLine(found != null ? found.ToString() : "Product not found");

        // Binary search requires sorted list
        products.Sort((a, b) => a.ProductName.CompareTo(b.ProductName));

        Console.WriteLine("\nBinary Search:");
        found = ProductSearch.BinarySearch(products, "Mouse");
        Console.WriteLine(found != null ? found.ToString() : "Product not found");
    }
}
