using System;
using Microsoft.EntityFrameworkCore;
using Utils;

namespace AsianStore {
  public class Program {
    public static void Main(string[] args) {
      ProductsRetrieval.ListAllProducts();
      ProductsAddition.AddProduct(ProductsAddition.GetProductDataFromClient());
    }
  }
}