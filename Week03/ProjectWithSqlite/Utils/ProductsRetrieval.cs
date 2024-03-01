using System;
using DataContext;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Utils {
  public class ProductsRetrieval {
    public static void ListAllProducts() {
      ProductsContext productsDB = new ProductsContext();
      List<Product>? products = productsDB.Products!.ToList();
      if (products != null) {
        Console.Clear();
        Console.WriteLine("Products in the Wee Asian Store:\n");
        foreach (Product product in products) {
          string name = product.name ?? "value missing";
          string description = product.description ?? "value missing";
          Console.WriteLine($"Name: {name} // Price: {product.price_in_gbp}£");
        }
      } else {
        ;
        ;
        Console.WriteLine("Failed to retrieve products");
      }
    }
  }
  public class ProductsAddition {
    public static void AddProduct(Product prod) {
      ProductsContext productsDB = new ProductsContext();
      Product product = new Product {
        name = prod.name,
        price_in_gbp = prod.price_in_gbp,
        description = prod.description,
        availability = prod.availability,
        stock_level = prod.stock_level,
        on_promo = prod.on_promo,
        promo_rate_as_percentage = prod.promo_rate_as_percentage
      };
      productsDB.Products!.Add(product);
      productsDB.SaveChanges();
    }
    public static Product GetProductDataFromClient() {
      Product product = new Product();
      Console.Write("Enter product name: ");
      product.name = Console.ReadLine();
      Console.Write($"Enter price in GBP for {product.name}: "); ;
      product.price_in_gbp = Convert.ToInt32(Console.ReadLine());
      Console.Write($"Enter description for {product.name}: ");
      product.description = Console.ReadLine();
      Console.Write($"Is {product.name} in stock? (true/false): ");
      product.availability = Convert.ToBoolean(Console.ReadLine());
      Console.Write($"Enter {product.name} stock level: ");
      product.stock_level = Convert.ToInt32(Console.ReadLine());
      Console.Write($"Is {product.name} on promotion (true/false): ");
      product.on_promo = Convert.ToBoolean(Console.ReadLine());
      Console.Write($"What is the percentage of discount applied to {product.name} ? ( Enter a number)"); ;
      product.promo_rate_as_percentage = Convert.ToInt32(Console.ReadLine());
      return product;
    }
  }
}