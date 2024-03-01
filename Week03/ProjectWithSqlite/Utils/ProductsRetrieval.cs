using System;
using DataContext;
using Entities;
using Microsoft.EntityFrameworkCore;
using Utils;

namespace Utils {

  public class ProductsRetrieval {
    public static List<Product> GetProductsAsList() {
      ProductsContext productsDB = new ProductsContext();
      return productsDB.Products!.ToList();
    }

    public static void ListAllProducts(List<Product> products) {
      if (products != null) {
        Console.Clear();
        Console.WriteLine("Products in the Wee Asian Store:\n");
        Console.WriteLine("Id\t| Name");
        Console.WriteLine("--------------------------------");
        foreach (Product product in products) {
          string name = product.name ?? "value missing";
          string description = product.description ?? "value missing";
          Console.WriteLine($"{product.id}\t| {name}");
        }
      } else {
        Console.WriteLine("Failed to retrieve products");
      }
    }

    public static Product GetClientToSelectExistingProduct(OperationList operation) {
      string operationName = operation switch {
        OperationList.ListDetails => "list details",
        OperationList.Modify => "modify",
        OperationList.Delete => "delete",
        _ => "unknown"
      };
      List<Product> products = GetProductsAsList();
      int selectedId = 0;
      bool isValidInput = false;

      while (!isValidInput) {
        Console.Clear();
        ListAllProducts(products);
        Console.Write($"\nEnter product number that you want to {operationName.ToLower()}: ");
        string? userInput = Console.ReadLine();

        if (int.TryParse(userInput, out selectedId) && selectedId > 0 && selectedId <= products.Count) {
          isValidInput = true;
        } else {
          Console.WriteLine("Invalid input. Please enter a valid product number.");
          MetaUtils.AnyKeyPressPlease();
        }
      }
      return products[selectedId - 1];
    }
  }

  public class ProductsAddition {
    public static void AddProduct(Product prod) {
      ProductsContext productsDB = new ProductsContext();
      productsDB.Products!.Add(prod);
      int affectedRows = productsDB.SaveChanges();

      if (affectedRows > 0) {
        Console.WriteLine("\nProduct addition successful.");
      } else {
        Console.WriteLine("\nFailed to add the product.");
      }
    }

    public static Product GetNewProductDataFromClient() {
      Product newProduct = new Product();
      Console.Write("\nEnter product name: ");
      newProduct.name = Console.ReadLine();
      Console.Write($"Enter price in GBP for {newProduct.name}: "); ;
      newProduct.price_in_gbp = Convert.ToInt32(Console.ReadLine());
      Console.Write($"Enter description for {newProduct.name}: ");
      newProduct.description = Console.ReadLine();
      Console.Write($"Is {newProduct.name} in stock? (true/false): ");
      newProduct.availability = Convert.ToBoolean(Console.ReadLine());
      Console.Write($"Enter {newProduct.name} stock level: ");
      newProduct.stock_level = Convert.ToInt32(Console.ReadLine());
      Console.Write($"Is {newProduct.name} on promotion (true/false): ");
      newProduct.on_promo = Convert.ToBoolean(Console.ReadLine());
      Console.Write($"What is the percentage of discount applied to {newProduct.name} ? ( Enter a number)"); ;
      newProduct.promo_rate_as_percentage = Convert.ToInt32(Console.ReadLine());
      return newProduct;
    }
  }

  public class ProductsDeletion {
    public static void DeleteProduct(Product prod) {
      ProductsContext productsDB = new ProductsContext();
      Product? productDel = productsDB.Products!.Find(prod.id);
      productsDB.Products.Remove(productDel!);
      productsDB.SaveChanges();
    }

  }

}