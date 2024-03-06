using System;
using System.Text;

namespace UI {
  class UiBlocks {
    public static String topBar(int length) {
      char vertChar = '═';
      var SB = new StringBuilder();
      for (int i = 0; i < length; i++) {
        SB.Append(vertChar);
      }
      return SB.ToString();
    }
    public static char startCharTop = '╒';
    public static char startCharBottom = '╘';
    public static char endCharTop = '╕';
    public static char endCharBottom = '╛';
    public static char sideChar = '│';
  }
  class Behaviours {
    public static void AnyKeyPressPlease() {
      Console.WriteLine("\nPress any key to continue...");
      Console.ReadKey();
    }
    public static void AnyKeyPressToExit() {
      Console.WriteLine("\nPress any key to exit...");
      Console.ReadKey();
      Environment.Exit(0);
    }
  }

  public class InputValidators {
    public static string? TakeAndValidateInputString(string message) {
      Console.Clear();
      Console.WriteLine(message);
      string? input = Console.ReadLine();
      if (input == "exit") return null;
      while (string.IsNullOrWhiteSpace(input)) {
        Console.Clear();
        Console.WriteLine("The input cannot be empty. Please try again.\n");
        Console.WriteLine(message);
        input = Console.ReadLine();
      }
      return input.ToString().Trim();
    }
  }
}