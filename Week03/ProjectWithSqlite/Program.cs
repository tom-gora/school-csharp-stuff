using System;
using DbUtils;
using Microsoft.EntityFrameworkCore;
using ProgramUtils;

namespace AsianStore {
  public class Program {
    public static void Main(string[] args) {
      bool continueRunning = true;

      while (continueRunning) {
        Console.Clear();
        Console.WriteLine("Welcome to the Wee Asian Store!");
        Console.WriteLine("1. List all products");
        Console.WriteLine("2. Add a product");
        Console.WriteLine("3. Delete a product");
        Console.WriteLine("4. Exit");
        Console.WriteLine("\nEnter your choice: ");

        string? input = Console.ReadLine();

        switch (input) {
          case "1":
            Console.Write(ProductsRetrieval.FormatProductList(ProductsRetrieval.GetProductsAsList()));
            FormatUtils.AnyKeyPressPlease();
            break;
          case "2":
            ProductsAddition.AddProduct(ProductsAddition.GetNewProductDataFromClient());
            FormatUtils.AnyKeyPressPlease();
            break;
          case "3":
            ProductsDeletion.DeleteProduct(ProductsRetrieval.GetClientToSelectExistingProduct(OperationList.Delete));
            FormatUtils.AnyKeyPressPlease();
            break;
          case "4":
            continueRunning = false;
            break;
          default:
            Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
            break;
        }
      }
    }
  }
}