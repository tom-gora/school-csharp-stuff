using System;
using DataContext;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace AsianStore {
  public class Program {
    public static void Main(string[] args) {
      ProductsContext productsDB = new ProductsContext();
      List<Product>? products = productsDB.Products.ToList();

      Console.Clear();
      Console.WriteLine("Products in the Wee Asian Store:\n");
      foreach (Product product in products) {
        Console.WriteLine($"Name: {product.name} // Price: {product.price_in_gbp}£");
      }
    }
  }
}