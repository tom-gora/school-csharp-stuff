using System;
using DataOperations;
using UtilsCollection;

namespace WebflixDatabase {
  class Program {
    static void Main(string[] args) {
      // calling my util functions
      Utils.PrintRandomMovie(Utils.GetRandomMovie());
    }
  }
}

