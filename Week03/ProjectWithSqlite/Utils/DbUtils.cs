using System;
using System.Text;
using DataContext;
using Entities;
using Microsoft.EntityFrameworkCore;
using ProgramUtils;

namespace DbUtils {

  public class ProductsRetrieval {
    public static List<Product> GetProductsAsList() {
      ProductsContext productsDB = new ProductsContext();
      return productsDB.Products!.ToList();
    }

    public static string FormatProductList(List<Product> products) {
      Console.Clear();
      if (products != null && products.Count > 0) {
        var sb = new StringBuilder();
        sb.AppendLine("Products in the Wee Asian Store:\n");
        sb.AppendLine("Id\t| Name");
        sb.AppendLine("--------------------------------");

        foreach (Product product in products) {
          string name = product.name ?? "value missing";
          sb.AppendLine($"{product.id}\t| {name}");
        }

        return sb.ToString();
      } else {
        return "Failed to retrieve products";
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
      Console.Clear();
      string productsListTxt = FormatProductList(products);
      string message = productsListTxt + $"\nEnter product number that you want to {operationName.ToLower()}: ";

      int selectedId = InputValidators.TakeAndValidateInputInt(message);
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

      string message = "Enter product name: ";
      newProduct.name = InputValidators.TakeAndValidateInputString(message);

      message = $"Enter price in GBP for {newProduct.name}: ";
      newProduct.price_in_gbp = InputValidators.TakeAndValidateInputFloat(message);

      message = $"Enter description for {newProduct.name}: ";
      newProduct.description = InputValidators.TakeAndValidateInputString(message);

      message = $"Is {newProduct.name} in stock? (y/n or yes/no): ";
      newProduct.availability = InputValidators.TakeAndValidateInputBool(message);

      if (newProduct.availability) {
        message = $"Enter {newProduct.name} stock level: ";
        newProduct.stock_level = InputValidators.TakeAndValidateInputInt(message);
      } else newProduct.stock_level = 0;

      message = $"Is {newProduct.name} on promotion (y/n or yes/no): ";
      newProduct.on_promo = InputValidators.TakeAndValidateInputBool(message);

      if (newProduct.on_promo) {
        message = $"What is the percentage of discount applied to {newProduct.name} ? ( Enter a number)";
        newProduct.promo_rate_as_percentage = InputValidators.TakeAndValidateInputInt(message);
      } else newProduct.promo_rate_as_percentage = 0;

      return newProduct;
    }
  }

  public class ProductsDeletion {
    public static void DeleteProduct(Product prod) {
      ProductsContext productsDB = new ProductsContext();
      Product? productDel = productsDB.Products!.Find(prod.id);
      productsDB.Products.Remove(productDel!);

      int affectedRows = productsDB.SaveChanges();

      if (affectedRows > 0) {
        Console.WriteLine("\nProduct deletion successful.");
      } else {
        Console.WriteLine("\nFailed to delete the product.");
      }
    }

  }

}